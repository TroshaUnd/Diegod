using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Stock : Form
    {
        // Flag para suspender temporalmente eventos de selección
        private bool _suspendSelectionEvents = false;

        public Stock()
        {
            InitializeComponent();
            txtId.ReadOnly = true;

            // Forzar selección de fila completa y desactivar multi-select
            DGViewStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewStock.MultiSelect = false;

            // Hookear eventos
            this.Load += Stock_Load;
            DGViewStock.CellClick += DGViewStock_CellClick;
            DGViewStock.SelectionChanged += DGViewStock_SelectionChanged;
            DGViewStock.DataBindingComplete += DGViewStock_DataBindingComplete;
        }

        private void Stock_Load(object sender, EventArgs e)
        {
            try
            {
                Cargar();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        private void DGViewStock_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Después de enlazar datos, quitar selección
            _suspendSelectionEvents = true;
            DGViewStock.ClearSelection();
            DGViewStock.CurrentCell = null;
            _suspendSelectionEvents = false;
        }

        private void LlenarCamposDesdeGrid(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= DGViewStock.Rows.Count) return;
            var row = DGViewStock.Rows[rowIndex];
            txtId.Text = row.Cells["ID"].Value?.ToString() ?? string.Empty;
            txtProducto.Text = row.Cells["Producto"].Value?.ToString() ?? string.Empty;
            txtLugar.Text = row.Cells["Lugar"].Value?.ToString() ?? string.Empty;
        }

        private void DGViewStock_SelectionChanged(object sender, EventArgs e)
        {
            if (_suspendSelectionEvents) return;
            if (DGViewStock.CurrentRow != null)
                LlenarCamposDesdeGrid(DGViewStock.CurrentRow.Index);
        }

        private void DGViewStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_suspendSelectionEvents) return;
            LlenarCamposDesdeGrid(e.RowIndex);
        }

        private void LimpiarCampos()
        {
            try
            {
                // Suspender eventos de selección
                _suspendSelectionEvents = true;

                txtId.Clear();
                txtProducto.Clear();
                txtLugar.Clear();
                txtBuscarID.Clear();
                txtBuscar.Clear();

                // Quitar cualquier selección
                DGViewStock.ClearSelection();
                DGViewStock.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al limpiar los campos: " + ex.Message);
            }
            finally
            {
                // Reactivar eventos de selección
                _suspendSelectionEvents = false;
            }
        }

        private void Cargar()
        {
            try
            {
                DGViewStock.DataSource = StockFunciones.RegistroStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar stock: " + ex.Message);
            }
        }

        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                StockPuente stock = new StockPuente
                {
                    Producto = txtProducto.Text,
                    Lugar = txtLugar.Text
                };

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    int resultado = StockFunciones.AgregarStock(stock);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto agregado con éxito.");
                        LimpiarCampos();
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar el producto.");
                    }
                }
                else
                {
                    stock.ID = int.Parse(txtId.Text);
                    int resultado = StockFunciones.ModificarStock(stock);
                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto modificado con éxito.");
                        LimpiarCampos();
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("Error al modificar el producto.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtBuscarID.Text.Trim();
                string producto = txtBuscar.Text.Trim();

                DGViewStock.DataSource = StockFunciones.BuscarStock(id, producto);
                // No llamar a Cargar aquí
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar producto: " + ex.Message);
            }
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            // Invertir orden para que LimpiarCampos quede después de Cargar
            Cargar();
            LimpiarCampos();
        }
    }
}