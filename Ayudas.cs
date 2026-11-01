using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Diegod
{
    /// <summary>
    /// Comodidades comunes a todas las pantallas:
    /// Enter pasa al campo siguiente (o busca / confirma), Esc vuelve al menu,
    /// textos de ayuda en los buscadores, fechas cortas y cierre ordenado.
    /// </summary>
    internal static class Ayudas
    {
        public static void Configurar(Form f)
        {
            f.KeyPreview = true;
            f.KeyDown += Form_KeyDown;
            f.FormClosed += Form_FormClosed;
            Preparar(f);
            foreach (var b in Recolectar<Button>(f))
            {
                if (b.Text == "OK")
                    b.Click += (s, e) => ReenfocarTrasGuardar(f, (Button)s);
            }
        }

        /// <summary>Si el formulario quedo vacio despues de guardar, deja el cursor en el primer campo.</summary>
        private static void ReenfocarTrasGuardar(Form f, Button ok)
        {
            var botonesOk = Filtrar(Recolectar<Button>(f), b => b.Text == "OK" && b.Visible && b.Enabled);
            var lista = new List<Control>();
            foreach (var c in Recolectar<Control>(f))
            {
                if (!(c is TextBox || c is ComboBox || c is DateTimePicker || c is CheckBox)) continue;
                if (EsBuscador(c) || !c.Visible || !c.Enabled) continue;
                if (c is TextBox tx && tx.ReadOnly) continue;
                if (c.Parent != null && (c.Bottom <= 0 || c.Top >= c.Parent.ClientSize.Height)) continue;
                if (Cercano(botonesOk, c) != ok) continue;
                lista.Add(c);
            }

            bool hayTexto = false, algunoLleno = false;
            foreach (var c in lista)
            {
                if (c is TextBox t)
                {
                    hayTexto = true;
                    if (!string.IsNullOrWhiteSpace(t.Text)) algunoLleno = true;
                }
            }
            if (!hayTexto || algunoLleno) return;

            lista.Sort((a, b) =>
            {
                Point pa = Posicion(a), pb = Posicion(b);
                return pa.Y != pb.Y ? pa.Y.CompareTo(pb.Y) : pa.X.CompareTo(pb.X);
            });
            var primero = lista.Find(x => x is TextBox);
            primero?.Focus();
        }

        /// <summary>Lee el numero inicial de textos como "3 - Juan Perez". Devuelve null si no hay.</summary>
        public static int? IdInicial(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return null;
            int i = 0;
            texto = texto.Trim();
            while (i < texto.Length && char.IsDigit(texto[i])) i++;
            return i > 0 && int.TryParse(texto.Substring(0, i), out int id) ? id : (int?)null;
        }

        /// <summary>Texto de una celda por nombre de columna; vacio si la columna no existe.</summary>
        public static string Celda(DataGridViewRow fila, string columna)
        {
            return fila.DataGridView != null && fila.DataGridView.Columns.Contains(columna)
                ? Convert.ToString(fila.Cells[columna].Value) ?? ""
                : "";
        }

        /// <summary>Vuelve al menu principal cerrando la pantalla actual.</summary>
        public static void Volver(Form f)
        {
            f.Tag = "volver";
            Menu.Mostrar();
            f.Close();
        }

        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var f = (Form)sender;
            if (f.Tag is string t && t == "volver") return;
            // Cerrar con Alt+F4 o desde la barra de tareas debe cerrar todo el programa
            if (e.CloseReason == CloseReason.UserClosing) Application.Exit();
        }

        private static void Preparar(Control raiz)
        {
            Preparar(raiz, raiz as Form);
        }

        private static void Preparar(Control raiz, Form forma)
        {
            foreach (Control c in raiz.Controls)
            {
                if (c is TextBox tb)
                {
                    if (tb.Name.StartsWith("txtBuscar") && string.IsNullOrEmpty(tb.Text))
                        tb.PlaceholderText = TextoAyuda(tb.Name, forma);
                    if (tb.ReadOnly) tb.TabStop = false;
                    if ((tb.Name == "txtId" || tb.Name == "txtID") && tb.ReadOnly && string.IsNullOrEmpty(tb.Text))
                        tb.PlaceholderText = "ID";
                }
                else if (c is DataGridView dgv)
                {
                    PrepararGrilla(dgv);
                }
                else if (c is DateTimePicker dtp && dtp.Format == DateTimePickerFormat.Long)
                {
                    dtp.Format = DateTimePickerFormat.Short;
                }
                if (c.HasChildren) Preparar(c, forma);
            }
        }

        private static void PrepararGrilla(DataGridView g)
        {
            g.AllowUserToAddRows = false;
            g.CellFormatting += (s, e) =>
            {
                if (e.Value is DateTime d)
                {
                    e.Value = d.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            };
            g.DataBindingComplete += (s, e) =>
            {
                foreach (DataGridViewColumn col in g.Columns)
                {
                    if (col.HeaderText.Contains("_"))
                        col.HeaderText = col.HeaderText.Replace("_", " ");
                    if (col.ValueType == typeof(DateTime))
                        col.DefaultCellStyle.Format = "dd/MM/yyyy";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            };
        }

        private static string TextoAyuda(string nombre, Form forma)
        {
            if (nombre == "txtBuscar" && forma is Stock) return "Producto";
            if (nombre.EndsWith("ID")) return "ID";
            if (nombre.Contains("Patente")) return "Patente";
            if (nombre.Contains("Proveedor")) return "Proveedor";
            if (nombre.Contains("Prestamista")) return "Prestamista";
            if (nombre.Contains("Stock") || nombre.Contains("Producto")) return "Producto";
            if (nombre.Contains("Empleado")) return "Empleado";
            if (nombre.Contains("Cliente")) return "Cliente";
            return "Nombre";
        }

        private static bool EsBuscador(Control c)
        {
            return c.Name.StartsWith("txtBuscar") || c.Name.StartsWith("DateBuscar") || c.Name.StartsWith("dtpBuscar")
                || c.Name == "txtCliente" || c.Name == "txtEmpleado" || c.Name == "txtVehiculo";
        }

        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            var f = (Form)sender;

            if (e.KeyCode == Keys.Escape)
            {
                if (ActivoFinal(f) is ComboBox abierto && abierto.DroppedDown) return;
                foreach (var b in Recolectar<Button>(f))
                {
                    if (b.Name == "BttnRetroceder" && b.Visible && b.Enabled)
                    {
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                        b.PerformClick();
                        return;
                    }
                }
                return;
            }

            if (e.KeyCode != Keys.Enter || e.Control || e.Alt || e.Shift) return;

            Control activo = ActivoFinal(f);
            if (activo == null) return;
            if (activo is ComboBox cb && cb.DroppedDown) return;
            if (activo is TextBox t && t.Multiline) return;
            if (!(activo is TextBox || activo is ComboBox || activo is DateTimePicker || activo is CheckBox)) return;

            e.Handled = true;
            e.SuppressKeyPress = true;

            // En un buscador: Enter = pulsar su boton Buscar
            if (EsBuscador(activo))
            {
                var buscar = Cercano(Filtrar(Recolectar<Button>(f), b => b.Text == "Buscar"), activo);
                buscar?.PerformClick();
                return;
            }

            // En el formulario: Enter = pasar al siguiente campo; en el ultimo, confirmar (OK)
            var entradas = new List<Control>();
            foreach (var c in Recolectar<Control>(f))
            {
                if (!(c is TextBox || c is ComboBox || c is DateTimePicker || c is CheckBox)) continue;
                if (EsBuscador(c) || !c.Visible || !c.Enabled) continue;
                if (c.Parent != activo.Parent) continue; // Enter solo recorre la tarjeta (panel) donde estas
                if (c.Parent != null && (c.Bottom <= 0 || c.Top >= c.Parent.ClientSize.Height)) continue; // fuera del area visible
                if (c is CheckBox && c != activo) continue; // las casillas se saltan con Enter
                if (c is TextBox tx && (tx.ReadOnly || tx.Multiline)) continue;
                entradas.Add(c);
            }
            entradas.Sort((a, b) =>
            {
                Point pa = Posicion(a), pb = Posicion(b);
                return pa.Y != pb.Y ? pa.Y.CompareTo(pb.Y) : pa.X.CompareTo(pb.X);
            });

            Button ok = Cercano(Filtrar(Recolectar<Button>(f), b => b.Text == "OK" && b.Visible && b.Enabled), activo);
            int i = entradas.IndexOf(activo);
            if (i >= 0 && i + 1 < entradas.Count)
            {
                Control siguiente = entradas[i + 1];
                Button okSiguiente = Cercano(Filtrar(Recolectar<Button>(f), b => b.Text == "OK" && b.Visible && b.Enabled), siguiente);
                if (ok == null || ok == okSiguiente)
                {
                    siguiente.Focus();
                    if (siguiente is TextBox ts) ts.SelectAll();
                    return;
                }
            }
            ok?.PerformClick();
        }

        private static Control ActivoFinal(Form f)
        {
            Control c = f.ActiveControl;
            while (c is ContainerControl cc && cc.ActiveControl != null && cc.ActiveControl != c)
                c = cc.ActiveControl;
            return c;
        }

        private static List<T> Recolectar<T>(Control raiz) where T : Control
        {
            var lista = new List<T>();
            foreach (Control c in raiz.Controls)
            {
                if (c is T t) lista.Add(t);
                if (c.HasChildren) lista.AddRange(Recolectar<T>(c));
            }
            return lista;
        }

        private static List<T> Filtrar<T>(List<T> origen, Func<T, bool> condicion)
        {
            return origen.FindAll(x => condicion(x));
        }

        private static Point Posicion(Control c)
        {
            return c.Parent != null ? c.Parent.PointToScreen(c.Location) : c.Location;
        }

        private static T Cercano<T>(List<T> candidatos, Control referencia) where T : Control
        {
            T mejor = null;
            double mejorDist = double.MaxValue;
            Point r = Posicion(referencia);
            r.Offset(referencia.Width / 2, referencia.Height / 2);
            foreach (var c in candidatos)
            {
                Point p = Posicion(c);
                p.Offset(c.Width / 2, c.Height / 2);
                double d = Math.Pow(p.X - r.X, 2) + Math.Pow(p.Y - r.Y, 2);
                if (d < mejorDist) { mejorDist = d; mejor = c; }
            }
            return mejor;
        }
    }
}
