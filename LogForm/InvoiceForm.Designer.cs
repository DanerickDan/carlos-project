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
            dataGridView1 = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            ClientColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            QuatityColumn = new DataGridViewTextBoxColumn();
            NetoColumn = new DataGridViewTextBoxColumn();
            TotalColumn = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            btnPanel = new Panel();
            btnAnadir = new CustomComponents.MainFormComponents.CustomButton();
            btnBorrar = new CustomComponents.MainFormComponents.CustomButton();
            btnEditar = new CustomComponents.MainFormComponents.CustomButton();
            btnImprimir = new CustomComponents.MainFormComponents.CustomButton();
            lblPrincipal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            btnPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, ClientColumn, DescriptionColumn, DateColumn, QuatityColumn, NetoColumn, TotalColumn });
            dataGridView1.Location = new Point(0, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(800, 392);
            dataGridView1.TabIndex = 0;
            // 
            // NumberColumn
            // 
            NumberColumn.HeaderText = "Número";
            NumberColumn.Name = "NumberColumn";
            NumberColumn.ReadOnly = true;
            // 
            // ClientColumn
            // 
            ClientColumn.HeaderText = "Cliente";
            ClientColumn.Name = "ClientColumn";
            ClientColumn.ReadOnly = true;
            // 
            // DescriptionColumn
            // 
            DescriptionColumn.HeaderText = "Descripción";
            DescriptionColumn.Name = "DescriptionColumn";
            DescriptionColumn.ReadOnly = true;
            // 
            // DateColumn
            // 
            DateColumn.HeaderText = "Fecha";
            DateColumn.Name = "DateColumn";
            DateColumn.ReadOnly = true;
            // 
            // QuatityColumn
            // 
            QuatityColumn.HeaderText = "Cantidad";
            QuatityColumn.Name = "QuatityColumn";
            QuatityColumn.ReadOnly = true;
            // 
            // NetoColumn
            // 
            NetoColumn.HeaderText = "Neto";
            NetoColumn.Name = "NetoColumn";
            NetoColumn.ReadOnly = true;
            // 
            // TotalColumn
            // 
            TotalColumn.HeaderText = "Total";
            TotalColumn.Name = "TotalColumn";
            TotalColumn.ReadOnly = true;
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
            btnPanel.Controls.Add(btnImprimir);
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
            btnAnadir.Location = new Point(459, 7);
            btnAnadir.Name = "btnAnadir";
            btnAnadir.Size = new Size(127, 37);
            btnAnadir.TabIndex = 0;
            btnAnadir.Text = "Añadir";
            btnAnadir.TextColor = Color.White;
            btnAnadir.UseVisualStyleBackColor = false;
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
            btnEditar.Location = new Point(182, 7);
            btnEditar.Margin = new Padding(8, 3, 3, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(127, 37);
            btnEditar.TabIndex = 0;
            btnEditar.Text = "Editar";
            btnEditar.TextColor = Color.White;
            btnEditar.UseVisualStyleBackColor = false;
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
            btnImprimir.Location = new Point(44, 7);
            btnImprimir.Margin = new Padding(8, 3, 3, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(127, 37);
            btnImprimir.TabIndex = 0;
            btnImprimir.Text = "Imprimir";
            btnImprimir.TextColor = Color.White;
            btnImprimir.UseVisualStyleBackColor = false;
            // 
            // lblPrincipal
            // 
            lblPrincipal.AutoSize = true;
            lblPrincipal.Font = new Font("Segoe UI", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrincipal.Location = new Point(3, 7);
            lblPrincipal.Name = "lblPrincipal";
            lblPrincipal.Size = new Size(113, 37);
            lblPrincipal.TabIndex = 8;
            lblPrincipal.Text = "Facturas";
            // 
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Name = "InvoiceForm";
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            btnPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NumberColumn;
        private DataGridViewTextBoxColumn ClientColumn;
        private DataGridViewTextBoxColumn DescriptionColumn;
        private DataGridViewTextBoxColumn DateColumn;
        private DataGridViewTextBoxColumn QuatityColumn;
        private DataGridViewTextBoxColumn NetoColumn;
        private DataGridViewTextBoxColumn TotalColumn;
        private Panel panel1;
        private Panel btnPanel;
        private CustomComponents.MainFormComponents.CustomButton btnAnadir;
        private CustomComponents.MainFormComponents.CustomButton btnBorrar;
        private CustomComponents.MainFormComponents.CustomButton btnEditar;
        private CustomComponents.MainFormComponents.CustomButton btnImprimir;
        private Label lblPrincipal;
    }
}