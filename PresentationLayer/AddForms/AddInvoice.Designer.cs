namespace PresentationLayer.AddForms
{
    partial class AddInvoice
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panelEjemplo = new Panel();
            label4 = new Label();
            cbFacturaDe = new CustomComponents.MainFormComponents.CustomComboBox();
            cbTerminos = new CustomComponents.MainFormComponents.CustomComboBox();
            cbFacturaPara = new CustomComponents.MainFormComponents.CustomComboBox();
            label5 = new Label();
            txtPrecio = new CustomComponents.MainFormComponents.CustomTextBox();
            txtCantidad = new CustomComponents.MainFormComponents.CustomTextBox();
            txtNeto = new CustomComponents.MainFormComponents.CustomTextBox();
            btnAgregarProd = new Button();
            label6 = new Label();
            txtDescrip = new CustomComponents.MainFormComponents.CustomTextBox();
            btnCrear = new CustomComponents.MainFormComponents.CustomButton();
            cbProductNombre = new CustomComponents.MainFormComponents.CustomComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 49);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "Factura de";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(241, 49);
            label2.Name = "label2";
            label2.Size = new Size(118, 25);
            label2.TabIndex = 0;
            label2.Text = "Factura para";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(451, 49);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 0;
            label3.Text = "Terminos";
            // 
            // panelEjemplo
            // 
            panelEjemplo.BackColor = SystemColors.ActiveBorder;
            panelEjemplo.Location = new Point(620, 73);
            panelEjemplo.Name = "panelEjemplo";
            panelEjemplo.Size = new Size(320, 366);
            panelEjemplo.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(725, 45);
            label4.Name = "label4";
            label4.Size = new Size(124, 25);
            label4.TabIndex = 0;
            label4.Text = "Ejemplo final";
            // 
            // cbFacturaDe
            // 
            cbFacturaDe.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFacturaDe.BackColor = Color.WhiteSmoke;
            cbFacturaDe.BorderColor = SystemColors.Control;
            cbFacturaDe.BorderSize = 1;
            cbFacturaDe.DropDownStyle = ComboBoxStyle.DropDown;
            cbFacturaDe.Font = new Font("Segoe UI", 10F);
            cbFacturaDe.ForeColor = Color.DimGray;
            cbFacturaDe.IconColor = Color.FromArgb(248, 169, 96);
            cbFacturaDe.Items.AddRange(new object[] { "Carlos Radhames", "Johanna Rodriguez" });
            cbFacturaDe.ListBackColor = Color.FromArgb(230, 228, 245);
            cbFacturaDe.ListTextColor = Color.DimGray;
            cbFacturaDe.Location = new Point(31, 77);
            cbFacturaDe.MinimumSize = new Size(150, 30);
            cbFacturaDe.Name = "cbFacturaDe";
            cbFacturaDe.Padding = new Padding(1);
            cbFacturaDe.Size = new Size(170, 30);
            cbFacturaDe.TabIndex = 2;
            cbFacturaDe.Texts = "";
            // 
            // cbTerminos
            // 
            cbTerminos.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbTerminos.BackColor = Color.WhiteSmoke;
            cbTerminos.BorderColor = SystemColors.Control;
            cbTerminos.BorderSize = 1;
            cbTerminos.DropDownStyle = ComboBoxStyle.DropDown;
            cbTerminos.Font = new Font("Segoe UI", 10F);
            cbTerminos.ForeColor = Color.DimGray;
            cbTerminos.IconColor = Color.FromArgb(248, 169, 96);
            cbTerminos.Items.AddRange(new object[] { "Credito", "Contado" });
            cbTerminos.ListBackColor = Color.FromArgb(230, 228, 245);
            cbTerminos.ListTextColor = Color.DimGray;
            cbTerminos.Location = new Point(451, 77);
            cbTerminos.MinimumSize = new Size(150, 30);
            cbTerminos.Name = "cbTerminos";
            cbTerminos.Padding = new Padding(1);
            cbTerminos.Size = new Size(150, 30);
            cbTerminos.TabIndex = 2;
            cbTerminos.Texts = "";
            // 
            // cbFacturaPara
            // 
            cbFacturaPara.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFacturaPara.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFacturaPara.BackColor = Color.WhiteSmoke;
            cbFacturaPara.BorderColor = SystemColors.Control;
            cbFacturaPara.BorderSize = 1;
            cbFacturaPara.DropDownStyle = ComboBoxStyle.DropDown;
            cbFacturaPara.Font = new Font("Segoe UI", 10F);
            cbFacturaPara.ForeColor = Color.DimGray;
            cbFacturaPara.IconColor = Color.FromArgb(248, 169, 96);
            cbFacturaPara.ListBackColor = Color.FromArgb(230, 228, 245);
            cbFacturaPara.ListTextColor = Color.DimGray;
            cbFacturaPara.Location = new Point(241, 77);
            cbFacturaPara.MinimumSize = new Size(150, 30);
            cbFacturaPara.Name = "cbFacturaPara";
            cbFacturaPara.Padding = new Padding(1);
            cbFacturaPara.Size = new Size(167, 30);
            cbFacturaPara.TabIndex = 2;
            cbFacturaPara.Texts = "";
            cbFacturaPara.OnSelectedIndexChanged += cbFacturaPara_OnSelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 154);
            label5.Name = "label5";
            label5.Size = new Size(111, 30);
            label5.TabIndex = 3;
            label5.Text = "Productos";
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderColor = Color.DarkGray;
            txtPrecio.BorderFocusColor = Color.HotPink;
            txtPrecio.BorderRadius = 6;
            txtPrecio.BorderSize = 1;
            txtPrecio.Font = new Font("Segoe UI", 9.5F);
            txtPrecio.ForeColor = Color.DimGray;
            txtPrecio.Location = new Point(233, 207);
            txtPrecio.Multiline = false;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Padding = new Padding(10, 7, 10, 7);
            txtPrecio.PasswordChar = false;
            txtPrecio.PlaceholderColor = Color.DarkGray;
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(76, 32);
            txtPrecio.TabIndex = 4;
            txtPrecio.Texts = "";
            txtPrecio.UnderlinedStyle = false;
            // 
            // txtCantidad
            // 
            txtCantidad.BackColor = Color.White;
            txtCantidad.BorderColor = Color.DarkGray;
            txtCantidad.BorderFocusColor = Color.HotPink;
            txtCantidad.BorderRadius = 6;
            txtCantidad.BorderSize = 1;
            txtCantidad.Font = new Font("Segoe UI", 9.5F);
            txtCantidad.ForeColor = Color.DimGray;
            txtCantidad.Location = new Point(315, 207);
            txtCantidad.Multiline = false;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Padding = new Padding(10, 7, 10, 7);
            txtCantidad.PasswordChar = false;
            txtCantidad.PlaceholderColor = Color.DarkGray;
            txtCantidad.PlaceholderText = "Cantidad";
            txtCantidad.Size = new Size(76, 32);
            txtCantidad.TabIndex = 4;
            txtCantidad.Texts = "";
            txtCantidad.UnderlinedStyle = false;
            txtCantidad._TextChanged += txtCantidad__TextChanged;
            // 
            // txtNeto
            // 
            txtNeto.BackColor = Color.White;
            txtNeto.BorderColor = Color.DarkGray;
            txtNeto.BorderFocusColor = Color.HotPink;
            txtNeto.BorderRadius = 6;
            txtNeto.BorderSize = 1;
            txtNeto.Enabled = false;
            txtNeto.Font = new Font("Segoe UI", 9.5F);
            txtNeto.ForeColor = Color.DimGray;
            txtNeto.Location = new Point(397, 207);
            txtNeto.Multiline = false;
            txtNeto.Name = "txtNeto";
            txtNeto.Padding = new Padding(10, 7, 10, 7);
            txtNeto.PasswordChar = false;
            txtNeto.PlaceholderColor = Color.DarkGray;
            txtNeto.PlaceholderText = "Neto";
            txtNeto.Size = new Size(76, 32);
            txtNeto.TabIndex = 4;
            txtNeto.Texts = "";
            txtNeto.UnderlinedStyle = false;
            // 
            // btnAgregarProd
            // 
            btnAgregarProd.FlatAppearance.BorderSize = 0;
            btnAgregarProd.FlatStyle = FlatStyle.Flat;
            btnAgregarProd.Image = Properties.Resources.icons8_añadir_40;
            btnAgregarProd.Location = new Point(482, 205);
            btnAgregarProd.Name = "btnAgregarProd";
            btnAgregarProd.Size = new Size(41, 40);
            btnAgregarProd.TabIndex = 6;
            btnAgregarProd.UseVisualStyleBackColor = true;
            btnAgregarProd.Click += btnAgregarProd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(30, 265);
            label6.Name = "label6";
            label6.Size = new Size(112, 25);
            label6.TabIndex = 7;
            label6.Text = "Descripción";
            // 
            // txtDescrip
            // 
            txtDescrip.BackColor = Color.White;
            txtDescrip.BorderColor = Color.DarkGray;
            txtDescrip.BorderFocusColor = Color.HotPink;
            txtDescrip.BorderRadius = 6;
            txtDescrip.BorderSize = 1;
            txtDescrip.Font = new Font("Segoe UI", 9.5F);
            txtDescrip.ForeColor = Color.DimGray;
            txtDescrip.Location = new Point(31, 293);
            txtDescrip.Multiline = true;
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Padding = new Padding(10, 7, 10, 7);
            txtDescrip.PasswordChar = false;
            txtDescrip.PlaceholderColor = Color.DarkGray;
            txtDescrip.PlaceholderText = "Descripción";
            txtDescrip.Size = new Size(232, 90);
            txtDescrip.TabIndex = 4;
            txtDescrip.Texts = "";
            txtDescrip.UnderlinedStyle = false;
            // 
            // btnCrear
            // 
            btnCrear.BackColor = Color.FromArgb(248, 169, 96);
            btnCrear.BackgroundColor = Color.FromArgb(248, 169, 96);
            btnCrear.BorderColor = Color.PaleVioletRed;
            btnCrear.BorderRadius = 5;
            btnCrear.BorderSize = 0;
            btnCrear.FlatAppearance.BorderSize = 0;
            btnCrear.FlatStyle = FlatStyle.Flat;
            btnCrear.ForeColor = Color.White;
            btnCrear.Location = new Point(241, 399);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(150, 40);
            btnCrear.TabIndex = 8;
            btnCrear.Text = "Crear Factura";
            btnCrear.TextColor = Color.White;
            btnCrear.UseVisualStyleBackColor = false;
            btnCrear.Click += btnCrear_Click;
            // 
            // cbProductNombre
            // 
            cbProductNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbProductNombre.BackColor = Color.WhiteSmoke;
            cbProductNombre.BorderColor = SystemColors.Control;
            cbProductNombre.BorderSize = 1;
            cbProductNombre.DropDownStyle = ComboBoxStyle.DropDown;
            cbProductNombre.Font = new Font("Segoe UI", 10F);
            cbProductNombre.ForeColor = Color.DimGray;
            cbProductNombre.IconColor = Color.FromArgb(248, 169, 96);
            cbProductNombre.ListBackColor = Color.FromArgb(230, 228, 245);
            cbProductNombre.ListTextColor = Color.DimGray;
            cbProductNombre.Location = new Point(31, 207);
            cbProductNombre.MinimumSize = new Size(150, 30);
            cbProductNombre.Name = "cbProductNombre";
            cbProductNombre.Padding = new Padding(1);
            cbProductNombre.Size = new Size(196, 30);
            cbProductNombre.TabIndex = 2;
            cbProductNombre.Texts = "Nombre";
            cbProductNombre.OnSelectedIndexChanged += cbProductNombre_OnSelectedIndexChanged;
            // 
            // AddInvoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(952, 450);
            Controls.Add(btnCrear);
            Controls.Add(label6);
            Controls.Add(btnAgregarProd);
            Controls.Add(txtNeto);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtDescrip);
            Controls.Add(label5);
            Controls.Add(cbFacturaPara);
            Controls.Add(cbTerminos);
            Controls.Add(cbProductNombre);
            Controls.Add(cbFacturaDe);
            Controls.Add(panelEjemplo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AddInvoice";
            Text = "AddInvoice";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panelEjemplo;
        private Label label4;
        private CustomComponents.MainFormComponents.CustomComboBox cbFacturaDe;
        private CustomComponents.MainFormComponents.CustomComboBox cbTerminos;
        private CustomComponents.MainFormComponents.CustomComboBox cbFacturaPara;
        private Label label5;
        private CustomComponents.MainFormComponents.CustomTextBox txtPrecio;
        private CustomComponents.MainFormComponents.CustomTextBox txtCantidad;
        private CustomComponents.MainFormComponents.CustomTextBox txtNeto;
        private Button btnAgregarProd;
        private Label label6;
        private CustomComponents.MainFormComponents.CustomTextBox txtDescrip;
        private CustomComponents.MainFormComponents.CustomButton btnCrear;
        private CustomComponents.MainFormComponents.CustomComboBox cbProductNombre;
    }
}