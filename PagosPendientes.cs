using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Diegod
{
    public partial class PagosPendientes : Form
    {
        private DataTable _pagosTable;

        public PagosPendientes()
        {
            InitializeComponent();

            // 1) Obtener la tabla completa sólo una vez
            _pagosTable = PagosFunciones.RegistroPagosPendientes();

            // 2) Configurar DGViewPagosPendientes (Cobrar)
            DGViewPagosPendientes.AllowUserToAddRows = false;
            DGViewPagosPendientes.AutoGenerateColumns = true;
            DGViewPagosPendientes.SelectionChanged += DGViewPagosPendientes_SelectionChanged;
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
            var row = DGViewPagosPendientes.Rows[e.RowIndex];

            // Gris si anulado
            if (row.Cells["Anulado"].Value is bool an && an)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                return;
            }

            // Verde si Pagado >= Deuda
            try
            {
                string dStr = row.Cells["Deuda"].Value?.ToString().Replace("$", "").Trim() ?? "0";
                string pStr = row.Cells["Pagado"].Value?.ToString().Replace("$", "").Trim() ?? "0";
                dStr = dStr.Replace(".", "").Replace(",", ".");
                pStr = pStr.Replace(".", "").Replace(",", ".");
                decimal deuda = decimal.Parse(dStr, CultureInfo.InvariantCulture);
                decimal pagado = decimal.Parse(pStr, CultureInfo.InvariantCulture);

                if (pagado >= deuda)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    return;
                }
            }
            catch { }

            // Dorado por defecto
            row.DefaultCellStyle.BackColor = Color.Gold;
        }

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
            var row = DGViewPagosPagar.Rows[e.RowIndex];

            // Gris si anulado
            if (row.Cells["Anulado"].Value is bool an && an)
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
                return;
            }

            // Verde si Pagado >= Deuda
            try
            {
                string dStr = row.Cells["Deuda"].Value?.ToString().Replace("$", "").Trim() ?? "0";
                string pStr = row.Cells["Pagado"].Value?.ToString().Replace("$", "").Trim() ?? "0";
                dStr = dStr.Replace(".", "").Replace(",", ".");
                pStr = pStr.Replace(".", "").Replace(",", ".");
                decimal deuda = decimal.Parse(dStr, CultureInfo.InvariantCulture);
                decimal pagado = decimal.Parse(pStr, CultureInfo.InvariantCulture);

                if (pagado >= deuda)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    return;
                }
            }
            catch { }

            // Dorado por defecto
            row.DefaultCellStyle.BackColor = Color.Gold;
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
                if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
                {
                    MessageBox.Show("Monto inválido.");
                    return;
                }
                DateTime fechaPago = DateFechaPago.Value;
                if (PagosFunciones.AgregarHistorial(pagoID, fechaPago, monto) > 0)
                    MessageBox.Show("Registro de historial agregado.");
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
            new Menu().Show();
            this.Hide();
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
