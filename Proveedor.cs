using System.Data;
using Diegod.Datos;

namespace Diegod
{
    public partial class Proveedor : Form
    {
        private const string PlaceholderBuscarID = "ID";
        private const string PlaceholderBuscarNombre = "Nombre y Apellido";
        private bool suppressSelection = false;

        public Proveedor()
        {
            InitializeComponent();
            Ayudas.Configurar(this);
            txtId.ReadOnly = true;

            // Suscripciones
            ComboxProvincia.SelectedIndexChanged += ComboxProvincia_SelectedIndexChanged;
            DGViewProveedor.DataBindingComplete += DGViewProveedor_DataBindingComplete;

            // Estado inicial limpio
            ComboxProvincia.SelectedIndex = -1;
            ComboxLocalidad.Items.Clear();
            ComboxLocalidad.SelectedIndex = -1;
            ComboxLocalidad.Text = string.Empty;
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {
            try
            {
                suppressSelection = true; // evitar que el SelectionChanged reaccione mientras cargo datos
                CargarProvincias();
                DGViewProveedor.DataSource = ProveedoresFunciones.RegistroProveedor();
                LimpiarCampos();

                var fuente8 = new Font(DGViewProveedor.Font.FontFamily, 8f);
                DGViewProveedor.DefaultCellStyle.Font = fuente8;

                DGViewProveedor.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
            finally
            {
                suppressSelection = false;
            }
        }

        private void DGViewProveedor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewProveedor.ClearSelection();
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            // evitar que SelectionChanged vuelva a poblar los controles mientras limpio
            suppressSelection = true;
            LimpiarCampos();
            DGViewProveedor.DataSource = ProveedoresFunciones.RegistroProveedor();
            DGViewProveedor.ClearSelection();
            suppressSelection = false;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmpresa.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtObservacion.Clear();
            txtBuscarID.Clear();
            txtBuscar.Clear();

            // limpiar por completo los combos
            ComboxProvincia.SelectedIndex = -1;
            ComboxLocalidad.Items.Clear();
            ComboxLocalidad.SelectedIndex = -1;
            ComboxLocalidad.Text = string.Empty;
        }

        private void CargarProvincias()
        {
            string query = "SELECT id, provincia FROM Provincias";
            using (SqlConnection conexion = BaseDatos.ObtenerConexion())
            using (var command = new SqlCommand(query, conexion))
            using (var reader = command.ExecuteReader())
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
            using (var command = new SqlCommand(query, conexion))
            {
                command.Parameters.AddWithValue("@id_provincia", provinciaId);
                using (var reader = command.ExecuteReader())
                {
                    ComboxLocalidad.Items.Clear();
                    while (reader.Read())
                        ComboxLocalidad.Items.Add(new KeyValuePair<int, string>(reader.GetInt32(0), reader.GetString(1)));
                }
            }
            ComboxLocalidad.DisplayMember = "Value";
            ComboxLocalidad.ValueMember = "Key";
            // no tocamos SelectedIndex aquí: lo maneja quien llame a CargarCiudades
        }

        private void DGViewProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (suppressSelection) return;
            if (DGViewProveedor.CurrentRow == null)
            {
                // si no hay fila seleccionada, dejar todo limpio
                LimpiarCampos();
                return;
            }

            suppressSelection = true; // prevenir efectos colaterales mientras actualizamos los combos
            try
            {
                var row = DGViewProveedor.CurrentRow;

                txtId.Text = row.Cells["ID"].Value?.ToString();
                txtNombre.Text = row.Cells["Nombre"].Value?.ToString();
                txtApellido.Text = row.Cells["Apellido"].Value?.ToString();
                txtEmpresa.Text = row.Cells["Empresa"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtTelefono.Text = row.Cells["Telefono"].Value?.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value?.ToString();
                txtObservacion.Text = row.Cells["Observaciones"].Value?.ToString();

                string provincia = row.Cells["Provincia"].Value?.ToString();
                string localidad = row.Cells["Localidad"].Value?.ToString();

                // seleccionar provincia por texto (si existe en el combo)
                int idxProv = ComboxProvincia.Items.Cast<KeyValuePair<int, string>>()
                    .ToList().FindIndex(x => x.Value == provincia);
                ComboxProvincia.SelectedIndex = idxProv;

                if (idxProv >= 0)
                {
                    // Asegurarse que las localidades estén cargadas para esa provincia
                    var selProv = (KeyValuePair<int, string>)ComboxProvincia.Items[idxProv];
                    CargarCiudades(selProv.Key);

                    // seleccionar localidad si existe en la lista recién cargada
                    int idxLoc = ComboxLocalidad.Items.Cast<KeyValuePair<int, string>>()
                        .ToList().FindIndex(x => x.Value == localidad);
                    if (idxLoc >= 0)
                    {
                        ComboxLocalidad.SelectedIndex = idxLoc;
                    }
                    else
                    {
                        // NO hay localidad para la fila: mantener la lista pero sin selección y sin texto
                        ComboxLocalidad.SelectedIndex = -1;
                        ComboxLocalidad.Text = string.Empty;
                    }
                }
                else
                {
                    // no hay provincia para la fila: limpiar localidades por completo
                    ComboxLocalidad.Items.Clear();
                    ComboxLocalidad.SelectedIndex = -1;
                    ComboxLocalidad.Text = string.Empty;
                }
            }
            finally
            {
                suppressSelection = false;
            }
        }

        private void ComboxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboxProvincia.SelectedItem is KeyValuePair<int, string> kv)
            {
                CargarCiudades(kv.Key);
                // arrancar sin selección de localidad al cambiar provincia
                ComboxLocalidad.SelectedIndex = -1;
                ComboxLocalidad.Text = string.Empty;
            }
            else
            {
                ComboxLocalidad.Items.Clear();
                ComboxLocalidad.SelectedIndex = -1;
                ComboxLocalidad.Text = string.Empty;
            }
        }

        private void SelectComboByValue(ComboBox combo, string text)
        {
            if (string.IsNullOrEmpty(text)) return;
            for (int i = 0; i < combo.Items.Count; i++)
            {
                var kv = (KeyValuePair<int, string>)combo.Items[i];
                if (kv.Value == text)
                {
                    combo.SelectedIndex = i;
                    break;
                }
            }
        }

        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("Debe ingresar Nombre y Apellido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("Debe ingresar la Empresa obligatoriamente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpresa.Focus();
                return;
            }

            ProveedorPuente puente = new ProveedorPuente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Empresa = txtEmpresa.Text,
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text,
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text,
                Direccion = string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text,
                Observaciones = string.IsNullOrWhiteSpace(txtObservacion.Text) ? null : txtObservacion.Text
            };

            if (ComboxLocalidad.SelectedItem is KeyValuePair<int, string> loc)
            {
                puente.Localidad_ID = loc.Key;
            }
            else
            {
                MessageBox.Show("Seleccione una localidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtId.Text))
            {
                int result = ProveedoresFunciones.AgregarProveedor(puente);
                if (result > 0)
                {
                    MessageBox.Show("Proveedor agregado con éxito.");
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al agregar el proveedor.");
                }
            }
            else if (int.TryParse(txtId.Text, out int id))
            {
                puente.ID = id;
                int result = ProveedoresFunciones.ModificarProveedor(puente);
                MessageBox.Show(result > 0 ? "Proveedor modificado con éxito." : "Error al modificar el proveedor.");
                LimpiarCampos();
            }

            DGViewProveedor.DataSource = ProveedoresFunciones.RegistroProveedor();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = txtBuscarID.Text.Trim();
            string texto = txtBuscar.Text.Trim();
            DGViewProveedor.DataSource = ProveedoresFunciones.BuscarProveedor(id, texto);
            DGViewProveedor.ClearSelection();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            DGViewProveedor.DataSource = ProveedoresFunciones.RegistroProveedor();
        }

        private void btnSalir_Click(object sender, EventArgs e) => Application.Exit();
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }
    }
}

