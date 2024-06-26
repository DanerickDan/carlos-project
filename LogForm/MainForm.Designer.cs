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
            panelSuperior = new CustomComponents.MainFormComponents.CustomPanel();
            panelNav = new FlowLayoutPanel();
            panel1 = new Panel();
            btnInicio = new FontAwesome.Sharp.IconButton();
            btnProdutos = new FontAwesome.Sharp.IconButton();
            btnFacturas = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            pictureBox1 = new PictureBox();
            panelNav.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelSuperior
            // 
            panelSuperior.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelSuperior.BackColor = Color.White;
            panelSuperior.BorderColor = Color.White;
            panelSuperior.Location = new Point(119, 1);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Radius = 15;
            panelSuperior.Size = new Size(724, 28);
            panelSuperior.TabIndex = 4;
            panelSuperior.Thickness = 5F;
            // 
            // panelNav
            // 
            panelNav.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelNav.BackColor = Color.White;
            panelNav.Controls.Add(panel1);
            panelNav.Controls.Add(btnInicio);
            panelNav.Controls.Add(btnProdutos);
            panelNav.Controls.Add(btnFacturas);
            panelNav.Controls.Add(btnClientes);
            panelNav.Location = new Point(1, 1);
            panelNav.Name = "panelNav";
            panelNav.Size = new Size(112, 514);
            panelNav.TabIndex = 5;
            panelNav.Paint += panelNav_Paint;
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
            btnInicio.Location = new Point(0, 90);
            btnInicio.Margin = new Padding(0, 15, 0, 12);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(100, 34);
            btnInicio.TabIndex = 1;
            btnInicio.Text = " Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleRight;
            btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnInicio.UseVisualStyleBackColor = true;
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
            btnProdutos.Location = new Point(0, 136);
            btnProdutos.Margin = new Padding(0, 0, 0, 12);
            btnProdutos.Name = "btnProdutos";
            btnProdutos.Size = new Size(113, 34);
            btnProdutos.TabIndex = 2;
            btnProdutos.Text = "Productos";
            btnProdutos.TextAlign = ContentAlignment.MiddleRight;
            btnProdutos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProdutos.UseVisualStyleBackColor = true;
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
            btnFacturas.Location = new Point(0, 182);
            btnFacturas.Margin = new Padding(0, 0, 0, 12);
            btnFacturas.Name = "btnFacturas";
            btnFacturas.Padding = new Padding(2, 0, 0, 0);
            btnFacturas.Size = new Size(105, 34);
            btnFacturas.TabIndex = 3;
            btnFacturas.Text = "Facturas";
            btnFacturas.TextAlign = ContentAlignment.MiddleRight;
            btnFacturas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnFacturas.UseVisualStyleBackColor = true;
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
            btnClientes.Location = new Point(3, 231);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(100, 34);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleRight;
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(215, 217, 221);
            ClientSize = new Size(834, 513);
            Controls.Add(panelNav);
            Controls.Add(panelSuperior);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            panelNav.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private CustomComponents.MainFormComponents.CustomPanel customPanel1;
        private CustomComponents.MainFormComponents.CustomPanel panelSuperior;
        private FlowLayoutPanel panelNav;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnProdutos;
        private FontAwesome.Sharp.IconButton btnFacturas;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnInicio;
        private PictureBox pictureBox1;
    }
}