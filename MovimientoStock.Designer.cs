namespace Diegod
{
    partial class MovimientoStock
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
            DGViewMovimientoStock = new DataGridView();
            txtPrecioTotal = new TextBox();
            label2 = new Label();
            label1 = new Label();
            txtCantidad = new TextBox();
            label14 = new Label();
            BttnX = new Button();
            txtPrecioUnitario = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label3 = new Label();
            bttnModyAgr = new Button();
            bttnLimpiar = new Button();
            panel3 = new Panel();
            chkCambio = new CheckBox();
            txtProveedor = new TextBox();
            txtProducto = new TextBox();
            PanelMovimiento = new Panel();
            chkEgreso = new CheckBox();
            chkIngreso = new CheckBox();
            label6 = new Label();
            label5 = new Label();
            txtDestino = new TextBox();
            label4 = new Label();
            dtpFechaMovimiento = new DateTimePicker();
            txtObservacion = new TextBox();
            BttnRetroceder = new Button();
            bttnBuscarMovimiento = new Button();
            txtBuscarMovimientoID = new TextBox();
            DateBuscarFecha = new DateTimePicker();
            txtBuscarStock = new TextBox();
            bttnBuscarStock = new Button();
            DGViewStock = new DataGridView();
            bttnBuscarProveedor = new Button();
            DGViewProveedor = new DataGridView();
            txtBuscarMovimientoStock = new TextBox();
            txtBuscarProveedor = new TextBox();
            txtBuscarMovimientoProveedor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)DGViewMovimientoStock).BeginInit();
            panel3.SuspendLayout();
            PanelMovimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)DGViewProveedor).BeginInit();
            SuspendLayout();
            // 
            // DGViewMovimientoStock
            // 
            DGViewMovimientoStock.Anchor = AnchorStyles.None;
            DGViewMovimientoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewMovimientoStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewMovimientoStock.BackgroundColor = Color.White;
            DGViewMovimientoStock.BorderStyle = BorderStyle.None;
            DGViewMovimientoStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGViewMovimientoStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGViewMovimientoStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Gold;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGViewMovimientoStock.DefaultCellStyle = dataGridViewCellStyle2;
            DGViewMovimientoStock.Location = new Point(12, 46);
            DGViewMovimientoStock.Margin = new Padding(3, 2, 3, 2);
            DGViewMovimientoStock.Name = "DGViewMovimientoStock";
            DGViewMovimientoStock.RowHeadersVisible = false;
            DGViewMovimientoStock.RowHeadersWidth = 51;
            DGViewMovimientoStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewMovimientoStock.Size = new Size(800, 663);
            DGViewMovimientoStock.TabIndex = 200;
            DGViewMovimientoStock.CellContentClick += DGViewMovimientoStock_CellContentClick;
            // 
            // txtPrecioTotal
            // 
            txtPrecioTotal.Anchor = AnchorStyles.None;
            txtPrecioTotal.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtPrecioTotal.Location = new Point(38, 384);
            txtPrecioTotal.Margin = new Padding(3, 2, 3, 2);
            txtPrecioTotal.Name = "txtPrecioTotal";
            txtPrecioTotal.Size = new Size(375, 22);
            txtPrecioTotal.TabIndex = 56;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.ImeMode = ImeMode.NoControl;
            label2.Location = new Point(38, 134);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 55;
            label2.Text = "Tipo Movimiento:";
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
            label1.Location = new Point(38, 87);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 53;
            label1.Text = "Cantidad:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCantidad
            // 
            txtCantidad.Anchor = AnchorStyles.None;
            txtCantidad.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtCantidad.Location = new Point(38, 110);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(375, 22);
            txtCantidad.TabIndex = 52;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.AutoSize = true;
            label14.BackColor = Color.Gold;
            label14.Font = new Font("Segoe UI", 21F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ImeMode = ImeMode.NoControl;
            label14.Location = new Point(0, 0);
            label14.Name = "label14";
            label14.Size = new Size(297, 38);
            label14.TabIndex = 41;
            label14.Text = "MOVIMIENTO STOCK";
            // 
            // BttnX
            // 
            BttnX.Anchor = AnchorStyles.None;
            BttnX.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BttnX.BackColor = Color.Red;
            BttnX.FlatStyle = FlatStyle.Flat;
            BttnX.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            BttnX.ImeMode = ImeMode.NoControl;
            BttnX.Location = new Point(1236, 10);
            BttnX.Margin = new Padding(3, 2, 3, 2);
            BttnX.Name = "BttnX";
            BttnX.Size = new Size(32, 32);
            BttnX.TabIndex = 198;
            BttnX.Text = "X";
            BttnX.UseVisualStyleBackColor = false;
            BttnX.Click += btnSalir_Click;
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Anchor = AnchorStyles.None;
            txtPrecioUnitario.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtPrecioUnitario.Location = new Point(38, 338);
            txtPrecioUnitario.Margin = new Padding(3, 2, 3, 2);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(375, 22);
            txtPrecioUnitario.TabIndex = 78;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.None;
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.ImeMode = ImeMode.NoControl;
            label13.Location = new Point(38, 265);
            label13.Name = "label13";
            label13.Size = new Size(58, 21);
            label13.TabIndex = 77;
            label13.Text = "Fecha:";
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
            label12.Location = new Point(38, 217);
            label12.Name = "label12";
            label12.Size = new Size(94, 21);
            label12.TabIndex = 75;
            label12.Text = "Proveedor:";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.ImeMode = ImeMode.NoControl;
            label3.Location = new Point(38, 361);
            label3.Name = "label3";
            label3.Size = new Size(104, 21);
            label3.TabIndex = 57;
            label3.Text = "Precio Total:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bttnModyAgr
            // 
            bttnModyAgr.Anchor = AnchorStyles.None;
            bttnModyAgr.BackColor = Color.FromArgb(65, 36, 7);
            bttnModyAgr.FlatStyle = FlatStyle.Flat;
            bttnModyAgr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            bttnModyAgr.ForeColor = Color.Gold;
            bttnModyAgr.ImeMode = ImeMode.NoControl;
            bttnModyAgr.Location = new Point(818, 468);
            bttnModyAgr.Margin = new Padding(3, 2, 3, 2);
            bttnModyAgr.Name = "bttnModyAgr";
            bttnModyAgr.Size = new Size(450, 37);
            bttnModyAgr.TabIndex = 191;
            bttnModyAgr.Text = "OK";
            bttnModyAgr.UseVisualStyleBackColor = false;
            bttnModyAgr.Click += btnAgregar_Click;
            // 
            // bttnLimpiar
            // 
            bttnLimpiar.Anchor = AnchorStyles.None;
            bttnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnLimpiar.BackColor = Color.FromArgb(255, 128, 0);
            bttnLimpiar.FlatStyle = FlatStyle.Flat;
            bttnLimpiar.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnLimpiar.ImeMode = ImeMode.NoControl;
            bttnLimpiar.Location = new Point(1113, 10);
            bttnLimpiar.Margin = new Padding(3, 2, 3, 2);
            bttnLimpiar.Name = "bttnLimpiar";
            bttnLimpiar.Size = new Size(79, 32);
            bttnLimpiar.TabIndex = 197;
            bttnLimpiar.Text = "Limpiar";
            bttnLimpiar.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.None;
            panel3.BackColor = Color.DarkGoldenrod;
            panel3.Controls.Add(chkCambio);
            panel3.Controls.Add(txtProveedor);
            panel3.Controls.Add(txtProducto);
            panel3.Controls.Add(PanelMovimiento);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtDestino);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dtpFechaMovimiento);
            panel3.Controls.Add(txtPrecioUnitario);
            panel3.Controls.Add(label13);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(txtObservacion);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtPrecioTotal);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(txtCantidad);
            panel3.Controls.Add(label14);
            panel3.Location = new Point(818, 46);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(450, 418);
            panel3.TabIndex = 192;
            // 
            // chkCambio
            // 
            chkCambio.AutoSize = true;
            chkCambio.Location = new Point(304, 39);
            chkCambio.Name = "chkCambio";
            chkCambio.Size = new Size(108, 19);
            chkCambio.TabIndex = 95;
            chkCambio.Text = "Sin Transaccion";
            chkCambio.UseVisualStyleBackColor = true;
            // 
            // txtProveedor
            // 
            txtProveedor.Anchor = AnchorStyles.None;
            txtProveedor.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtProveedor.Location = new Point(38, 240);
            txtProveedor.Margin = new Padding(3, 2, 3, 2);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(375, 22);
            txtProveedor.TabIndex = 94;
            // 
            // txtProducto
            // 
            txtProducto.Anchor = AnchorStyles.None;
            txtProducto.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtProducto.Location = new Point(38, 63);
            txtProducto.Margin = new Padding(3, 2, 3, 2);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(375, 22);
            txtProducto.TabIndex = 93;
            // 
            // PanelMovimiento
            // 
            PanelMovimiento.Controls.Add(chkEgreso);
            PanelMovimiento.Controls.Add(chkIngreso);
            PanelMovimiento.Location = new Point(282, 134);
            PanelMovimiento.Name = "PanelMovimiento";
            PanelMovimiento.Size = new Size(131, 55);
            PanelMovimiento.TabIndex = 92;
            // 
            // chkEgreso
            // 
            chkEgreso.AutoSize = true;
            chkEgreso.Location = new Point(24, 33);
            chkEgreso.Name = "chkEgreso";
            chkEgreso.Size = new Size(61, 19);
            chkEgreso.TabIndex = 1;
            chkEgreso.Text = "Egreso";
            chkEgreso.UseVisualStyleBackColor = true;
            // 
            // chkIngreso
            // 
            chkIngreso.AutoSize = true;
            chkIngreso.Location = new Point(24, 3);
            chkIngreso.Name = "chkIngreso";
            chkIngreso.Size = new Size(65, 19);
            chkIngreso.TabIndex = 0;
            chkIngreso.Text = "Ingreso";
            chkIngreso.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.None;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.ImeMode = ImeMode.NoControl;
            label6.Location = new Point(38, 171);
            label6.Name = "label6";
            label6.Size = new Size(73, 21);
            label6.TabIndex = 90;
            label6.Text = "Destino:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.ImeMode = ImeMode.NoControl;
            label5.Location = new Point(38, 315);
            label5.Name = "label5";
            label5.Size = new Size(129, 21);
            label5.TabIndex = 89;
            label5.Text = "Precio Unitario:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtDestino
            // 
            txtDestino.Anchor = AnchorStyles.None;
            txtDestino.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            txtDestino.Location = new Point(38, 194);
            txtDestino.Margin = new Padding(3, 2, 3, 2);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(375, 22);
            txtDestino.TabIndex = 87;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.ImeMode = ImeMode.NoControl;
            label4.Location = new Point(38, 40);
            label4.Name = "label4";
            label4.Size = new Size(84, 21);
            label4.TabIndex = 84;
            label4.Text = "Producto:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpFechaMovimiento
            // 
            dtpFechaMovimiento.Anchor = AnchorStyles.None;
            dtpFechaMovimiento.Location = new Point(38, 289);
            dtpFechaMovimiento.Name = "dtpFechaMovimiento";
            dtpFechaMovimiento.Size = new Size(375, 23);
            dtpFechaMovimiento.TabIndex = 81;
            // 
            // txtObservacion
            // 
            txtObservacion.Anchor = AnchorStyles.None;
            txtObservacion.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtObservacion.Location = new Point(342, 1487);
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
            BttnRetroceder.Location = new Point(1198, 10);
            BttnRetroceder.Margin = new Padding(3, 2, 3, 2);
            BttnRetroceder.Name = "BttnRetroceder";
            BttnRetroceder.Size = new Size(32, 32);
            BttnRetroceder.TabIndex = 194;
            BttnRetroceder.Text = "↩";
            BttnRetroceder.UseVisualStyleBackColor = false;
            BttnRetroceder.Click += btnVolver_Click;
            // 
            // bttnBuscarMovimiento
            // 
            bttnBuscarMovimiento.Anchor = AnchorStyles.None;
            bttnBuscarMovimiento.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscarMovimiento.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscarMovimiento.FlatStyle = FlatStyle.Flat;
            bttnBuscarMovimiento.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscarMovimiento.ImeMode = ImeMode.NoControl;
            bttnBuscarMovimiento.Location = new Point(674, 10);
            bttnBuscarMovimiento.Margin = new Padding(3, 2, 3, 2);
            bttnBuscarMovimiento.Name = "bttnBuscarMovimiento";
            bttnBuscarMovimiento.Size = new Size(100, 32);
            bttnBuscarMovimiento.TabIndex = 195;
            bttnBuscarMovimiento.Text = "Buscar";
            bttnBuscarMovimiento.UseVisualStyleBackColor = false;
            bttnBuscarMovimiento.Click += btnBuscarStock_Click;
            // 
            // txtBuscarMovimientoID
            // 
            txtBuscarMovimientoID.Anchor = AnchorStyles.None;
            txtBuscarMovimientoID.Font = new Font("Segoe UI", 13.8F);
            txtBuscarMovimientoID.Location = new Point(12, 10);
            txtBuscarMovimientoID.Margin = new Padding(3, 2, 3, 2);
            txtBuscarMovimientoID.Name = "txtBuscarMovimientoID";
            txtBuscarMovimientoID.Size = new Size(142, 32);
            txtBuscarMovimientoID.TabIndex = 196;
            // 
            // DateBuscarFecha
            // 
            DateBuscarFecha.Anchor = AnchorStyles.None;
            DateBuscarFecha.Location = new Point(456, 16);
            DateBuscarFecha.Name = "DateBuscarFecha";
            DateBuscarFecha.Size = new Size(212, 23);
            DateBuscarFecha.TabIndex = 89;
            // 
            // txtBuscarStock
            // 
            txtBuscarStock.Anchor = AnchorStyles.None;
            txtBuscarStock.Font = new Font("Segoe UI", 13.8F);
            txtBuscarStock.Location = new Point(1067, 508);
            txtBuscarStock.Margin = new Padding(3, 2, 3, 2);
            txtBuscarStock.Name = "txtBuscarStock";
            txtBuscarStock.Size = new Size(109, 32);
            txtBuscarStock.TabIndex = 206;
            // 
            // bttnBuscarStock
            // 
            bttnBuscarStock.Anchor = AnchorStyles.None;
            bttnBuscarStock.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscarStock.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscarStock.FlatStyle = FlatStyle.Flat;
            bttnBuscarStock.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscarStock.ImeMode = ImeMode.NoControl;
            bttnBuscarStock.Location = new Point(1182, 508);
            bttnBuscarStock.Margin = new Padding(3, 2, 3, 2);
            bttnBuscarStock.Name = "bttnBuscarStock";
            bttnBuscarStock.Size = new Size(86, 32);
            bttnBuscarStock.TabIndex = 205;
            bttnBuscarStock.Text = "Buscar";
            bttnBuscarStock.UseVisualStyleBackColor = false;
            bttnBuscarStock.Click += btnBuscarStock_Click;
            // 
            // DGViewStock
            // 
            DGViewStock.Anchor = AnchorStyles.None;
            DGViewStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewStock.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewStock.BackgroundColor = Color.White;
            DGViewStock.BorderStyle = BorderStyle.None;
            DGViewStock.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            DGViewStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            DGViewStock.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.Gold;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DGViewStock.DefaultCellStyle = dataGridViewCellStyle4;
            DGViewStock.Location = new Point(1067, 545);
            DGViewStock.Margin = new Padding(3, 2, 3, 2);
            DGViewStock.Name = "DGViewStock";
            DGViewStock.RowHeadersVisible = false;
            DGViewStock.RowHeadersWidth = 51;
            DGViewStock.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewStock.Size = new Size(201, 163);
            DGViewStock.TabIndex = 204;
            // 
            // bttnBuscarProveedor
            // 
            bttnBuscarProveedor.Anchor = AnchorStyles.None;
            bttnBuscarProveedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            bttnBuscarProveedor.BackColor = Color.FromArgb(255, 128, 0);
            bttnBuscarProveedor.FlatStyle = FlatStyle.Flat;
            bttnBuscarProveedor.Font = new Font("Segoe UI Black", 10.2F, FontStyle.Bold);
            bttnBuscarProveedor.ImeMode = ImeMode.NoControl;
            bttnBuscarProveedor.Location = new Point(975, 508);
            bttnBuscarProveedor.Margin = new Padding(3, 2, 3, 2);
            bttnBuscarProveedor.Name = "bttnBuscarProveedor";
            bttnBuscarProveedor.Size = new Size(86, 32);
            bttnBuscarProveedor.TabIndex = 208;
            bttnBuscarProveedor.Text = "Buscar";
            bttnBuscarProveedor.UseVisualStyleBackColor = false;
            // 
            // DGViewProveedor
            // 
            DGViewProveedor.Anchor = AnchorStyles.None;
            DGViewProveedor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGViewProveedor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            DGViewProveedor.BackgroundColor = Color.White;
            DGViewProveedor.BorderStyle = BorderStyle.None;
            DGViewProveedor.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DGViewProveedor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DGViewProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.Gold;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 255, 128);
            dataGridViewCellStyle6.SelectionForeColor = Color.Black;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DGViewProveedor.DefaultCellStyle = dataGridViewCellStyle6;
            DGViewProveedor.Location = new Point(818, 545);
            DGViewProveedor.Margin = new Padding(3, 2, 3, 2);
            DGViewProveedor.Name = "DGViewProveedor";
            DGViewProveedor.RowHeadersVisible = false;
            DGViewProveedor.RowHeadersWidth = 51;
            DGViewProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGViewProveedor.Size = new Size(243, 164);
            DGViewProveedor.TabIndex = 209;
            // 
            // txtBuscarMovimientoStock
            // 
            txtBuscarMovimientoStock.Anchor = AnchorStyles.None;
            txtBuscarMovimientoStock.Font = new Font("Segoe UI", 13.8F);
            txtBuscarMovimientoStock.Location = new Point(160, 10);
            txtBuscarMovimientoStock.Margin = new Padding(3, 2, 3, 2);
            txtBuscarMovimientoStock.Name = "txtBuscarMovimientoStock";
            txtBuscarMovimientoStock.Size = new Size(142, 32);
            txtBuscarMovimientoStock.TabIndex = 210;
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.Anchor = AnchorStyles.None;
            txtBuscarProveedor.Font = new Font("Segoe UI", 13.8F);
            txtBuscarProveedor.Location = new Point(818, 509);
            txtBuscarProveedor.Margin = new Padding(3, 2, 3, 2);
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(151, 32);
            txtBuscarProveedor.TabIndex = 211;
            // 
            // txtBuscarMovimientoProveedor
            // 
            txtBuscarMovimientoProveedor.Anchor = AnchorStyles.None;
            txtBuscarMovimientoProveedor.Font = new Font("Segoe UI", 13.8F);
            txtBuscarMovimientoProveedor.Location = new Point(308, 11);
            txtBuscarMovimientoProveedor.Margin = new Padding(3, 2, 3, 2);
            txtBuscarMovimientoProveedor.Name = "txtBuscarMovimientoProveedor";
            txtBuscarMovimientoProveedor.Size = new Size(142, 32);
            txtBuscarMovimientoProveedor.TabIndex = 212;
            // 
            // MovimientoStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(1280, 720);
            Controls.Add(txtBuscarMovimientoProveedor);
            Controls.Add(txtBuscarProveedor);
            Controls.Add(txtBuscarMovimientoStock);
            Controls.Add(DGViewProveedor);
            Controls.Add(bttnBuscarProveedor);
            Controls.Add(txtBuscarStock);
            Controls.Add(bttnBuscarStock);
            Controls.Add(DGViewStock);
            Controls.Add(DateBuscarFecha);
            Controls.Add(DGViewMovimientoStock);
            Controls.Add(BttnX);
            Controls.Add(bttnModyAgr);
            Controls.Add(bttnLimpiar);
            Controls.Add(panel3);
            Controls.Add(BttnRetroceder);
            Controls.Add(bttnBuscarMovimiento);
            Controls.Add(txtBuscarMovimientoID);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MovimientoStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movimiento";
            Load += MovimientoStock_Load;
            ((System.ComponentModel.ISupportInitialize)DGViewMovimientoStock).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            PanelMovimiento.ResumeLayout(false);
            PanelMovimiento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGViewStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)DGViewProveedor).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DGViewMovimientoStock;
        private TextBox txtPrecioTotal;
        private Label label2;
        private Label label1;
        private TextBox txtCantidad;
        private Label label14;
        private Button BttnX;
        private TextBox txtBuscarMovimientoProveedor;
        private TextBox txtPrecioUnitario;
        private Label label13;
        private Label label12;
        private Label label3;
        private Button bttnModyAgr;
        private Button bttnLimpiar;
        private Panel panel3;
        private TextBox txtObservacion;
        private Button BttnRetroceder;
        private Button bttnBuscarMovimiento;
        private TextBox txtBuscarMovimientoID;
        private DateTimePicker dtpFechaMovimiento;
        private Label label4;
        private DateTimePicker DateBuscarFecha;
        private TextBox txtBuscarStock;
        private Button bttnBuscarStock;
        private DataGridView DGViewStock;
        private TextBox txtBuscarProductoID;
        private Label label5;
        private Label label6;
        private TextBox txtDestino;
        private Panel PanelMovimiento;
        private CheckBox chkEgreso;
        private CheckBox chkIngreso;
        private TextBox txtProducto;
        private Button bttnBuscarProveedor;
        private DataGridView DGViewProveedor;
        private TextBox txtProveedor;
        private TextBox txtBuscarMovimientoStock;
        private TextBox txtBuscarProveedor;
        private TextBox txtBuscarProveedorID;
        private CheckBox chkCambio;
    }
}