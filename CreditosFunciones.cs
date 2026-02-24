using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Diegod
{
    public static class CreditosFunciones
    {
        public static DataTable RegistroCreditos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    c.Anulado,
                    c.ID,
                    p.Nombre   AS Nombre,
                    p.Apellido AS Apellido,
                    p.Empresa  AS Empresa,
                    FORMAT(c.Monto_Credito, 'C', 'es-AR') AS Monto_Credito,
                    c.Fecha_Credito,
                    c.Fecha_Vencimiento,
                    c.Observacion
                FROM Credito c
                LEFT JOIN Prestamista p ON c.Prestamista_ID = p.ID
                ORDER BY c.ID DESC;", conexion))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Buscar por ID exacto
        public static DataTable BuscarCreditosPorID(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    c.Anulado,
                    c.ID,
                    p.Nombre   AS Nombre,
                    p.Apellido AS Apellido,
                    p.Empresa  AS Empresa,
                    FORMAT(c.Monto_Credito, 'C', 'es-AR') AS Monto_Credito,
                    c.Fecha_Credito,
                    c.Fecha_Vencimiento,
                    c.Observacion
                FROM Credito c
                LEFT JOIN Prestamista p ON c.Prestamista_ID = p.ID
                WHERE c.ID = @ID
                ORDER BY c.ID DESC;", conexion))
            {
                command.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Buscar por nombre o apellido (LIKE)
        public static DataTable BuscarCreditosPorNombre(string texto)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    c.Anulado,
                    c.ID,
                    p.Nombre   AS Nombre,
                    p.Apellido AS Apellido,
                    p.Empresa  AS Empresa,
                    FORMAT(c.Monto_Credito, 'C', 'es-AR') AS Monto_Credito,
                    c.Fecha_Credito,
                    c.Fecha_Vencimiento,
                    c.Observacion
                FROM Credito c
                LEFT JOIN Prestamista p ON c.Prestamista_ID = p.ID
                WHERE p.Nombre LIKE @Patron OR p.Apellido LIKE @Patron
                ORDER BY c.ID DESC;", conexion))
            {
                command.Parameters.AddWithValue("@Patron", "%" + texto + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Buscar por fecha exacta de crédito
        public static DataTable BuscarCreditosPorFecha(DateTime fecha)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    c.Anulado,
                    c.ID,
                    p.Nombre   AS Nombre,
                    p.Apellido AS Apellido,
                    p.Empresa  AS Empresa,
                    FORMAT(c.Monto_Credito, 'C', 'es-AR') AS Monto_Credito,
                    c.Fecha_Credito,
                    c.Fecha_Vencimiento,
                    c.Observacion
                FROM Credito c
                LEFT JOIN Prestamista p ON c.Prestamista_ID = p.ID
                WHERE CAST(c.Fecha_Credito AS DATE) = @Fecha
                ORDER BY c.ID DESC;", conexion))
            {
                command.Parameters.AddWithValue("@Fecha", fecha.Date);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }
        public static DataTable BuscarCreditos(string idText, string nombreApellido, DateTime? fecha)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string sql = @"
                        SELECT 
                            c.Anulado,
                            c.ID,
                            p.Nombre      AS Nombre,
                            p.Apellido    AS Apellido,
                            p.Empresa     AS Empresa,
                            FORMAT(c.Monto_Credito, 'C', 'es-AR') AS Monto_Credito,
                            c.Fecha_Credito,
                            c.Fecha_Vencimiento,
                            c.Observacion
                        FROM Credito c
                        LEFT JOIN Prestamista p ON c.Prestamista_ID = p.ID
                        WHERE 1=1";

                    if (!string.IsNullOrEmpty(idText))
                        sql += " AND c.ID = @ID";

                    if (!string.IsNullOrEmpty(nombreApellido))
                        sql += " AND (p.Nombre LIKE @Patron OR p.Apellido LIKE @Patron)";

                    if (fecha.HasValue)
                        sql += " AND CAST(c.Fecha_Credito AS DATE) = @Fecha";

                    sql += " ORDER BY c.ID DESC;";

                    using (SqlCommand command = new SqlCommand(sql, conexion))
                    {
                        if (!string.IsNullOrEmpty(idText) && int.TryParse(idText, out int id))
                            command.Parameters.AddWithValue("@ID", id);

                        if (!string.IsNullOrEmpty(nombreApellido))
                            command.Parameters.AddWithValue("@Patron", "%" + nombreApellido + "%");

                        if (fecha.HasValue)
                            command.Parameters.AddWithValue("@Fecha", fecha.Value.Date);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar crédito: " + ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerPrestamistas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    ID,
                    Nombre,
                    Apellido,
                    Empresa
                FROM Prestamista;", conexion))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarPrestamistaPorID(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    ID,
                    Nombre,
                    Apellido,
                    Empresa
                FROM Prestamista
                WHERE ID = @ID;", conexion))
            {
                command.Parameters.AddWithValue("@ID", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarPrestamistaPorNombre(string texto)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand(@"
                SELECT 
                    ID,
                    Nombre,
                    Apellido,
                    Empresa
                FROM Prestamista
                WHERE Nombre LIKE @Patron OR Apellido LIKE @Patron;", conexion))
            {
                command.Parameters.AddWithValue("@Patron", "%" + texto + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static int ActualizarAnulado(int id, bool anulado)
        {
            int resultado = 0;
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand command = new SqlCommand("UPDATE Credito SET Anulado = @Anulado WHERE ID = @ID", conexion))
            {
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@Anulado", anulado);
                resultado = command.ExecuteNonQuery();
            }
            return resultado;
        }

        public static int AgregarCredito(CreditoPuente credito)
        {
            int filas = 0;
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string sqlCred = @"
                        INSERT INTO Credito
                            (Prestamista_ID, Monto_Credito, Fecha_Credito, Fecha_Vencimiento, Observacion, Anulado)
                        VALUES
                            (@Prestamista_ID, @Monto_Credito, @Fecha_Credito, @Fecha_Vencimiento, @Observacion, @Anulado);
                        SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    using (SqlCommand cmd = new SqlCommand(sqlCred, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Prestamista_ID", credito.Prestamista_ID);
                        cmd.Parameters.AddWithValue("@Monto_Credito", credito.Monto_Credito);
                        cmd.Parameters.AddWithValue("@Fecha_Credito", credito.Fecha_Credito);
                        cmd.Parameters.AddWithValue("@Fecha_Vencimiento", credito.Fecha_Vencimiento);
                        cmd.Parameters.AddWithValue("@Observacion", string.IsNullOrEmpty(credito.Observacion) ? DBNull.Value : credito.Observacion);
                        cmd.Parameters.AddWithValue("@Anulado", credito.Anulado);
                        int nuevoID = Convert.ToInt32(cmd.ExecuteScalar());
                        filas++;

                        string sqlPago = @"
                            INSERT INTO Pagos_Pendientes
                                (CreditoID)
                            VALUES
                                (@CreditoID);";
                        using (var cmd2 = new SqlCommand(sqlPago, conexion))
                        {
                            cmd2.Parameters.AddWithValue("@CreditoID", nuevoID);
                            filas += cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar crédito: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filas = 0;
            }
            return filas;
        }
    }
}
