// Prestamista.cs
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Prestamista : Form
    {
        // Flag para suspender el llenado de campos durante Cargar/Limpiar
        private bool _suspendSelection = false;

        public Prestamista()
        {
            InitializeComponent();
            Ayudas.Configurar(this);

            txtId.ReadOnly = true;

            // Eventos del formulario
            this.Load += Prestamista_Load;
            DGViewPrestamistas.DataBindingComplete += DGViewPrestamistas_DataBindingComplete;

            // Botones
        }
        private const string PlaceholderBuscarID = "ID";
        private const string PlaceholderBuscarNombre = "Nombre y Apellido";
        private bool suppressSelection = false;
        private void Prestamista_Load(object sender, EventArgs e)
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

        private void DGViewPrestamistas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Siempre quitamos selección tras bind
            DGViewPrestamistas.ClearSelection();
            DGViewPrestamistas.CurrentCell = null;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtEmpresa.Clear();
            txtObservacion.Clear();
            txtBuscar.Clear();
            txtBuscarID.Clear();
        }

        private void Cargar()
        {
            try
            {
                _suspendSelection = true;               // suspendemos SelectionChanged
                DGViewPrestamistas.DataSource = PrestamistaFunciones.RegistroPrestamista();
                DGViewPrestamistas.ClearSelection();
                DGViewPrestamistas.CurrentCell = null;
            }
            finally
            {
                _suspendSelection = false;              // reactivamos SelectionChanged
            }
        }

        private void DGViewPrestamistas_SelectionChanged(object sender, EventArgs e)
        {
            if (_suspendSelection)
                return;

            // Si no hay celdas seleccionadas, no hacemos nada
            if (DGViewPrestamistas.SelectedCells.Count == 0 || DGViewPrestamistas.CurrentRow == null)
                return;

            try
            {
                var row = DGViewPrestamistas.CurrentRow;
                txtId.Text = row.Cells["ID"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value is DBNull ? "" : row.Cells["Email"].Value.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value is DBNull ? "" : row.Cells["Telefono"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value is DBNull ? "" : row.Cells["Direccion"].Value.ToString();
                txtEmpresa.Text = row.Cells["Empresa"].Value is DBNull ? "" : row.Cells["Empresa"].Value.ToString();
                txtObservacion.Text = row.Cells["Observacion"].Value is DBNull ? "" : row.Cells["Observacion"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar prestamista: " + ex.Message);
            }
        }

        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)){
                    MessageBox.Show("El nombre es obligatorio.", "Falta un dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtApellido.Text)){
                    MessageBox.Show("El apellido es obligatorio.", "Falta un dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApellido.Focus();
                    return;
                }
                var prestamista = new PrestamistaPuente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Empresa = txtEmpresa.Text,
                    Observacion = txtObservacion.Text
                };

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    int res = PrestamistaFunciones.AgregarPrestamista(prestamista);
                    if (res > 0)
                    {
                        MessageBox.Show("Prestamista agregado con éxito.");
                        LimpiarCampos();
                        Cargar();
                    }
                    else
                        MessageBox.Show("Error al agregar el prestamista.");
                }
                else
                {
                    prestamista.ID = int.Parse(txtId.Text);
                    int res = PrestamistaFunciones.ModificarPrestamista(prestamista);
                    if (res > 0)
                    {
                        MessageBox.Show("Prestamista modificado con éxito.");
                        LimpiarCampos();
                        Cargar();
                    }
                    else
                        MessageBox.Show("Error al modificar el prestamista.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _suspendSelection = true;   // suspendemos selección al rebind
                if (!string.IsNullOrWhiteSpace(txtBuscarID.Text))
                {
                    if (int.TryParse(txtBuscarID.Text.Trim(), out int id))
                        DGViewPrestamistas.DataSource = PrestamistaFunciones.BuscarPrestamistaPorID(id);
                    else
                        MessageBox.Show("El ID debe ser un número válido.");
                }
                else if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    DGViewPrestamistas.DataSource =
                        PrestamistaFunciones.BuscarPrestamistaPorNombreApellido(txtBuscar.Text.Trim());
                }
                else
                {
                    DGViewPrestamistas.DataSource = PrestamistaFunciones.RegistroPrestamista();
                }

                DGViewPrestamistas.ClearSelection();
                DGViewPrestamistas.CurrentCell = null;
            }
            finally
            {
                _suspendSelection = false;
            }
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            Cargar();  // Cargar ya maneja el suspend flag
        }
        private void btnVolver_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }

        private void bttnSalir_Click(object sender, EventArgs e) => Application.Exit();
 
    }
}
