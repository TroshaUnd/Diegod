using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Menu : Form
    {
        private static Menu _instancia;

        /// <summary>Muestra el menu principal (una sola instancia).</summary>
        public static void Mostrar()
        {
            if (_instancia == null || _instancia.IsDisposed)
                _instancia = new Menu();
            _instancia.Show();
            _instancia.Activate();
        }

        public Menu()
        {
            InitializeComponent();
            Ayudas.Configurar(this);

            // Titulo propio y boton Historial con tamano normal (antes parecia un titulo)
            BttnHistorial.Location = new Point(908, 13);
            BttnHistorial.Size = new Size(225, 47);
            var titulo = new Label
            {
                Text = "MENÚ PRINCIPAL",
                Font = new Font("Segoe UI Black", 18F, FontStyle.Bold),
                ForeColor = Color.Black,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = false,
                Location = new Point(14, 13),
                Size = new Size(880, 47)
            };
            BttnHistorial.Parent.Controls.Add(titulo);
        }
        private void Menu_Load(object sender, EventArgs e)
        {

        }
        private void BttnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void BttnEmpleados_Click(object sender, EventArgs e)
        {
            Empleados FrmEmpleados = new Empleados();
            this.Hide();
            FrmEmpleados.Show();
        }
        private void BttnStock_Click(object sender, EventArgs e)
        {
            Stock FrmStock = new Stock();
            this.Hide();
            FrmStock.Show();
        }
        private void bttnClientes_Click(object sender, EventArgs e)
        {
            Clientes FrmClientes = new Clientes();
            this.Hide();
            FrmClientes.Show();
        }
        private void BttnProveedores_Click(object sender, EventArgs e)
        {
            Proveedor FrmProveedor = new Proveedor();
            this.Hide();
            FrmProveedor.Show();
        }
        private void BttnMovimiento_Click(object sender, EventArgs e)
        {
            MovimientoStock FrmMovimiento = new MovimientoStock();
            this.Hide();
            FrmMovimiento.Show();
        }
        private void BttnVehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo FrmVehiculo = new Vehiculo();
            this.Hide();
            FrmVehiculo.Show();
        }
        private void BttnPagosPendientes_Click(object sender, EventArgs e)
        {
            PagosPendientes FrmPagosPendientes = new PagosPendientes();
            this.Hide();
            FrmPagosPendientes.Show();
        }
        private void BttnHistorial_Click(object sender, EventArgs e)
        {
            Historial Historial = new Historial();
            this.Hide();
            Historial.Show();
        }
        private void BttnTrabajo_Click(object sender, EventArgs e)
        {
            Trabajo FrmTrabajo = new Trabajo();
            this.Hide();
            FrmTrabajo.Show();
        }
        private void BttnPrestamista_Click(object sender, EventArgs e)
        {
            Prestamista FrmPrestamista = new Prestamista();
            this.Hide();
            FrmPrestamista.Show();
        }
        private void BttnCredito_Click(object sender, EventArgs e)
        {
            Credito FrmCredito = new Credito();
            this.Hide();
            FrmCredito.Show();
        }
        private void Menu_Load_1(object sender, EventArgs e)
        {

        }
    }
}
