using System;
using System.Collections.Generic;
using Diegod.Datos;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diegod
{
    public class ProveedoresFunciones
    {
        public static DataTable RegistroProveedor()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    p.ID,
                    p.Nombre,
                    p.Apellido,
                    p.Empresa,
                    p.Email,
                    p.Telefono,
                    p.Direccion,
                    l.localidad AS Localidad,
                    prov.provincia AS Provincia,
                    p.Observaciones
                FROM Proveedor p
                LEFT JOIN Localidades l ON p.Localidad_ID = l.Localidad_ID
                LEFT JOIN Provincias prov ON l.id_provincia = prov.id
                ORDER BY p.ID DESC;", conexion))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public static int AgregarProveedor(ProveedorPuente proveedor)
        {
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Proveedor
                    (Nombre, Apellido, Empresa, Email, Telefono, Direccion, Localidad_ID, Observaciones)
                VALUES
                    (@Nombre, @Apellido, @Empresa, @Email, @Telefono, @Direccion, @Localidad_ID, @Observaciones);", conexion))
            {
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", proveedor.Apellido);
                cmd.Parameters.AddWithValue("@Empresa", proveedor.Empresa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Localidad_ID", proveedor.Localidad_ID);
                cmd.Parameters.AddWithValue("@Observaciones", proveedor.Observaciones ?? (object)DBNull.Value);
                return cmd.ExecuteNonQuery();
            }
        }

        public static int ModificarProveedor(ProveedorPuente proveedor)
        {
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                UPDATE Proveedor SET
                    Nombre = @Nombre,
                    Apellido = @Apellido,
                    Empresa = @Empresa,
                    Email = @Email,
                    Telefono = @Telefono,
                    Direccion = @Direccion,
                    Localidad_ID = @Localidad_ID,
                    Observaciones = @Observaciones
                WHERE ID = @ID;", conexion))
            {
                cmd.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                cmd.Parameters.AddWithValue("@Apellido", proveedor.Apellido);
                cmd.Parameters.AddWithValue("@Empresa", proveedor.Empresa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", proveedor.Email ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefono", proveedor.Telefono ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Direccion", proveedor.Direccion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Localidad_ID", proveedor.Localidad_ID);
                cmd.Parameters.AddWithValue("@Observaciones", proveedor.Observaciones ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ID", proveedor.ID);
                return cmd.ExecuteNonQuery();
            }
        }

        public static DataTable BuscarProveedor(string id, string nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(@"
                SELECT 
                    p.ID,
                    p.Nombre,
                    p.Apellido,
                    p.Empresa,
                    p.Email,
                    p.Telefono,
                    p.Direccion,
                    l.localidad AS Localidad,
                    prov.provincia AS Provincia,
                    p.Observaciones
                FROM Proveedor p
                LEFT JOIN Localidades l ON p.Localidad_ID = l.Localidad_ID
                LEFT JOIN Provincias prov ON l.id_provincia = prov.id
                WHERE 1=1
                    " + (string.IsNullOrEmpty(id) ? "" : " AND p.ID = @ID") +
                    (string.IsNullOrEmpty(nombre) ? "" : " AND (p.Nombre LIKE @Nombre OR p.Apellido LIKE @Nombre)") +
                " ORDER BY p.ID DESC;", conexion))
            {
                if (!string.IsNullOrEmpty(id))
                    cmd.Parameters.AddWithValue("@ID", int.Parse(id));
                if (!string.IsNullOrEmpty(nombre))
                    cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

