using System;
using System.Data;
using Diegod.Datos;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace Diegod
{
    public static class HistorialFunciones
    {
        public static DataTable RegistroHistorial()
        {
            var dt = new DataTable();
            try
            {
                using var cn = BaseDatos.ObtenerConexion();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = @"
SELECT
    h.Anulado       AS Anulado,
    h.ID            AS ID,
    -- Descriptivos antes de fecha
    COALESCE(
      (SELECT cl.Nombre FROM Pagos_Pendientes pp
           JOIN Trabajos tr     ON pp.TrabajoID = tr.ID
           JOIN Clientes cl     ON tr.Cliente_ID = cl.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT e.Nombre  FROM Pagos_Pendientes pp
           JOIN Empleados_Trabajo et ON pp.EmpleadoTrabajoID = et.ID
           JOIN Empleados e         ON et.Empleado_ID = e.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pr.Nombre FROM Pagos_Pendientes pp
           JOIN MovimientoStock ms  ON pp.MovimientoStockID = ms.ID
           JOIN Proveedor pr        ON ms.Proveedor_ID = pr.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pt.Nombre FROM Pagos_Pendientes pp
           JOIN Credito c          ON pp.CreditoID = c.ID
           JOIN Prestamista pt     ON c.Prestamista_ID = pt.ID
         WHERE pp.ID = h.Pendiente_ID)
    ) AS Nombre,
    -- Apellido
    COALESCE(
      (SELECT cl.Apellido FROM Pagos_Pendientes pp
           JOIN Trabajos tr ON pp.TrabajoID = tr.ID
           JOIN Clientes cl ON tr.Cliente_ID = cl.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT e.Apellido FROM Pagos_Pendientes pp
           JOIN Empleados_Trabajo et ON pp.EmpleadoTrabajoID = et.ID
           JOIN Empleados e         ON et.Empleado_ID = e.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pr.Apellido FROM Pagos_Pendientes pp
           JOIN MovimientoStock ms ON pp.MovimientoStockID = ms.ID
           JOIN Proveedor pr       ON ms.Proveedor_ID = pr.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pt.Apellido FROM Pagos_Pendientes pp
           JOIN Credito c          ON pp.CreditoID = c.ID
           JOIN Prestamista pt     ON c.Prestamista_ID = pt.ID
         WHERE pp.ID = h.Pendiente_ID)
    ) AS Apellido,
    -- Empresa
    COALESCE(
      (SELECT cl.Empresa FROM Pagos_Pendientes pp
           JOIN Trabajos tr ON pp.TrabajoID = tr.ID
           JOIN Clientes cl ON tr.Cliente_ID = cl.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT e.Empresa FROM Pagos_Pendientes pp
           JOIN Empleados_Trabajo et ON pp.EmpleadoTrabajoID = et.ID
           JOIN Empleados e         ON et.Empleado_ID = e.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pr.Empresa FROM Pagos_Pendientes pp
           JOIN MovimientoStock ms ON pp.MovimientoStockID = ms.ID
           JOIN Proveedor pr       ON ms.Proveedor_ID = pr.ID
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT pt.Empresa FROM Pagos_Pendientes pp
           JOIN Credito c          ON pp.CreditoID = c.ID
           JOIN Prestamista pt     ON c.Prestamista_ID = pt.ID
         WHERE pp.ID = h.Pendiente_ID)
    ) AS Empresa,
    -- Tipo (ruta completa FK→TipoId→Tipo.Nombre)
    COALESCE(
      (SELECT t2.Nombre FROM Pagos_Pendientes pp
           JOIN Credito c      ON pp.CreditoID = c.ID
           JOIN Prestamista pt ON c.Prestamista_ID = pt.ID
           JOIN Tipo t2        ON pt.TipoId = t2.TipoId
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT t2.Nombre FROM Pagos_Pendientes pp
           JOIN Empleados_Trabajo et ON pp.EmpleadoTrabajoID = et.ID
           JOIN Empleados e         ON et.Empleado_ID = e.ID
           JOIN Tipo t2             ON e.TipoId = t2.TipoId
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT t2.Nombre FROM Pagos_Pendientes pp
           JOIN MovimientoStock ms ON pp.MovimientoStockID = ms.ID
           JOIN Proveedor pr       ON ms.Proveedor_ID = pr.ID
           JOIN Tipo t2            ON pr.TipoId = t2.TipoId
         WHERE pp.ID = h.Pendiente_ID),
      (SELECT t2.Nombre FROM Pagos_Pendientes pp
           JOIN Credito c          ON pp.CreditoID = c.ID
           JOIN Prestamista pt     ON c.Prestamista_ID = pt.ID
           JOIN Tipo t2            ON pt.TipoId = t2.TipoId
         WHERE pp.ID = h.Pendiente_ID)
    ) AS Tipo,
    -- Fecha y Monto
    h.Fecha_Pago AS FechaPago,
    '$' || fmt_n0(h.Monto) AS Monto,
    -- Transacción
    CASE
      WHEN EXISTS(SELECT 1 FROM Pagos_Pendientes pp2 JOIN Trabajos t2 ON pp2.TrabajoID = t2.ID WHERE pp2.ID = h.Pendiente_ID) THEN 'Cobrar'
      WHEN EXISTS(SELECT 1 FROM Pagos_Pendientes pp2 WHERE pp2.ID = h.Pendiente_ID AND (pp2.EmpleadoTrabajoID IS NOT NULL OR pp2.CreditoID IS NOT NULL)) THEN 'Pagar'
      WHEN EXISTS(SELECT 1 FROM Pagos_Pendientes pp2 JOIN MovimientoStock m2 ON pp2.MovimientoStockID = m2.ID WHERE pp2.ID = h.Pendiente_ID AND m2.Tipo_Movimiento = 1) THEN 'Pagar'
      ELSE 'Cobrar'
    END AS Transaccion,
    -- FK al final
    h.Pendiente_ID AS Pendiente_ID
FROM Historial h;
";
                using var da = new SqlDataAdapter(cmd);
                da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                da.FillSchema(dt, SchemaType.Source);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener historial: " + ex.Message);
            }
            return dt;
        }

        public static void BindToGrid(DataGridView grid)
        {
            // Ajustar modo de selección para permitir columnas auto-generadas con SortMode Automático
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoGenerateColumns = true;
            grid.DataSource = RegistroHistorial();
            grid.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        public static int ModificarAnuladoHistorial(int historialID, bool anulado)
        {
            int rows;
            using var cn = BaseDatos.ObtenerConexion();
            if (cn.State == ConnectionState.Open) cn.Close();
            cn.Open();
            using var cmd = cn.CreateCommand();
            cmd.CommandText = @"
        UPDATE Historial
           SET Anulado = @an
         WHERE ID = @id";
            cmd.Parameters.AddWithValue("@an", anulado);
            cmd.Parameters.AddWithValue("@id", historialID);
            rows = cmd.ExecuteNonQuery();
            return rows;
        }
        public static void ImprimirHistorialMes(DateTime fechaSeleccionada)
        {
            DataTable dt = RegistroHistorial();

            int mes = fechaSeleccionada.Month;
            int anio = fechaSeleccionada.Year;

            var filas = dt.AsEnumerable()
                          .Where(r => r.Field<DateTime>("FechaPago").Month == mes &&
                                      r.Field<DateTime>("FechaPago").Year == anio);

            DataTable dtMes = filas.Any() ? filas.CopyToDataTable() : dt.Clone();

            if (dtMes.Rows.Count == 0)
            {
                MessageBox.Show("No hay registros para el mes seleccionado.",
                                "Historial vacío",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            // ============================
            //     CÁLCULO DE TOTALES
            // ============================
            decimal totalCobrado = 0m, totalPagado = 0m;

            foreach (DataRow row in dtMes.Rows)
            {
                string montoStr = row["Monto"].ToString()
                    .Replace("$", "").Replace(".", "").Replace(",", "");

                if (!decimal.TryParse(montoStr, out decimal monto))
                    continue;

                string trans = row["Transaccion"].ToString();

                if (trans == "Cobrar") totalCobrado += monto;
                if (trans == "Pagar") totalPagado += monto;
            }

            decimal totalFinal = totalCobrado - totalPagado;

            // ============================
            //        IMPRESIÓN
            // ============================
            PrintDocument pd = new PrintDocument();

            pd.PrintPage += (sender, e) =>
            {
                int y = 20;
                int margen = 40;

                Font fuente = new Font("Consolas", 10);
                Font fuenteTitulo = new Font("Consolas", 14, FontStyle.Bold);
                Font fuenteTotales = new Font("Consolas", 10, FontStyle.Bold);

                // ----- Título -----
                e.Graphics.DrawString($"Historial del mes: {fechaSeleccionada:MMMM yyyy}",
                                      fuenteTitulo, Brushes.Black, margen, y);
                y += 40;

                // ----- Encabezados -----
                string[] columnas = { "Nombre", "Apellido", "Empresa", "Tipo", "Transaccion", "Monto", "FechaPago" };

                // ---- Calcular ancho automático por columna ----
                int[] ancho = new int[columnas.Length];

                for (int i = 0; i < columnas.Length; i++)
                {
                    int max = (int)e.Graphics.MeasureString(columnas[i], fuente).Width + 20;

                    foreach (DataRow row in dtMes.Rows)
                    {
                        string val;

                        if (columnas[i] == "FechaPago")
                        {
                            val = row.Field<DateTime>("FechaPago").ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            val = row[columnas[i]].ToString();
                        }

                        int w = (int)e.Graphics.MeasureString(val, fuente).Width + 20;
                        if (w > max) max = w;
                    }

                    ancho[i] = max;
                }

                int x = margen;

                // ----- Línea superior -----
                e.Graphics.DrawLine(Pens.Black, margen, y, margen + ancho.Sum(), y);
                y += 5;

                // ----- Encabezados -----
                for (int i = 0; i < columnas.Length; i++)
                {
                    e.Graphics.DrawString(columnas[i], fuente, Brushes.Black, x, y);
                    x += ancho[i];
                    e.Graphics.DrawLine(Pens.Black, x, y - 5, x, y + 20);
                }

                y += 25;

                // ----- Línea horizontal -----
                e.Graphics.DrawLine(Pens.Black, margen, y, margen + ancho.Sum(), y);
                y += 5;

                // ----- Filas -----
                foreach (DataRow row in dtMes.Rows)
                {
                    x = margen;

                    for (int i = 0; i < columnas.Length; i++)
                    {
                        string col = columnas[i];
                        string valor = "";

                        if (col == "Monto")
                        {
                            string montoRaw = row["Monto"].ToString()
                                .Replace("$", "").Replace(".", "").Replace(",", "");

                            if (!decimal.TryParse(montoRaw, out decimal montoVal))
                                montoVal = 0;

                            valor = montoVal.ToString("N0", new CultureInfo("es-AR"));

                            // Alinear a derecha
                            SizeF size = e.Graphics.MeasureString(valor, fuente);
                            e.Graphics.DrawString(valor, fuente, Brushes.Black,
                                x + ancho[i] - size.Width - 5, y);
                        }
                        else if (col == "FechaPago")
                        {
                            valor = row.Field<DateTime>("FechaPago")
                                        .ToString("dd/MM/yyyy");

                            e.Graphics.DrawString(valor, fuente, Brushes.Black, x, y);
                        }
                        else
                        {
                            valor = row[col]?.ToString() ?? "";
                            e.Graphics.DrawString(valor, fuente, Brushes.Black, x, y);
                        }

                        x += ancho[i];
                        e.Graphics.DrawLine(Pens.Black, x, y - 5, x, y + 20);
                    }

                    y += 22;

                    // línea horizontal
                    e.Graphics.DrawLine(Pens.Black, margen, y, margen + ancho.Sum(), y);
                    y += 5;
                }

                // ----- Totales -----
                y += 20;

                e.Graphics.DrawString($"Total Cobrado: {totalCobrado.ToString("N0", new CultureInfo("es-AR"))}",
                                      fuenteTotales, Brushes.Black, margen, y);
                y += 22;

                e.Graphics.DrawString($"Total Pagado : {totalPagado.ToString("N0", new CultureInfo("es-AR"))}",
                                      fuenteTotales, Brushes.Black, margen, y);
                y += 22;

                e.Graphics.DrawString($"Total Final  : {totalFinal.ToString("N0", new CultureInfo("es-AR"))}",
                                      fuenteTotales, Brushes.Black, margen, y);
            };

            // ---- Vista previa ----
            PrintPreviewDialog ppd = new PrintPreviewDialog
            {
                Document = pd,
                Width = 900,
                Height = 600
            };

            ppd.ShowDialog();
        }
    }
}
