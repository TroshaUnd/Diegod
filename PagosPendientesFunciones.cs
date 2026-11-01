using Diegod.Datos;
using System.Data;

namespace Diegod
{
    public static class PagosFunciones
    {
        public static DataTable RegistroPagosPendientes()
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
SELECT
    pp.ID                 AS ID,
    pp.CreditoID,
    pp.EmpleadoTrabajoID,
    pp.MovimientoStockID,
    pp.TrabajoID,
    pp.Anulado            AS Anulado,
    COALESCE(
        (SELECT cl.Nombre  FROM Trabajos tr INNER JOIN Clientes cl ON tr.Cliente_ID     = cl.ID WHERE tr.ID        = pp.TrabajoID),
        (SELECT e.Nombre   FROM Empleados_Trabajo et INNER JOIN Empleados e ON et.Empleado_ID = e.ID WHERE et.ID        = pp.EmpleadoTrabajoID),
        (SELECT pr.Nombre  FROM MovimientoStock ms INNER JOIN Proveedor pr ON ms.Proveedor_ID = pr.ID WHERE ms.ID        = pp.MovimientoStockID),
        (SELECT pt.Nombre  FROM Credito c INNER JOIN Prestamista pt ON c.Prestamista_ID  = pt.ID WHERE c.ID         = pp.CreditoID)
    )                     AS Nombre,
    COALESCE(
        (SELECT cl.Apellido FROM Trabajos tr INNER JOIN Clientes cl ON tr.Cliente_ID     = cl.ID WHERE tr.ID        = pp.TrabajoID),
        (SELECT e.Apellido  FROM Empleados_Trabajo et INNER JOIN Empleados e ON et.Empleado_ID = e.ID WHERE et.ID        = pp.EmpleadoTrabajoID),
        (SELECT pr.Apellido FROM MovimientoStock ms INNER JOIN Proveedor pr ON ms.Proveedor_ID = pr.ID WHERE ms.ID        = pp.MovimientoStockID),
        (SELECT pt.Apellido FROM Credito c INNER JOIN Prestamista pt ON c.Prestamista_ID  = pt.ID WHERE c.ID         = pp.CreditoID)
    )                     AS Apellido,
    COALESCE(
        (SELECT cl.Empresa  FROM Trabajos tr INNER JOIN Clientes cl ON tr.Cliente_ID     = cl.ID WHERE tr.ID        = pp.TrabajoID),
        (SELECT e.Empresa   FROM Empleados_Trabajo et INNER JOIN Empleados e ON et.Empleado_ID = e.ID WHERE et.ID        = pp.EmpleadoTrabajoID),
        (SELECT pt.Empresa  FROM Credito c INNER JOIN Prestamista pt ON c.Prestamista_ID  = pt.ID WHERE c.ID         = pp.CreditoID),
        (SELECT pr.Empresa  FROM MovimientoStock ms INNER JOIN Proveedor pr ON ms.Proveedor_ID = pr.ID WHERE ms.ID        = pp.MovimientoStockID)
    )                     AS Empresa,
    COALESCE(
        (SELECT t.Nombre   FROM Trabajos tr INNER JOIN Clientes cl ON tr.Cliente_ID     = cl.ID INNER JOIN Tipo t ON cl.TipoId    = t.TipoId WHERE tr.ID        = pp.TrabajoID),
        (SELECT t.Nombre   FROM Empleados_Trabajo et INNER JOIN Empleados e ON et.Empleado_ID = e.ID INNER JOIN Tipo t ON e.TipoId      = t.TipoId WHERE et.ID        = pp.EmpleadoTrabajoID),
        (SELECT t.Nombre   FROM MovimientoStock ms INNER JOIN Proveedor pr ON ms.Proveedor_ID = pr.ID INNER JOIN Tipo t ON pr.TipoId     = t.TipoId WHERE ms.ID        = pp.MovimientoStockID),
        (SELECT t.Nombre   FROM Credito c INNER JOIN Prestamista pt ON c.Prestamista_ID  = pt.ID INNER JOIN Tipo t ON pt.TipoId     = t.TipoId WHERE c.ID         = pp.CreditoID)
    )                     AS Tipo,
    fmt_pesos(COALESCE(
        (SELECT CAST(tr.Presupuesto   AS TEXT) FROM Trabajos        tr WHERE tr.ID        = pp.TrabajoID),
        (SELECT CAST(et.Valor_Trabajo AS TEXT) FROM Empleados_Trabajo et WHERE et.ID        = pp.EmpleadoTrabajoID),
        (SELECT fmt_txt(ms.Precio_Total) FROM MovimientoStock  ms WHERE ms.ID        = pp.MovimientoStockID),
        (SELECT fmt_txt(c.Monto_Credito) FROM Credito         c  WHERE c.ID        = pp.CreditoID),
        '0'
    ))                    AS Deuda,
    fmt_pesos(
        IFNULL(
            (SELECT SUM(h.Monto)
               FROM Historial h
              WHERE h.Pendiente_ID = pp.ID
                AND h.Anulado      = 0
              GROUP BY h.Pendiente_ID),
            0
        )
    )                     AS Pagado,
    COALESCE(
        (SELECT tr.Fecha_Inicio     FROM Trabajos        tr WHERE tr.ID        = pp.TrabajoID),
        (SELECT tr2.Fecha_Inicio    FROM Empleados_Trabajo et INNER JOIN Trabajos tr2 ON et.Trabajo_ID = tr2.ID WHERE et.ID   = pp.EmpleadoTrabajoID),
        (SELECT ms.Fecha_Movimiento FROM MovimientoStock ms WHERE ms.ID        = pp.MovimientoStockID),
        (SELECT c.Fecha_Credito     FROM Credito         c  WHERE c.ID        = pp.CreditoID)
    )                     AS Fecha_Deuda,
    CASE
      WHEN pp.CreditoID IS NOT NULL THEN (SELECT c.Fecha_Vencimiento FROM Credito c WHERE c.ID = pp.CreditoID)
      ELSE pp.Fecha_Vencimiento
    END                   AS Fecha_Vencimiento,
    CASE
      WHEN pp.TrabajoID IS NOT NULL                                          THEN 'Cobrar'
      WHEN pp.EmpleadoTrabajoID IS NOT NULL OR pp.CreditoID IS NOT NULL      THEN 'Pagar'
      WHEN pp.MovimientoStockID IS NOT NULL 
           AND (SELECT Tipo_Movimiento FROM MovimientoStock WHERE ID = pp.MovimientoStockID) = 1 THEN 'Pagar'
      ELSE 'Cobrar'
    END                   AS Tipo_Transaccion
FROM Pagos_Pendientes pp
WHERE NOT (
    (pp.TrabajoID IS NOT NULL 
     AND EXISTS(
         SELECT 1 
           FROM Trabajos tr 
          WHERE tr.ID      = pp.TrabajoID 
            AND tr.Anulado = 1
     ))
    OR (pp.EmpleadoTrabajoID IS NOT NULL 
        AND EXISTS(
            SELECT 1 
              FROM Empleados_Trabajo et 
             WHERE et.ID      = pp.EmpleadoTrabajoID 
               AND et.Anulado = 1
        ))
    OR (pp.MovimientoStockID IS NOT NULL 
        AND EXISTS(
            SELECT 1 
              FROM MovimientoStock ms 
             WHERE ms.ID      = pp.MovimientoStockID 
               AND ms.Anulado = 1
        ))
    OR (pp.CreditoID IS NOT NULL 
        AND EXISTS(
            SELECT 1 
              FROM Credito c 
             WHERE c.ID      = pp.CreditoID 
               AND c.Anulado = 1
        ))
);";

                using var da = new SqlDataAdapter(cmd);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.FillSchema(dt, SchemaType.Source);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener datos de PagosPendientes: " + ex.Message);
            }

            return dt;
        }
        public static int ModificarAnulado(int pagoID, bool anulado)
        {
            int rows;
            using (var cn = BaseDatos.ObtenerConexion())
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Pagos_Pendientes
                       SET Anulado = @an
                     WHERE ID = @id";
                cmd.Parameters.AddWithValue("@an", anulado);
                cmd.Parameters.AddWithValue("@id", pagoID);
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }


        public static void BindToGrid(DataGridView grid)
        {
            grid.AutoGenerateColumns = true;
            grid.DataSource = RegistroPagosPendientes();
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            // Ocultar columnas de ID internas
            foreach (string col in new[] { "CreditoID", "EmpleadoTrabajoID", "MovimientoStockID", "TrabajoID" })
            {
                if (grid.Columns.Contains(col))
                    grid.Columns[col].Visible = false;
            }
        }
        public static int ModificarVencimientoPago(int pagoID, DateTime nuevaFecha)
        {
            int rows;
            using (var cn = BaseDatos.ObtenerConexion())
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Pagos_Pendientes
                       SET Fecha_Vencimiento = @vto
                     WHERE ID = @id";
                cmd.Parameters.AddWithValue("@vto", nuevaFecha);
                cmd.Parameters.AddWithValue("@id", pagoID);
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }

        public static int ModificarVencimientoCredito(int creditoID, DateTime nuevaFecha)
        {
            int rows;
            using (var cn = BaseDatos.ObtenerConexion())
            {
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
                    UPDATE Credito
                       SET Fecha_Vencimiento = @vto
                     WHERE ID = @id";
                cmd.Parameters.AddWithValue("@vto", nuevaFecha);
                cmd.Parameters.AddWithValue("@id", creditoID);
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }
        public static int AgregarHistorial(int pagoID, DateTime fechaPago, decimal monto)
        {
            int rows;
            using (var cn = BaseDatos.ObtenerConexion())
            {
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO Historial (Pendiente_ID, Fecha_Pago, Monto, Anulado)
            VALUES (@pendiente, @fecha, @monto, 0)";
                cmd.Parameters.AddWithValue("@pendiente", pagoID);
                cmd.Parameters.AddWithValue("@fecha", fechaPago);
                cmd.Parameters.AddWithValue("@monto", monto);
                rows = cmd.ExecuteNonQuery();
            }
            return rows;
        }

    }
}
