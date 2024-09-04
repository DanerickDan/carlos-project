namespace PresentationLayer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            txtBuscar = new TextBox();
            panelNav = new FlowLayoutPanel();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            btnInicio = new FontAwesome.Sharp.IconButton();
            btnProdutos = new FontAwesome.Sharp.IconButton();
            btnFacturas = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            CenterPanel = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            customDatePicker1 = new CustomComponents.MainFormComponents.CustomDatePicker();
            panel6 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panelNav.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            CenterPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = Color.Silver;
            txtBuscar.BorderStyle = BorderStyle.None;
            txtBuscar.Location = new Point(16, 6);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(100, 16);
            txtBuscar.TabIndex = 0;
            // 
            // panelNav
            // 
            panelNav.BackColor = Color.White;
            panelNav.Controls.Add(panel1);
            panelNav.Controls.Add(btnInicio);
            panelNav.Controls.Add(btnProdutos);
            panelNav.Controls.Add(btnFacturas);
            panelNav.Controls.Add(btnClientes);
            panelNav.Dock = DockStyle.Left;
            panelNav.Location = new Point(0, 0);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(112, 639);
            panelNav.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(105, 69);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(3, 10, 3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(0, 10, 0, 0);
            pictureBox1.Size = new Size(105, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnInicio
            // 
            btnInicio.Dock = DockStyle.Top;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 12F);
            btnInicio.ForeColor = Color.FromArgb(40, 40, 48);
            btnInicio.IconChar = FontAwesome.Sharp.IconChar.HouseChimney;
            btnInicio.IconColor = Color.FromArgb(204, 204, 204);
            btnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnInicio.IconSize = 25;
            btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
            btnInicio.Location = new Point(0, 115);
            btnInicio.Margin = new Padding(0, 40, 0, 15);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(100, 34);
            btnInicio.TabIndex = 1;
            btnInicio.Text = " Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleRight;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = true;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnProdutos
            // 
            btnProdutos.Dock = DockStyle.Top;
            btnProdutos.FlatAppearance.BorderSize = 0;
            btnProdutos.FlatStyle = FlatStyle.Flat;
            btnProdutos.Font = new Font("Segoe UI", 12F);
            btnProdutos.ForeColor = Color.FromArgb(40, 40, 48);
            btnProdutos.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            btnProdutos.IconColor = Color.FromArgb(204, 204, 204);
            btnProdutos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProdutos.IconSize = 25;
            btnProdutos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProdutos.Location = new Point(0, 164);
            btnProdutos.Margin = new Padding(0, 0, 0, 15);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(113, 34);
            btnProdutos.TabIndex = 2;
            btnProdutos.Text = "Productos";
            btnProdutos.TextAlign = ContentAlignment.MiddleRight;
            btnProdutos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProdutos.UseVisualStyleBackColor = true;
            btnProdutos.Click += btnProdutos_Click;
            // 
            // btnFacturas
            // 
            btnFacturas.Dock = DockStyle.Top;
            btnFacturas.FlatAppearance.BorderSize = 0;
            btnFacturas.FlatStyle = FlatStyle.Flat;
            btnFacturas.Font = new Font("Segoe UI", 12F);
            btnFacturas.ForeColor = Color.FromArgb(40, 40, 48);
            btnFacturas.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            btnFacturas.IconColor = Color.FromArgb(204, 204, 204);
            btnFacturas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnFacturas.IconSize = 25;
            btnFacturas.ImageAlign = ContentAlignment.MiddleLeft;
            btnFacturas.Location = new Point(0, 213);
            btnFacturas.Margin = new Padding(0, 0, 0, 15);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Padding = new Padding(2, 0, 0, 0);
            btnFacturas.Size = new Size(105, 34);
            btnFacturas.TabIndex = 3;
            btnFacturas.Text = "Facturas";
            btnFacturas.TextAlign = ContentAlignment.MiddleRight;
            btnFacturas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFacturas.UseVisualStyleBackColor = true;
            btnFacturas.Click += btnFacturas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatAppearance.BorderSize = 0;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 12F);
            btnClientes.ForeColor = Color.FromArgb(40, 40, 48);
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            btnClientes.IconColor = Color.FromArgb(204, 204, 204);
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 25;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(3, 265);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(100, 34);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleRight;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // CenterPanel
            // 
            CenterPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CenterPanel.Controls.Add(panel2);
            CenterPanel.Controls.Add(customDatePicker1);
            CenterPanel.Controls.Add(panel6);
            CenterPanel.Controls.Add(panel4);
            CenterPanel.Controls.Add(panel3);
            CenterPanel.Location = new Point(128, 0);
            CenterPanel.Name = "CenterPanel";
            CenterPanel.Size = new Size(933, 639);
            CenterPanel.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Location = new Point(3, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(930, 38);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(789, 3);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 0;
            label1.Text = "DashBoard";
            // 
            // customDatePicker1
            // 
            customDatePicker1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            customDatePicker1.BorderColor = Color.PaleVioletRed;
            customDatePicker1.BorderSize = 0;
            customDatePicker1.CalendarForeColor = Color.Black;
            customDatePicker1.Font = new Font("Segoe UI", 9.5F);
            customDatePicker1.Location = new Point(708, 197);
            customDatePicker1.MinimumSize = new Size(0, 35);
            customDatePicker1.Name = "customDatePicker1";
            customDatePicker1.Size = new Size(200, 35);
            customDatePicker1.SkinColor = Color.White;
            customDatePicker1.TabIndex = 1;
            customDatePicker1.TextColor = Color.Black;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.Silver;
            panel6.Location = new Point(21, 270);
            panel6.Name = "panel6";
            panel6.Size = new Size(900, 352);
            panel6.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel4.BackColor = Color.Silver;
            panel4.Location = new Point(505, 60);
            panel4.MaximumSize = new Size(950, 200);
            panel4.Name = "panel4";
            panel4.Size = new Size(416, 122);
            panel4.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(21, 60);
            panel3.MaximumSize = new Size(950, 200);
            panel3.Name = "panel3";
            panel3.Size = new Size(420, 122);
            panel3.TabIndex = 0;
            panel3.Paint += panel3_Paint;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(215, 217, 221);
            ClientSize = new Size(1061, 639);
            Controls.Add(CenterPanel);
            Controls.Add(panelNav);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DashBoard";
            Load += MainForm_Load;
            panelNav.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            CenterPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CustomComponents.MainFormComponents.CustomPanel panelSuperior;
        private FlowLayoutPanel panelNav;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnProdutos;
        private FontAwesome.Sharp.IconButton btnFacturas;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnInicio;
        private PictureBox pictureBox1;
        private TextBox txtBuscar;
        private Panel CenterPanel;
        private Panel panel4;
        private Panel panel3;
        private Panel panel6;
        private CustomComponents.MainFormComponents.CustomDatePicker customDatePicker1;
        private Panel panel2;
        private Label label1;
    }
}