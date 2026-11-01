using System;
using System.Data;
using Diegod.Datos;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Vehiculo : Form
    {
        public Vehiculo()
        {
            InitializeComponent();
            Ayudas.Configurar(this);
            txtId.ReadOnly = true;

            // Desactivar fila vacía
            DGViewVehiculos.AllowUserToAddRows = false;

            // Suscribir eventos
            Load += Vehiculo_Load;
            DGViewVehiculos.CellContentClick += dgvVehiculos_CellContentClick;
            DGViewVehiculos.CurrentCellDirtyStateChanged += dgvVehiculos_CurrentCellDirtyStateChanged;
            DGViewVehiculos.CellValueChanged += dgvVehiculos_CellValueChanged;
            DGViewVehiculos.SelectionChanged += dgvVehiculos_SelectionChanged;
        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {
            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            var lista = VehiculosFunciones.RegistroVehiculo();
            DGViewVehiculos.DataSource = lista;
            DGViewVehiculos.AllowUserToAddRows = false;

            // Configurar Activo
            if (DGViewVehiculos.Columns.Contains("Activo"))
            {
                var col = DGViewVehiculos.Columns["Activo"];
                col.DisplayIndex = 0;
                col.ReadOnly = false;
                DGViewVehiculos.Columns["Activo"].CellTemplate = new DataGridViewCheckBoxCell();
            }

            // Aplicar color inicial
            foreach (DataGridViewRow row in DGViewVehiculos.Rows)
            {
                if (row.IsNewRow) continue;

                var val = row.Cells["Activo"].Value;
                if (val != null && bool.TryParse(val.ToString(), out bool activo))
                    row.DefaultCellStyle.BackColor = activo ? Color.Gold : Color.Gray;
            }

            DGViewVehiculos.ClearSelection();
            LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtBuscarID.Text.Trim();
            string nombre = txtBuscar.Text.Trim();
            string patente = txtBuscarPatente.Text.Trim();

            DGViewVehiculos.DataSource = VehiculosFunciones.BuscarVehiculo(id, nombre, patente);
            DGViewVehiculos.AllowUserToAddRows = false;

            if (DGViewVehiculos.Columns.Contains("Activo"))
                DGViewVehiculos.Columns["Activo"].DisplayIndex = 0;

            DGViewVehiculos.ClearSelection();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarID.Clear();
            txtBuscar.Clear();
            txtBuscarPatente.Clear();
            RefrescarGrid();
            DGViewVehiculos.ClearSelection();
            LimpiarCampos();
        }

        private void dgvVehiculos_SelectionChanged(object sender, EventArgs e)
        {
            if (DGViewVehiculos.CurrentRow == null || DGViewVehiculos.CurrentRow.IsNewRow)
                return;

            var cells = DGViewVehiculos.CurrentRow.Cells;

            txtId.Text = cells["ID"].Value?.ToString() ?? string.Empty;
            txtNombre.Text = cells["Nombre"].Value?.ToString() ?? string.Empty;
            txtPatente.Text = cells["Patente"].Value?.ToString() ?? string.Empty;
            txtObservacion.Text = cells["Observacion"].Value?.ToString() ?? string.Empty;

            var actVal = cells["Activo"].Value;
            chkActivo.Checked = actVal != null && bool.TryParse(actVal.ToString(), out bool act) && act;

            var fechaVal = cells["Fecha_UltimoServicio"].Value;
            if (fechaVal != null && DateTime.TryParse(fechaVal.ToString(), out DateTime fs))
                DateFechaUltimoServicio.Value = fs;
        }

        private void dgvVehiculos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGViewVehiculos.Columns[e.ColumnIndex].Name == "Activo" && e.RowIndex >= 0)
                DGViewVehiculos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvVehiculos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewVehiculos.IsCurrentCellDirty && DGViewVehiculos.CurrentCell.OwningColumn.Name == "Activo")
                DGViewVehiculos.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void dgvVehiculos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewVehiculos.Columns[e.ColumnIndex].Name != "Activo") return;

            var row = DGViewVehiculos.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (int.TryParse(row.Cells["ID"].Value?.ToString(), out int id) &&
                bool.TryParse(row.Cells["Activo"].Value?.ToString(), out bool nuevo))
            {
                VehiculosFunciones.ActualizarActivoVehiculo(id, nuevo);
                row.DefaultCellStyle.BackColor = nuevo ? Color.Green : Color.LightGray;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtPatente.Clear();
            txtObservacion.Clear();
            chkActivo.Checked = true;
            DateFechaUltimoServicio.Value = DateTime.Now;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text)){
                    MessageBox.Show("El nombre es obligatorio.", "Falta un dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPatente.Text)){
                    MessageBox.Show("La patente es obligatoria.", "Falta un dato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPatente.Focus();
                    return;
                }
                var vehiculo = new VehiculosPuente
                {
                    Nombre = txtNombre.Text,
                    Patente = txtPatente.Text,
                    Fecha_UltimoServicio = DateFechaUltimoServicio.Value,
                    Observacion = txtObservacion.Text,
                    Activo = chkActivo.Checked
                };

                if (string.IsNullOrEmpty(txtId.Text))
                {
                    if (VehiculosFunciones.AgregarVehiculo(vehiculo) > 0)
                        MessageBox.Show("Vehículo agregado con éxito.");
                    else
                        MessageBox.Show("Error al agregar el vehículo.");
                }
                else if (int.TryParse(txtId.Text, out int id))
                {
                    vehiculo.ID = id;
                    if (VehiculosFunciones.ModificarVehiculo(vehiculo) > 0)
                        MessageBox.Show("Vehículo modificado con éxito.");
                    else
                        MessageBox.Show("Error al modificar el vehículo.");
                }
                else
                    MessageBox.Show("ID inválido.");

                LimpiarCampos();
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Application.Exit();

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }
        private void DGViewVehiculo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGViewVehiculos.Columns.Contains("Activo") && e.RowIndex >= 0 && e.RowIndex < DGViewVehiculos.Rows.Count)
            {
                var row = DGViewVehiculos.Rows[e.RowIndex];

                if (row.Cells["Activo"].Value != null &&
                    bool.TryParse(row.Cells["Activo"].Value.ToString(), out bool activo))
                {
                    row.DefaultCellStyle.BackColor = activo ? Color.Gold : Color.Gray;
                }
            }
        }
    }
}