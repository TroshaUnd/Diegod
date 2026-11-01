using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Diegod
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
            Ayudas.Configurar(this);
            Load += Historial_Load;

            // Configuro dtp para meses
            dtpFechaPagos.Format = DateTimePickerFormat.Custom;
            dtpFechaPagos.CustomFormat = "MMMM yyyy";
            dtpFechaPagos.ShowUpDown = true;
            dtpFechaPagos.ValueChanged += (s, e) => ActualizarTotalesPorMes();
        }
        private void Historial_Load(object sender, EventArgs e)
        {
            CargarHistorial();

            // Suscribirse a los eventos de la grilla
            DGViewHistorial.CurrentCellDirtyStateChanged += DGViewHistorial_CurrentCellDirtyStateChanged;
            DGViewHistorial.CellValueChanged += DGViewHistorial_CellValueChanged;
            DGViewHistorial.RowPrePaint += DGViewHistorial_RowPrePaint;
        }

        private void DGViewHistorial_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGViewHistorial.IsCurrentCellDirty)
                DGViewHistorial.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void ActualizarTotalesPorMes()
        {
            int m = dtpFechaPagos.Value.Month;
            int y = dtpFechaPagos.Value.Year;

            var dt = HistorialFunciones.RegistroHistorial();
            decimal sumCobrado = 0m, sumPagado = 0m;

            foreach (DataRow row in dt.Rows)
            {
                var fp = row.Field<DateTime>("FechaPago");
                if (fp.Month != m || fp.Year != y)
                    continue;

                var montoStr = row["Monto"].ToString().Replace("$", "").Replace(",", "");
                if (!decimal.TryParse(montoStr, out decimal monto))
                    continue;

                var trans = row["Transaccion"].ToString();
                if (trans == "Cobrar")
                    sumCobrado += monto;
                else
                    sumPagado += monto;
            }

            lblCobrado.Text = sumCobrado.ToString("C0");
            lblPagado.Text = sumPagado.ToString("C0");

            // TODO: Asegúrate de que lblTotal exista en el diseñador
            decimal total = sumCobrado - sumPagado;
            lblTotal.Text = total.ToString("C0");
        }
        private void CargarHistorial()
        {
            HistorialFunciones.BindToGrid(DGViewHistorial);
            DGViewHistorial.ClearSelection();
            ActualizarTotalesPorMes();
        }

        private void DGViewHistorial_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Solo si cambiaron en la columna “Anulado”
            if (e.ColumnIndex < 0 || DGViewHistorial.Columns[e.ColumnIndex].Name != "Anulado")
                return;

            var row = DGViewHistorial.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["ID"].Value);
            bool anulado = Convert.ToBoolean(row.Cells["Anulado"].Value);

            // Actualizar en la BD
            HistorialFunciones.ModificarAnuladoHistorial(id, anulado);

            // Repintar fila
            DGViewHistorial.InvalidateRow(e.RowIndex);
        }

        private void DGViewHistorial_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = DGViewHistorial.Rows[e.RowIndex];
            if (row.Cells["Anulado"].Value is bool an && an)
                row.DefaultCellStyle.BackColor = Color.LightGray;
            else
                row.DefaultCellStyle.BackColor = Color.Gold;
        }
        private void BttnLimpiar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
            LimpiarCampos();
        }

        private void BttnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BttnRetroceder_Click(object sender, EventArgs e)
        {
            Ayudas.Volver(this);
        }

        private void LimpiarCampos()
        {
            // tu lógica para limpiar inputs si hace falta
        }
        private void bttnImprimirReporte_Click(object sender, EventArgs e)
        {
            HistorialFunciones.ImprimirHistorialMes(dtpFechaPagos.Value);
        }
    }
}
