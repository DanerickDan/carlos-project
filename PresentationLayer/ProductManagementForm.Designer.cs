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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductManagementForm));
            dataGridView1 = new DataGridView();
            Code = new DataGridViewTextBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            CategoryColumn = new DataGridViewTextBoxColumn();
            TimeColumn = new DataGridViewTextBoxColumn();
            StateColumn = new DataGridViewTextBoxColumn();
            ProductID = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnPanel = new Panel();
            btnAnadir = new CustomComponents.MainFormComponents.CustomButton();
            btnBorrar = new CustomComponents.MainFormComponents.CustomButton();
            btnEditar = new CustomComponents.MainFormComponents.CustomButton();
            lblPrincipal = new Label();
            panel2 = new Panel();
            cltTxtRegistros = new Label();
            cltTxtFiltrados = new Label();
            materialScrollBar1 = new MaterialSkin.Controls.MaterialScrollBar();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            btnPanel.SuspendLayout();
            panel2.SuspendLayout();
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
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(248, 196, 96);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Code, NameColumn, DescriptionColumn, Quantity, CategoryColumn, TimeColumn, StateColumn, ProductID });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(814, 370);
            dataGridView1.TabIndex = 0;
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
            // CategoryColumn
            // 
            CategoryColumn.DataPropertyName = "CategoryId";
            CategoryColumn.HeaderText = "Categoria";
            CategoryColumn.Name = "CategoryColumn";
            CategoryColumn.ReadOnly = true;
            CategoryColumn.Visible = false;
            // 
            // TimeColumn
            // 
            TimeColumn.DataPropertyName = "ExpirationDate";
            TimeColumn.HeaderText = "Expiracion";
            TimeColumn.Name = "TimeColumn";
            TimeColumn.ReadOnly = true;
            // 
            // StateColumn
            // 
            StateColumn.DataPropertyName = "StatusId";
            StateColumn.HeaderText = "Estado";
            StateColumn.Name = "StateColumn";
            StateColumn.ReadOnly = true;
            // 
            // ProductID
            // 
            ProductID.HeaderText = "ProductID";
            ProductID.Name = "ProductID";
            ProductID.ReadOnly = true;
            ProductID.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPanel);
            panel1.Controls.Add(lblPrincipal);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(830, 47);
            panel1.TabIndex = 1;
            // 
            // btnPanel
            // 
            btnPanel.BackColor = SystemColors.Control;
            btnPanel.Controls.Add(btnAnadir);
            btnPanel.Controls.Add(btnBorrar);
            btnPanel.Controls.Add(btnEditar);
            btnPanel.Dock = DockStyle.Right;
            btnPanel.Location = new Point(218, 0);
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
            btnAnadir.Location = new Point(448, 6);
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
            btnBorrar.Location = new Point(315, 6);
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
            btnEditar.Location = new Point(177, 6);
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
            panel2.Controls.Add(cltTxtRegistros);
            panel2.Controls.Add(cltTxtFiltrados);
            panel2.Location = new Point(51, 425);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 23);
            panel2.TabIndex = 6;
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
            materialScrollBar1.Location = new Point(812, 80);
            materialScrollBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialScrollBar1.Name = "materialScrollBar1";
            materialScrollBar1.Orientation = MaterialSkin.Controls.MaterialScrollOrientation.Vertical;
            materialScrollBar1.ScrollbarSize = 15;
            materialScrollBar1.Size = new Size(15, 339);
            materialScrollBar1.TabIndex = 7;
            materialScrollBar1.Text = "materialScrollBar1";
            materialScrollBar1.Scroll += materialScrollBar1_Scroll;
            // 
            // ProductManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(830, 449);
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
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn CategoryColumn;
        private DataGridViewTextBoxColumn TimeColumn;
        private DataGridViewTextBoxColumn StateColumn;
        private DataGridViewTextBoxColumn ProductID;
        private Panel panel2;
        private Label cltTxtRegistros;
        private Label cltTxtFiltrados;
        private MaterialSkin.Controls.MaterialScrollBar materialScrollBar1;
    }
}