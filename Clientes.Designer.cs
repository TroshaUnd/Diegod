namespace Diegod
{
    partial class Clientes
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
            txtBuscar = new TextBox();
            DGViewCliente = new DataGridView();
            panel3 = new Panel();
            txtObservacion = new TextBox();
            label13 = new Label();
            label12 = new Label();
            txtDireccion = new TextBox();
            label8 = new Label();
            ComboxLocalidad = new ComboBox();
            ComboxProvincia = new ComboBox();
            label7 = new Label();
            txtCuit = new TextBox();
            label3 = new Label();
            txtTelefono = new TextBox();
            label2 = new Label();
            txtEmail = new TextBox();
            label1 = new Label();
            txtApellido = new TextBox();
            label9 = new Label();
            label14 = new Label();
            txtNombre = new TextBox();
            txtId = new TextBox();
            BttnX = new Button();
            bttnModyAgr = new Button();
            bttnLimpiar = new Button();
            BttnRetroceder = new Button();
            txtBuscarID = new TextBox();
            bttnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)DGViewCliente).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.None;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(115, 11);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(735, 32);
            txtBuscar.TabIndex = 179;
            // 
            // DGViewCliente
            // 
            DGViewCliente.Anchor = AnchorStyles.None;
            DGViewCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewCliente.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewCliente.BackgroundColor = Color.White;
            DGViewCliente.BorderStyle = BorderStyle.None;
            DGViewCliente.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGViewCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGViewCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gold;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGViewCliente.DefaultCellStyle = dataGridViewCellStyle2;
            DGViewCliente.Location = new Point(12, 50);
            DGViewCliente.Margin = new Padding(3, 2, 3, 2);
            DGViewCliente.Name = "DGViewCliente";
            DGViewCliente.RowHeadersVisible = false;
            DGViewCliente.RowHeadersWidth = 51;
            DGViewCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewCliente.Size = new Size(838, 659);
            DGViewCliente.TabIndex = 170;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(txtObservacion);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(txtDireccion);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(ComboxLocalidad);
            panel3.Controls.Add(ComboxProvincia);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(txtCuit);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtTelefono);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(txtEmail);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtApellido);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(txtNombre);
            panel3.Controls.Add(txtId);
            panel3.Location = new Point(865, 50);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(403, 562);
            panel3.TabIndex = 172;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.None;
            txtObservacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(13, 513);
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
            label13.Location = new Point(13, 490);
            label13.Name = "label13";
            label13.Size = new Size(110, 21);
            label13.TabIndex = 77;
            label13.Text = "Observacion:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.ImeMode = ImeMode.NoControl;
            label12.Location = new Point(13, 429);
            label12.Name = "label12";
            label12.Size = new Size(87, 21);
            label12.TabIndex = 75;
            label12.Text = "Direccion:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.None;
            txtDireccion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtDireccion.Location = new Point(13, 452);
            txtDireccion.Margin = new Padding(3, 2, 3, 2);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(375, 33);
            txtDireccion.TabIndex = 74;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.ImeMode = ImeMode.NoControl;
            label8.Location = new Point(13, 350);
            label8.Name = "label8";
            label8.Size = new Size(96, 21);
            label8.TabIndex = 69;
            label8.Text = "Residencia:";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ComboxLocalidad
            // 
            ComboxLocalidad.Anchor = AnchorStyles.None;
            ComboxLocalidad.FormattingEnabled = true;
            ComboxLocalidad.Location = new Point(13, 403);
            ComboxLocalidad.Name = "ComboxLocalidad";
            ComboxLocalidad.Size = new Size(375, 23);
            ComboxLocalidad.TabIndex = 68;
            // 
            // ComboxProvincia
            // 
            ComboxProvincia.Anchor = AnchorStyles.None;
            ComboxProvincia.FormattingEnabled = true;
            ComboxProvincia.Location = new Point(13, 374);
            ComboxProvincia.Name = "ComboxProvincia";
            ComboxProvincia.Size = new Size(375, 23);
            ComboxProvincia.TabIndex = 67;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.None;
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.ImeMode = ImeMode.NoControl;
            label7.Location = new Point(13, 290);
            label7.Name = "label7";
            label7.Size = new Size(45, 21);
            label7.TabIndex = 66;
            label7.Text = "Cuit:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCuit
            // 
            txtCuit.Anchor = AnchorStyles.None;
            txtCuit.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtCuit.Location = new Point(13, 313);
            txtCuit.Margin = new Padding(3, 2, 3, 2);
            txtCuit.Name = "txtCuit";
            txtCuit.Size = new Size(375, 33);
            txtCuit.TabIndex = 65;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(13, 231);
            label3.Name = "label3";
            label3.Size = new Size(81, 21);
            label3.TabIndex = 57;
            label3.Text = "Telefono:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.None;
            txtTelefono.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTelefono.Location = new Point(13, 254);
            txtTelefono.Margin = new Padding(3, 2, 3, 2);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(375, 33);
            txtTelefono.TabIndex = 56;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(13, 170);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 55;
            label2.Text = "Email:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.None;
            txtEmail.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtEmail.Location = new Point(13, 193);
            txtEmail.Margin = new Padding(3, 2, 3, 2);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(375, 33);
            txtEmail.TabIndex = 54;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.ImeMode = ImeMode.NoControl;
            label1.Location = new Point(13, 111);
            label1.Name = "label1";
            label1.Size = new Size(79, 21);
            label1.TabIndex = 53;
            label1.Text = "Apellido:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtApellido
            // 
            txtApellido.Anchor = AnchorStyles.None;
            txtApellido.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtApellido.Location = new Point(13, 134);
            txtApellido.Margin = new Padding(3, 2, 3, 2);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(375, 33);
            txtApellido.TabIndex = 52;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.None;
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(13, 53);
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
            label14.Location = new Point(13, 13);
            label14.Name = "label14";
            label14.Size = new Size(120, 38);
            label14.TabIndex = 41;
            label14.Text = "Clientes";
            // 
            // txtNombre
            // 
            txtNombre.Anchor = AnchorStyles.None;
            txtNombre.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNombre.Location = new Point(13, 76);
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
            txtId.Location = new Point(292, 10);
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
            BttnX.Location = new Point(1236, 11);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 178;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += BttnX_Click;
            // 
            // bttnModyAgr
            // 
            bttnModyAgr.Anchor = AnchorStyles.None;
            bttnModyAgr.BackColor = Color.FromArgb(65, 36, 7);
            bttnModyAgr.FlatStyle = FlatStyle.Flat;
            bttnModyAgr.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnModyAgr.ForeColor = Color.Gold;
            bttnModyAgr.ImeMode = ImeMode.NoControl;
            bttnModyAgr.Location = new Point(866, 634);
            bttnModyAgr.Margin = new Padding(3, 2, 3, 2);
            bttnModyAgr.Name = "bttnModyAgr";
            bttnModyAgr.Size = new Size(403, 75);
            bttnModyAgr.TabIndex = 171;
            bttnModyAgr.Text = "OK";
            bttnModyAgr.UseVisualStyleBackColor = false;
            bttnModyAgr.Click += bttnModyAgr_Click;
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
            bttnLimpiar.TabIndex = 177;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            bttnLimpiar.Click += bttnLimpiar_Click;
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
            BttnRetroceder.TabIndex = 174;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += BttnRetroceder_Click;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Anchor = AnchorStyles.None;
            txtBuscarID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarID.Location = new Point(12, 11);
            txtBuscarID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(97, 32);
            txtBuscarID.TabIndex = 176;
            // 
            // bttnBuscar
            // 
            bttnBuscar.Anchor = AnchorStyles.None;
            bttnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscar.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscar.FlatStyle = FlatStyle.Flat;
            bttnBuscar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscar.ImeMode = ImeMode.NoControl;
            bttnBuscar.Location = new Point(866, 11);
            bttnBuscar.Margin = new Padding(3, 2, 3, 2);
            bttnBuscar.Name = "bttnBuscar";
            bttnBuscar.Size = new Size(80, 32);
            bttnBuscar.TabIndex = 175;
            bttnBuscar.Text = "Buscar";
            bttnBuscar.UseVisualStyleBackColor = false;
            bttnBuscar.Click += bttnBuscar_Click;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(txtBuscar);
            Controls.Add(DGViewCliente);
            Controls.Add(panel3);
            Controls.Add(BttnX);
            Controls.Add(bttnModyAgr);
            Controls.Add(bttnLimpiar);
            Controls.Add(BttnRetroceder);
            Controls.Add(txtBuscarID);
            Controls.Add(bttnBuscar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Clientes";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Clientes_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewCliente).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBuscar;
        private DataGridView DGViewCliente;
        private Panel panel3;
        private TextBox txtObservacion;
        private Label label8;
        private ComboBox ComboxLocalidad;
        private ComboBox ComboxProvincia;
        private Label label7;
        private TextBox txtCuit;
        private Label label3;
        private TextBox txtTelefono;
        private Label label2;
        private TextBox txtEmail;
        private Label label1;
        private TextBox txtApellido;
        private Label label9;
        private Label label14;
        private TextBox txtNombre;
        private TextBox txtId;
        private Button BttnX;
        private Button bttnModyAgr;
        private Button bttnLimpiar;
        private Button BttnRetroceder;
        private TextBox txtBuscarID;
        private Button bttnBuscar;
        private Label label13;
        private Label label12;
        private TextBox txtDireccion;
    }
}