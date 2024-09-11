namespace PresentationLayer
{
    partial class InvoiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnPanel = new Panel();
            btnAnadir = new CustomComponents.MainFormComponents.CustomButton();
            btnBorrar = new CustomComponents.MainFormComponents.CustomButton();
            btnImprimir = new CustomComponents.MainFormComponents.CustomButton();
            lblPrincipal = new Label();
            dataGridView1 = new DataGridView();
            InvoiceID = new DataGridViewTextBoxColumn();
            OrderNumber = new DataGridViewTextBoxColumn();
            Terms = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            ClientID = new DataGridViewTextBoxColumn();
            SellerName = new DataGridViewTextBoxColumn();
            Neto = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Lote = new DataGridViewTextBoxColumn();
            NCF = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ProductCode = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            ProductId = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            panel2 = new Panel();
            lblFiltrados = new Label();
            lblTotalRegistros = new Label();
            cltTxtRegistros = new Label();
            cltTxtFiltrados = new Label();
            materialScrollBar1 = new MaterialSkin.Controls.MaterialScrollBar();
            panel3 = new Panel();
            txtSearch = new CustomComponents.MainFormComponents.CustomTextBox();
            customButton1 = new CustomComponents.MainFormComponents.CustomButton();
            panel1.SuspendLayout();
            btnPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(btnPanel);
            panel1.Controls.Add(lblPrincipal);
            panel1.Location = new Point(0, 71);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(914, 63);
            panel1.TabIndex = 2;
            // 
            // btnPanel
            // 
            btnPanel.Anchor = AnchorStyles.Right;
            btnPanel.BackColor = SystemColors.Control;
            btnPanel.Controls.Add(btnAnadir);
            btnPanel.Controls.Add(btnBorrar);
            btnPanel.Controls.Add(btnImprimir);
            btnPanel.Location = new Point(215, 0);
            btnPanel.Margin = new Padding(3, 4, 3, 4);
            btnPanel.Name = "btnPanel";
            btnPanel.Size = new Size(699, 63);
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
            btnAnadir.Location = new Point(525, 9);
            btnAnadir.Margin = new Padding(3, 4, 3, 4);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(145, 49);
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
            btnBorrar.Location = new Point(366, 9);
            btnBorrar.Margin = new Padding(9, 4, 3, 4);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(145, 49);
            btnBorrar.TabIndex = 0;
            btnBorrar.Text = "Eliminar";
            btnBorrar.TextColor = Color.White;
            btnBorrar.UseVisualStyleBackColor = false;
            btnBorrar.Click += btnBorrar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Anchor = AnchorStyles.Left;
            btnImprimir.BackColor = Color.FromArgb(243, 156, 76);
            btnImprimir.BackgroundColor = Color.FromArgb(243, 156, 76);
            btnImprimir.BorderColor = Color.PaleVioletRed;
            btnImprimir.BorderRadius = 5;
            btnImprimir.BorderSize = 0;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Image = (Image)resources.GetObject("btnImprimir.Image");
            btnImprimir.ImageAlign = ContentAlignment.MiddleLeft;
            btnImprimir.Location = new Point(208, 9);
            btnImprimir.Margin = new Padding(9, 4, 3, 4);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(145, 49);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextColor = Color.White;
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // lblPrincipal
            // 
            lblPrincipal.Anchor = AnchorStyles.Left;
            lblPrincipal.AutoSize = true;
            lblPrincipal.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrincipal.Location = new Point(3, 9);
            lblPrincipal.Name = "lblPrincipal";
            lblPrincipal.Size = new Size(143, 46);
            lblPrincipal.TabIndex = 8;
            lblPrincipal.Text = "Facturas";
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
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(248, 196, 96);
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { InvoiceID, OrderNumber, Terms, Date, ClientID, SellerName, Neto, Price, Total, Lote, NCF, Quantity, ProductCode, SubTotal, ProductId, Number });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 137);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Control;
            dataGridViewCellStyle12.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle12.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(899, 495);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            // 
            // InvoiceID
            // 
            InvoiceID.DataPropertyName = "InvoiceID";
            InvoiceID.HeaderText = "Id";
            InvoiceID.MinimumWidth = 6;
            InvoiceID.Name = "InvoiceID";
            InvoiceID.ReadOnly = true;
            InvoiceID.Visible = false;
            // 
            // OrderNumber
            // 
            OrderNumber.DataPropertyName = "OrderNumber";
            OrderNumber.HeaderText = "Número de Orden";
            OrderNumber.MinimumWidth = 6;
            OrderNumber.Name = "OrderNumber";
            OrderNumber.ReadOnly = true;
            // 
            // Terms
            // 
            Terms.DataPropertyName = "Terms";
            Terms.HeaderText = "Termino";
            Terms.MinimumWidth = 6;
            Terms.Name = "Terms";
            Terms.ReadOnly = true;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Fecha";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // ClientID
            // 
            ClientID.DataPropertyName = "ClientID";
            ClientID.HeaderText = "Cliente";
            ClientID.MinimumWidth = 6;
            ClientID.Name = "ClientID";
            ClientID.ReadOnly = true;
            // 
            // SellerName
            // 
            SellerName.DataPropertyName = "SellerName";
            SellerName.HeaderText = "Vendedor";
            SellerName.MinimumWidth = 6;
            SellerName.Name = "SellerName";
            SellerName.ReadOnly = true;
            // 
            // Neto
            // 
            Neto.DataPropertyName = "Neto";
            Neto.HeaderText = "Neto";
            Neto.MinimumWidth = 6;
            Neto.Name = "Neto";
            Neto.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Precio";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Visible = false;
            // 
            // Total
            // 
            Total.DataPropertyName = "Total";
            dataGridViewCellStyle10.ForeColor = Color.MediumSeaGreen;
            Total.DefaultCellStyle = dataGridViewCellStyle10;
            Total.HeaderText = "Total";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // Lote
            // 
            Lote.DataPropertyName = "Lote";
            Lote.HeaderText = "Lote";
            Lote.MinimumWidth = 6;
            Lote.Name = "Lote";
            Lote.ReadOnly = true;
            Lote.Visible = false;
            // 
            // NCF
            // 
            NCF.DataPropertyName = "NCF";
            NCF.HeaderText = "NCF";
            NCF.MinimumWidth = 6;
            NCF.Name = "NCF";
            NCF.ReadOnly = true;
            NCF.Visible = false;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Cantidad";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Visible = false;
            // 
            // ProductCode
            // 
            ProductCode.DataPropertyName = "ProductCode";
            ProductCode.HeaderText = "Codigo";
            ProductCode.MinimumWidth = 6;
            ProductCode.Name = "ProductCode";
            ProductCode.ReadOnly = true;
            ProductCode.Visible = false;
            // 
            // SubTotal
            // 
            SubTotal.DataPropertyName = "SubTotal";
            SubTotal.HeaderText = "SubTotal";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            SubTotal.ReadOnly = true;
            SubTotal.Visible = false;
            // 
            // ProductId
            // 
            ProductId.DataPropertyName = "ProductId";
            ProductId.HeaderText = "ProductId";
            ProductId.MinimumWidth = 6;
            ProductId.Name = "ProductId";
            ProductId.ReadOnly = true;
            ProductId.Visible = false;
            // 
            // Number
            // 
            Number.DataPropertyName = "Number";
            Number.HeaderText = "NumeroFactura";
            Number.MinimumWidth = 6;
            Number.Name = "Number";
            Number.ReadOnly = true;
            Number.Visible = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.Controls.Add(lblFiltrados);
            panel2.Controls.Add(lblTotalRegistros);
            panel2.Controls.Add(cltTxtRegistros);
            panel2.Controls.Add(cltTxtFiltrados);
            panel2.Location = new Point(37, 659);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(310, 31);
            panel2.TabIndex = 6;
            // 
            // lblFiltrados
            // 
            lblFiltrados.AutoSize = true;
            lblFiltrados.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFiltrados.Location = new Point(264, 7);
            lblFiltrados.Name = "lblFiltrados";
            lblFiltrados.Size = new Size(17, 20);
            lblFiltrados.TabIndex = 6;
            lblFiltrados.Text = "0";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRegistros.Location = new Point(101, 7);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(17, 20);
            lblTotalRegistros.TabIndex = 5;
            lblTotalRegistros.Text = "0";
            // 
            // cltTxtRegistros
            // 
            cltTxtRegistros.AutoSize = true;
            cltTxtRegistros.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cltTxtRegistros.ForeColor = Color.Gray;
            cltTxtRegistros.Location = new Point(22, 4);
            cltTxtRegistros.Name = "cltTxtRegistros";
            cltTxtRegistros.Size = new Size(79, 23);
            cltTxtRegistros.TabIndex = 4;
            cltTxtRegistros.Text = "Registros";
            // 
            // cltTxtFiltrados
            // 
            cltTxtFiltrados.AutoSize = true;
            cltTxtFiltrados.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cltTxtFiltrados.ForeColor = Color.Gray;
            cltTxtFiltrados.Location = new Point(191, 4);
            cltTxtFiltrados.Name = "cltTxtFiltrados";
            cltTxtFiltrados.Size = new Size(74, 23);
            cltTxtFiltrados.TabIndex = 4;
            cltTxtFiltrados.Text = "Filtrados";
            // 
            // materialScrollBar1
            // 
            materialScrollBar1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            materialScrollBar1.Depth = 0;
            materialScrollBar1.Location = new Point(899, 177);
            materialScrollBar1.Margin = new Padding(3, 4, 3, 4);
            materialScrollBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialScrollBar1.Name = "materialScrollBar1";
            materialScrollBar1.Orientation = MaterialSkin.Controls.MaterialScrollOrientation.Vertical;
            materialScrollBar1.ScrollbarSize = 15;
            materialScrollBar1.Size = new Size(15, 455);
            materialScrollBar1.TabIndex = 7;
            materialScrollBar1.Text = "materialScrollBar1";
            materialScrollBar1.Scroll += materialScrollBar1_Scroll;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(txtSearch);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(914, 51);
            panel3.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.Gainsboro;
            txtSearch.BorderColor = Color.GhostWhite;
            txtSearch.BorderFocusColor = Color.GhostWhite;
            txtSearch.BorderRadius = 9;
            txtSearch.BorderSize = 1;
            txtSearch.Font = new Font("Segoe UI", 9.5F);
            txtSearch.ForeColor = Color.DimGray;
            txtSearch.Location = new Point(8, 4);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Multiline = false;
            txtSearch.Name = "txtSearch";
            txtSearch.Padding = new Padding(11, 9, 11, 9);
            txtSearch.PasswordChar = false;
            txtSearch.PlaceholderColor = Color.DarkGray;
            txtSearch.PlaceholderText = "Buscar";
            txtSearch.Size = new Size(286, 40);
            txtSearch.TabIndex = 0;
            txtSearch.Texts = "";
            txtSearch.UnderlinedStyle = false;
            txtSearch._TextChanged += txtSearch__TextChanged;
            // 
            // customButton1
            // 
            customButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            customButton1.BackColor = Color.MediumSeaGreen;
            customButton1.BackgroundColor = Color.MediumSeaGreen;
            customButton1.BorderColor = Color.PaleVioletRed;
            customButton1.BorderRadius = 5;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            customButton1.ForeColor = Color.FromArgb(64, 64, 64);
            customButton1.Image = (Image)resources.GetObject("customButton1.Image");
            customButton1.ImageAlign = ContentAlignment.MiddleLeft;
            customButton1.Location = new Point(746, 640);
            customButton1.Margin = new Padding(9, 4, 3, 4);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(154, 49);
            customButton1.TabIndex = 9;
            customButton1.Text = "Generar CSV";
            customButton1.TextColor = Color.FromArgb(64, 64, 64);
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 696);
            Controls.Add(customButton1);
            Controls.Add(panel3);
            Controls.Add(materialScrollBar1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "InvoiceForm";
            Text = "Facturas";
            Load += InvoiceForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            btnPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Panel btnPanel;
        private CustomComponents.MainFormComponents.CustomButton btnAnadir;
        private CustomComponents.MainFormComponents.CustomButton btnBorrar;
        private CustomComponents.MainFormComponents.CustomButton btnImprimir;
        private Label lblPrincipal;
        private DataGridView dataGridView1;
        private Panel panel2;
        private Label cltTxtRegistros;
        private Label cltTxtFiltrados;
        private MaterialSkin.Controls.MaterialScrollBar materialScrollBar1;
        private DataGridViewTextBoxColumn InvoiceID;
        private DataGridViewTextBoxColumn OrderNumber;
        private DataGridViewTextBoxColumn Terms;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn ClientID;
        private DataGridViewTextBoxColumn SellerName;
        private DataGridViewTextBoxColumn Neto;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Lote;
        private DataGridViewTextBoxColumn NCF;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn ProductCode;
        private DataGridViewTextBoxColumn SubTotal;
        private DataGridViewTextBoxColumn ProductId;
        private DataGridViewTextBoxColumn Number;
        private Panel panel3;
        private CustomComponents.MainFormComponents.CustomTextBox txtSearch;
        private Label lblFiltrados;
        private Label lblTotalRegistros;
        private CustomComponents.MainFormComponents.CustomButton customButton1;
    }
}