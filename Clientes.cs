using System.Data;
using Diegod.Datos;


namespace Diegod
{
    public partial class Clientes : Form
    {
        private const string PlaceholderBuscarID = "ID";
        private const string PlaceholderBuscarNombre = "Nombre y Apellido";
        private bool suppressSelection = false;

        public Clientes()
        {
            InitializeComponent();
            txtId.ReadOnly = true;

            // Placeholders
            ApplyPlaceholder(txtBuscarID, PlaceholderBuscarID);
            ApplyPlaceholder(txtBuscar, PlaceholderBuscarNombre);
            txtBuscarID.GotFocus += (s, e) => RemovePlaceholder(txtBuscarID, PlaceholderBuscarID);
            txtBuscarID.LostFocus += (s, e) => ApplyPlaceholder(txtBuscarID, PlaceholderBuscarID);
            txtBuscar.GotFocus += (s, e) => RemovePlaceholder(txtBuscar, PlaceholderBuscarNombre);
            txtBuscar.LostFocus += (s, e) => ApplyPlaceholder(txtBuscar, PlaceholderBuscarNombre);

            // Suscribir eventos
            Load += Clientes_Load;
            bttnBuscar.Click += bttnBuscar_Click;
            bttnLimpiar.Click += bttnLimpiar_Click;
            DGViewCliente.SelectionChanged += DGViewCliente_SelectionChanged;
            ComboxProvincia.SelectedIndexChanged += ComboxProvincia_SelectedIndexChanged;
            bttnModyAgr.Click += bttnModyAgr_Click;
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            CargarProvincias();
            RefrescarGrid();
        }

        private void RefrescarGrid()
        {
            suppressSelection = true;
            var dt = ClientesFunciones.RegistroClientes();
            DGViewCliente.DataSource = dt;

            // Ocultar columna Localidad_ID si existe
            if (DGViewCliente.Columns.Contains("Localidad_ID"))
                DGViewCliente.Columns["Localidad_ID"].Visible = false;

            DGViewCliente.ClearSelection();
            LimpiarCampos();
            suppressSelection = false;
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            suppressSelection = true;
            string id = txtBuscarID.Text.Trim();
            string texto = txtBuscar.Text.Trim();
            if (id == PlaceholderBuscarID) id = string.Empty;
            if (texto == PlaceholderBuscarNombre) texto = string.Empty;

            var dt = ClientesFunciones.BuscarCliente(id, texto);
            DGViewCliente.DataSource = dt;

            if (DGViewCliente.Columns.Contains("Localidad_ID"))
                DGViewCliente.Columns["Localidad_ID"].Visible = false;

            DGViewCliente.ClearSelection();
            LimpiarCampos();
            suppressSelection = false;
        }

        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            ApplyPlaceholder(txtBuscarID, PlaceholderBuscarID);
            ApplyPlaceholder(txtBuscar, PlaceholderBuscarNombre);
            RefrescarGrid();
        }

        private void DGViewCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (suppressSelection) return;
            if (DGViewCliente.CurrentRow == null) return;

            var cells = DGViewCliente.CurrentRow.Cells;
            txtId.Text = cells["ID"].Value?.ToString();
            txtNombre.Text = cells["Nombre"].Value?.ToString();
            txtApellido.Text = cells["Apellido"].Value?.ToString();
            txtEmail.Text = cells["Email"].Value?.ToString();
            txtTelefono.Text = cells["Telefono"].Value?.ToString();
            txtDireccion.Text = cells["Direccion"].Value?.ToString();
            txtCuit.Text = cells["Cuit"].Value?.ToString();
            txtObservacion.Text = cells["Observacion"].Value?.ToString();

            string provincia = cells["Provincia"].Value?.ToString();
            string localidad = cells["Localidad"].Value?.ToString();

            int idxProv = ComboxProvincia.Items.Cast<KeyValuePair<int, string>>()
                .ToList().FindIndex(x => x.Value == provincia);
            ComboxProvincia.SelectedIndex = idxProv;
            if (idxProv >= 0)
            {
                var selProv = (KeyValuePair<int, string>)ComboxProvincia.Items[idxProv];
                CargarCiudades(selProv.Key);
                int idxLoc = ComboxLocalidad.Items.Cast<KeyValuePair<int, string>>()
                    .ToList().FindIndex(x => x.Value == localidad);
                ComboxLocalidad.SelectedIndex = idxLoc;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDireccion.Clear();
            txtCuit.Clear();
            txtObservacion.Clear();

            ComboxProvincia.SelectedIndex = -1;

            ComboxLocalidad.Items.Clear();
            ComboxLocalidad.SelectedIndex = -1;
            ComboxLocalidad.Text = string.Empty; // 👈 esto es clave
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
        private void bttnModyAgr_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            suppressSelection = true;
            var puente = new ClientesPuente
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Direccion = txtDireccion.Text.Trim(),
                Cuit = txtCuit.Text.Trim(),
                Observacion = txtObservacion.Text.Trim(),
                Localidad_ID = ComboxLocalidad.SelectedItem is KeyValuePair<int, string> loc ? loc.Key : (int?)null
            };
            bool esModificacion = int.TryParse(txtId.Text, out int id);
            int result = esModificacion
                ? ClientesFunciones.ModificarCliente(new ClientesPuente { ID = id, Nombre = puente.Nombre, Apellido = puente.Apellido, Email = puente.Email, Telefono = puente.Telefono, Direccion = puente.Direccion, Cuit = puente.Cuit, Observacion = puente.Observacion, Localidad_ID = puente.Localidad_ID })
                : ClientesFunciones.AgregarCliente(puente);
            // Mostrar mensaje de éxito
            if (result > 0)
            {
                MessageBox.Show(esModificacion ? "Cliente modificado con éxito." : "Cliente agregado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimpiarCampos();
            RefrescarGrid();
            suppressSelection = false;
        }
        private void ApplyPlaceholder(TextBox tb, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.Text = placeholder;
                tb.ForeColor = Color.Gray;
            }
        }
        private void RemovePlaceholder(TextBox tb, string placeholder)
        {
            if (tb.Text == placeholder)
            {
                tb.Clear();
                tb.ForeColor = Color.Black;
            }
        }
        private void BttnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BttnRetroceder_Click(object sender, EventArgs e)
        {
            Menu FrmMenu = new Menu();
            this.Hide();
            FrmMenu.Show();
        }
    }
}

