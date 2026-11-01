using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Diegod
{
    public partial class PagosPendientes : Form
    {
        private DataTable _pagosTable;

        public PagosPendientes()
        {
            InitializeComponent();
            Ayudas.Configurar(this);

            // 1) Obtener la tabla completa sólo una vez
            _pagosTable = PagosFunciones.RegistroPagosPendientes();

            // 2) Configurar DGViewPagosPendientes (Cobrar)
            DGViewPagosPendientes.AllowUserToAddRows = false;
            DGViewPagosPendientes.AutoGenerateColumns = true;
            DGViewPagosPendientes.CurrentCellDirtyStateChanged += DGViewPagosPendientes_CurrentCellDirtyStateChanged;
            DGViewPagosPendientes.CellValueChanged += DGViewPagosPendientes_CellValueChanged;
            DGViewPagosPendientes.RowPrePaint += DGViewPagosPendientes_RowPrePaint;

            // 3) Configurar DGViewPagosPagar (Pagar)
            DGViewPagosPagar.AllowUserToAddRows = false;
            DGViewPagosPagar.AutoGenerateColumns = true;
            DGViewPagosPagar.SelectionChanged += DGViewPagosPagar_SelectionChanged;
            DGViewPagosPagar.CurrentCellDirtyStateChanged += DGViewPagosPagar_CurrentCellDirtyStateChanged;
            DGViewPagosPagar.CellValueChanged += DGViewPagosPagar_CellValueChanged;
            DGViewPagosPagar.RowPrePaint += DGViewPagosPagar_RowPrePaint;

            // 4) Configurar DateTimePicker para búsqueda de fecha
            DateBuscarFecha.Format = DateTimePickerFormat.Short;
            DateBuscarFecha.ShowCheckBox = true;

            // 5) Asignar botón Buscar
            bttnBuscar.Click += BttnBuscar_Click;

            // 6) Cargar ambos grids
            CargarGrillas();
        }

        private void CargarGrillas()
        {
            // Filtrar Cobrar
            var dvCobrar = new DataView(_pagosTable);
            dvCobrar.RowFilter = "Tipo_Transaccion = 'Cobrar'";
            DGViewPagosPendientes.DataSource = dvCobrar;
            DGViewPagosPendientes.ClearSelection();

            // Filtrar Pagar
            var dvPagar = new DataView(_pagosTable);
            dvPagar.RowFilter = "Tipo_Transaccion = 'Pagar'";
            DGViewPagosPagar.DataSource = dvPagar;
            DGViewPagosPagar.ClearSelection();

            // Ocultar columnas internas en ambos grids
            foreach (string col in new[] { "CreditoID", "EmpleadoTrabajoID", "MovimientoStockID", "TrabajoID" })
            {
                if (DGViewPagosPendientes.Columns.Contains(col))
                    DGViewPagosPendientes.Columns[col].Visible = false;
                if (DGViewPagosPagar.Columns.Contains(col))
                    DGViewPagosPagar.Columns[col].Visible = false;
            }
        }

        // --- BOTÓN BUSCAR ---
        private void BttnBuscar_Click(object sender, EventArgs e)
        {
            var dv = new DataView(_pagosTable);
            string filter = "";

            // 1) Filtrar por ID exacto si txtBuscarID tiene un número válido
            if (int.TryParse(txtBuscarID.Text.Trim(), out int buscaId) && buscaId > 0)
            {
                filter = $"ID = {buscaId}";
            }
            // 2) Filtrar por Nombre o Apellido si txtBuscar no está vacío
            else if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                string txt = txtBuscar.Text.Replace("'", "''").Trim();
                filter = $"Nombre LIKE '%{txt}%' OR Apellido LIKE '%{txt}%'";
            }
            // 3) Filtrar por Fecha_Deuda si DateBuscarFecha.Checked
            else if (DateBuscarFecha.Checked)
            {
                var d = DateBuscarFecha.Value.Date;
                string desde = d.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                string hasta = d.AddDays(1).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
                filter = $"Fecha_Deuda >= #{desde}# AND Fecha_Deuda < #{hasta}#";
            }
            // Sino, filter queda vacío y muestra todo

            // Aplicar filtro a la tabla original y recargar ambas grillas
            dv.RowFilter = filter;
            _pagosTable = dv.ToTable(); // sobrescribir fuente con datos filtrados
            CargarGrillas();
        }

        // --- EVENTOS DGViewPagosPendientes (Cobrar) ---
        private void DGViewPagosPendientes_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewPagosPendientes.IsCurrentCellDirty)
                DGViewPagosPendientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewPagosPendientes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewPagosPendientes.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewPagosPendientes.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);
            PagosFunciones.ModificarAnulado(id, anulado);
            DGViewPagosPendientes.InvalidateRow(e.RowIndex);
        }

        private void DGViewPagosPendientes_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PintarFila(DGViewPagosPendientes.Rows[e.RowIndex]);
        }

        // Gris = anulado | Verde = pagado completo | Rojo = vencido sin pagar | Dorado = pendiente
        private static void PintarFila(DataGridViewRow row)
        {
            PintarFilaColor(row);
            // La fila seleccionada se ve un poco mas oscura pero conserva su color
            Color fondo = row.DefaultCellStyle.BackColor;
            row.DefaultCellStyle.SelectionBackColor = ControlPaint.Dark(fondo, 0.05f);
            row.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private static void PintarFilaColor(DataGridViewRow row)
        {
            if (row.Cells["Anulado"].Value is bool an && an)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                return;
            }

            decimal? deuda = ParseMonto(row.Cells["Deuda"].Value?.ToString());
            decimal? pagado = ParseMonto(row.Cells["Pagado"].Value?.ToString());
            if (deuda.HasValue && pagado.HasValue && pagado.Value >= deuda.Value)
            {
                row.DefaultCellStyle.BackColor = Color.LightGreen;
                return;
            }

            if (row.Cells["Fecha_Vencimiento"].Value is DateTime venc && venc.Date < DateTime.Today)
            {
                row.DefaultCellStyle.BackColor = Color.Tomato;
                return;
            }

            row.DefaultCellStyle.BackColor = Color.Gold;
        }

        /// <summary>Convierte textos como "$150.000", "$1500.5" o "$2000" en numero. Null si no se entiende.</summary>
        internal static decimal? ParseMonto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            string s = texto.Replace("$", "").Replace(" ", "").Trim();
            if (s.Length == 0) return null;

            bool punto = s.Contains('.'), coma = s.Contains(',');
            if (punto && coma) s = s.Replace(".", "").Replace(",", ".");
            else if (coma) s = s.Replace(",", ".");
            else if (punto && Regex.IsMatch(s, @"^\d{1,3}(\.\d{3})+$")) s = s.Replace(".", "");

            return decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal d) ? d : (decimal?)null;
        }

        internal static string Dinero(decimal v) => "$" + v.ToString("#,##0.##", new CultureInfo("es-AR"));

        private void DGViewPagosPendientes_SelectionChanged(object sender, EventArgs e)
        {
            if (DGViewPagosPendientes.CurrentRow == null) return;
            var row = (DataRowView)DGViewPagosPendientes.CurrentRow.DataBoundItem;

            txtID.Text = row.Row.Field<int>("ID").ToString();
            txtMovimientoID.Text = row.Row.Field<int?>("MovimientoStockID")?.ToString() ?? "";
            txtCreditoID.Text = row.Row.Field<int?>("CreditoID")?.ToString() ?? "";
            txtTrabajoID.Text = row.Row.Field<int?>("TrabajoID")?.ToString() ?? "";
            txtEmpleadoID.Text = row.Row.Field<int?>("EmpleadoTrabajoID")?.ToString() ?? "";

            if (int.TryParse(txtCreditoID.Text, out int credId) && credId > 0)
            {
                using var cn = BaseDatos.ObtenerConexion();
                if (cn.State != System.Data.ConnectionState.Open)
                    cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT Fecha_Vencimiento FROM Credito WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", credId);
                var result = cmd.ExecuteScalar();
                if (result != null && DateTime.TryParse(result.ToString(), out DateTime fechaCred))
                {
                    dtpVencimiento.Value = fechaCred;
                    return;
                }
                cn.Close();
            }

            var vtoField = row.Row.Field<DateTime?>("Fecha_Vencimiento");
            dtpVencimiento.Value = vtoField ?? DateTime.Today;
        }

        // --- EVENTOS DGViewPagosPagar (Pagar) ---
        private void DGViewPagosPagar_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewPagosPagar.IsCurrentCellDirty)
                DGViewPagosPagar.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewPagosPagar_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewPagosPagar.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewPagosPagar.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);
            PagosFunciones.ModificarAnulado(id, anulado);
            DGViewPagosPagar.InvalidateRow(e.RowIndex);
        }

        private void DGViewPagosPagar_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0) return;
            PintarFila(DGViewPagosPagar.Rows[e.RowIndex]);
        }

        private void DGViewPagosPagar_SelectionChanged(object sender, EventArgs e)
        {
            if (DGViewPagosPagar.CurrentRow == null) return;
            var row = (DataRowView)DGViewPagosPagar.CurrentRow.DataBoundItem;

            txtID.Text = row.Row.Field<int>("ID").ToString();
            txtMovimientoID.Text = row.Row.Field<int?>("MovimientoStockID")?.ToString() ?? "";
            txtCreditoID.Text = row.Row.Field<int?>("CreditoID")?.ToString() ?? "";
            txtTrabajoID.Text = row.Row.Field<int?>("TrabajoID")?.ToString() ?? "";
            txtEmpleadoID.Text = row.Row.Field<int?>("EmpleadoTrabajoID")?.ToString() ?? "";

            if (int.TryParse(txtCreditoID.Text, out int credId) && credId > 0)
            {
                using var cn = BaseDatos.ObtenerConexion();
                if (cn.State != System.Data.ConnectionState.Open)
                    cn.Open();
                using var cmd = cn.CreateCommand();
                cmd.CommandText = "SELECT Fecha_Vencimiento FROM Credito WHERE ID = @id";
                cmd.Parameters.AddWithValue("@id", credId);
                var result = cmd.ExecuteScalar();
                if (result != null && DateTime.TryParse(result.ToString(), out DateTime fechaCred))
                {
                    dtpVencimiento.Value = fechaCred;
                    return;
                }
                cn.Close();
            }

            var vtoField = row.Row.Field<DateTime?>("Fecha_Vencimiento");
            dtpVencimiento.Value = vtoField ?? DateTime.Today;
        }

        // --- RESTO DE HANDLERS (idénticos) ---

        private void bttnAgregarVencimiento_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtID.Text, out int pagoID))
                {
                    MessageBox.Show("ID de Pago inválido.");
                    return;
                }
                DateTime nuevaFecha = dtpVencimiento.Value;

                bool updated;
                if (int.TryParse(txtCreditoID.Text, out int creditoID) && creditoID > 0)
                {
                    updated = PagosFunciones.ModificarVencimientoCredito(creditoID, nuevaFecha) > 0;
                    MessageBox.Show(updated
                        ? "Fecha de vencimiento de crédito actualizada."
                        : "No se encontró el crédito para actualizar.");
                }
                else
                {
                    updated = PagosFunciones.ModificarVencimientoPago(pagoID, nuevaFecha) > 0;
                    MessageBox.Show(updated
                        ? "Fecha de vencimiento de pago pendiente actualizada."
                        : "No se encontró el pago pendiente para actualizar.");
                }

                // Refrescar tablas y grillas
                _pagosTable = PagosFunciones.RegistroPagosPendientes();
                CargarGrillas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void bttnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtID.Text, out int pagoID))
                {
                    MessageBox.Show("ID de Pago inválido.");
                    return;
                }
                decimal? montoLeido = ParseMonto(txtMonto.Text);
                if (!montoLeido.HasValue || montoLeido.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a cero (por ejemplo 5000).", "Monto incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Focus();
                    return;
                }
                decimal monto = montoLeido.Value;
                // Controlar contra lo que se debe / se tiene que cobrar
                DataTable actual = PagosFunciones.RegistroPagosPendientes();
                DataRow fila = actual.AsEnumerable().FirstOrDefault(r => r.Field<int>("ID") == pagoID);
                if (fila != null)
                {
                    decimal? deuda = ParseMonto(fila["Deuda"]?.ToString());
                    decimal pagado = ParseMonto(fila["Pagado"]?.ToString()) ?? 0m;
                    if (deuda.HasValue && deuda.Value > 0)
                    {
                        decimal saldo = deuda.Value - pagado;
                        if (saldo <= 0)
                        {
                            MessageBox.Show("El monto ya está completo.\n\nTotal: " + Dinero(deuda.Value) +
                                            "\nYa registrado: " + Dinero(pagado),
                                            "Monto completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (monto > saldo)
                        {
                            MessageBox.Show("El monto ingresado (" + Dinero(monto) + ") se pasa por " +
                                            Dinero(monto - saldo) + " de lo solicitado.\n\nTotal: " + Dinero(deuda.Value) +
                                            "\nYa registrado: " + Dinero(pagado) + "\nSaldo pendiente: " + Dinero(saldo),
                                            "Monto excedido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                DateTime fechaPago = DateFechaPago.Value;
                if (PagosFunciones.AgregarHistorial(pagoID, fechaPago, monto) > 0)
                {
                    string detalle = "Pago registrado: " + Dinero(monto);
                    if (fila != null)
                    {
                        decimal? d2 = ParseMonto(fila["Deuda"]?.ToString());
                        decimal p2 = ParseMonto(fila["Pagado"]?.ToString()) ?? 0m;
                        if (d2.HasValue && d2.Value > 0)
                        {
                            decimal resto = d2.Value - p2 - monto;
                            detalle += resto <= 0 ? "\nLa deuda quedó completa." : "\nSaldo pendiente: " + Dinero(resto);
                        }
                    }
                    MessageBox.Show(detalle, "Pago registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMonto.Clear();
                    // Recargar las tablas para que cambien los montos y los colores
                    _pagosTable = PagosFunciones.RegistroPagosPendientes();
                    CargarGrillas();
                }
                else
                    MessageBox.Show("Error al agregar historial.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void PagosPendientes_Load(object sender, EventArgs e)
        {
            try
            {
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar pagos pendientes: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtID.Clear();
            txtMonto.Clear();
            txtBuscarID.Clear();
            txtBuscar.Clear();
            DateBuscarFecha.Checked = false;
            DateBuscarFecha.Value = DateTime.Today;
            dtpVencimiento.Value = DateTime.Today;
            _pagosTable = PagosFunciones.RegistroPagosPendientes();
            CargarGrillas();
        }

        private void BttnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void BttnX_Click(object sender, EventArgs e) => Application.Exit();

        private void BttnRetroceder_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }
        private void HideAllNewRows()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is DataGridView dgv)
                    dgv.AllowUserToAddRows = false;
            }
        }
        private void CargarPendientes()
        {
            DGViewPagosPendientes.DataSource = PagosFunciones.RegistroPagosPendientes();
            DGViewPagosPendientes.ClearSelection();
        }
    }
}
