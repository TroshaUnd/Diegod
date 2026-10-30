using System;
using System.Collections.Generic;
using System.Data;
using Diegod.Datos;

namespace Diegod
{
    public class VehiculosFunciones
    {
        public static int AgregarVehiculo(VehiculosPuente vehiculo)
        {
            int resultado = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand comando = conexion.CreateCommand())
            {
                comando.CommandText = @"
            INSERT INTO Vehiculos
                (Nombre, Patente, Fecha_UltimoServicio, Observacion, Activo)
            VALUES
                (@Nombre, @Patente, @Fecha_UltimoServicio, @Observacion, @Activo);";

                // Abrir la conexión si no está abierta
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                // Parámetros (especificando tipos)
                comando.Parameters.Add("@Nombre", SqlDbType.NVarChar, 200).Value =
                    string.IsNullOrWhiteSpace(vehiculo.Nombre) ? DBNull.Value : vehiculo.Nombre;

                comando.Parameters.Add("@Patente", SqlDbType.NVarChar, 50).Value =
                    string.IsNullOrWhiteSpace(vehiculo.Patente) ? DBNull.Value : vehiculo.Patente;

                // Fecha nullable
                var pFecha = comando.Parameters.Add("@Fecha_UltimoServicio", SqlDbType.DateTime2);
                pFecha.Value = vehiculo.Fecha_UltimoServicio.HasValue
                    ? vehiculo.Fecha_UltimoServicio.Value
                    : DBNull.Value;

                comando.Parameters.Add("@Observacion", SqlDbType.NVarChar, -1).Value =
                    string.IsNullOrWhiteSpace(vehiculo.Observacion) ? DBNull.Value : vehiculo.Observacion;

                comando.Parameters.Add("@Activo", SqlDbType.Bit).Value = vehiculo.Activo;

                resultado = comando.ExecuteNonQuery();
            }

            return resultado;
        }

        public static List<VehiculosPuente> RegistroVehiculo()
        {
            List<VehiculosPuente> lista = new List<VehiculosPuente>();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"SELECT ID, Nombre, Patente, Fecha_UltimoServicio, Observacion, Activo
                                 FROM Vehiculos";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var puente = new VehiculosPuente
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? string.Empty : reader.GetString(reader.GetOrdinal("Nombre")),
                            Patente = reader.IsDBNull(reader.GetOrdinal("Patente")) ? string.Empty : reader.GetString(reader.GetOrdinal("Patente")),
                            Fecha_UltimoServicio = reader.IsDBNull(reader.GetOrdinal("Fecha_UltimoServicio"))
                                ? null
                                : reader.GetDateTime(reader.GetOrdinal("Fecha_UltimoServicio")),
                            Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion"))
                                ? string.Empty
                                : reader.GetString(reader.GetOrdinal("Observacion")),
                            Activo = reader.GetBoolean(reader.GetOrdinal("Activo"))
                        };
                        lista.Add(puente);
                    }
                }
            }
            return lista;
        }

        public static int ModificarVehiculo(VehiculosPuente vehiculo)
        {
            int resultado = 0;
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"UPDATE Vehiculos
                                 SET Nombre = @Nombre,
                                     Patente = @Patente,
                                     Fecha_UltimoServicio = @Fecha_UltimoServicio,
                                     Observacion = @Observacion,
                                     Activo = @Activo
                                 WHERE ID = @ID";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Nombre", vehiculo.Nombre);
                    comando.Parameters.AddWithValue("@Patente", vehiculo.Patente);
                    comando.Parameters.AddWithValue("@Fecha_UltimoServicio", (object)vehiculo.Fecha_UltimoServicio ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@Observacion", string.IsNullOrEmpty(vehiculo.Observacion) ? DBNull.Value : vehiculo.Observacion);
                    comando.Parameters.AddWithValue("@Activo", vehiculo.Activo);
                    comando.Parameters.AddWithValue("@ID", vehiculo.ID);

                    resultado = comando.ExecuteNonQuery();
                }
            }
            return resultado;
        }

        public static int ActualizarActivoVehiculo(int id, bool activo)
        {
            int resultado;
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand(
                "UPDATE Vehiculos SET Activo = @Activo WHERE ID = @ID", conexion))
            {
                comando.Parameters.AddWithValue("@Activo", activo);
                comando.Parameters.AddWithValue("@ID", id);
                resultado = comando.ExecuteNonQuery();
            }
            return resultado;
        }

        public static DataTable BuscarVehiculo(string id, string nombre, string patente)
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand comando = new SqlCommand())
            {
                string sql = @"SELECT ID, Nombre, Patente, Fecha_UltimoServicio, Observacion, Activo
                               FROM Vehiculos
                               WHERE 1 = 1";

                if (!string.IsNullOrEmpty(id))
                    sql += " AND ID = @ID";
                if (!string.IsNullOrEmpty(nombre))
                    sql += " AND Nombre LIKE @Nombre";
                if (!string.IsNullOrEmpty(patente))
                    sql += " AND Patente LIKE @Patente";

                sql += " ORDER BY ID DESC";

                comando.Connection = conexion;
                comando.CommandText = sql;

                if (!string.IsNullOrEmpty(id))
                    comando.Parameters.AddWithValue("@ID", int.Parse(id));
                if (!string.IsNullOrEmpty(nombre))
                    comando.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                if (!string.IsNullOrEmpty(patente))
                    comando.Parameters.AddWithValue("@Patente", "%" + patente + "%");

                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }
    }
}
