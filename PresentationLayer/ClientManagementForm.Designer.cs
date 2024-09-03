namespace PresentationLayer
{
    partial class ClientManagementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientManagementForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnPanel = new Panel();
            btnAnadir = new CustomComponents.MainFormComponents.CustomButton();
            btnBorrar = new CustomComponents.MainFormComponents.CustomButton();
            btnEditar = new CustomComponents.MainFormComponents.CustomButton();
            lblPrincipal = new Label();
            dataGridView1 = new DataGridView();
            materialScrollBar1 = new MaterialSkin.Controls.MaterialScrollBar();
            cltTxtRegistros = new Label();
            cltTxtFiltrados = new Label();
            panel2 = new Panel();
            ClientID = new DataGridViewTextBoxColumn();
            CodeColumn = new DataGridViewTextBoxColumn();
            NameColumn = new DataGridViewTextBoxColumn();
            AddressColumn = new DataGridViewTextBoxColumn();
            PhoneColumn = new DataGridViewTextBoxColumn();
            RNcColumn = new DataGridViewTextBoxColumn();
            EmailColumn = new DataGridViewTextBoxColumn();
            City = new DataGridViewTextBoxColumn();
            Fax = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            btnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnPanel);
            panel1.Controls.Add(lblPrincipal);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 2;
            // 
            // btnPanel
            // 
            btnPanel.BackColor = SystemColors.Control;
            btnPanel.Controls.Add(btnAnadir);
            btnPanel.Controls.Add(btnBorrar);
            btnPanel.Controls.Add(btnEditar);
            btnPanel.Dock = DockStyle.Right;
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
            btnAnadir.Location = new Point(448, 7);
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
            btnBorrar.Location = new Point(315, 7);
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
            btnEditar.Location = new Point(177, 7);
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
            lblPrincipal.Size = new Size(111, 37);
            lblPrincipal.TabIndex = 8;
            lblPrincipal.Text = "Clientes";
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ClientID, CodeColumn, NameColumn, AddressColumn, PhoneColumn, RNcColumn, EmailColumn, City, Fax });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 53);
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
            dataGridView1.Size = new Size(785, 365);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            // 
            // materialScrollBar1
            // 
            materialScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            materialScrollBar1.Depth = 0;
            materialScrollBar1.Location = new Point(783, 84);
            materialScrollBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialScrollBar1.Name = "materialScrollBar1";
            materialScrollBar1.Orientation = MaterialSkin.Controls.MaterialScrollOrientation.Vertical;
            materialScrollBar1.ScrollbarSize = 17;
            materialScrollBar1.Size = new Size(17, 334);
            materialScrollBar1.TabIndex = 3;
            materialScrollBar1.Text = "materialScrollBar1";
            materialScrollBar1.Scroll += materialScrollBar1_Scroll;
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
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(cltTxtRegistros);
            panel2.Controls.Add(cltTxtFiltrados);
            panel2.Location = new Point(52, 424);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 23);
            panel2.TabIndex = 5;
            // 
            // ClientID
            // 
            ClientID.DataPropertyName = "ClientID";
            ClientID.HeaderText = "ClienteID";
            ClientID.Name = "ClientID";
            ClientID.ReadOnly = true;
            ClientID.Visible = false;
            // 
            // CodeColumn
            // 
            CodeColumn.DataPropertyName = "Code";
            CodeColumn.HeaderText = "Codígo";
            CodeColumn.Name = "CodeColumn";
            CodeColumn.ReadOnly = true;
            // 
            // NameColumn
            // 
            NameColumn.DataPropertyName = "ClientName";
            NameColumn.HeaderText = "Nombre";
            NameColumn.Name = "NameColumn";
            NameColumn.ReadOnly = true;
            // 
            // AddressColumn
            // 
            AddressColumn.DataPropertyName = "Address";
            AddressColumn.HeaderText = "Dirección";
            AddressColumn.Name = "AddressColumn";
            AddressColumn.ReadOnly = true;
            // 
            // PhoneColumn
            // 
            PhoneColumn.DataPropertyName = "PhoneNumber";
            PhoneColumn.HeaderText = "Teléfono";
            PhoneColumn.Name = "PhoneColumn";
            PhoneColumn.ReadOnly = true;
            // 
            // RNcColumn
            // 
            RNcColumn.DataPropertyName = "Rnc";
            RNcColumn.HeaderText = "RNC";
            RNcColumn.Name = "RNcColumn";
            RNcColumn.ReadOnly = true;
            // 
            // EmailColumn
            // 
            EmailColumn.DataPropertyName = "Email";
            EmailColumn.HeaderText = "Correo";
            EmailColumn.Name = "EmailColumn";
            EmailColumn.ReadOnly = true;
            // 
            // City
            // 
            City.DataPropertyName = "City";
            City.HeaderText = "Ciudad";
            City.Name = "City";
            City.ReadOnly = true;
            City.Visible = false;
            // 
            // Fax
            // 
            Fax.DataPropertyName = "Fax";
            Fax.HeaderText = "Fax";
            Fax.Name = "Fax";
            Fax.ReadOnly = true;
            Fax.Visible = false;
            // 
            // ClientManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(materialScrollBar1);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(panel2);
            Name = "ClientManagementForm";
            Text = "Clientes";
            Load += ClientManagementForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            btnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel btnPanel;
        private CustomComponents.MainFormComponents.CustomButton btnAnadir;
        private CustomComponents.MainFormComponents.CustomButton btnBorrar;
        private CustomComponents.MainFormComponents.CustomButton btnEditar;
        private Label lblPrincipal;
        private DataGridView dataGridView1;
        private MaterialSkin.Controls.MaterialScrollBar materialScrollBar1;
        private Label cltTxtRegistros;
        private Label cltTxtFiltrados;
        private Panel panel2;
        private DataGridViewTextBoxColumn ClientID;
        private DataGridViewTextBoxColumn CodeColumn;
        private DataGridViewTextBoxColumn NameColumn;
        private DataGridViewTextBoxColumn AddressColumn;
        private DataGridViewTextBoxColumn PhoneColumn;
        private DataGridViewTextBoxColumn RNcColumn;
        private DataGridViewTextBoxColumn EmailColumn;
        private DataGridViewTextBoxColumn City;
        private DataGridViewTextBoxColumn Fax;
    }
}