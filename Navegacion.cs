using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Diegod
{
    /// <summary>Menu lateral siempre visible y navegacion entre pantallas.</summary>
    internal static class Navegacion
    {
        private const int AnchoBase = 190;

        [DllImport("user32.dll")] private static extern bool ReleaseCapture();
        [DllImport("user32.dll")] private static extern IntPtr SendMessage(IntPtr h, int msg, int w, int l);

        private static readonly (string Texto, Func<Form> Crear)[] Items =
        {
            ("Inicio", null),
            ("Clientes", () => new Clientes()),
            ("Trabajos", () => new Trabajo()),
            ("Vehículos", () => new Vehiculo()),
            ("Empleados", () => new Empleados()),
            ("Movimientos", () => new MovimientoStock()),
            ("Stock", () => new Stock()),
            ("Proveedores", () => new Proveedor()),
            ("Crédito", () => new Credito()),
            ("Prestamista", () => new Prestamista()),
            ("Pagos pendientes", () => new PagosPendientes()),
            ("Historial", () => new Historial()),
        };

        public static void Agregar(Form f)
        {
            int ancho = f.LogicalToDeviceUnits(AnchoBase);
            Size original = f.ClientSize;

            // 1) Todo el contenido original pasa a un panel del mismo tamano (nada se mueve ni se estira)
            var contenido = new Panel
            {
                Name = "pnlContenido",
                BackColor = Tema.Fondo,
                Location = new Point(ancho, 0),
                Size = original,
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };
            var originales = new List<Control>();
            foreach (Control c in f.Controls) originales.Add(c);
            foreach (var c in originales) contenido.Controls.Add(c);

            // 2) El formulario se ensancha para dar lugar al menu
            f.ClientSize = new Size(original.Width + ancho, original.Height);

            var nav = new Panel
            {
                Name = "pnlNavegacion",
                BackColor = Tema.Oscuro,
                Location = new Point(0, 0),
                Size = new Size(ancho, original.Height),
                Anchor = AnchorStyles.Top | AnchorStyles.Left
            };

            var marca = new Label
            {
                Text = "DIEGOD",
                Font = new Font("Segoe UI Black", 17F),
                ForeColor = Tema.Acento,
                BackColor = Color.Transparent,
                TextAlign = ContentAlignment.MiddleLeft,
                Location = new Point(f.LogicalToDeviceUnits(18), f.LogicalToDeviceUnits(14)),
                Size = new Size(ancho - f.LogicalToDeviceUnits(30), f.LogicalToDeviceUnits(40))
            };
            nav.Controls.Add(marca);
            Arrastrable(f, nav);
            Arrastrable(f, marca);

            int y = f.LogicalToDeviceUnits(64);
            int alto = f.LogicalToDeviceUnits(40);
            int pasos = f.LogicalToDeviceUnits(2);
            foreach (var it in Items)
            {
                bool activo = EsActual(f, it.Texto);
                var b = new Button
                {
                    Text = "   " + it.Texto,
                    TextAlign = ContentAlignment.MiddleLeft,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 10.5F, activo ? FontStyle.Bold : FontStyle.Regular),
                    ForeColor = activo ? Tema.Oscuro : Color.FromArgb(229, 231, 235),
                    BackColor = activo ? Tema.Acento : Tema.Oscuro,
                    Cursor = Cursors.Hand,
                    TabStop = false,
                    Location = new Point(f.LogicalToDeviceUnits(10), y),
                    Size = new Size(ancho - f.LogicalToDeviceUnits(20), alto),
                    Name = "nav" + it.Texto.Replace(" ", "")
                };
                b.FlatAppearance.BorderSize = 0;
                b.FlatAppearance.MouseOverBackColor = activo ? Tema.Acento : Tema.OscuroHover;
                b.FlatAppearance.MouseDownBackColor = activo ? Tema.Acento : Tema.OscuroHover;
                Tema.Redondear(b, 8);
                var crear = it.Crear;
                b.Click += (s, e) => Ir(f, crear);
                nav.Controls.Add(b);
                y += alto + pasos;
            }

            var salir = new Button
            {
                Text = "   Salir",
                TextAlign = ContentAlignment.MiddleLeft,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10.5F),
                ForeColor = Color.FromArgb(252, 165, 165),
                BackColor = Tema.Oscuro,
                Cursor = Cursors.Hand,
                TabStop = false,
                Name = "navSalir",
                Location = new Point(f.LogicalToDeviceUnits(10), original.Height - alto - f.LogicalToDeviceUnits(14)),
                Size = new Size(ancho - f.LogicalToDeviceUnits(20), alto)
            };
            salir.FlatAppearance.BorderSize = 0;
            salir.FlatAppearance.MouseOverBackColor = Tema.OscuroHover;
            Tema.Redondear(salir, 8);
            salir.Click += (s, e) => Application.Exit();
            nav.Controls.Add(salir);

            f.Controls.Add(contenido);
            f.Controls.Add(nav);
            nav.BringToFront();
        }

        private static bool EsActual(Form f, string texto)
        {
            switch (texto)
            {
                case "Inicio": return f is Menu;
                case "Clientes": return f is Clientes;
                case "Trabajos": return f is Trabajo;
                case "Vehículos": return f is Vehiculo;
                case "Empleados": return f is Empleados;
                case "Movimientos": return f is MovimientoStock;
                case "Stock": return f is Stock;
                case "Proveedores": return f is Proveedor;
                case "Crédito": return f is Credito;
                case "Prestamista": return f is Prestamista;
                case "Pagos pendientes": return f is PagosPendientes;
                case "Historial": return f is Historial;
            }
            return false;
        }

        private static void Ir(Form actual, Func<Form> crear)
        {
            if (crear == null)
            {
                if (actual is Menu) return;
                Ayudas.Volver(actual);
                return;
            }
            Form nuevo = crear();
            if (nuevo.GetType() == actual.GetType()) { nuevo.Dispose(); return; }
            nuevo.StartPosition = FormStartPosition.Manual;
            nuevo.Location = actual.Location;
            if (actual is Menu)
            {
                actual.Hide();
            }
            else
            {
                actual.Tag = "volver";
                Menu.Ocultar();
                actual.Close();
            }
            nuevo.Show();
        }

        private static void Arrastrable(Form f, Control c)
        {
            c.MouseDown += (s, e) =>
            {
                if (e.Button != MouseButtons.Left) return;
                ReleaseCapture();
                SendMessage(f.Handle, 0xA1, 0x2, 0);
            };
        }
    }
}
