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
            dataGridView1 = new DataGridView();
            NumberColumn = new DataGridViewTextBoxColumn();
            ClientColumn = new DataGridViewTextBoxColumn();
            DescriptionColumn = new DataGridViewTextBoxColumn();
            DateColumn = new DataGridViewTextBoxColumn();
            QuatityColumn = new DataGridViewTextBoxColumn();
            NetoColumn = new DataGridViewTextBoxColumn();
            TotalColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NumberColumn, ClientColumn, DescriptionColumn, DateColumn, QuatityColumn, NetoColumn, TotalColumn });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(800, 450);
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
            // InvoiceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Name = "InvoiceForm";
            Text = "Facturas";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
    }
}