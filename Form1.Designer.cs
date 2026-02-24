namespace Diegod
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtUsuario = new TextBox();
            TxtContra = new TextBox();
            BttnIngresar = new Button();
            lblUsuario = new Label();
            label2 = new Label();
            bttnX = new Button();
            pictureBox1 = new PictureBox();
            panel5 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel7 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TxtUsuario
            // 
            TxtUsuario.Anchor = AnchorStyles.None;
            TxtUsuario.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtUsuario.Location = new Point(81, 311);
            TxtUsuario.Margin = new Padding(3, 2, 3, 2);
            TxtUsuario.Name = "TxtUsuario";
            TxtUsuario.Size = new Size(263, 33);
            TxtUsuario.TabIndex = 0;
            TxtUsuario.KeyDown += TxtUsuario_KeyDown_1;
            // 
            // TxtContra
            // 
            TxtContra.Anchor = AnchorStyles.None;
            TxtContra.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtContra.Location = new Point(81, 376);
            TxtContra.Margin = new Padding(3, 2, 3, 2);
            TxtContra.Name = "TxtContra";
            TxtContra.PasswordChar = '*';
            TxtContra.Size = new Size(263, 33);
            TxtContra.TabIndex = 1;
            TxtContra.KeyDown += TxtContra_KeyDown_1;
            // 
            // BttnIngresar
            // 
            BttnIngresar.BackColor = Color.Transparent;
            BttnIngresar.FlatAppearance.BorderColor = Color.White;
            BttnIngresar.FlatAppearance.BorderSize = 4;
            BttnIngresar.FlatAppearance.MouseDownBackColor = Color.Red;
            BttnIngresar.FlatAppearance.MouseOverBackColor = Color.White;
            BttnIngresar.FlatStyle = FlatStyle.Flat;
            BttnIngresar.Font = new Font("Segoe UI Black", 14F, FontStyle.Bold);
            BttnIngresar.ForeColor = Color.Black;
            BttnIngresar.Location = new Point(37, 425);
            BttnIngresar.Margin = new Padding(3, 2, 3, 2);
            BttnIngresar.Name = "BttnIngresar";
            BttnIngresar.Size = new Size(346, 92);
            BttnIngresar.TabIndex = 2;
            BttnIngresar.Text = "INGRESAR";
            BttnIngresar.UseVisualStyleBackColor = false;
            BttnIngresar.Click += BttnIngresar_Click;
            BttnIngresar.KeyDown += BttnIngresar_KeyDown_1;
            // 
            // lblUsuario
            // 
            lblUsuario.Anchor = AnchorStyles.None;
            lblUsuario.AutoSize = true;
            lblUsuario.BackColor = Color.Transparent;
            lblUsuario.Cursor = Cursors.Hand;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuario.ForeColor = Color.Black;
            lblUsuario.Location = new Point(178, 288);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(69, 21);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(163, 353);
            label2.Name = "label2";
            label2.Size = new Size(96, 21);
            label2.TabIndex = 4;
            label2.Text = "Contraseña";
            // 
            // bttnX
            // 
            bttnX.Anchor = AnchorStyles.None;
            bttnX.BackColor = Color.Red;
            bttnX.FlatAppearance.BorderColor = Color.Black;
            bttnX.FlatAppearance.BorderSize = 3;
            bttnX.FlatAppearance.MouseDownBackColor = Color.Red;
            bttnX.FlatAppearance.MouseOverBackColor = Color.Red;
            bttnX.FlatStyle = FlatStyle.Flat;
            bttnX.Font = new Font("Segoe UI Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bttnX.Location = new Point(350, 15);
            bttnX.Margin = new Padding(3, 2, 3, 2);
            bttnX.Name = "bttnX";
            bttnX.Size = new Size(55, 51);
            bttnX.TabIndex = 5;
            bttnX.Text = "X";
            bttnX.UseVisualStyleBackColor = false;
            bttnX.Click += bttnX_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources._d862f1d6_c2eb_4afb_b3d1_6776339483cc;
            pictureBox1.InitialImage = Properties.Resources._d862f1d6_c2eb_4afb_b3d1_6776339483cc;
            pictureBox1.Location = new Point(81, 1);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(263, 285);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.None;
            panel5.BackColor = Color.Black;
            panel5.Location = new Point(-5, 537);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(435, 21);
            panel5.TabIndex = 9;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.Black;
            panel1.Location = new Point(411, -8);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(19, 564);
            panel1.TabIndex = 7;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.Black;
            panel2.Location = new Point(-3, -8);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(15, 545);
            panel2.TabIndex = 8;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.None;
            panel7.BackColor = Color.Black;
            panel7.Location = new Point(-3, -10);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(433, 21);
            panel7.TabIndex = 10;
            panel7.Paint += panel7_Paint;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gold;
            ClientSize = new Size(422, 548);
            Controls.Add(panel7);
            Controls.Add(panel5);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(bttnX);
            Controls.Add(label2);
            Controls.Add(lblUsuario);
            Controls.Add(BttnIngresar);
            Controls.Add(TxtContra);
            Controls.Add(TxtUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtUsuario;
        private TextBox TxtContra;
        private Button BttnIngresar;
        private Label lblUsuario;
        private Label label2;
        private Button bttnX;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Panel panel1;
        private Panel panel2;
        private Panel panel7;
    }
}
