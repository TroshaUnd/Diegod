using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Diegod
{
    public class MovimientosStockFunciones
    {
        public static DataTable RegistroMovimientosStock()
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = new SqlCommand(@"
                    SELECT
                        m.ID,
                        s.Producto AS Stock,
                        p.Nombre + ' ' + p.Apellido AS Proveedor,
                        m.Cantidad,
                        CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
                        m.Destino,
                        m.Fecha_Movimiento,
                        m.Precio_Unitario,
                        m.Precio_Total,
                        m.Anulado,
                        m.Cambio
                    FROM MovimientoStock m
                    LEFT JOIN Stock s ON m.Stock_ID = s.ID
                    LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
                    ORDER BY m.Anulado DESC, m.Fecha_Movimiento DESC;", cn);
                var adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener movimientos de stock: " + ex.Message);
            }
            return dt;
        }
        public static DataTable BuscarMovimientosPorStockID(int stockId)
        {
            var dt = new DataTable();
            using var cn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(@"
        SELECT
            m.ID,
            s.Producto   AS Stock,
            p.Nombre + ' ' + p.Apellido AS Proveedor,
            m.Cantidad,
            CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
            m.Destino,
            m.Fecha_Movimiento,
            m.Precio_Unitario,
            m.Precio_Total,
            m.Anulado,
            m.Cambio
        FROM MovimientoStock m
        LEFT JOIN Stock     s ON m.Stock_ID     = s.ID
        LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
        WHERE m.Stock_ID = @StockID
        ORDER BY m.Anulado DESC, m.Fecha_Movimiento DESC;", cn);
    {
                cmd.Parameters.AddWithValue("@StockID", stockId);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarMovimientosPorProveedorID(int provId)
        {
            var dt = new DataTable();
            using var cn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(@"
        SELECT
            m.ID,
            s.Producto   AS Stock,
            p.Nombre + ' ' + p.Apellido AS Proveedor,
            m.Cantidad,
            CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
            m.Destino,
            m.Fecha_Movimiento,
            m.Precio_Unitario,
            m.Precio_Total,
            m.Anulado,
            m.Cambio
        FROM MovimientoStock m
        LEFT JOIN Stock     s ON m.Stock_ID     = s.ID
        LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
        WHERE m.Proveedor_ID = @ProvID
        ORDER BY m.Anulado DESC, m.Fecha_Movimiento DESC;", cn);
    {
                cmd.Parameters.AddWithValue("@ProvID", provId);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarMovimientoPorID(int id)
        {
            var dt = new DataTable();
            using var cn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(@"
        SELECT m.ID, s.Producto AS Stock, 
               p.Nombre + ' ' + p.Apellido AS Proveedor,
               m.Cantidad,
               CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
               m.Destino, m.Fecha_Movimiento,
               m.Precio_Unitario, m.Precio_Total,
               m.Anulado, m.Cambio
        FROM MovimientoStock m
        LEFT JOIN Stock s     ON m.Stock_ID     = s.ID
        LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
        WHERE m.ID = @ID
        ORDER BY m.Anulado DESC, m.Fecha_Movimiento DESC;", cn);
            cmd.Parameters.AddWithValue("@ID", id);
            new SqlDataAdapter(cmd).Fill(dt);
            return dt;
        }
        public static DataTable BuscarMovimientosPorFecha(DateTime fecha)
        {
            var dt = new DataTable();
            using var cn = BaseDatos.ObtenerConexion();
            using var cmd = new SqlCommand(@"
        SELECT
            m.ID,
            s.Producto   AS Stock,
            p.Nombre + ' ' + p.Apellido AS Proveedor,
            m.Cantidad,
            CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
            m.Destino,
            m.Fecha_Movimiento,
            m.Precio_Unitario,
            m.Precio_Total,
            m.Anulado,
            m.Cambio
        FROM MovimientoStock m
        LEFT JOIN Stock     s ON m.Stock_ID     = s.ID
        LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
        WHERE CAST(m.Fecha_Movimiento AS DATE) = @Fecha
        ORDER BY m.Anulado DESC, m.Fecha_Movimiento DESC;", cn);
    {
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            return dt;
        }

        public static DataTable BuscarMovimientos(
    string idText,
    string stockText,
    string provText,
    DateTime? fechaMov
)
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = new SqlCommand();
                cmd.Connection = cn;

                var sql = new StringBuilder(@"
            SELECT
                m.ID,
                s.Producto   AS Stock,
                p.Nombre + ' ' + p.Apellido AS Proveedor,
                m.Cantidad,
                CASE WHEN m.Tipo_Movimiento = 1 THEN 'Ingreso' ELSE 'Egreso' END AS Movimiento,
                m.Destino,
                m.Fecha_Movimiento,
                m.Precio_Unitario,
                m.Precio_Total,
                m.Anulado,
                m.Cambio
            FROM MovimientoStock m
            LEFT JOIN Stock     s ON m.Stock_ID     = s.ID
            LEFT JOIN Proveedor p ON m.Proveedor_ID = p.ID
            WHERE 1 = 1");

                // Si vienen texto en los TextBox, agrego el filtro y el parámetro
                if (!string.IsNullOrEmpty(idText))
                {
                    sql.Append(" AND m.ID = @ID");
                    cmd.Parameters.AddWithValue("@ID", int.Parse(idText));
                }
                if (!string.IsNullOrEmpty(stockText))
                {
                    sql.Append(" AND m.Stock_ID = @StockID");
                    cmd.Parameters.AddWithValue("@StockID", int.Parse(stockText));
                }
                if (!string.IsNullOrEmpty(provText))
                {
                    sql.Append(" AND m.Proveedor_ID = @ProvID");
                    cmd.Parameters.AddWithValue("@ProvID", int.Parse(provText));
                }
                if (fechaMov.HasValue)
                {
                    sql.Append(" AND CAST(m.Fecha_Movimiento AS DATE) = @FechaMov");
                    cmd.Parameters.AddWithValue("@FechaMov", fechaMov.Value.Date);
                }

                sql.Append(@"
            ORDER BY
                m.Anulado DESC,
                m.Fecha_Movimiento DESC;");

                cmd.CommandText = sql.ToString();
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar movimientos: " + ex.Message);
            }
            return dt;
        }
        public static int AgregarMovimientoStock(MovimientoStockPuente movimiento)
        {
            int nuevoMovimientoID = 0;
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    // 1) Inserción y obtención del nuevo ID
                    using (SqlCommand command = new SqlCommand(@"
                INSERT INTO MovimientoStock 
                    (Stock_ID, Fecha_Movimiento, Tipo_Movimiento, Cantidad, Precio_Unitario, Anulado, Destino, Precio_Total, Proveedor_ID, Cambio)
                VALUES 
                    (@Stock_ID, @Fecha_Movimiento, @Tipo_Movimiento, @Cantidad, @Precio_Unitario, @Anulado, @Destino, @Precio_Total, @Proveedor_ID, @Cambio);
                SELECT CAST(SCOPE_IDENTITY() AS INT);", conexion))
                    {
                        command.Parameters.AddWithValue("@Stock_ID", movimiento.StockID);
                        command.Parameters.AddWithValue("@Fecha_Movimiento", movimiento.FechaMovimiento);
                        command.Parameters.AddWithValue("@Tipo_Movimiento", movimiento.TipoMovimiento);
                        command.Parameters.AddWithValue("@Cantidad", movimiento.Cantidad);
                        command.Parameters.AddWithValue("@Precio_Unitario", movimiento.PrecioUnitario);
                        command.Parameters.AddWithValue("@Anulado", movimiento.Anulado);
                        command.Parameters.AddWithValue("@Destino", string.IsNullOrEmpty(movimiento.Destino) ? DBNull.Value : movimiento.Destino);
                        command.Parameters.AddWithValue("@Precio_Total", movimiento.PrecioTotal);
                        command.Parameters.AddWithValue("@Proveedor_ID", movimiento.ProveedorID.HasValue ? movimiento.ProveedorID.Value : DBNull.Value);
                        command.Parameters.AddWithValue("@Cambio", movimiento.Cambio);

                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            nuevoMovimientoID = Convert.ToInt32(result);
                        }
                        else
                        {
                            throw new Exception("No se pudo obtener el ID del movimiento de stock.");
                        }
                    }

                    // 2) Inserción en Pagos_Pendientes solo si es Egreso (TipoMovimiento = false)
                    if (!movimiento.TipoMovimiento)
                    {
                        using (SqlCommand command2 = new SqlCommand(@"
                INSERT INTO Pagos_Pendientes
                    (MovimientoStockID)
                VALUES
                    (@MovimientoStockID);", conexion))
                        {
                            command2.Parameters.AddWithValue("@MovimientoStockID", nuevoMovimientoID);
                            command2.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar movimiento de stock y pago pendiente: "
                                + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            return nuevoMovimientoID;
        }

        
        public static DataTable RegistroProveedores()
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = new SqlCommand(
                    "SELECT ID, Nombre, Apellido, Empresa FROM Proveedor ORDER BY Empresa, Apellido", cn);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener proveedores: " + ex.Message);
            }
            return dt;
        }

        public static DataTable BuscarProveedores(string texto)
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                var sql = "SELECT ID, Nombre, Apellido, Empresa FROM Proveedor WHERE Nombre LIKE @t OR Apellido LIKE @t";
                using var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@t", "%" + texto + "%");
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar proveedores: " + ex.Message);
            }
            return dt;
        }

        public static DataTable ObtenerStock()
        {
            return RegistroStock();
        }

        public static DataTable RegistroStock()
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = new SqlCommand("SELECT ID, Producto FROM Stock ORDER BY Producto", cn);
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener stock: " + ex.Message);
            }
            return dt;
        }

        public static DataTable BuscarStock(string texto)
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                var sql = "SELECT ID, Producto FROM Stock WHERE Producto LIKE @p";
                using var cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@p", "%" + texto + "%");
                new SqlDataAdapter(cmd).Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar stock: " + ex.Message);
            }
            return dt;
        }

        public static DataTable BuscarStockPorNombre(string nombre)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = "SELECT ID, Producto FROM Stock WHERE Producto LIKE @Nombre";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar productos por nombre: " + ex.Message);
            }
            return dt;
        }
        public static DataTable BuscarStockPorID(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = "SELECT ID, Producto FROM Stock WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto por ID: " + ex.Message);
            }
            return dt;
        }
        public static DataTable ObtenerProveedores()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = "SELECT ID, Empresa FROM Proveedor";
                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener proveedores: " + ex.Message);
            }
            return dt;
        }
        public static int AnularMovimientoStock(int id, bool anulado)
        {
            int resultado = 0;
            try
            {
                using (var conexion = BaseDatos.ObtenerConexion())
                using (var cmd = new SqlCommand(
                    "UPDATE MovimientoStock SET Anulado = @Anulado WHERE ID = @ID", conexion))
                {
                    cmd.Parameters.AddWithValue("@Anulado", anulado);
                    cmd.Parameters.AddWithValue("@ID", id);
                    resultado = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar Anulado: " + ex.Message);
            }
            return resultado;
        }
    }
}