namespace Diegod
{
    partial class Historial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DGViewHistorial = new DataGridView();
            BttnX = new Button();
            BttnRetroceder = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpFechaPagos = new DateTimePicker();
            lblCobrado = new Label();
            lblPagado = new Label();
            lblTotal = new Label();
            bttnImprimirReporte = new Button();
            ((System.ComponentModel.ISupportInitialize)DGViewHistorial).BeginInit();
            SuspendLayout();
            // 
            // DGViewHistorial
            // 
            DGViewHistorial.Anchor = AnchorStyles.None;
            DGViewHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewHistorial.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewHistorial.BackgroundColor = Color.White;
            DGViewHistorial.BorderStyle = BorderStyle.None;
            DGViewHistorial.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGViewHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGViewHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gold;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGViewHistorial.DefaultCellStyle = dataGridViewCellStyle2;
            DGViewHistorial.Location = new Point(12, 80);
            DGViewHistorial.Margin = new Padding(3, 2, 3, 2);
            DGViewHistorial.Name = "DGViewHistorial";
            DGViewHistorial.RowHeadersVisible = false;
            DGViewHistorial.RowHeadersWidth = 51;
            DGViewHistorial.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            DGViewHistorial.Size = new Size(1256, 629);
            DGViewHistorial.TabIndex = 245;
            // 
            // BttnX
            // 
            BttnX.Anchor = AnchorStyles.None;
            BttnX.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnX.BackColor = Color.Red;
            BttnX.FlatStyle = FlatStyle.Flat;
            BttnX.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnX.ImeMode = ImeMode.NoControl;
            BttnX.Location = new Point(1236, 9);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 243;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += BttnX_Click;
            // 
            // BttnRetroceder
            // 
            BttnRetroceder.Anchor = AnchorStyles.None;
            BttnRetroceder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnRetroceder.BackColor = Color.FromArgb(255, 128, 0);
            BttnRetroceder.FlatStyle = FlatStyle.Flat;
            BttnRetroceder.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnRetroceder.ImeMode = ImeMode.NoControl;
            BttnRetroceder.Location = new Point(1198, 9);
            BttnRetroceder.Margin = new Padding(3, 2, 3, 2);
            BttnRetroceder.Name = "BttnRetroceder";
            BttnRetroceder.Size = new Size(32, 32);
            BttnRetroceder.TabIndex = 239;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += BttnRetroceder_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(395, 28);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 246;
            label1.Text = "Cobrado:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(555, 27);
            label2.Name = "label2";
            label2.Size = new Size(72, 21);
            label2.TabIndex = 247;
            label2.Text = "Pagado:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(840, 28);
            label3.Name = "label3";
            label3.Size = new Size(115, 21);
            label3.TabIndex = 248;
            label3.Text = "Total del Mes:";
            // 
            // dtpFechaPagos
            // 
            dtpFechaPagos.Location = new Point(12, 26);
            dtpFechaPagos.Name = "dtpFechaPagos";
            dtpFechaPagos.Size = new Size(219, 23);
            dtpFechaPagos.TabIndex = 249;
            // 
            // lblCobrado
            // 
            lblCobrado.AutoSize = true;
            lblCobrado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCobrado.Location = new Point(480, 28);
            lblCobrado.Name = "lblCobrado";
            lblCobrado.Size = new Size(48, 21);
            lblCobrado.TabIndex = 250;
            lblCobrado.Text = "$0";
            // 
            // lblPagado
            // 
            lblPagado.AutoSize = true;
            lblPagado.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPagado.Location = new Point(633, 28);
            lblPagado.Name = "lblPagado";
            lblPagado.Size = new Size(48, 21);
            lblPagado.TabIndex = 251;
            lblPagado.Text = "$0";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotal.Location = new Point(961, 28);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(48, 21);
            lblTotal.TabIndex = 252;
            lblTotal.Text = "$0";
            // 
            // bttnImprimirReporte
            // 
            bttnImprimirReporte.Location = new Point(237, 26);
            bttnImprimirReporte.Name = "bttnImprimirReporte";
            bttnImprimirReporte.Size = new Size(150, 30);
            bttnImprimirReporte.TabIndex = 253;
            bttnImprimirReporte.Text = "Imprimir reporte";
            bttnImprimirReporte.UseVisualStyleBackColor = true;
            bttnImprimirReporte.Click += bttnImprimirReporte_Click;
            // 
            // Historial
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(bttnImprimirReporte);
            Controls.Add(lblTotal);
            Controls.Add(lblPagado);
            Controls.Add(lblCobrado);
            Controls.Add(dtpFechaPagos);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DGViewHistorial);
            Controls.Add(BttnX);
            Controls.Add(BttnRetroceder);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Historial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial";
            Load += Historial_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DGViewHistorial;
        private Button BttnX;
        private Button BttnRetroceder;
        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpFechaPagos;
        private Label lblCobrado;
        private Label lblPagado;
        private Label lblTotal;
        private Button bttnImprimirReporte;
    }
}