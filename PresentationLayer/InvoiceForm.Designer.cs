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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            customTextBox1 = new CustomComponents.MainFormComponents.CustomTextBox();
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
            panel1.Location = new Point(0, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 2;
            // 
            // btnPanel
            // 
            btnPanel.Anchor = AnchorStyles.Right;
            btnPanel.BackColor = SystemColors.Control;
            btnPanel.Controls.Add(btnAnadir);
            btnPanel.Controls.Add(btnBorrar);
            btnPanel.Controls.Add(btnImprimir);
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
            btnAnadir.Location = new Point(459, 7);
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
            btnBorrar.Location = new Point(320, 7);
            btnBorrar.Margin = new Padding(8, 3, 3, 3);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(127, 37);
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
            btnImprimir.Location = new Point(182, 7);
            btnImprimir.Margin = new Padding(8, 3, 3, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(127, 37);
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
            lblPrincipal.Location = new Point(3, 7);
            lblPrincipal.Name = "lblPrincipal";
            lblPrincipal.Size = new Size(113, 37);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 196, 96);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { InvoiceID, OrderNumber, Terms, Date, ClientID, SellerName, Neto, Price, Total, Lote, NCF, Quantity, ProductCode, SubTotal, ProductId, Number });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(243, 156, 76);
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.Location = new Point(0, 103);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.ScrollBars = ScrollBars.None;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(787, 385);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            // 
            // InvoiceID
            // 
            InvoiceID.DataPropertyName = "InvoiceID";
            InvoiceID.HeaderText = "Id";
            InvoiceID.Name = "InvoiceID";
            InvoiceID.ReadOnly = true;
            InvoiceID.Visible = false;
            // 
            // OrderNumber
            // 
            OrderNumber.DataPropertyName = "OrderNumber";
            OrderNumber.HeaderText = "Número de Orden";
            OrderNumber.Name = "OrderNumber";
            OrderNumber.ReadOnly = true;
            // 
            // Terms
            // 
            Terms.DataPropertyName = "Terms";
            Terms.HeaderText = "Termino";
            Terms.Name = "Terms";
            Terms.ReadOnly = true;
            // 
            // Date
            // 
            Date.DataPropertyName = "Date";
            Date.HeaderText = "Fecha";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // ClientID
            // 
            ClientID.DataPropertyName = "ClientID";
            ClientID.HeaderText = "Cliente";
            ClientID.Name = "ClientID";
            ClientID.ReadOnly = true;
            // 
            // SellerName
            // 
            SellerName.DataPropertyName = "SellerName";
            SellerName.HeaderText = "Vendedor";
            SellerName.Name = "SellerName";
            SellerName.ReadOnly = true;
            // 
            // Neto
            // 
            Neto.DataPropertyName = "Neto";
            Neto.HeaderText = "Neto";
            Neto.Name = "Neto";
            Neto.ReadOnly = true;
            // 
            // Price
            // 
            Price.DataPropertyName = "Price";
            Price.HeaderText = "Precio";
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Visible = false;
            // 
            // Total
            // 
            Total.DataPropertyName = "Total";
            dataGridViewCellStyle2.ForeColor = Color.MediumSeaGreen;
            Total.DefaultCellStyle = dataGridViewCellStyle2;
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // Lote
            // 
            Lote.DataPropertyName = "Lote";
            Lote.HeaderText = "Lote";
            Lote.Name = "Lote";
            Lote.ReadOnly = true;
            Lote.Visible = false;
            // 
            // NCF
            // 
            NCF.DataPropertyName = "NCF";
            NCF.HeaderText = "NCF";
            NCF.Name = "NCF";
            NCF.ReadOnly = true;
            NCF.Visible = false;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Cantidad";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            Quantity.Visible = false;
            // 
            // ProductCode
            // 
            ProductCode.DataPropertyName = "ProductCode";
            ProductCode.HeaderText = "Codigo";
            ProductCode.Name = "ProductCode";
            ProductCode.ReadOnly = true;
            ProductCode.Visible = false;
            // 
            // SubTotal
            // 
            SubTotal.DataPropertyName = "SubTotal";
            SubTotal.HeaderText = "SubTotal";
            SubTotal.Name = "SubTotal";
            SubTotal.ReadOnly = true;
            SubTotal.Visible = false;
            // 
            // ProductId
            // 
            ProductId.DataPropertyName = "ProductId";
            ProductId.HeaderText = "ProductId";
            ProductId.Name = "ProductId";
            ProductId.ReadOnly = true;
            ProductId.Visible = false;
            // 
            // Number
            // 
            Number.DataPropertyName = "Number";
            Number.HeaderText = "NumeroFactura";
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
            panel2.Location = new Point(32, 494);
            panel2.Name = "panel2";
            panel2.Size = new Size(271, 23);
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
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalRegistros.Location = new Point(88, 5);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(13, 15);
            lblTotalRegistros.TabIndex = 5;
            lblTotalRegistros.Text = "0";
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
            materialScrollBar1.Location = new Point(787, 130);
            materialScrollBar1.MouseState = MaterialSkin.MouseState.HOVER;
            materialScrollBar1.Name = "materialScrollBar1";
            materialScrollBar1.Orientation = MaterialSkin.Controls.MaterialScrollOrientation.Vertical;
            materialScrollBar1.ScrollbarSize = 13;
            materialScrollBar1.Size = new Size(13, 358);
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
            customTextBox1.BorderColor = Color.GhostWhite;
            customTextBox1.BorderFocusColor = Color.GhostWhite;
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
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 522);
            Controls.Add(panel3);
            Controls.Add(materialScrollBar1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
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
        private CustomComponents.MainFormComponents.CustomTextBox customTextBox1;
        private Label lblFiltrados;
        private Label lblTotalRegistros;
    }
}