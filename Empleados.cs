using System;
using System.Data;
using Diegod.Datos;
using System.Linq;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Empleados : Form
    {
        public Empleados()
        {
            InitializeComponent();
            Ayudas.Configurar(this);
            txtId.ReadOnly = true;

            // Desactivar fila vacía
            DGViewEmpleado.AllowUserToAddRows = false;

            // Suscribir eventos
            Load += Empleados_Load;
            bttnLimpiar.Click += bttnLimpiar_Click;
            DGViewEmpleado.CellContentClick += DGViewEmpleado_CellContentClick;
            DGViewEmpleado.CurrentCellDirtyStateChanged += DGViewEmpleado_CurrentCellDirtyStateChanged;
            DGViewEmpleado.CellValueChanged += DGViewEmpleado_CellValueChanged;
            DGViewEmpleado.SelectionChanged += DGViewEmpleado_SelectionChanged;
            ComboxProvincia.SelectedIndexChanged += ComboxProvincia_SelectedIndexChanged;
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            RefrescarGrid();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtCargo.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtObservacion.Clear();

            chkActivo.Checked = true;
            DateContratacion.Value = DateTime.Now;
            DateNacimiento.Value = DateTime.Now;

            ComboxProvincia.SelectedIndex = -1;

            ComboxLocalidad.Items.Clear();
            ComboxLocalidad.SelectedIndex = -1;
            ComboxLocalidad.Text = string.Empty; // 👈 esto evita que quede el último valor
        }

        private void RefrescarGrid()
        {
            var lista = EmpleadosFunciones.RegistroEmpleado();
            DGViewEmpleado.DataSource = lista;
            DGViewEmpleado.AllowUserToAddRows = false;

            // Configurar columna Activo editable
            if (DGViewEmpleado.Columns.Contains("Activo"))
            {
                var col = DGViewEmpleado.Columns["Activo"];
                col.DisplayIndex = 0;
                col.ReadOnly = false;
                DGViewEmpleado.Columns["Activo"].CellTemplate = new DataGridViewCheckBoxCell();
            }

            // Aplicar color inicial
            foreach (DataGridViewRow row in DGViewEmpleado.Rows)
            {
                if (row.IsNewRow) continue;
                var val = row.Cells["Activo"].Value;
                if (val != null && bool.TryParse(val.ToString(), out bool activo))
                    row.DefaultCellStyle.BackColor = activo ? Color.Gold : Color.Gray;
            }

            DGViewEmpleado.ClearSelection();
            LimpiarCampos();
        }

        private void DGViewEmpleado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !DGViewEmpleado.Columns.Contains("Activo"))
                return;

            var row = DGViewEmpleado.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            var val = row.Cells["Activo"].Value;
            if (val != null && bool.TryParse(val.ToString(), out bool activo))
                row.DefaultCellStyle.BackColor = activo ? Color.Gold : Color.Gray;
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtBuscarID.Text.Trim();
            string nom = txtBuscar.Text.Trim();
            DGViewEmpleado.DataSource = EmpleadosFunciones.BuscarEmpleado(id, nom);
            DGViewEmpleado.AllowUserToAddRows = false;

            if (DGViewEmpleado.Columns.Contains("Activo"))
                DGViewEmpleado.Columns["Activo"].DisplayIndex = 0;

            DGViewEmpleado.ClearSelection();
            LimpiarCampos();
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarID.Clear();
            txtBuscar.Clear();
            RefrescarGrid();
        }

        private void DGViewEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            if (DGViewEmpleado.CurrentRow == null || DGViewEmpleado.CurrentRow.IsNewRow)
                return;
            var cells = DGViewEmpleado.CurrentRow.Cells;
            txtId.Text = cells["ID"].Value?.ToString() ?? string.Empty;
            txtNombre.Text = cells["Nombre"].Value?.ToString() ?? string.Empty;
            txtApellido.Text = cells["Apellido"].Value?.ToString() ?? string.Empty;
            txtEmail.Text = cells["Email"].Value?.ToString() ?? string.Empty;
            txtCargo.Text = cells["Cargo"].Value?.ToString() ?? string.Empty;
            txtDni.Text = cells["Dni"].Value?.ToString() ?? string.Empty;
            txtTelefono.Text = cells["Telefono"].Value?.ToString() ?? string.Empty;
            txtDireccion.Text = cells["Direccion"].Value?.ToString() ?? string.Empty;
            txtObservacion.Text = cells["Observacion"].Value?.ToString() ?? string.Empty;

            var actVal = cells["Activo"].Value;
            chkActivo.Checked = actVal != null && bool.TryParse(actVal.ToString(), out bool act) && act;

            if (DateTime.TryParse(cells["Fecha_Contratacion"].Value?.ToString(), out DateTime fc))
                DateContratacion.Value = fc;
            if (DateTime.TryParse(cells["Nacimiento"].Value?.ToString(), out DateTime fn))
                DateNacimiento.Value = fn;

            // Cargar selección de provincia/localidad
            string prov = cells["Provincia"].Value?.ToString();
            string loc = cells["Localidad"].Value?.ToString();
            int idxProv = ComboxProvincia.Items.Cast<KeyValuePair<int, string>>()
                .ToList().FindIndex(x => x.Value == prov);
            ComboxProvincia.SelectedIndex = idxProv;
            if (idxProv >= 0)
            {
                CargarCiudades(((KeyValuePair<int, string>)ComboxProvincia.Items[idxProv]).Key);
                int idxLoc = ComboxLocalidad.Items.Cast<KeyValuePair<int, string>>()
                    .ToList().FindIndex(x => x.Value == loc);
                ComboxLocalidad.SelectedIndex = idxLoc;
            }
        }

        private void DGViewEmpleado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGViewEmpleado.Columns[e.ColumnIndex].Name == "Activo" && e.RowIndex >= 0)
                DGViewEmpleado.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewEmpleado_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewEmpleado.IsCurrentCellDirty && DGViewEmpleado.CurrentCell.OwningColumn.Name == "Activo")
                DGViewEmpleado.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewEmpleado_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewEmpleado.Columns[e.ColumnIndex].Name != "Activo") return;
            var row = DGViewEmpleado.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            if (int.TryParse(row.Cells["ID"].Value?.ToString(), out int id) &&
                bool.TryParse(row.Cells["Activo"].Value?.ToString(), out bool nuevo))
            {
                EmpleadosFunciones.ActualizarActivo(id, nuevo);
                row.DefaultCellStyle.BackColor = nuevo ? Color.Gold : Color.Gray;
            }
        }
        private void SetupActivoColumn()
        {
            if (DGViewEmpleado.Columns.Contains("Activo"))
            {
                var col = DGViewEmpleado.Columns["Activo"] as DataGridViewCheckBoxColumn;
                if (col == null)
                {
                    col = new DataGridViewCheckBoxColumn
                    {
                        Name = "Activo",
                        HeaderText = "Activo",
                        DataPropertyName = "Activo",
                        TrueValue = true,
                        FalseValue = false
                    };
                    DGViewEmpleado.Columns.Insert(0, col);
                }
                col.DisplayIndex = 0;
                col.ReadOnly = false;
                DGViewEmpleado.Columns["Activo"].CellTemplate = new DataGridViewCheckBoxCell();
            }
        }
        private void CargarProvincias()
        {
            string query = "SELECT id, provincia FROM Provincias";
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                ComboxProvincia.Items.Clear();
                while (reader.Read())
                    ComboxProvincia.Items.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                ComboxProvincia.DisplayMember = "Value";
                ComboxProvincia.ValueMember = "Key";
            }
        }
        private void CargarCiudades(int provinciaId)
        {
            string query = "SELECT Localidad_ID, localidad FROM Localidades WHERE id_provincia = @id_provincia";
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@id_provincia", provinciaId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ComboxLocalidad.Items.Clear();
                    while (reader.Read())
                        ComboxLocalidad.Items.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            ComboxLocalidad.DisplayMember = "Value";
            ComboxLocalidad.ValueMember = "Key";
        }
        private void ComboxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboxProvincia.SelectedItem is KeyValuePair<int, string> kv)
                CargarCiudades(kv.Key);
            else
                ComboxLocalidad.Items.Clear();
        }
        private void DGViewEmpleado_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewEmpleado.ClearSelection();
        }
        private void bttnModyAgr_Click(object sender, EventArgs e)
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
                if (ComboxProvincia.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una provincia.");
                    return;
                }
                if (ComboxLocalidad.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una localidad.");
                    return;
                }
                var puente = new EmpleadosPuente
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text,
                    Cargo = txtCargo.Text,
                    Fecha_Contratacion = DateContratacion.Value,
                    Nacimiento = DateNacimiento.Value,
                    Dni = txtDni.Text,
                    Direccion = txtDireccion.Text,
                    Activo = chkActivo.Checked,
                    Observacion = txtObservacion.Text,
                    Localidad_ID = ((KeyValuePair<int, string>)ComboxLocalidad.SelectedItem).Key
                };
                if (string.IsNullOrEmpty(txtId.Text))
                {
                    if (EmpleadosFunciones.AgregarEmpleado(puente) > 0)
                        MessageBox.Show("Empleado agregado con éxito.");
                    else
                        MessageBox.Show("Error al agregar el empleado.");
                }
                else if (int.TryParse(txtId.Text, out int id))
                {
                    puente.ID = id;
                    if (EmpleadosFunciones.ModificarEmpleado(puente) > 0)
                        MessageBox.Show("Empleado modificado con éxito.");
                    else
                        MessageBox.Show("Error al modificar el empleado.");
                }
                else
                    MessageBox.Show("ID inválido. No se puede modificar el empleado.");
                RefrescarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }
        private void BttnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarID.Clear();
            txtBuscar.Clear();
            RefrescarGrid();
        }
        private void BttnX_Click(object sender, EventArgs e) => Application.Exit();
        private void BttnRetroceder_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }

        private void ComboxLocalidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
