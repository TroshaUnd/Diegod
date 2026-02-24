
using System.Data.SqlClient;
using System.Data;

namespace Diegod
{
    public class StockFunciones
    {
        public static DataTable RegistroStock()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = @"
                        SELECT 
                            s.ID,
                            s.Producto,
                            s.Lugar,
                            COALESCE(sc.CantidadTotal, 0) AS Cantidad,
                            um.Precio_Unitario,
                            um.Fecha_Movimiento
                        FROM Stock s
                        LEFT JOIN vwStockCantidad sc 
                            ON s.ID = sc.Stock_ID
                        LEFT JOIN vwUltimoMovimiento um 
                            ON s.ID = um.Stock_ID
                        ORDER BY s.ID;
                    ";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener registro de stock: " + ex.Message);
            }
            return dt;
        }
        public static int AgregarStock(StockPuente stock)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = @"
                        INSERT INTO Stock (Producto, Lugar)
                        VALUES (@Producto, @Lugar)";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Producto", stock.Producto);
                        command.Parameters.AddWithValue("@Lugar", stock.Lugar ?? (object)DBNull.Value);
                        resultado = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al agregar stock: " + ex.Message);
            }
            return resultado;
        }

        public static int ModificarStock(StockPuente stock)
        {
            int resultado = 0;
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string query = @"
                        UPDATE Stock 
                        SET Producto = @Producto,
                            Lugar = @Lugar
                        WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        command.Parameters.AddWithValue("@Producto", stock.Producto);
                        command.Parameters.AddWithValue("@Lugar", stock.Lugar ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ID", stock.ID);
                        resultado = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al modificar stock: " + ex.Message);
            }
            return resultado;
        }

        public static DataTable BuscarStock(string id, string producto)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    // Usamos las mismas vistas que en RegistroStock()
                    string query = @"
                    SELECT 
                        s.ID,
                        s.Producto,
                        s.Lugar,
                        COALESCE(sc.CantidadTotal, 0) AS Cantidad,
                        um.Precio_Unitario,
                        um.Precio_Total,
                        um.Fecha_Movimiento
                    FROM Stock s
                    LEFT JOIN vwStockCantidad sc ON s.ID = sc.Stock_ID
                    LEFT JOIN vwUltimoMovimiento um ON s.ID = um.Stock_ID
                    WHERE 1 = 1";

                    if (!string.IsNullOrEmpty(id))
                        query += " AND s.ID = @ID";
                    if (!string.IsNullOrEmpty(producto))
                        query += " AND s.Producto LIKE @Producto";

                    query += " ORDER BY s.ID;";

                    using (SqlCommand command = new SqlCommand(query, conexion))
                    {
                        if (!string.IsNullOrEmpty(id))
                            command.Parameters.AddWithValue("@ID", id);
                        if (!string.IsNullOrEmpty(producto))
                            command.Parameters.AddWithValue("@Producto", "%" + producto + "%");

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al buscar stock: " + ex.Message);
            }
            return dt;
        }

    }
}
