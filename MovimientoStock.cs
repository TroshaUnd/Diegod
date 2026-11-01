using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Diegod
{
    public partial class MovimientoStock : Form
    {
        public MovimientoStock()
        {
            InitializeComponent();
            Load += MovimientoStock_Load;

            // Stock grid events
            DGViewStock.DataBindingComplete += DGViewStock_DataBindingComplete;
            DGViewStock.SelectionChanged += DGViewStock_SelectionChanged;
            bttnBuscarStock.Click += bttnBuscarStock_Click;

            // Proveedores grid events
            DGViewProveedor.DataBindingComplete += DGViewProveedor_DataBindingComplete;
            DGViewProveedor.SelectionChanged += DGViewProveedor_SelectionChanged;
            bttnBuscarProveedor.Click += bttnBuscarProveedor_Click;

            // Movimientos grid events
            DGViewMovimientoStock.DataBindingComplete += DGViewMovimientoStock_DataBindingComplete;
            DGViewMovimientoStock.CurrentCellDirtyStateChanged += DGViewMovimientoStock_CurrentCellDirtyStateChanged;
            DGViewMovimientoStock.CellValueChanged += DGViewMovimientoStock_CellValueChanged;
            DGViewMovimientoStock.DataError += DGViewMovimientoStock_DataError;
            bttnBuscarMovimiento.Click += bttnBuscarMovimiento_Click;

            // Controls (cada evento se suscribe una sola vez)
            chkIngreso.CheckedChanged += chkIngresoEgreso_CheckedChanged;
            chkEgreso.CheckedChanged += chkIngresoEgreso_CheckedChanged;
            chkCambio.CheckedChanged += chkCambio_CheckedChanged;
            bttnLimpiar.Click += btnLimpiar_Click;

            // ============================================
            // NUEVO: Bloquear txtPrecioTotal y suscribir recálculo
            // ============================================
            txtPrecioTotal.ReadOnly = true;
            txtCantidad.TextChanged += RecalcularPrecioTotal;
            txtPrecioUnitario.TextChanged += RecalcularPrecioTotal;
        }

        private void MovimientoStock_Load(object sender, EventArgs e)
        {
            CargarMovimientosStock();
            CargarStockGrid();
            CargarProveedoresGrid();
            DGViewMovimientoStock.AllowUserToAddRows = false;
            DGViewStock.AllowUserToAddRows = false;
            DGViewProveedor.AllowUserToAddRows = false;

            LimpiarCampos(); // deja Ingreso marcado y actualiza los controles
        }

        private void bttnBuscarMovimiento_Click(object sender, EventArgs e)
        {
            DataTable resultados = null;

            // 1) Si pusieron algo en ID, buscamos por ID
            if (!string.IsNullOrWhiteSpace(txtBuscarMovimientoID.Text))
            {
                if (int.TryParse(txtBuscarMovimientoID.Text, out int id))
                    resultados = MovimientosStockFunciones.BuscarMovimientoPorID(id);
                else
                    MessageBox.Show("ID inválido");
            }
            // 2) sino, si pusieron algo en Stock_ID, buscamos por Stock
            else if (!string.IsNullOrWhiteSpace(txtBuscarMovimientoStock.Text))
            {
                if (int.TryParse(txtBuscarMovimientoStock.Text, out int sid))
                    resultados = MovimientosStockFunciones.BuscarMovimientosPorStockID(sid);
                else
                    MessageBox.Show("Stock ID inválido");
            }
            // 3) sino, si pusieron algo en Proveedor_ID
            else if (!string.IsNullOrWhiteSpace(txtBuscarMovimientoProveedor.Text))
            {
                if (int.TryParse(txtBuscarMovimientoProveedor.Text, out int pid))
                    resultados = MovimientosStockFunciones.BuscarMovimientosPorProveedorID(pid);
                else
                    MessageBox.Show("Proveedor ID inválido");
            }
            // 4) sino, si marcaron la fecha
            else if (DateBuscarFecha.Checked)
            {
                resultados = MovimientosStockFunciones.BuscarMovimientosPorFecha(DateBuscarFecha.Value);
            }
            // 5) sino, muestro todo
            else
            {
                resultados = MovimientosStockFunciones.RegistroMovimientosStock();
            }

            DGViewMovimientoStock.DataSource = resultados;
            DGViewMovimientoStock.ClearSelection();
        }

        private void DGViewMovimientoStock_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewMovimientoStock.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewMovimientoStock.Rows[e.RowIndex];
            // Evito procesar la fila “nueva” o celdas vacías
            if (row.IsNewRow) return;

            var cellValue = row.Cells["ID"].Value;
            if (cellValue == null || cellValue == DBNull.Value)
                return;

            int id = Convert.ToInt32(cellValue);
            bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);

            // Ahora sí anulo
            MovimientosStockFunciones.AnularMovimientoStock(id, anulado);

            // Y recargo
            CargarMovimientosStock();
        }

        private void ActualizarEstadoControles()
        {
            bool esIngreso = chkIngreso.Checked;
            bool esEgreso = chkEgreso.Checked;
            bool esCambio = chkCambio.Checked;

            // Destino: habilitado si es Egreso o Cambio
            txtDestino.Enabled = esEgreso || esCambio;
            if (!txtDestino.Enabled) txtDestino.Clear();

            // Proveedor: sólo en Ingreso puro
            bool proveedorActivo = esIngreso && !esCambio;
            DGViewProveedor.Enabled = proveedorActivo;
            txtProveedor.Enabled = proveedorActivo;
            txtProveedor.ReadOnly = false;
            if (!proveedorActivo) txtProveedor.Clear();

            // Precios: deshabilitados en Cambio
            txtPrecioUnitario.Enabled = !esCambio;
            txtPrecioTotal.Enabled = !esCambio;
            if (esCambio)
            {
                txtPrecioUnitario.Clear();
                txtPrecioTotal.Clear();
            }

            // Cantidad siempre habilitado
            txtCantidad.Enabled = true;
        }

        private bool _handlingToggle = false;

        private void chkIngresoEgreso_CheckedChanged(object sender, EventArgs e)
        {
            if (_handlingToggle) return;
            try
            {
                _handlingToggle = true;
                if (sender == chkIngreso && chkIngreso.Checked)
                    chkEgreso.Checked = false;
                else if (sender == chkEgreso && chkEgreso.Checked)
                    chkIngreso.Checked = false;

                // Evita que ambos queden desmarcados
                if (!chkIngreso.Checked && !chkEgreso.Checked)
                    ((CheckBox)sender).Checked = true;
            }
            finally { _handlingToggle = false; }

            ActualizarEstadoControles();
        }

        private void chkCambio_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarEstadoControles();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProducto.Text))
                {
                    MessageBox.Show("Seleccione un producto.");
                    return;
                }
                bool esCambio = chkCambio.Checked;
                if (!esCambio)
                {
                    if (chkIngreso.Checked && string.IsNullOrEmpty(txtProveedor.Text))
                    {
                        MessageBox.Show("Seleccione un proveedor para ingreso.");
                        return;
                    }
                    if (chkEgreso.Checked && string.IsNullOrWhiteSpace(txtDestino.Text))
                    {
                        MessageBox.Show("Ingrese destino para egreso.");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(txtCantidad.Text) || string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) || string.IsNullOrWhiteSpace(txtPrecioTotal.Text))
                    {
                        MessageBox.Show("Cantidad, Precio Unitario y Precio Total son obligatorios.");
                        return;
                    }
                }

                var mov = new MovimientoStockPuente
                {
                    StockID = int.Parse(txtProducto.Text),
                    ProveedorID = (!esCambio && chkIngreso.Checked) ? int.Parse(txtProveedor.Text) : (int?)null,
                    Destino = (!esCambio && chkEgreso.Checked) ? txtDestino.Text : null,
                    FechaMovimiento = dtpFechaMovimiento.Value,
                    TipoMovimiento = chkIngreso.Checked,
                    Cantidad = !string.IsNullOrWhiteSpace(txtCantidad.Text) ? int.Parse(txtCantidad.Text) : 0,
                    PrecioUnitario = !esCambio && !string.IsNullOrWhiteSpace(txtPrecioUnitario.Text) ? decimal.Parse(txtPrecioUnitario.Text) : 0,
                    // Calcular PrecioTotal automáticamente
                    PrecioTotal = !esCambio &&
                                  !string.IsNullOrWhiteSpace(txtCantidad.Text) &&
                                  !string.IsNullOrWhiteSpace(txtPrecioUnitario.Text)
                                  ? int.Parse(txtCantidad.Text) * decimal.Parse(txtPrecioUnitario.Text)
                                  : 0,
                    Cambio = esCambio
                };

                int res = MovimientosStockFunciones.AgregarMovimientoStock(mov);
                if (res > 0)
                {
                    MessageBox.Show("Movimiento agregado correctamente.");
                    CargarMovimientosStock();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar movimiento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CargarMovimientosStock()
        {
            DGViewMovimientoStock.DataSource = MovimientosStockFunciones.RegistroMovimientosStock();
        }

        private void CargarStockGrid()
        {
            DGViewStock.DataSource = MovimientosStockFunciones.ObtenerStock();
        }

        private void CargarProveedoresGrid()
        {
            DGViewProveedor.DataSource = MovimientosStockFunciones.RegistroProveedores();
        }

        private void bttnBuscarProveedor_Click(object sender, EventArgs e)
        {
            DGViewProveedor.DataSource = MovimientosStockFunciones.BuscarProveedores(txtBuscarProveedor.Text);
        }

        private void bttnBuscarStock_Click(object sender, EventArgs e)
        {
            DGViewStock.DataSource = MovimientosStockFunciones.BuscarStock(txtBuscarStock.Text);
        }

        private void DGViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if (DGViewStock.CurrentRow != null)
                txtProducto.Text = DGViewStock.CurrentRow.Cells["ID"].Value?.ToString();
        }

        private void DGViewProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (!chkIngreso.Checked) return;
            if (DGViewProveedor.CurrentRow != null)
                txtProveedor.Text = DGViewProveedor.CurrentRow.Cells["ID"].Value?.ToString();
        }

        private void DGViewProveedor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn col in DGViewProveedor.Columns)
                col.Visible = col.Name == "ID" || col.Name == "Nombre" || col.Name == "Apellido" || col.Name == "Empresa";
            DGViewProveedor.ClearSelection();
        }

        private void btnBuscarStock_Click(object sender, EventArgs e)
        {
            string producto = txtBuscarStock.Text.Trim();
            DGViewStock.DataSource = StockFunciones.BuscarStock(null, producto);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            CargarMovimientosStock();
            CargarStockGrid();
            CargarProveedoresGrid();
            ActualizarEstadoControles();
        }

        private void DGViewMovimientoStock_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGViewMovimientoStock.Columns[e.ColumnIndex].Name == "Anulado")
                DGViewMovimientoStock.EndEdit();
        }

        private void DGViewMovimientoStock_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewMovimientoStock.IsCurrentCellDirty && DGViewMovimientoStock.CurrentCell.OwningColumn.Name == "Anulado")
                DGViewMovimientoStock.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewMovimientoStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (DGViewMovimientoStock.Columns.Contains("Anulado"))
                DGViewMovimientoStock.Columns["Anulado"].DisplayIndex = 0;

            foreach (DataGridViewRow row in DGViewMovimientoStock.Rows)
            {
                if (row.IsNewRow) continue;
                bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);
                row.DefaultCellStyle.BackColor = anulado ? Color.LightGray : Color.Gold;
            }
            DGViewMovimientoStock.ClearSelection();
        }

        private void DGViewStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewStock.ClearSelection();
        }

        private void DGViewMovimientoStock_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            e.Cancel = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Menu frmMenu = new Menu();
            this.Hide();
            frmMenu.Show();
        }

        private void MovimientoStock_Load_1(object sender, EventArgs e)
        {
            // Si tu diseñador tiene este método vacío, puedes dejarlo así.
        }

        /// <summary>
        /// Recalcula el valor de txtPrecioTotal = txtCantidad * txtPrecioUnitario.
        /// </summary>
        private void RecalcularPrecioTotal(object sender, EventArgs e)
        {
            // Intentar convertir cantidad a entero
            if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad))
            {
                txtPrecioTotal.Text = string.Empty;
                return;
            }

            // Intentar convertir precio unitario a decimal
            if (!decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precioUnitario))
            {
                txtPrecioTotal.Text = string.Empty;
                return;
            }

            // Calcular y mostrar resultado
            decimal total = cantidad * precioUnitario;
            txtPrecioTotal.Text = total.ToString("0.##");
        }
        private void LimpiarCampos()
        {
            txtProducto.Clear();
            txtBuscarStock.Clear();
            txtBuscarProveedor.Clear();
            txtBuscarMovimientoID.Clear();
            txtBuscarMovimientoStock.Clear();
            txtBuscarMovimientoProveedor.Clear();
            txtProveedor.Clear();
            txtDestino.Clear();
            dtpFechaMovimiento.Value = DateTime.Now;
            chkIngreso.Checked = true;
            chkEgreso.Checked = false;
            chkCambio.Checked = false;
            txtCantidad.Clear();
            txtPrecioUnitario.Clear();
            txtPrecioTotal.Clear();

            // Sólo limpio selección y estado de controles:
            DGViewMovimientoStock.ClearSelection();
            DGViewStock.ClearSelection();
            DGViewProveedor.ClearSelection();
            ActualizarEstadoControles();
        }
    }
}
