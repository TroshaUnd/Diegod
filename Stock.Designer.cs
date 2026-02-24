namespace Diegod
{
    partial class Stock
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
            DGViewStock = new DataGridView();
            txtLugar = new TextBox();
            label9 = new Label();
            label14 = new Label();
            txtProducto = new TextBox();
            txtId = new TextBox();
            BttnX = new Button();
            bttnLimpiar = new Button();
            txtBuscar = new TextBox();
            label3 = new Label();
            bttnModyAgr = new Button();
            panel3 = new Panel();
            txtObservacion = new TextBox();
            BttnRetroceder = new Button();
            bttnBuscar = new Button();
            txtBuscarID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGViewStock).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // DGViewStock
            // 
            DGViewStock.Anchor = AnchorStyles.None;
            DGViewStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewStock.BackgroundColor = Color.White;
            DGViewStock.BorderStyle = BorderStyle.None;
            DGViewStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGViewStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGViewStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gold;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGViewStock.DefaultCellStyle = dataGridViewCellStyle2;
            DGViewStock.Location = new Point(12, 46);
            DGViewStock.Margin = new Padding(3, 2, 3, 2);
            DGViewStock.Name = "DGViewStock";
            DGViewStock.RowHeadersVisible = false;
            DGViewStock.RowHeadersWidth = 51;
            DGViewStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewStock.Size = new Size(967, 663);
            DGViewStock.TabIndex = 200;
            // 
            // txtLugar
            // 
            txtLugar.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtLugar.Location = new Point(15, 162);
            txtLugar.Margin = new Padding(3, 2, 3, 2);
            txtLugar.Name = "txtLugar";
            txtLugar.Size = new Size(254, 33);
            txtLugar.TabIndex = 56;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.ImeMode = ImeMode.NoControl;
            label9.Location = new Point(15, 78);
            label9.Name = "label9";
            label9.Size = new Size(84, 21);
            label9.TabIndex = 51;
            label9.Text = "Producto:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Gold;
            label14.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(15, 16);
            label14.Name = "label14";
            label14.Size = new Size(104, 38);
            label14.TabIndex = 41;
            label14.Text = "STOCK";
            // 
            // txtProducto
            // 
            txtProducto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtProducto.Location = new Point(15, 101);
            txtProducto.Margin = new Padding(3, 2, 3, 2);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(254, 33);
            txtProducto.TabIndex = 16;
            // 
            // txtId
            // 
            txtId.Cursor = Cursors.IBeam;
            txtId.Font = new Font("Segoe UI", 18.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(173, 16);
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
            BttnX.Location = new Point(1236, 9);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 198;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += btnSalir_Click;
            // 
            // bttnLimpiar
            // 
            bttnLimpiar.Anchor = AnchorStyles.None;
            bttnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnLimpiar.BackColor = Color.DarkOrange;
            bttnLimpiar.FlatStyle = FlatStyle.Flat;
            bttnLimpiar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnLimpiar.ForeColor = Color.Black;
            bttnLimpiar.ImeMode = ImeMode.NoControl;
            bttnLimpiar.Location = new Point(1109, 9);
            bttnLimpiar.Margin = new Padding(3, 2, 3, 2);
            bttnLimpiar.Name = "bttnLimpiar";
            bttnLimpiar.Size = new Size(83, 32);
            bttnLimpiar.TabIndex = 193;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            bttnLimpiar.Click += bttnLimpiar_Click;
            // 
            // txtBuscar
            // 
            txtBuscar.Anchor = AnchorStyles.None;
            txtBuscar.Font = new Font("Segoe UI", 13.8F);
            txtBuscar.Location = new Point(136, 9);
            txtBuscar.Margin = new Padding(3, 2, 3, 2);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(738, 32);
            txtBuscar.TabIndex = 199;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(15, 139);
            label3.Name = "label3";
            label3.Size = new Size(58, 21);
            label3.TabIndex = 57;
            label3.Text = "Lugar:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bttnModyAgr
            // 
            bttnModyAgr.Anchor = AnchorStyles.None;
            bttnModyAgr.BackColor = Color.FromArgb(65, 36, 7);
            bttnModyAgr.FlatStyle = FlatStyle.Flat;
            bttnModyAgr.Font = new Font("Segoe UI", 25.8000011F, FontStyle.Bold);
            bttnModyAgr.ForeColor = Color.Gold;
            bttnModyAgr.ImeMode = ImeMode.NoControl;
            bttnModyAgr.Location = new Point(985, 267);
            bttnModyAgr.Margin = new Padding(3, 2, 3, 2);
            bttnModyAgr.Name = "bttnModyAgr";
            bttnModyAgr.Size = new Size(283, 75);
            bttnModyAgr.TabIndex = 191;
            bttnModyAgr.Text = "OK";
            bttnModyAgr.UseVisualStyleBackColor = false;
            bttnModyAgr.Click += btnAgregarModificar_Click;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(txtObservacion);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtLugar);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(txtProducto);
            panel3.Controls.Add(txtId);
            panel3.Location = new Point(985, 45);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(283, 218);
            panel3.TabIndex = 192;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.None;
            txtObservacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(258, 1387);
            txtObservacion.Margin = new Padding(3, 2, 3, 2);
            txtObservacion.Name = "txtObservacion";
            txtObservacion.Size = new Size(375, 33);
            txtObservacion.TabIndex = 76;
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
            bttnBuscar.Location = new Point(880, 9);
            bttnBuscar.Margin = new Padding(3, 2, 3, 2);
            bttnBuscar.Name = "bttnBuscar";
            bttnBuscar.Size = new Size(99, 32);
            bttnBuscar.TabIndex = 195;
            bttnBuscar.Text = "Buscar";
            bttnBuscar.UseVisualStyleBackColor = false;
            bttnBuscar.Click += bttnBuscar_Click;
            // 
            // txtBuscarID
            // 
            txtBuscarID.Anchor = AnchorStyles.None;
            txtBuscarID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarID.Location = new Point(12, 9);
            txtBuscarID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarID.Name = "txtBuscarID";
            txtBuscarID.Size = new Size(120, 32);
            txtBuscarID.TabIndex = 196;
            // 
            // Stock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(DGViewStock);
            Controls.Add(BttnX);
            Controls.Add(bttnLimpiar);
            Controls.Add(txtBuscar);
            Controls.Add(bttnModyAgr);
            Controls.Add(panel3);
            Controls.Add(BttnRetroceder);
            Controls.Add(bttnBuscar);
            Controls.Add(txtBuscarID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Stock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Stock";
            Load += Stock_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewStock).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGViewStock;
        private TextBox txtLugar;
        private Label label9;
        private Label label14;
        private TextBox txtProducto;
        private TextBox txtId;
        private Button BttnX;
        private Button bttnLimpiar;
        private TextBox txtBuscar;
        private Label label3;
        private Button bttnModyAgr;
        private Panel panel3;
        private TextBox txtObservacion;
        private Button BttnRetroceder;
        private Button bttnBuscar;
        private TextBox txtBuscarID;
    }
}