using System.Data;
using Diegod.Datos;

namespace Diegod
{
    public partial class Form1 : Form
    {
        // Declara la variable conexion a nivel de clase
        private SqlConnection conexion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexion = BaseDatos.ObtenerConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la conexión: " + ex.Message);
            }
        }
       
        private void BttnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = BaseDatos.ObtenerConexion())
                {
                    string consulta = "SELECT * FROM Usuario WHERE Usuario = @usuario AND Contra = @contra";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@usuario", TxtUsuario.Text);
                        comando.Parameters.AddWithValue("@contra", TxtContra.Text);

                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            if (lector.HasRows)
                            {
                                Menu frmMenu = new Menu();
                                this.Hide();
                                frmMenu.Show();
                            }
                            else
                            {
                                MessageBox.Show("Contraseña Incorrecta");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void TxtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void bttnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void TxtUsuario_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TxtContra.Focus(); // Cambia el foco al siguiente control
                e.SuppressKeyPress = true; // Evita que el Enter haga un sonido "ding"
            }
        }

        private void TxtContra_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BttnIngresar.Focus(); // Cambia el foco al botón
                e.SuppressKeyPress = true; // Evita el sonido "ding"
            }
        }

        private void BttnIngresar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BttnIngresar.PerformClick(); // Simula un clic en el botón
                e.SuppressKeyPress = true;
            }
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
