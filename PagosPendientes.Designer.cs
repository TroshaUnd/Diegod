namespace Diegod
{
    partial class PagosPendientes
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            bttnAgregar = new Button();
            txtBuscar = new TextBox();
            BttnX = new Button();
            DateFechaPago = new DateTimePicker();
            bttnLimpiar = new Button();
            panel3 = new Panel();
            txtTrabajoID = new TextBox();
            txtEmpleadoID = new TextBox();
            label2 = new Label();
            txtCreditoID = new TextBox();
            label1 = new Label();
            txtMonto = new TextBox();
            txtMovimientoID = new TextBox();
            label14 = new Label();
            txtID = new TextBox();
            DGViewPagosPendientes = new DataGridView();
            txtBuscarID = new TextBox();
            DateBuscarFecha = new DateTimePicker();
            BttnRetroceder = new Button();
            bttnBuscar = new Button();
            panel1 = new Panel();
            dtpVencimiento = new DateTimePicker();
            label5 = new Label();
            label7 = new Label();
            bttnAgregarVencimiento = new Button();
            DGViewPagosPagar = new DataGridView();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewPagosPendientes).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewPagosPagar).BeginInit();
            SuspendLayout();
            // 
            // bttnAgregar
            // 
            bttnAgregar.Anchor = AnchorStyles.None;
            bttnAgregar.BackColor = Color.FromArgb(65, 36, 7);
            bttnAgregar.FlatStyle = FlatStyle.Flat;
            bttnAgregar.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnAgregar.ForeColor = Color.Gold;
            bttnAgregar.ImeMode = ImeMode.NoControl;
            bttnAgregar.Location = new Point(865, 455);
            bttnAgregar.Margin = new Padding(3, 2, 3, 2);
            bttnAgregar.Name = "bttnAgregar";
            bttnAgregar.Size = new Size(403, 75);
            bttnAgregar.TabIndex = 223;
            bttnAgregar.Text = "OK";
            bttnAgregar.UseVisualStyleBackColor = false;
            bttnAgregar.Click += bttnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.None;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(116, 11);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(445, 32);
            txtBuscar.TabIndex = 230;
            // 
            // BttnX
            // 
            BttnX.Anchor = AnchorStyles.None;
            BttnX.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnX.BackColor = Color.Red;
            BttnX.FlatStyle = FlatStyle.Flat;
            BttnX.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnX.ImeMode = ImeMode.NoControl;
            BttnX.Location = new Point(1236, 11);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 229;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += BttnX_Click;
            // 
            // DateFechaPago
            // 
            DateFechaPago.Anchor = AnchorStyles.None;
            DateFechaPago.Location = new Point(13, 145);
            DateFechaPago.Name = "DateFechaPago";
            DateFechaPago.Size = new Size(375, 23);
            DateFechaPago.TabIndex = 95;
            // 
            // bttnLimpiar
            // 
            bttnLimpiar.Anchor = AnchorStyles.None;
            bttnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnLimpiar.BackColor = Color.FromArgb(255, 128, 0);
            bttnLimpiar.FlatStyle = FlatStyle.Flat;
            bttnLimpiar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnLimpiar.ImeMode = ImeMode.NoControl;
            bttnLimpiar.Location = new Point(1113, 11);
            bttnLimpiar.Margin = new Padding(3, 2, 3, 2);
            bttnLimpiar.Name = "bttnLimpiar";
            bttnLimpiar.Size = new Size(79, 32);
            bttnLimpiar.TabIndex = 228;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            bttnLimpiar.Click += BttnLimpiar_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(txtTrabajoID);
            panel3.Controls.Add(DateFechaPago);
            panel3.Controls.Add(txtEmpleadoID);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtCreditoID);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtMonto);
            panel3.Controls.Add(txtMovimientoID);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(865, 258);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(403, 193);
            panel3.TabIndex = 224;
            // 
            // txtTrabajoID
            // 
            txtTrabajoID.Anchor = AnchorStyles.None;
            txtTrabajoID.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTrabajoID.Location = new Point(372, 21);
            txtTrabajoID.Margin = new Padding(3, 2, 3, 2);
            txtTrabajoID.Name = "txtTrabajoID";
            txtTrabajoID.Size = new Size(31, 33);
            txtTrabajoID.TabIndex = 98;
            txtTrabajoID.Visible = false;
            // 
            // txtEmpleadoID
            // 
            txtEmpleadoID.Anchor = AnchorStyles.None;
            txtEmpleadoID.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmpleadoID.Location = new Point(335, 21);
            txtEmpleadoID.Margin = new Padding(3, 2, 3, 2);
            txtEmpleadoID.Name = "txtEmpleadoID";
            txtEmpleadoID.Size = new Size(31, 33);
            txtEmpleadoID.TabIndex = 97;
            txtEmpleadoID.Visible = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(12, 121);
            label2.Name = "label2";
            label2.Size = new Size(124, 21);
            label2.TabIndex = 55;
            label2.Text = "Fecha de Pago:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCreditoID
            // 
            txtCreditoID.Anchor = AnchorStyles.None;
            txtCreditoID.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCreditoID.Location = new Point(298, 21);
            txtCreditoID.Margin = new Padding(3, 2, 3, 2);
            txtCreditoID.Name = "txtCreditoID";
            txtCreditoID.Size = new Size(31, 33);
            txtCreditoID.TabIndex = 96;
            txtCreditoID.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(12, 63);
            label1.Name = "label1";
            label1.Size = new Size(65, 21);
            label1.TabIndex = 53;
            label1.Text = "Monto:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMonto
            // 
            txtMonto.Anchor = AnchorStyles.None;
            txtMonto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMonto.Location = new Point(12, 86);
            txtMonto.Margin = new Padding(3, 2, 3, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(375, 33);
            txtMonto.TabIndex = 52;
            // 
            // txtMovimientoID
            // 
            txtMovimientoID.Anchor = AnchorStyles.None;
            txtMovimientoID.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtMovimientoID.Location = new Point(261, 21);
            txtMovimientoID.Margin = new Padding(3, 2, 3, 2);
            txtMovimientoID.Name = "txtMovimientoID";
            txtMovimientoID.Size = new Size(31, 33);
            txtMovimientoID.TabIndex = 94;
            txtMovimientoID.Visible = false;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.BackColor = Color.Gold;
            label14.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(12, 16);
            label14.Name = "label14";
            label14.Size = new Size(251, 38);
            label14.TabIndex = 41;
            label14.Text = "REGISTRAR PAGO";
            // 
            // txtID
            // 
            txtID.Anchor = AnchorStyles.None;
            txtID.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtID.Location = new Point(303, 50);
            txtID.Margin = new Padding(3, 2, 3, 2);
            txtID.Name = "txtID";
            txtID.Size = new Size(84, 33);
            txtID.TabIndex = 94;
            // 
            // DGViewPagosPendientes
            // 
            DGViewPagosPendientes.Anchor = AnchorStyles.None;
            DGViewPagosPendientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewPagosPendientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewPagosPendientes.BackgroundColor = Color.White;
            DGViewPagosPendientes.BorderStyle = BorderStyle.None;
            DGViewPagosPendientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DGViewPagosPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DGViewPagosPendientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gold;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DGViewPagosPendientes.DefaultCellStyle = dataGridViewCellStyle6;
            DGViewPagosPendientes.Location = new Point(12, 47);
            DGViewPagosPendientes.Margin = new Padding(3, 2, 3, 2);
            DGViewPagosPendientes.Name = "DGViewPagosPendientes";
            DGViewPagosPendientes.RowHeadersVisible = false;
            DGViewPagosPendientes.RowHeadersWidth = 51;
            DGViewPagosPendientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewPagosPendientes.Size = new Size(847, 330);
            DGViewPagosPendientes.TabIndex = 231;
            DGViewPagosPendientes.SelectionChanged += DGViewPagosPendientes_SelectionChanged;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Anchor = AnchorStyles.None;
            txtBuscarID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarID.Location = new Point(12, 11);
            txtBuscarID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(98, 32);
            txtBuscarID.TabIndex = 227;
            // 
            // DateBuscarFecha
            // 
            DateBuscarFecha.Anchor = AnchorStyles.None;
            DateBuscarFecha.Location = new Point(567, 16);
            DateBuscarFecha.Name = "DateBuscarFecha";
            DateBuscarFecha.Size = new Size(292, 23);
            DateBuscarFecha.TabIndex = 222;
            // 
            // BttnRetroceder
            // 
            BttnRetroceder.Anchor = AnchorStyles.None;
            BttnRetroceder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnRetroceder.BackColor = Color.FromArgb(255, 128, 0);
            BttnRetroceder.FlatStyle = FlatStyle.Flat;
            BttnRetroceder.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnRetroceder.ImeMode = ImeMode.NoControl;
            BttnRetroceder.Location = new Point(1198, 11);
            BttnRetroceder.Margin = new Padding(3, 2, 3, 2);
            BttnRetroceder.Name = "BttnRetroceder";
            BttnRetroceder.Size = new Size(32, 32);
            BttnRetroceder.TabIndex = 225;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += BttnRetroceder_Click;
            // 
            // bttnBuscar
            // 
            bttnBuscar.Anchor = AnchorStyles.None;
            bttnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscar.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscar.FlatStyle = FlatStyle.Flat;
            bttnBuscar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscar.ImeMode = ImeMode.NoControl;
            bttnBuscar.Location = new Point(865, 11);
            bttnBuscar.Margin = new Padding(3, 2, 3, 2);
            bttnBuscar.Name = "bttnBuscar";
            bttnBuscar.Size = new Size(92, 32);
            bttnBuscar.TabIndex = 226;
            bttnBuscar.Text = "Buscar";
            bttnBuscar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.DarkGoldenrod;
            panel1.Controls.Add(txtID);
            panel1.Controls.Add(dtpVencimiento);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Location = new Point(865, 48);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(403, 127);
            panel1.TabIndex = 225;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Anchor = AnchorStyles.None;
            dtpVencimiento.Location = new Point(12, 85);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(375, 23);
            dtpVencimiento.TabIndex = 95;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(11, 61);
            label5.Name = "label5";
            label5.Size = new Size(182, 21);
            label5.TabIndex = 55;
            label5.Text = "Fecha de Vencimiento:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.Gold;
            label7.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(11, 10);
            label7.Name = "label7";
            label7.Size = new Size(366, 38);
            label7.TabIndex = 41;
            label7.Text = "REGISTRAR VENCIMIENTO";
            // 
            // bttnAgregarVencimiento
            // 
            bttnAgregarVencimiento.Anchor = AnchorStyles.None;
            bttnAgregarVencimiento.BackColor = Color.FromArgb(65, 36, 7);
            bttnAgregarVencimiento.FlatStyle = FlatStyle.Flat;
            bttnAgregarVencimiento.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnAgregarVencimiento.ForeColor = Color.Gold;
            bttnAgregarVencimiento.ImeMode = ImeMode.NoControl;
            bttnAgregarVencimiento.Location = new Point(865, 179);
            bttnAgregarVencimiento.Margin = new Padding(3, 2, 3, 2);
            bttnAgregarVencimiento.Name = "bttnAgregarVencimiento";
            bttnAgregarVencimiento.Size = new Size(403, 75);
            bttnAgregarVencimiento.TabIndex = 232;
            bttnAgregarVencimiento.Text = "OK";
            bttnAgregarVencimiento.UseVisualStyleBackColor = false;
            bttnAgregarVencimiento.Click += bttnAgregarVencimiento_Click;
            // 
            // DGViewPagosPagar
            // 
            DGViewPagosPagar.Anchor = AnchorStyles.None;
            DGViewPagosPagar.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewPagosPagar.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewPagosPagar.BackgroundColor = Color.White;
            DGViewPagosPagar.BorderStyle = BorderStyle.None;
            DGViewPagosPagar.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            DGViewPagosPagar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            DGViewPagosPagar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.Gold;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle8.SelectionForeColor = Color.Black;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            DGViewPagosPagar.DefaultCellStyle = dataGridViewCellStyle8;
            DGViewPagosPagar.Location = new Point(12, 381);
            DGViewPagosPagar.Margin = new Padding(3, 2, 3, 2);
            DGViewPagosPagar.Name = "DGViewPagosPagar";
            DGViewPagosPagar.RowHeadersVisible = false;
            DGViewPagosPagar.RowHeadersWidth = 51;
            DGViewPagosPagar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewPagosPagar.Size = new Size(847, 328);
            DGViewPagosPagar.TabIndex = 233;
            // 
            // PagosPendientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(DGViewPagosPagar);
            Controls.Add(bttnAgregarVencimiento);
            Controls.Add(panel1);
            Controls.Add(bttnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(BttnX);
            Controls.Add(bttnLimpiar);
            Controls.Add(panel3);
            Controls.Add(DGViewPagosPendientes);
            Controls.Add(txtBuscarID);
            Controls.Add(DateBuscarFecha);
            Controls.Add(BttnRetroceder);
            Controls.Add(bttnBuscar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PagosPendientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PagosPendientes";
            Load += PagosPendientes_Load;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewPagosPendientes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewPagosPagar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button bttnAgregar;
        private TextBox txtBuscar;
        private Button BttnX;
        private DateTimePicker DateFechaPago;
        private Button bttnLimpiar;
        private Panel panel3;
        private TextBox txtID;
        private Label label2;
        private Label label1;
        private TextBox txtMonto;
        private Label label14;
        private DataGridView DGViewPagosPendientes;
        private TextBox txtBuscarID;
        private DateTimePicker DateBuscarFecha;
        private Button BttnRetroceder;
        private Button bttnBuscar;
        private Panel panel1;
        private TextBox txtTrabajoID;
        private TextBox txtEmpleadoID;
        private TextBox txtCreditoID;
        private DateTimePicker dtpVencimiento;
        private TextBox txtMovimientoID;
        private Label label5;
        private Label label7;
        private Button bttnAgregarVencimiento;
        private DataGridView DGViewPagosPagar;
    }
}