namespace Diegod
{
    partial class Credito
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            txtBuscarPrestamistaID = new TextBox();
            txtBuscarPrestamista = new TextBox();
            bttnBuscarPrestamista = new Button();
            DateBuscarFecha = new DateTimePicker();
            BttnRetroceder = new Button();
            bttnBuscar = new Button();
            txtBuscarID = new TextBox();
            DGViewPrestamista = new DataGridView();
            txtPrestamista = new TextBox();
            bttnLimpiar = new Button();
            panel3 = new Panel();
            DateFechaCredito = new DateTimePicker();
            label6 = new Label();
            txtObservacion = new TextBox();
            label4 = new Label();
            DateFechaVencimiento = new DateTimePicker();
            label13 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtMonto = new TextBox();
            label14 = new Label();
            DGViewCredito = new DataGridView();
            bttnAgregar = new Button();
            txtBuscar = new TextBox();
            BttnX = new Button();
            ((System.ComponentModel.ISupportInitialize)DGViewPrestamista).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewCredito).BeginInit();
            SuspendLayout();
            // 
            // txtBuscarPrestamistaID
            // 
            txtBuscarPrestamistaID.Anchor = AnchorStyles.None;
            txtBuscarPrestamistaID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarPrestamistaID.Location = new Point(864, 483);
            txtBuscarPrestamistaID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarPrestamistaID.Name = "txtBuscarPrestamistaID";
            txtBuscarPrestamistaID.Size = new Size(106, 32);
            txtBuscarPrestamistaID.TabIndex = 221;
            // 
            // txtBuscarPrestamista
            // 
            txtBuscarPrestamista.Anchor = AnchorStyles.None;
            txtBuscarPrestamista.Font = new Font("Segoe UI", 13.8F);
            txtBuscarPrestamista.Location = new Point(976, 483);
            txtBuscarPrestamista.Margin = new Padding(3, 2, 3, 2);
            txtBuscarPrestamista.Name = "txtBuscarPrestamista";
            txtBuscarPrestamista.Size = new Size(186, 32);
            txtBuscarPrestamista.TabIndex = 220;
            // 
            // bttnBuscarPrestamista
            // 
            bttnBuscarPrestamista.Anchor = AnchorStyles.None;
            bttnBuscarPrestamista.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscarPrestamista.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscarPrestamista.FlatStyle = FlatStyle.Flat;
            bttnBuscarPrestamista.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscarPrestamista.ImeMode = ImeMode.NoControl;
            bttnBuscarPrestamista.Location = new Point(1168, 483);
            bttnBuscarPrestamista.Margin = new Padding(3, 2, 3, 2);
            bttnBuscarPrestamista.Name = "bttnBuscarPrestamista";
            bttnBuscarPrestamista.Size = new Size(99, 32);
            bttnBuscarPrestamista.TabIndex = 219;
            bttnBuscarPrestamista.Text = "Buscar";
            bttnBuscarPrestamista.UseVisualStyleBackColor = false;
            bttnBuscarPrestamista.Click += BttnBuscarPrestamista_Click;
            // 
            // DateBuscarFecha
            // 
            DateBuscarFecha.Anchor = AnchorStyles.None;
            DateBuscarFecha.Location = new Point(612, 16);
            DateBuscarFecha.Name = "DateBuscarFecha";
            DateBuscarFecha.Size = new Size(247, 23);
            DateBuscarFecha.TabIndex = 208;
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
            BttnRetroceder.TabIndex = 211;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += bttnVolver_Click;
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
            bttnBuscar.TabIndex = 212;
            bttnBuscar.Text = "Buscar";
            bttnBuscar.UseVisualStyleBackColor = false;
            bttnBuscar.Click += BttnBuscarCredito_Click;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Anchor = AnchorStyles.None;
            txtBuscarID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarID.Location = new Point(12, 11);
            txtBuscarID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(101, 32);
            txtBuscarID.TabIndex = 213;
            // 
            // DGViewPrestamista
            // 
            DGViewPrestamista.Anchor = AnchorStyles.None;
            DGViewPrestamista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewPrestamista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewPrestamista.BackgroundColor = Color.White;
            DGViewPrestamista.BorderStyle = BorderStyle.None;
            DGViewPrestamista.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGViewPrestamista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGViewPrestamista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gold;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGViewPrestamista.DefaultCellStyle = dataGridViewCellStyle2;
            DGViewPrestamista.Location = new Point(865, 519);
            DGViewPrestamista.Margin = new Padding(3, 2, 3, 2);
            DGViewPrestamista.Name = "DGViewPrestamista";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGViewPrestamista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGViewPrestamista.RowHeadersVisible = false;
            DGViewPrestamista.RowHeadersWidth = 51;
            DGViewPrestamista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewPrestamista.Size = new Size(403, 190);
            DGViewPrestamista.TabIndex = 218;
            // 
            // txtPrestamista
            // 
            txtPrestamista.Anchor = AnchorStyles.None;
            txtPrestamista.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPrestamista.Location = new Point(13, 95);
            txtPrestamista.Margin = new Padding(3, 2, 3, 2);
            txtPrestamista.Name = "txtPrestamista";
            txtPrestamista.Size = new Size(375, 33);
            txtPrestamista.TabIndex = 93;
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
            bttnLimpiar.TabIndex = 214;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            bttnLimpiar.Click += bttnLimpiar_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(DateFechaCredito);
            panel3.Controls.Add(txtPrestamista);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(txtObservacion);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(DateFechaVencimiento);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtMonto);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(865, 47);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(403, 353);
            panel3.TabIndex = 210;
            // 
            // DateFechaCredito
            // 
            DateFechaCredito.Anchor = AnchorStyles.None;
            DateFechaCredito.Location = new Point(14, 212);
            DateFechaCredito.Name = "DateFechaCredito";
            DateFechaCredito.Size = new Size(375, 23);
            DateFechaCredito.TabIndex = 95;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(13, 284);
            label6.Name = "label6";
            label6.Size = new Size(110, 21);
            label6.TabIndex = 90;
            label6.Text = "Observación:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.None;
            txtObservacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(13, 307);
            txtObservacion.Margin = new Padding(3, 2, 3, 2);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(375, 33);
            txtObservacion.TabIndex = 87;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(13, 72);
            label4.Name = "label4";
            label4.Size = new Size(103, 21);
            label4.TabIndex = 84;
            label4.Text = "Prestamista:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateFechaVencimiento
            // 
            DateFechaVencimiento.Anchor = AnchorStyles.None;
            DateFechaVencimiento.Location = new Point(14, 258);
            DateFechaVencimiento.Name = "DateFechaVencimiento";
            DateFechaVencimiento.Size = new Size(375, 23);
            DateFechaVencimiento.TabIndex = 81;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(14, 234);
            label13.Name = "label13";
            label13.Size = new Size(159, 21);
            label13.TabIndex = 77;
            label13.Text = "Fecha Vencimiento:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(13, 188);
            label2.Name = "label2";
            label2.Size = new Size(141, 21);
            label2.TabIndex = 55;
            label2.Text = "Fecha de Credito:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(13, 130);
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
            txtMonto.Location = new Point(13, 153);
            txtMonto.Margin = new Padding(3, 2, 3, 2);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(375, 33);
            txtMonto.TabIndex = 52;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.BackColor = Color.Gold;
            label14.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(14, 10);
            label14.Name = "label14";
            label14.Size = new Size(133, 38);
            label14.TabIndex = 41;
            label14.Text = "CREDITO";
            // 
            // DGViewCredito
            // 
            DGViewCredito.Anchor = AnchorStyles.None;
            DGViewCredito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewCredito.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewCredito.BackgroundColor = Color.White;
            DGViewCredito.BorderStyle = BorderStyle.None;
            DGViewCredito.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            DGViewCredito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            DGViewCredito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.Gold;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            DGViewCredito.DefaultCellStyle = dataGridViewCellStyle5;
            DGViewCredito.Location = new Point(12, 47);
            DGViewCredito.Margin = new Padding(3, 2, 3, 2);
            DGViewCredito.Name = "DGViewCredito";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            DGViewCredito.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            DGViewCredito.RowHeadersVisible = false;
            DGViewCredito.RowHeadersWidth = 51;
            DGViewCredito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewCredito.Size = new Size(846, 662);
            DGViewCredito.TabIndex = 217;
            // 
            // bttnAgregar
            // 
            bttnAgregar.Anchor = AnchorStyles.None;
            bttnAgregar.BackColor = Color.FromArgb(65, 36, 7);
            bttnAgregar.FlatStyle = FlatStyle.Flat;
            bttnAgregar.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnAgregar.ForeColor = Color.Gold;
            bttnAgregar.ImeMode = ImeMode.NoControl;
            bttnAgregar.Location = new Point(865, 404);
            bttnAgregar.Margin = new Padding(3, 2, 3, 2);
            bttnAgregar.Name = "bttnAgregar";
            bttnAgregar.Size = new Size(403, 75);
            bttnAgregar.TabIndex = 209;
            bttnAgregar.Text = "OK";
            bttnAgregar.UseVisualStyleBackColor = false;
            bttnAgregar.Click += BttnAgregar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.None;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(119, 11);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(487, 32);
            txtBuscar.TabIndex = 216;
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
            BttnX.TabIndex = 215;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += bttnSalir_Click;
            // 
            // Credito
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(txtBuscarPrestamistaID);
            Controls.Add(txtBuscarPrestamista);
            Controls.Add(bttnBuscarPrestamista);
            Controls.Add(DateBuscarFecha);
            Controls.Add(BttnRetroceder);
            Controls.Add(bttnBuscar);
            Controls.Add(txtBuscarID);
            Controls.Add(DGViewPrestamista);
            Controls.Add(bttnLimpiar);
            Controls.Add(panel3);
            Controls.Add(DGViewCredito);
            Controls.Add(bttnAgregar);
            Controls.Add(txtBuscar);
            Controls.Add(BttnX);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Credito";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crédito";
            Load += Credito_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewPrestamista).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewCredito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label13;
        private TextBox txtDireccion;
        private Label label11;
        private ComboBox ComboxTipo_Pago;
        private Panel panel3;
        private Label label10;
        private Label label43;
        private ComboBox ComboxPrestamista;
        private Label label7;
        private TextBox txtDni;
        private CheckBox chkActivo;
        private Label label6;
        private DateTimePicker DateFechaVencimiento;
        private Label label4;
        private TextBox txtCargo;
        private TextBox txtTelefono;
        private Label label2;
        private TextBox txtEmail;
        private Label label1;
        private TextBox txtApellido;
        private Label label9;
        private Label label14;
        private TextBox txtNombre;
        private Button BttnX;
        private Button bttnAgregar;
        private Button bttnLimpiar;
        private Button BttnRetroceder;
        private Button bttnRestablecer;
        private TextBox txtBuscarPrestamistaID;
        private TextBox txtBuscarPrestamista;
        private Button bttnBuscarPrestamista;
        private DateTimePicker DateBuscarFecha;
        private Button bttnBuscar;
        private TextBox txtBuscarID;
        private DataGridView DGViewPrestamista;
        private TextBox txtPrestamista;
        private TextBox txtObservacion;
        private TextBox txtMonto;
        private DataGridView DGViewCredito;
        private DateTimePicker dtpFechaVencimiento;
        private TextBox txtBuscar;
        private TextBox textBox1;
        private TextBox txtId;
        private DateTimePicker DateFechaCredito;
    }
}