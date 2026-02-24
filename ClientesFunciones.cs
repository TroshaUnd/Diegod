using System.Data.SqlClient;
using System.Data;

namespace Diegod
{
    public class ClientesFunciones
    {
        /// <summary>
        /// Agregar un nuevo cliente a la base de datos.
        /// </summary>
        /// <param name="cliente">Objeto ClientesPuente con los datos del cliente.</param>
        /// <returns>Número de filas afectadas.</returns>
        public static int AgregarCliente(ClientesPuente cliente)
        {
            int retorna = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"INSERT INTO Clientes 
                (Nombre, Apellido, Email, Telefono, Direccion, Cuit, Observacion, Localidad_ID) 
                VALUES 
                (@Nombre, @Apellido, @Email, @Telefono, @Direccion, @Cuit, @Observacion, @Localidad_ID)";

                SqlCommand comando = new SqlCommand(query, conexion);

                // Asignar parámetros con manejo de valores nulos
                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Cuit", cliente.Cuit ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Observacion", cliente.Observacion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Localidad_ID", cliente.Localidad_ID.HasValue ? cliente.Localidad_ID.Value : DBNull.Value);

                retorna = comando.ExecuteNonQuery();
            }

            return retorna;
        }

        /// <summary>
        /// Obtiene el registro de clientes, incluyendo el nombre de la localidad y provincia (a través de JOIN).
        /// </summary>
        public static List<ClientesPuente> RegistroClientes()
        {
            List<ClientesPuente> Lista = new List<ClientesPuente>();

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"
                    SELECT 
                        c.ID, 
                        c.Nombre, 
                        c.Apellido, 
                        c.Email, 
                        c.Telefono, 
                        c.Direccion, 
                        c.Cuit, 
                        c.Observacion, 
                        c.Localidad_ID,
                        l.localidad AS Localidad,
                        p.provincia AS Provincia
                    FROM Clientes c
                    LEFT JOIN Localidades l ON c.Localidad_ID = l.Localidad_ID
                    LEFT JOIN Provincias p ON l.id_provincia = p.id";
                SqlCommand comando = new SqlCommand(query, conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    ClientesPuente puente = new ClientesPuente
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("ID")),
                        Nombre = reader.IsDBNull(reader.GetOrdinal("Nombre")) ? null : reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.IsDBNull(reader.GetOrdinal("Apellido")) ? null : reader.GetString(reader.GetOrdinal("Apellido")),
                        Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                        Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono")) ? null : reader.GetString(reader.GetOrdinal("Telefono")),
                        Direccion = reader.IsDBNull(reader.GetOrdinal("Direccion")) ? null : reader.GetString(reader.GetOrdinal("Direccion")),
                        Cuit = reader.IsDBNull(reader.GetOrdinal("Cuit")) ? null : reader.GetString(reader.GetOrdinal("Cuit")),
                        Observacion = reader.IsDBNull(reader.GetOrdinal("Observacion")) ? null : reader.GetString(reader.GetOrdinal("Observacion")),
                        Localidad_ID = reader.IsDBNull(reader.GetOrdinal("Localidad_ID")) ? null : reader.GetInt32(reader.GetOrdinal("Localidad_ID")),
                        Localidad = reader.IsDBNull(reader.GetOrdinal("Localidad")) ? null : reader.GetString(reader.GetOrdinal("Localidad")),
                        Provincia = reader.IsDBNull(reader.GetOrdinal("Provincia")) ? null : reader.GetString(reader.GetOrdinal("Provincia"))
                    };
                    Lista.Add(puente);
                }
            }

            return Lista;
        }

        /// <summary>
        /// Modificar un cliente en la base de datos.
        /// </summary>
        public static int ModificarCliente(ClientesPuente cliente)
        {
            int result = 0;

            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            {
                string query = @"UPDATE Clientes 
                SET Nombre = @Nombre,
                    Apellido = @Apellido,
                    Email = @Email,
                    Telefono = @Telefono,
                    Direccion = @Direccion,
                    Cuit = @Cuit,
                    Observacion = @Observacion,
                    Localidad_ID = @Localidad_ID
                WHERE ID = @ID";

                SqlCommand comando = new SqlCommand(query, conexion);

                comando.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cliente.Apellido);
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Telefono", cliente.Telefono ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Direccion", cliente.Direccion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Cuit", cliente.Cuit ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Observacion", cliente.Observacion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@Localidad_ID", cliente.Localidad_ID.HasValue ? cliente.Localidad_ID.Value : DBNull.Value);
                comando.Parameters.AddWithValue("@ID", cliente.ID);

                result = comando.ExecuteNonQuery();
            }
            return result;
        }
        public static DataTable BuscarCliente(string id, string nombreOapellido)
        {
            var tabla = new DataTable();
            using (var conexion = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(@"
        SELECT 
            c.ID, 
            c.Nombre, 
            c.Apellido, 
            c.Email, 
            c.Telefono, 
            c.Direccion, 
            c.Cuit, 
            c.Observacion, 
            c.Localidad_ID,
            l.localidad AS Localidad,
            p.provincia AS Provincia
        FROM Clientes c
        LEFT JOIN Localidades l ON c.Localidad_ID = l.Localidad_ID
        LEFT JOIN Provincias  p ON l.id_provincia  = p.id
        WHERE 1 = 1"
                + (string.IsNullOrEmpty(id)
                    ? ""
                    : " AND c.ID = @ID")
                + (string.IsNullOrEmpty(nombreOapellido)
                    ? ""
                    : " AND (c.Nombre LIKE @Texto OR c.Apellido LIKE @Texto)")
                + " ORDER BY c.ID DESC;", conexion))
            {
                if (!string.IsNullOrEmpty(id))
                    cmd.Parameters.AddWithValue("@ID", int.Parse(id));
                if (!string.IsNullOrEmpty(nombreOapellido))
                    cmd.Parameters.AddWithValue("@Texto", "%" + nombreOapellido + "%");

                using (var adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(tabla);
                }
            }
            return tabla;
        }
    }
}
