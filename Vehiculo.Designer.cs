namespace Diegod
{
    partial class Vehiculo
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DGViewVehiculos = new DataGridView();
            label1 = new Label();
            txtPatente = new TextBox();
            label9 = new Label();
            label14 = new Label();
            txtNombre = new TextBox();
            txtId = new TextBox();
            BttnX = new Button();
            txtBuscar = new TextBox();
            txtObservacion = new TextBox();
            label13 = new Label();
            bttnModyAgr = new Button();
            bttnLimpiar = new Button();
            panel3 = new Panel();
            label6 = new Label();
            DateFechaUltimoServicio = new DateTimePicker();
            BttnRetroceder = new Button();
            bttnBuscar = new Button();
            txtBuscarID = new TextBox();
            txtBuscarPatente = new TextBox();
            chkActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)DGViewVehiculos).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // DGViewVehiculos
            // 
            DGViewVehiculos.Anchor = AnchorStyles.None;
            DGViewVehiculos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewVehiculos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewVehiculos.BackgroundColor = Color.White;
            DGViewVehiculos.BorderStyle = BorderStyle.None;
            DGViewVehiculos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGViewVehiculos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGViewVehiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gold;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DGViewVehiculos.DefaultCellStyle = dataGridViewCellStyle4;
            DGViewVehiculos.Location = new Point(12, 49);
            DGViewVehiculos.Margin = new Padding(3, 2, 3, 2);
            DGViewVehiculos.Name = "DGViewVehiculos";
            DGViewVehiculos.RowHeadersVisible = false;
            DGViewVehiculos.RowHeadersWidth = 51;
            DGViewVehiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewVehiculos.Size = new Size(846, 660);
            DGViewVehiculos.TabIndex = 200;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(15, 142);
            label1.Name = "label1";
            label1.Size = new Size(73, 21);
            label1.TabIndex = 53;
            label1.Text = "Patente:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtPatente
            // 
            txtPatente.Anchor = AnchorStyles.None;
            txtPatente.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPatente.Location = new Point(15, 165);
            txtPatente.Margin = new Padding(3, 2, 3, 2);
            txtPatente.Name = "txtPatente";
            txtPatente.Size = new Size(375, 33);
            txtPatente.TabIndex = 52;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(15, 79);
            label9.Name = "label9";
            label9.Size = new Size(77, 21);
            label9.TabIndex = 51;
            label9.Text = "Nombre:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.BackColor = Color.Gold;
            label14.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(15, 17);
            label14.Name = "label14";
            label14.Size = new Size(152, 38);
            label14.TabIndex = 41;
            label14.Text = "VEHICULO";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(15, 102);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(375, 33);
            txtNombre.TabIndex = 16;
            // 
            // txtId
            // 
            txtId.Anchor = AnchorStyles.None;
            txtId.Cursor = Cursors.IBeam;
            txtId.Font = new Font("Segoe UI", 18.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(294, 14);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(96, 41);
            txtId.TabIndex = 29;
            // 
            // BttnX
            // 
            BttnX.Anchor = AnchorStyles.None;
            BttnX.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnX.BackColor = Color.Red;
            BttnX.FlatStyle = FlatStyle.Flat;
            BttnX.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnX.ImeMode = ImeMode.NoControl;
            BttnX.Location = new Point(1235, 12);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 198;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += btnCerrar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.None;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(306, 12);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(552, 32);
            txtBuscar.TabIndex = 199;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.None;
            txtObservacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(15, 298);
            txtObservacion.Margin = new Padding(3, 2, 3, 2);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(375, 33);
            txtObservacion.TabIndex = 78;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(15, 275);
            label13.Name = "label13";
            label13.Size = new Size(110, 21);
            label13.TabIndex = 77;
            label13.Text = "Observacion:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bttnModyAgr
            // 
            bttnModyAgr.Anchor = AnchorStyles.None;
            bttnModyAgr.BackColor = Color.FromArgb(65, 36, 7);
            bttnModyAgr.FlatStyle = FlatStyle.Flat;
            bttnModyAgr.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnModyAgr.ForeColor = Color.Gold;
            bttnModyAgr.ImeMode = ImeMode.NoControl;
            bttnModyAgr.Location = new Point(864, 397);
            bttnModyAgr.Margin = new Padding(3, 2, 3, 2);
            bttnModyAgr.Name = "bttnModyAgr";
            bttnModyAgr.Size = new Size(403, 75);
            bttnModyAgr.TabIndex = 191;
            bttnModyAgr.Text = "OK";
            bttnModyAgr.UseVisualStyleBackColor = false;
            bttnModyAgr.Click += btnGuardar_Click;
            // 
            // bttnLimpiar
            // 
            bttnLimpiar.Anchor = AnchorStyles.None;
            bttnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnLimpiar.BackColor = Color.FromArgb(255, 128, 0);
            bttnLimpiar.FlatStyle = FlatStyle.Flat;
            bttnLimpiar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnLimpiar.ImeMode = ImeMode.NoControl;
            bttnLimpiar.Location = new Point(1112, 12);
            bttnLimpiar.Margin = new Padding(3, 2, 3, 2);
            bttnLimpiar.Name = "bttnLimpiar";
            bttnLimpiar.Size = new Size(79, 32);
            bttnLimpiar.TabIndex = 197;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            bttnLimpiar.Click += btnLimpiar_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(label6);
            panel3.Controls.Add(txtObservacion);
            panel3.Controls.Add(DateFechaUltimoServicio);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtPatente);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(txtNombre);
            panel3.Controls.Add(txtId);
            panel3.Location = new Point(864, 49);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(403, 344);
            panel3.TabIndex = 192;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(15, 207);
            label6.Name = "label6";
            label6.Size = new Size(108, 21);
            label6.TabIndex = 202;
            label6.Text = "Fecha Servis:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DateFechaUltimoServicio
            // 
            DateFechaUltimoServicio.Anchor = AnchorStyles.None;
            DateFechaUltimoServicio.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DateFechaUltimoServicio.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DateFechaUltimoServicio.Location = new Point(15, 231);
            DateFechaUltimoServicio.Name = "DateFechaUltimoServicio";
            DateFechaUltimoServicio.Size = new Size(375, 33);
            DateFechaUltimoServicio.TabIndex = 201;
            // 
            // BttnRetroceder
            // 
            BttnRetroceder.Anchor = AnchorStyles.None;
            BttnRetroceder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnRetroceder.BackColor = Color.FromArgb(255, 128, 0);
            BttnRetroceder.FlatStyle = FlatStyle.Flat;
            BttnRetroceder.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnRetroceder.ImeMode = ImeMode.NoControl;
            BttnRetroceder.Location = new Point(1197, 12);
            BttnRetroceder.Margin = new Padding(3, 2, 3, 2);
            BttnRetroceder.Name = "BttnRetroceder";
            BttnRetroceder.Size = new Size(32, 32);
            BttnRetroceder.TabIndex = 194;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += btnVolver_Click;
            // 
            // bttnBuscar
            // 
            bttnBuscar.Anchor = AnchorStyles.None;
            bttnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscar.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscar.FlatStyle = FlatStyle.Flat;
            bttnBuscar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscar.ImeMode = ImeMode.NoControl;
            bttnBuscar.Location = new Point(864, 13);
            bttnBuscar.Margin = new Padding(3, 2, 3, 2);
            bttnBuscar.Name = "bttnBuscar";
            bttnBuscar.Size = new Size(80, 32);
            bttnBuscar.TabIndex = 195;
            bttnBuscar.Text = "Buscar";
            bttnBuscar.UseVisualStyleBackColor = false;
            bttnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Anchor = AnchorStyles.None;
            txtBuscarID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarID.Location = new Point(12, 12);
            txtBuscarID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(97, 32);
            txtBuscarID.TabIndex = 196;
            // 
            // txtBuscarPatente
            // 
            txtBuscarPatente.Anchor = AnchorStyles.None;
            txtBuscarPatente.Font = new Font("Segoe UI", 13.8F);
            txtBuscarPatente.Location = new Point(115, 12);
            txtBuscarPatente.Margin = new Padding(3, 2, 3, 2);
            txtBuscarPatente.Name = "txtBuscarPatente";
            txtBuscarPatente.Size = new Size(185, 32);
            txtBuscarPatente.TabIndex = 201;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(1186, 690);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(82, 19);
            chkActivo.TabIndex = 202;
            chkActivo.Text = "checkBox1";
            chkActivo.UseVisualStyleBackColor = true;
            chkActivo.Visible = false;
            // 
            // Vehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(chkActivo);
            Controls.Add(txtBuscarPatente);
            Controls.Add(DGViewVehiculos);
            Controls.Add(BttnX);
            Controls.Add(txtBuscar);
            Controls.Add(bttnModyAgr);
            Controls.Add(bttnLimpiar);
            Controls.Add(panel3);
            Controls.Add(BttnRetroceder);
            Controls.Add(bttnBuscar);
            Controls.Add(txtBuscarID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Vehiculo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Vehículos";
            Load += Vehiculo_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewVehiculos).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGViewVehiculos;
        private Label label1;
        private TextBox txtPatente;
        private Label label9;
        private Label label14;
        private TextBox txtNombre;
        private TextBox txtId;
        private Button BttnX;
        private TextBox txtBuscar;
        private TextBox txtObservacion;
        private Label label13;
        private Button bttnModyAgr;
        private Button bttnLimpiar;
        private Panel panel3;
        private Button BttnRetroceder;
        private Button bttnBuscar;
        private TextBox txtBuscarID;
        private Label label6;
        private DateTimePicker DateFechaUltimoServicio;
        private TextBox txtBuscarPatente;
        private CheckBox chkActivo;
    }
}