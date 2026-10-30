// PrestamistaFunciones.cs
using Diegod.Datos;
using System.Data;

namespace Diegod
{
    public class PrestamistaFunciones
    {
        public static DataTable RegistroPrestamista()
        {
            var dt = new DataTable();
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT ID, Nombre, Apellido, Email, Telefono, Direccion, Empresa, Observacion FROM Prestamista",
                conn))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarPrestamistaPorID(int id)
        {
            var dt = new DataTable();
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT ID, Nombre, Apellido, Email, Telefono, Direccion, Empresa, Observacion " +
                "FROM Prestamista WHERE ID = @ID", conn))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarPrestamistaPorNombreApellido(string termino)
        {
            var dt = new DataTable();
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(
                "SELECT ID, Nombre, Apellido, Email, Telefono, Direccion, Empresa, Observacion " +
                "FROM Prestamista " +
                "WHERE Nombre LIKE '%' || @T || '%' OR Apellido LIKE '%' || @T || '%'", conn))
            {
                cmd.Parameters.AddWithValue("@T", termino);
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(dt);
            }
            return dt;
        }

        public static int AgregarPrestamista(PrestamistaPuente prestamista)
        {
            if (string.IsNullOrWhiteSpace(prestamista.Nombre) || string.IsNullOrWhiteSpace(prestamista.Apellido))
                throw new ArgumentException("Nombre y Apellido son obligatorios.");

            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(
                @"INSERT INTO Prestamista
                  (Nombre, Apellido, Email, Telefono, Direccion, Empresa, Observacion)
                  VALUES (@Nombre,@Apellido,@Email,@Telefono,@Direccion,@Empresa,@Observacion)",
                conn))
            {
                cmd.Parameters.AddWithValue("@Nombre", prestamista.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", prestamista.Apellido);
                cmd.Parameters.AddWithValue("@Email", prestamista.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", prestamista.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", prestamista.Direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Empresa", prestamista.Empresa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Observacion", prestamista.Observacion ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ModificarPrestamista(PrestamistaPuente prestamista)
        {
            using (var conn = BaseDatos.ObtenerConexion())
            using (var cmd = new SqlCommand(
                @"UPDATE Prestamista SET
                    Nombre    = @Nombre,
                    Apellido  = @Apellido,
                    Email     = @Email,
                    Telefono  = @Telefono,
                    Direccion = @Direccion,
                    Empresa   = @Empresa,
                    Observacion = @Observacion
                  WHERE ID = @ID",
                conn))
            {
                cmd.Parameters.AddWithValue("@ID", prestamista.ID);
                cmd.Parameters.AddWithValue("@Nombre", prestamista.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", prestamista.Apellido);
                cmd.Parameters.AddWithValue("@Email", prestamista.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", prestamista.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", prestamista.Direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Empresa", prestamista.Empresa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Observacion", prestamista.Observacion ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
