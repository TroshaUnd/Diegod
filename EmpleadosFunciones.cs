using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diegod
{
    public class EmpleadosFunciones
    {
        public static int AgregarEmpleado(EmpleadosPuente empleado)
        {
            int retorna = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"INSERT INTO Empleados
                (Nombre, Apellido, Email, Cargo, Fecha_Contratacion, Nacimiento, Dni, Telefono, Direccion, Activo, Observacion, Localidad_ID)
                VALUES
                (@Nombre, @Apellido, @Email, @Cargo, @FechaContratacion, @FechaNacimiento, @Dni, @Telefono, @Direccion, @Activo, @Observacion, @Localidad_ID)";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                comando.Parameters.AddWithValue("@Email", empleado.Email);
                comando.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                comando.Parameters.AddWithValue("@FechaContratacion", empleado.Fecha_Contratacion);
                comando.Parameters.AddWithValue("@FechaNacimiento", empleado.Nacimiento);
                comando.Parameters.AddWithValue("@Dni", empleado.Dni);
                comando.Parameters.AddWithValue("@Telefono", empleado.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", empleado.Direccion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Activo", empleado.Activo);
                comando.Parameters.AddWithValue("@Observacion", empleado.Observacion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Localidad_ID", empleado.Localidad_ID.HasValue ? (object)empleado.Localidad_ID.Value : DBNull.Value);

                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }

        public static List<EmpleadosPuente> RegistroEmpleado()
        {
            List<EmpleadosPuente> Lista = new List<EmpleadosPuente>();

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        e.ID, 
                        e.Nombre, 
                        e.Apellido, 
                        e.Email, 
                        e.Cargo, 
                        e.Fecha_Contratacion, 
                        e.Nacimiento, 
                        e.Dni, 
                        e.Telefono, 
                        e.Direccion,
                        e.Activo, 
                        e.Observacion,
                        e.Localidad_ID,
                        l.localidad AS Localidad, 
                        p.provincia AS Provincia
                    FROM Empleados e
                    LEFT JOIN Localidades l ON e.Localidad_ID = l.Localidad_ID
                    LEFT JOIN Provincias p ON l.id_provincia = p.id";

                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    EmpleadosPuente puente = new EmpleadosPuente
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido")) ? null : reader.GetString(reader.GetOrdinal("Apellido")),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                        Cargo = reader.IsDBNull(reader.GetOrdinal("Cargo")) ? null : reader.GetString(reader.GetOrdinal("Cargo")),
                        Fecha_Contratacion = reader.GetDateTime(reader.GetOrdinal("Fecha_Contratacion")),
                        Nacimiento = reader.GetDateTime(reader.GetOrdinal("Nacimiento")),
                        Dni = reader.IsDBNull(reader.GetOrdinal("Dni")) ? null : reader.GetString(reader.GetOrdinal("Dni")),
                        Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                        Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                        Activo = reader.GetBoolean(reader.GetOrdinal("Activo")),
                        Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? null : reader.GetString(reader.GetOrdinal("Observacion")),
                        Localidad_ID = reader.IsDBNull(reader.GetOrdinal("Localidad_ID")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("Localidad_ID")),
                        Localidad = reader.IsDBNull(reader.GetOrdinal("Localidad")) ? null : reader.GetString(reader.GetOrdinal("Localidad")),
                        Provincia = reader.IsDBNull(reader.GetOrdinal("Provincia")) ? null : reader.GetString(reader.GetOrdinal("Provincia")),
                    };
                    Lista.Add(puente);
                }
            }

            return Lista;
        }

        public static int ModificarEmpleado(EmpleadosPuente empleado)
        {
            int result = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"UPDATE Empleados 
                    SET Nombre = @Nombre,
                        Apellido = @Apellido,
                        Email = @Email,
                        Cargo = @Cargo,
                        Fecha_Contratacion = @FechaContratacion,
                        Nacimiento = @Nacimiento,
                        Dni = @Dni,
                        Telefono = @Telefono,
                        Direccion = @Direccion,
                        Activo = @Activo,
                        Observacion = @Observacion,
                        Localidad_ID = @Localidad_ID
                    WHERE ID = @ID";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                comando.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                comando.Parameters.AddWithValue("@Email", empleado.Email);
                comando.Parameters.AddWithValue("@Cargo", empleado.Cargo);
                comando.Parameters.AddWithValue("@FechaContratacion", empleado.Fecha_Contratacion);
                comando.Parameters.AddWithValue("@Nacimiento", empleado.Nacimiento);
                comando.Parameters.AddWithValue("@Dni", empleado.Dni);
                comando.Parameters.AddWithValue("@Telefono", empleado.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", empleado.Direccion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Activo", empleado.Activo);
                comando.Parameters.AddWithValue("@Observacion", empleado.Observacion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Localidad_ID", empleado.Localidad_ID.HasValue ? (object)empleado.Localidad_ID.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@ID", empleado.ID);

                result = comando.ExecuteNonQuery();
            }
            return result;
        }
        public static int ActualizarActivo(int id, bool activo)
        {
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand("UPDATE Empleados SET Activo = @Activo WHERE ID = @ID", conexion))
            {
                cmd.Parameters.AddWithValue("@Activo", activo);
                cmd.Parameters.AddWithValue("@ID", id);
                return cmd.ExecuteNonQuery();
            }
        }
        public static DataTable BuscarEmpleado(string id, string nombre)
        {
            var tabla = new DataTable();
            using (var conexion = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
        SELECT 
            e.ID,
            e.Nombre,
            e.Apellido,
            e.Email,
            e.Cargo,
            e.Fecha_Contratacion,
            e.Nacimiento,
            e.Dni,
            e.Telefono,
            e.Direccion,
            e.Activo,               -- <— Asegúrate de incluir esta línea
            e.Observacion,
            e.Localidad_ID,
            l.localidad   AS Localidad,
            p.provincia   AS Provincia
        FROM Empleados e
        LEFT JOIN Localidades l ON e.Localidad_ID = l.Localidad_ID
        LEFT JOIN Provincias  p ON l.id_provincia  = p.id
        WHERE 1 = 1"
                + (string.IsNullOrEmpty(id) ? "" : " AND e.ID = @ID")
                + (string.IsNullOrEmpty(nombre) ? "" : " AND (e.Nombre LIKE @Nombre OR e.Apellido LIKE @Nombre)")
                + " ORDER BY e.ID DESC;", conexion))
            {
                if (!string.IsNullOrEmpty(id))
                    cmd.Parameters.AddWithValue("@ID", int.Parse(id));
                if (!string.IsNullOrEmpty(nombre))
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(tabla);
            }
            return tabla;
        }
    }
}
