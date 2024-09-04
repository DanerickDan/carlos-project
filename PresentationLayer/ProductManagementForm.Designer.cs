namespace PresentationLayer
{
    partial class ProductManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagementForm));
            dataGridView1 = new DataGridView();
            ProductID = new DataGridViewTextBoxColumn();
            Code = new DataGridViewTextBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            TimeColumn = new DataGridViewTextBoxColumn();
            Lote = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            StateColumn = new DataGridViewTextBoxColumn();
            CategoryColumn = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnPanel = new Panel();
            btnAnadir = new CustomComponents.MainFormComponents.CustomButton();
            btnBorrar = new CustomComponents.MainFormComponents.CustomButton();
            btnEditar = new CustomComponents.MainFormComponents.CustomButton();
            lblPrincipal = new Label();
            panel2 = new Panel();
            lblFiltrados = new Label();
            lblTotalFiltrados = new Label();
            cltTxtRegistros = new Label();
            cltTxtFiltrados = new Label();
            materialScrollBar1 = new MaterialSkin.Controls.MaterialScrollBar();
            panel3 = new Panel();
            customTextBox1 = new CustomComponents.MainFormComponents.CustomTextBox();
            customButton1 = new CustomComponents.MainFormComponents.CustomButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            btnPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 196, 96);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProductID, Code, NameColumn, DescriptionColumn, Quantity, TimeColumn, Lote, Price, StateColumn, CategoryColumn });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(787, 371);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            // 
            // ProductID
            // 
            ProductID.DataPropertyName = "ProductsId";
            ProductID.HeaderText = "ProductID";
            ProductID.Name = "ProductID";
            ProductID.ReadOnly = true;
            ProductID.Visible = false;
            // 
            // Code
            // 
            Code.DataPropertyName = "Code";
            Code.HeaderText = "Codigo";
            Code.Name = "Code";
            Code.ReadOnly = true;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName = "ProductName";
            NameColumn.HeaderText = "Nombre";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.DataPropertyName = "Description";
            DescriptionColumn.HeaderText = "Descripción";
            DescriptionColumn.Name = "DescriptionColumn";
            DescriptionColumn.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Cantidad";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // TimeColumn
            // 
            TimeColumn.DataPropertyName = "ExpirationDate";
            TimeColumn.HeaderText = "Expiracion";
            TimeColumn.Name = "TimeColumn";
            TimeColumn.ReadOnly = true;
            // 
            // Lote
            // 
            Lote.DataPropertyName = "Lote";
            Lote.HeaderText = "Lote";
            Lote.Name = "Lote";
            Lote.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Precio";
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // StateColumn
            // 
            StateColumn.DataPropertyName = "StatusId";
            StateColumn.HeaderText = "Estado";
            StateColumn.Name = "StateColumn";
            StateColumn.ReadOnly = true;
            StateColumn.Visible = false;
            // 
            // CategoryColumn
            // 
            CategoryColumn.DataPropertyName = "CategoryId";
            CategoryColumn.HeaderText = "Categoria";
            CategoryColumn.Name = "CategoryColumn";
            CategoryColumn.ReadOnly = true;
            CategoryColumn.Visible = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnPanel);
            panel1.Controls.Add(lblPrincipal);
            panel1.Location = new Point(0, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 1;
            // 
            // btnPanel
            // 
            btnPanel.Anchor = AnchorStyles.Right;
            btnPanel.BackColor = SystemColors.Control;
            btnPanel.Controls.Add(btnAnadir);
            btnPanel.Controls.Add(btnBorrar);
            btnPanel.Controls.Add(btnEditar);
            btnPanel.Location = new Point(188, 0);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(612, 47);
            btnPanel.TabIndex = 13;
            // 
            // btnAnadir
            // 
            btnAnadir.Anchor = AnchorStyles.Left;
            btnAnadir.BackColor = Color.FromArgb(243, 156, 76);
            btnAnadir.BackgroundColor = Color.FromArgb(243, 156, 76);
            btnAnadir.BorderColor = Color.PaleVioletRed;
            btnAnadir.BorderRadius = 5;
            btnAnadir.BorderSize = 0;
            btnAnadir.FlatAppearance.BorderSize = 0;
            btnAnadir.FlatStyle = FlatStyle.Flat;
            btnAnadir.ForeColor = Color.White;
            btnAnadir.Image = (Image)resources.GetObject("btnAnadir.Image");
            btnAnadir.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnadir.Location = new Point(472, 7);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(127, 37);
            btnAnadir.TabIndex = 0;
            btnAnadir.Text = "Añadir";
            btnAnadir.TextColor = Color.White;
            btnAnadir.UseVisualStyleBackColor = false;
            btnAnadir.Click += btnAnadir_Click;
            // 
            // btnBorrar
            // 
            btnBorrar.Anchor = AnchorStyles.Left;
            btnBorrar.BackColor = Color.FromArgb(243, 156, 76);
            btnBorrar.BackgroundColor = Color.FromArgb(243, 156, 76);
            btnBorrar.BorderColor = Color.PaleVioletRed;
            btnBorrar.BorderRadius = 5;
            btnBorrar.BorderSize = 0;
            btnBorrar.FlatAppearance.BorderSize = 0;
            btnBorrar.FlatStyle = FlatStyle.Flat;
            btnBorrar.ForeColor = Color.White;
            btnBorrar.Image = (Image)resources.GetObject("btnBorrar.Image");
            btnBorrar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBorrar.Location = new Point(339, 7);
            btnBorrar.Margin = new Padding(8, 3, 3, 3);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(127, 37);
            btnBorrar.TabIndex = 0;
            btnBorrar.Text = "Eliminar";
            btnBorrar.TextColor = Color.White;
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.Left;
            btnEditar.BackColor = Color.FromArgb(243, 156, 76);
            btnEditar.BackgroundColor = Color.FromArgb(243, 156, 76);
            btnEditar.BorderColor = Color.PaleVioletRed;
            btnEditar.BorderRadius = 5;
            btnEditar.BorderSize = 0;
            btnEditar.FlatAppearance.BorderSize = 0;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.ForeColor = Color.White;
            btnEditar.Image = (Image)resources.GetObject("btnEditar.Image");
            btnEditar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEditar.Location = new Point(201, 7);
            btnEditar.Margin = new Padding(8, 3, 3, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(127, 37);
            btnEditar.TabIndex = 0;
            btnEditar.Text = "Editar";
            btnEditar.TextColor = Color.White;
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // lblPrincipal
            // 
            lblPrincipal.AutoSize = true;
            lblPrincipal.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrincipal.Location = new Point(3, 9);
            lblPrincipal.Name = "lblPrincipal";
            lblPrincipal.Size = new Size(136, 37);
            lblPrincipal.TabIndex = 8;
            lblPrincipal.Text = "Productos";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(lblFiltrados);
            panel2.Controls.Add(lblTotalFiltrados);
            panel2.Controls.Add(cltTxtRegistros);
            panel2.Controls.Add(cltTxtFiltrados);
            panel2.Location = new Point(32, 494);
            panel2.Name = "panel2";
            panel2.Size = new Size(272, 23);
            panel2.TabIndex = 6;
            // 
            // lblFiltrados
            // 
            lblFiltrados.AutoSize = true;
            lblFiltrados.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFiltrados.Location = new Point(231, 5);
            lblFiltrados.Name = "lblFiltrados";
            lblFiltrados.Size = new Size(13, 15);
            lblFiltrados.TabIndex = 6;
            lblFiltrados.Text = "0";
            // 
            // lblTotalFiltrados
            // 
            lblTotalFiltrados.AutoSize = true;
            lblTotalFiltrados.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalFiltrados.Location = new Point(88, 5);
            lblTotalFiltrados.Name = "lblTotalFiltrados";
            lblTotalFiltrados.Size = new Size(13, 15);
            lblTotalFiltrados.TabIndex = 5;
            lblTotalFiltrados.Text = "0";
            // 
            // cltTxtRegistros
            // 
            cltTxtRegistros.AutoSize = true;
            cltTxtRegistros.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cltTxtRegistros.ForeColor = Color.Gray;
            cltTxtRegistros.Location = new Point(19, 3);
            cltTxtRegistros.Name = "cltTxtRegistros";
            cltTxtRegistros.Size = new Size(63, 17);
            cltTxtRegistros.TabIndex = 4;
            cltTxtRegistros.Text = "Registros";
            // 
            // cltTxtFiltrados
            // 
            cltTxtFiltrados.AutoSize = true;
            cltTxtFiltrados.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cltTxtFiltrados.ForeColor = Color.Gray;
            cltTxtFiltrados.Location = new Point(167, 3);
            cltTxtFiltrados.Name = "cltTxtFiltrados";
            cltTxtFiltrados.Size = new Size(58, 17);
            cltTxtFiltrados.TabIndex = 4;
            cltTxtFiltrados.Text = "Filtrados";
            // 
            // materialScrollBar1
            // 
            materialScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            materialScrollBar1.Depth = 0;
            materialScrollBar1.Location = new Point(782, 129);
            materialScrollBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialScrollBar1.Name = "materialScrollBar1";
            materialScrollBar1.Orientation = MaterialSkin.Controls.MaterialScrollOrientation.Vertical;
            materialScrollBar1.ScrollbarSize = 15;
            materialScrollBar1.Size = new Size(15, 345);
            materialScrollBar1.TabIndex = 7;
            materialScrollBar1.Text = "materialScrollBar1";
            materialScrollBar1.Scroll += materialScrollBar1_Scroll;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(customTextBox1);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(800, 38);
            panel3.TabIndex = 8;
            // 
            // customTextBox1
            // 
            customTextBox1.BackColor = Color.Gainsboro;
            customTextBox1.BorderColor = Color.Gainsboro;
            customTextBox1.BorderFocusColor = Color.Gainsboro;
            customTextBox1.BorderRadius = 9;
            customTextBox1.BorderSize = 1;
            customTextBox1.Font = new Font("Segoe UI", 9.5F);
            customTextBox1.ForeColor = Color.DimGray;
            customTextBox1.Location = new Point(7, 3);
            customTextBox1.Multiline = false;
            customTextBox1.Name = "customTextBox1";
            customTextBox1.Padding = new Padding(10, 7, 10, 7);
            customTextBox1.PasswordChar = false;
            customTextBox1.PlaceholderColor = Color.DarkGray;
            customTextBox1.PlaceholderText = "Buscar";
            customTextBox1.Size = new Size(250, 32);
            customTextBox1.TabIndex = 0;
            customTextBox1.Texts = "";
            customTextBox1.UnderlinedStyle = false;
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            customButton1.BackColor = Color.MediumSeaGreen;
            customButton1.BackgroundColor = Color.MediumSeaGreen;
            customButton1.BorderColor = Color.FromArgb(128, 255, 128);
            customButton1.BorderRadius = 5;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.FromArgb(64, 64, 64);
            customButton1.Image = Properties.Resources.icons8_microsoft_excel_2019_25;
            customButton1.ImageAlign = ContentAlignment.MiddleLeft;
            customButton1.Location = new Point(641, 480);
            customButton1.Margin = new Padding(8, 3, 3, 3);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(135, 37);
            customButton1.TabIndex = 9;
            customButton1.Text = "Generar CSV";
            customButton1.TextColor = Color.FromArgb(64, 64, 64);
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(customButton1);
            Controls.Add(panel3);
            Controls.Add(materialScrollBar1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "ProductManagementForm";
            Text = "Productos";
            Load += ProductManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            btnPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Panel panel1;
        private Label lblPrincipal;
        private Panel btnPanel;
        private CustomComponents.MainFormComponents.CustomButton btnAnadir;
        private CustomComponents.MainFormComponents.CustomButton btnBorrar;
        private CustomComponents.MainFormComponents.CustomButton btnEditar;
        private Panel panel2;
        private Label cltTxtRegistros;
        private Label cltTxtFiltrados;
        private MaterialSkin.Controls.MaterialScrollBar materialScrollBar1;
        private DataGridViewTextBoxColumn ProductID;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn Lote;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn StateColumn;
        private DataGridViewTextBoxColumn CategoryColumn;
        private Panel panel3;
        private CustomComponents.MainFormComponents.CustomTextBox customTextBox1;
        private Label lblFiltrados;
        private Label lblTotalFiltrados;
        private CustomComponents.MainFormComponents.CustomButton customButton1;
    }
}