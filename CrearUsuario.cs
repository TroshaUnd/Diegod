using System.Drawing;
using System.Text.RegularExpressions;
using Diegod.Datos;

namespace Diegod
{
    /// <summary>
    /// Pantalla que aparece al entrar con el usuario genérico: el dueño del programa crea su cuenta
    /// (usuario, correo y contraseña). El usuario genérico se elimina y desde ahí se entra con la cuenta nueva.
    /// </summary>
    public class CrearUsuario : Form
    {
        private readonly TextBox txtUsuario = new TextBox();
        private readonly TextBox txtCorreo = new TextBox();
        private readonly TextBox txtClave = new TextBox();
        private readonly TextBox txtClave2 = new TextBox();
        private readonly CheckBox chkMostrar = new CheckBox();
        private readonly Button btnCrear = new Button();
        private bool creado;

        public CrearUsuario()
        {
            Text = "Diegod - Crear cuenta";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ClientSize = new Size(440, 520);
            BackColor = Color.White;
            Font = new Font("Segoe UI", 10F);
            KeyPreview = true;

            var cabecera = new Panel { Dock = DockStyle.Top, Height = 90, BackColor = Color.Black };
            cabecera.Controls.Add(new Label
            {
                Text = "Creá tu cuenta",
                Font = new Font("Segoe UI Black", 18F),
                ForeColor = Color.Gold,
                AutoSize = false,
                Location = new Point(20, 12),
                Size = new Size(400, 36)
            });
            cabecera.Controls.Add(new Label
            {
                Text = "Estás usando el acceso genérico. Creá tu usuario para continuar.",
                ForeColor = Color.White,
                AutoSize = false,
                Location = new Point(20, 50),
                Size = new Size(400, 32)
            });
            Controls.Add(cabecera);

            int y = 108;
            Agregar("Usuario", txtUsuario, ref y);
            Agregar("Correo (por si olvidás la contraseña)", txtCorreo, ref y);
            Agregar("Contraseña (mínimo 6 caracteres)", txtClave, ref y);
            Agregar("Repetir contraseña", txtClave2, ref y);
            txtClave.UseSystemPasswordChar = true;
            txtClave2.UseSystemPasswordChar = true;

            chkMostrar.Text = "Mostrar contraseña";
            chkMostrar.AutoSize = true;
            chkMostrar.Location = new Point(24, y);
            chkMostrar.CheckedChanged += (s, e) =>
            {
                txtClave.UseSystemPasswordChar = !chkMostrar.Checked;
                txtClave2.UseSystemPasswordChar = !chkMostrar.Checked;
            };
            Controls.Add(chkMostrar);

            btnCrear.Text = "CREAR CUENTA";
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.BackColor = Color.Gold;
            btnCrear.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCrear.Location = new Point(24, y + 40);
            btnCrear.Size = new Size(392, 48);
            btnCrear.Click += (s, e) => Crear();
            Controls.Add(btnCrear);
            AcceptButton = btnCrear;

            FormClosed += (s, e) => { if (!creado) Application.Exit(); };
            Shown += (s, e) => txtUsuario.Focus();
        }

        private void Agregar(string titulo, TextBox caja, ref int y)
        {
            Controls.Add(new Label { Text = titulo, AutoSize = true, Location = new Point(24, y), Font = new Font("Segoe UI Semibold", 9.5F) });
            caja.Location = new Point(24, y + 24);
            caja.Size = new Size(392, 28);
            caja.Font = new Font("Segoe UI", 11F);
            Controls.Add(caja);
            y += 70;
        }

        private void Crear()
        {
            string usuario = txtUsuario.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string clave = txtClave.Text;

            if (usuario.Length < 3 || usuario.Contains(' '))
            { Aviso("El usuario debe tener al menos 3 letras y no puede tener espacios.", txtUsuario); return; }
            if (usuario.Equals("admin", StringComparison.OrdinalIgnoreCase))
            { Aviso("Ese nombre de usuario está reservado. Elegí otro.", txtUsuario); return; }
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { Aviso("Escribí un correo válido (por ejemplo nombre@gmail.com).", txtCorreo); return; }
            if (clave.Length < 6)
            { Aviso("La contraseña debe tener al menos 6 caracteres.", txtClave); return; }
            if (clave != txtClave2.Text)
            { Aviso("Las dos contraseñas no coinciden.", txtClave2); return; }

            try
            {
                using (SqlConnection cn = BaseDatos.ObtenerConexion())
                {
                    using (var existe = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE Usuario = @u", cn))
                    {
                        existe.Parameters.AddWithValue("@u", usuario);
                        if (Convert.ToInt32(existe.ExecuteScalar()) > 0)
                        { Aviso("Ya existe un usuario con ese nombre.", txtUsuario); return; }
                    }
                    using (var cmd = new SqlCommand(
                        "INSERT INTO Usuario (TipoUsuario_ID, Usuario, Contra, Correo, Generico) VALUES (1, @u, @c, @m, 0);" +
                        "DELETE FROM Usuario WHERE Generico = 1;", cn))
                    {
                        cmd.Parameters.AddWithValue("@u", usuario);
                        cmd.Parameters.AddWithValue("@c", Seguridad.Hashear(clave));
                        cmd.Parameters.AddWithValue("@m", correo);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear la cuenta: " + ex.Message, "Diegod",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            creado = true;
            MessageBox.Show("Cuenta creada. ¡Bienvenido, " + usuario + "!\n\nDesde ahora entrás con tu usuario y contraseña.",
                "Diegod", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Menu.Mostrar();
            Close();
        }

        private void Aviso(string texto, Control foco)
        {
            MessageBox.Show(texto, "Diegod", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            foco.Focus();
        }
    }
}
