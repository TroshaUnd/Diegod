using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Credito : Form
    {
        public Credito()
        {
            InitializeComponent();
            Ayudas.Configurar(this);
            Load += Credito_Load;
            DGViewPrestamista.CellClick += DGViewPrestamistas_CellClick;
            DGViewPrestamista.DataBindingComplete += DGViewPrestamistas_DataBindingComplete;

            DGViewCredito.DataBindingComplete += DGViewCreditos_DataBindingComplete;
            DGViewCredito.CellFormatting += DGViewCreditos_CellFormatting;
            DGViewCredito.CellValueChanged += DGViewCreditos_CellValueChanged;
            DGViewCredito.CellContentClick += DGViewCreditos_CellContentClick;
            DGViewCredito.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (DGViewCredito.CurrentCell is DataGridViewCheckBoxCell)
                    DGViewCredito.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
            DGViewCredito.AllowUserToAddRows = false;
        }

        private void Credito_Load(object sender, EventArgs e)
        {
            CargarCreditos();
            CargarPrestamistas();

            var fuente8 = new Font(DGViewCredito.Font.FontFamily, 8f);
            DGViewCredito.DefaultCellStyle.Font = fuente8;
            DGViewPrestamista.DefaultCellStyle.Font = fuente8;

            foreach (DataGridViewColumn col in DGViewCredito.Columns)
                col.ReadOnly = col.Name != "Anulado";
            DGViewCredito.Columns["Anulado"].ReadOnly = false;
            DGViewCredito.Columns["Anulado"].CellTemplate = new DataGridViewCheckBoxCell();
            DGViewCredito.Columns["Anulado"].DisplayIndex = 0;

            DGViewCredito.ClearSelection();
        }
        private void BttnBuscarCredito_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBuscarID.Text) && int.TryParse(txtBuscarID.Text, out int id))
            {
                DGViewCredito.DataSource = CreditosFunciones.BuscarCreditosPorID(id);
            }
            else if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                DGViewCredito.DataSource = CreditosFunciones.BuscarCreditosPorNombre(txtBuscar.Text.Trim());
            }
            else if (DateBuscarFecha.Checked)
            {
                DGViewCredito.DataSource = CreditosFunciones.BuscarCreditosPorFecha(DateBuscarFecha.Value.Date);
            }
            else
            {
                CargarCreditos();
            }

            DGViewCredito.ClearSelection();
        }
        private void bttnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscarID.Clear();
            txtBuscar.Clear();
            DateBuscarFecha.Value = DateTime.Now;
            txtPrestamista.Clear();
            txtMonto.Clear();
            txtObservacion.Clear();
            DateFechaCredito.Value = DateTime.Now;
            DateFechaVencimiento.Value = DateTime.Now;
            txtBuscarPrestamistaID.Clear();
            txtBuscarPrestamista.Clear();
            CargarCreditos();
            CargarPrestamistas();
        }

        private void BttnBuscarPrestamista_Click(object sender, EventArgs e)
        {
            DataTable dt;
            if (!string.IsNullOrEmpty(txtBuscarPrestamistaID.Text))
            {
                // Buscar por ID exacto
                dt = CreditosFunciones.BuscarPrestamistaPorID(int.Parse(txtBuscarPrestamistaID.Text));
            }
            else if (!string.IsNullOrEmpty(txtBuscarPrestamista.Text))
            {
                // Buscar por nombre o apellido
                dt = CreditosFunciones.BuscarPrestamistaPorNombre(txtBuscarPrestamista.Text);
            }
            else
            {
                dt = CreditosFunciones.ObtenerPrestamistas();
            }
            DGViewPrestamista.DataSource = dt;
        }
        private void DGViewPrestamistas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = DGViewPrestamista.Rows[e.RowIndex];
            txtPrestamista.Text = (Ayudas.Celda(row, "ID") + " - " + Ayudas.Celda(row, "Nombre") + " " + Ayudas.Celda(row, "Apellido")).Trim();
        }

        private void DGViewPrestamistas_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewPrestamista.ClearSelection();
        }

        private void DGViewCreditos_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGViewCredito.ClearSelection();
        }

        private void DGViewCreditos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DGViewCredito.Columns[e.ColumnIndex].Name == "Anulado")
            {
                bool anulado = e.Value != null && e.Value != DBNull.Value && Convert.ToBoolean(e.Value);
                DGViewCredito.Rows[e.RowIndex].DefaultCellStyle.BackColor = anulado ? Tema.FilaInactiva : Tema.FilaNormal;
            }
        }

        private void DGViewCreditos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewCredito.Columns[e.ColumnIndex].Name != "Anulado") return;
            DGViewCredito.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DGViewCreditos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || DGViewCredito.Columns[e.ColumnIndex].Name != "Anulado")
                return;
            var row = DGViewCredito.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool nuevoEstado = Convert.ToBoolean(row.Cells["Anulado"].Value);
            try
            {
                CreditosFunciones.ActualizarAnulado(id, nuevoEstado);
                DGViewCredito.InvalidateRow(e.RowIndex);
                DGViewCredito.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el estado: " + ex.Message);
                CargarCreditos();
            }
        }

        
        private void bttnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bttnVolver_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }

        private void CargarCreditos()
        {
            DGViewCredito.DataSource = CreditosFunciones.RegistroCreditos();
        }

        private void CargarPrestamistas()
        {
            DGViewPrestamista.DataSource = CreditosFunciones.ObtenerPrestamistas();
        }
        private void BttnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Ayudas.IdInicial(txtPrestamista.Text) == null)
                {
                    MessageBox.Show("Seleccione un prestamista.");
                    return;
                }

                decimal? montoValido = PagosPendientes.ParseMonto(txtMonto.Text);
                if (!montoValido.HasValue || montoValido.Value <= 0)
                {
                    MessageBox.Show("Ingrese un monto válido mayor a cero (por ejemplo 15000).", "Monto incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMonto.Focus();
                    return;
                }
                if (DateFechaVencimiento.Value.Date < DateFechaCredito.Value.Date)
                {
                    MessageBox.Show("La fecha de vencimiento no puede ser anterior a la fecha del crédito.", "Fecha incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var credito = new CreditoPuente
                {
                    Prestamista_ID = Ayudas.IdInicial(txtPrestamista.Text) ?? 0,
                    Monto_Credito = montoValido.Value,
                    Fecha_Credito = DateFechaCredito.Value,
                    Fecha_Vencimiento = DateFechaVencimiento.Value,
                    Observacion = string.IsNullOrEmpty(txtObservacion.Text) ? null : txtObservacion.Text,
                };

                int resultado = CreditosFunciones.AgregarCredito(credito);
                if (resultado > 0)
                {
                    MessageBox.Show("Crédito agregado correctamente.");
                    CargarCreditos();
                    bttnLimpiar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Error al agregar crédito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
