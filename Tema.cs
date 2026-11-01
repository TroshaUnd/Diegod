using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Diegod
{
    /// <summary>
    /// Look moderno claro con acento amarillo. Se aplica a todas las pantallas
    /// en tiempo de ejecucion sin tocar sus funciones.
    /// </summary>
    internal static class Tema
    {
        public static readonly Color Fondo = ColorTranslator.FromHtml("#F3F4F6");
        public static readonly Color Tarjeta = Color.White;
        public static readonly Color Borde = ColorTranslator.FromHtml("#E5E7EB");
        public static readonly Color Texto = ColorTranslator.FromHtml("#111827");
        public static readonly Color TextoSuave = ColorTranslator.FromHtml("#6B7280");
        public static readonly Color Etiqueta = ColorTranslator.FromHtml("#374151");
        public static readonly Color Acento = ColorTranslator.FromHtml("#FFC107");
        public static readonly Color AcentoHover = ColorTranslator.FromHtml("#FFCE3A");
        public static readonly Color AcentoSuave = ColorTranslator.FromHtml("#FEF3C7");
        public static readonly Color Oscuro = ColorTranslator.FromHtml("#1F2937");
        public static readonly Color OscuroHover = ColorTranslator.FromHtml("#374151");
        public static readonly Color Peligro = ColorTranslator.FromHtml("#DC2626");
        public static readonly Color PeligroSuave = ColorTranslator.FromHtml("#FEE2E2");
        public static readonly Color Gris = ColorTranslator.FromHtml("#E5E7EB");

        // Colores de filas en las tablas
        public static readonly Color FilaNormal = Color.White;
        public static readonly Color FilaInactiva = ColorTranslator.FromHtml("#E5E7EB");
        public static readonly Color FilaOk = ColorTranslator.FromHtml("#D1FAE5");
        public static readonly Color FilaAlerta = ColorTranslator.FromHtml("#FECACA");

        public static void Aplicar(Form f)
        {
            f.BackColor = Fondo;
            f.Font = new Font("Segoe UI", 9.75F);
            Recorrer(f);
        }

        private static void Recorrer(Control padre)
        {
            foreach (Control c in padre.Controls)
            {
                Estilizar(c);
                if (c.HasChildren) Recorrer(c);
            }
        }

        private static void Estilizar(Control c)
        {
            if (c is Panel p)
            {
                if (p.Height <= 14 && p.Width > 200)
                {
                    p.Visible = false; // franjas negras decorativas
                    return;
                }
                p.BackColor = Tarjeta;
                p.BorderStyle = (p.Width >= 120 && p.Height >= 60) ? BorderStyle.FixedSingle : BorderStyle.None;
            }
            else if (c is Label l)
            {
                l.BackColor = Color.Transparent;
                if (l.Name.StartsWith("lbl"))
                {
                    l.Font = new Font("Segoe UI Semibold", 11F);
                    l.ForeColor = Texto;
                }
                else if (l.Font.Size >= 16F)
                {
                    l.Font = new Font("Segoe UI Semibold", 15F);
                    l.ForeColor = Texto;
                }
                else
                {
                    l.Font = new Font("Segoe UI Semibold", 9.5F);
                    l.ForeColor = Etiqueta;
                }
            }
            else if (c is TextBox t)
            {
                t.BorderStyle = BorderStyle.FixedSingle;
                t.Font = new Font("Segoe UI", 11F);
                t.ForeColor = Texto;
                t.BackColor = t.ReadOnly ? Fondo : Color.White;
            }
            else if (c is ComboBox cb)
            {
                cb.FlatStyle = FlatStyle.Flat;
                cb.BackColor = Color.White;
                cb.ForeColor = Texto;
                cb.Font = new Font("Segoe UI", 10.5F);
            }
            else if (c is DateTimePicker dtp)
            {
                dtp.Font = new Font("Segoe UI", 10.5F);
            }
            else if (c is CheckBox ck)
            {
                ck.BackColor = Color.Transparent;
                ck.ForeColor = Texto;
                ck.Font = new Font("Segoe UI", 10F);
            }
            else if (c is DataGridView g)
            {
                EstilizarGrilla(g);
            }
            else if (c is Button b)
            {
                EstilizarBoton(b);
            }
        }

        private static void EstilizarGrilla(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = Tarjeta;
            g.GridColor = Borde;
            g.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            g.RowHeadersVisible = false;

            g.ColumnHeadersDefaultCellStyle.BackColor = Oscuro;
            g.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Oscuro;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.White;
            g.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F);
            g.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 4, 6, 4);

            g.DefaultCellStyle.BackColor = FilaNormal;
            g.DefaultCellStyle.ForeColor = Texto;
            g.DefaultCellStyle.SelectionBackColor = AcentoSuave;
            g.DefaultCellStyle.SelectionForeColor = Texto;
            g.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            g.DefaultCellStyle.Padding = new Padding(6, 3, 6, 3);
        }

        private static void EstilizarBoton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.UseVisualStyleBackColor = false;
            b.Cursor = Cursors.Hand;
            b.FlatAppearance.BorderSize = 0;

            bool enMenu = b.FindForm() is Menu;

            if (b.Name == "BttnX")
            {
                Pintar(b, PeligroSuave, Peligro, new Font("Segoe UI", 11F, FontStyle.Bold), ControlPaint.Light(PeligroSuave));
            }
            else if (b.Name == "BttnRetroceder")
            {
                Pintar(b, Gris, Texto, new Font("Segoe UI", 12F, FontStyle.Bold), ControlPaint.Light(Gris));
            }
            else if (enMenu)
            {
                // Los botones del menu inicial se ven como tarjetas
                Pintar(b, Tarjeta, Texto, new Font("Segoe UI Semibold", 13F), AcentoSuave);
                b.FlatAppearance.BorderSize = 1;
                b.FlatAppearance.BorderColor = Borde;
                return;
            }
            else if (b.Text == "OK")
            {
                Pintar(b, Acento, Texto, new Font("Segoe UI", 14F, FontStyle.Bold), AcentoHover);
            }
            else if (b.Name.Contains("Limpiar"))
            {
                Pintar(b, Gris, Texto, new Font("Segoe UI Semibold", 9.5F), ControlPaint.Light(Gris));
            }
            else
            {
                Pintar(b, Oscuro, Color.White, new Font("Segoe UI Semibold", 9.5F), OscuroHover);
            }
            Redondear(b, 8);
        }

        private static void Pintar(Button b, Color fondo, Color texto, Font fuente, Color hover)
        {
            b.BackColor = fondo;
            b.ForeColor = texto;
            b.Font = fuente;
            b.FlatAppearance.MouseOverBackColor = hover;
            b.FlatAppearance.MouseDownBackColor = hover;
        }

        /// <summary>Esquinas redondeadas para un control (botones principalmente).</summary>
        public static void Redondear(Control c, int radio)
        {
            void Ajustar()
            {
                if (c.Width <= 0 || c.Height <= 0) return;
                int d = radio * 2;
                using (var gp = new GraphicsPath())
                {
                    gp.AddArc(0, 0, d, d, 180, 90);
                    gp.AddArc(c.Width - d, 0, d, d, 270, 90);
                    gp.AddArc(c.Width - d, c.Height - d, d, d, 0, 90);
                    gp.AddArc(0, c.Height - d, d, d, 90, 90);
                    gp.CloseFigure();
                    c.Region = new Region(gp);
                }
            }
            Ajustar();
            c.SizeChanged += (s, e) => Ajustar();
        }
    }
}
