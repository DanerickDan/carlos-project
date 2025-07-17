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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInvoice));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            panelEjemplo = new Panel();
            lblClienteId = new Label();
            lblFax = new Label();
            lblEmail = new Label();
            lblRnc = new Label();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            lblNeto = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblLote = new Label();
            lblDescrPr = new Label();
            lblCodigoPr = new Label();
            lblTotal = new Label();
            label14 = new Label();
            lblSubTotal = new Label();
            lblDireccion = new Label();
            label25 = new Label();
            label11 = new Label();
            label18 = new Label();
            label12 = new Label();
            label24 = new Label();
            label23 = new Label();
            label21 = new Label();
            label22 = new Label();
            label20 = new Label();
            label19 = new Label();
            lblTelefono = new Label();
            lblCiudad = new Label();
            lblCodigo = new Label();
            lblNombre = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            lblVendedor = new Label();
            lblPedido = new Label();
            lblTerminos = new Label();
            lblNumFactura = new Label();
            lblFecha = new Label();
            lblNcf = new Label();
            label13 = new Label();
            label7 = new Label();
            label4 = new Label();
            cbFacturaDe = new PresentationLayer.CustomComponents.MainFormComponents.CustomComboBox();
            cbTerminos = new PresentationLayer.CustomComponents.MainFormComponents.CustomComboBox();
            cbFacturaPara = new PresentationLayer.CustomComponents.MainFormComponents.CustomComboBox();
            label5 = new Label();
            txtNeto = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            btnAgregarProd = new Button();
            label6 = new Label();
            txtDescrip = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            btnCrear = new PresentationLayer.CustomComponents.MainFormComponents.CustomButton();
            cbProductNombre = new PresentationLayer.CustomComponents.MainFormComponents.CustomComboBox();
            txtPrecio = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            txtCantidad = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            is_ncf = new MaterialSkin.Controls.MaterialCheckbox();
            lblNcfVence = new Label();
            panelEjemplo.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 65);
            label1.Name = "label1";
            label1.Size = new Size(128, 32);
            label1.TabIndex = 0;
            label1.Text = "Factura de";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(275, 65);
            label2.Name = "label2";
            label2.Size = new Size(150, 32);
            label2.TabIndex = 0;
            label2.Text = "Factura para";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(515, 65);
            label3.Name = "label3";
            label3.Size = new Size(112, 32);
            label3.TabIndex = 0;
            label3.Text = "Terminos";
            // 
            // panelEjemplo
            // 
            panelEjemplo.BackColor = Color.Silver;
            panelEjemplo.Controls.Add(lblNcfVence);
            panelEjemplo.Controls.Add(lblClienteId);
            panelEjemplo.Controls.Add(lblFax);
            panelEjemplo.Controls.Add(lblEmail);
            panelEjemplo.Controls.Add(lblRnc);
            panelEjemplo.Controls.Add(label17);
            panelEjemplo.Controls.Add(label16);
            panelEjemplo.Controls.Add(label15);
            panelEjemplo.Controls.Add(lblNeto);
            panelEjemplo.Controls.Add(lblPrecio);
            panelEjemplo.Controls.Add(lblCantidad);
            panelEjemplo.Controls.Add(lblLote);
            panelEjemplo.Controls.Add(lblDescrPr);
            panelEjemplo.Controls.Add(lblCodigoPr);
            panelEjemplo.Controls.Add(lblTotal);
            panelEjemplo.Controls.Add(label14);
            panelEjemplo.Controls.Add(lblSubTotal);
            panelEjemplo.Controls.Add(lblDireccion);
            panelEjemplo.Controls.Add(label25);
            panelEjemplo.Controls.Add(label11);
            panelEjemplo.Controls.Add(label18);
            panelEjemplo.Controls.Add(label12);
            panelEjemplo.Controls.Add(label24);
            panelEjemplo.Controls.Add(label23);
            panelEjemplo.Controls.Add(label21);
            panelEjemplo.Controls.Add(label22);
            panelEjemplo.Controls.Add(label20);
            panelEjemplo.Controls.Add(label19);
            panelEjemplo.Controls.Add(lblTelefono);
            panelEjemplo.Controls.Add(lblCiudad);
            panelEjemplo.Controls.Add(lblCodigo);
            panelEjemplo.Controls.Add(lblNombre);
            panelEjemplo.Controls.Add(label10);
            panelEjemplo.Controls.Add(label9);
            panelEjemplo.Controls.Add(label8);
            panelEjemplo.Controls.Add(lblVendedor);
            panelEjemplo.Controls.Add(lblPedido);
            panelEjemplo.Controls.Add(lblTerminos);
            panelEjemplo.Controls.Add(lblNumFactura);
            panelEjemplo.Controls.Add(lblFecha);
            panelEjemplo.Controls.Add(lblNcf);
            panelEjemplo.Controls.Add(label13);
            panelEjemplo.Controls.Add(label7);
            panelEjemplo.Location = new Point(709, 49);
            panelEjemplo.Margin = new Padding(3, 4, 3, 4);
            panelEjemplo.Name = "panelEjemplo";
            panelEjemplo.Size = new Size(390, 536);
            panelEjemplo.TabIndex = 1;
            // 
            // lblClienteId
            // 
            lblClienteId.AutoSize = true;
            lblClienteId.Location = new Point(129, 172);
            lblClienteId.Name = "lblClienteId";
            lblClienteId.Size = new Size(58, 20);
            lblClienteId.TabIndex = 13;
            lblClienteId.Text = "label26";
            lblClienteId.Visible = false;
            // 
            // lblFax
            // 
            lblFax.AutoSize = true;
            lblFax.Location = new Point(151, 129);
            lblFax.Name = "lblFax";
            lblFax.Size = new Size(30, 20);
            lblFax.TabIndex = 11;
            lblFax.Text = "Fax";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(22, 172);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 12;
            lblEmail.Text = "Email";
            lblEmail.Visible = false;
            // 
            // lblRnc
            // 
            lblRnc.AutoSize = true;
            lblRnc.Location = new Point(22, 149);
            lblRnc.Name = "lblRnc";
            lblRnc.Size = new Size(38, 20);
            lblRnc.TabIndex = 11;
            lblRnc.Text = "RNC";
            lblRnc.Visible = false;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(255, 149);
            label17.Name = "label17";
            label17.Size = new Size(82, 20);
            label17.TabIndex = 8;
            label17.Text = "Pedido No:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(282, 93);
            label16.Name = "label16";
            label16.Size = new Size(39, 20);
            label16.TabIndex = 8;
            label16.Text = "NCF:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(246, 53);
            label15.Name = "label15";
            label15.Size = new Size(83, 20);
            label15.TabIndex = 8;
            label15.Text = "Factura No:";
            // 
            // lblNeto
            // 
            lblNeto.AutoSize = true;
            lblNeto.Location = new Point(330, 289);
            lblNeto.Name = "lblNeto";
            lblNeto.Size = new Size(42, 20);
            lblNeto.TabIndex = 7;
            lblNeto.Text = "label";
            lblNeto.Visible = false;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(282, 289);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(38, 20);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "labe";
            lblPrecio.Visible = false;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(221, 289);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(50, 20);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "label1";
            lblCantidad.Visible = false;
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Location = new Point(167, 289);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(50, 20);
            lblLote.TabIndex = 4;
            lblLote.Text = "label1";
            lblLote.Visible = false;
            // 
            // lblDescrPr
            // 
            lblDescrPr.AutoSize = true;
            lblDescrPr.Location = new Point(87, 289);
            lblDescrPr.Name = "lblDescrPr";
            lblDescrPr.Size = new Size(50, 20);
            lblDescrPr.TabIndex = 3;
            lblDescrPr.Text = "label1";
            lblDescrPr.Visible = false;
            // 
            // lblCodigoPr
            // 
            lblCodigoPr.AutoSize = true;
            lblCodigoPr.Location = new Point(13, 289);
            lblCodigoPr.Name = "lblCodigoPr";
            lblCodigoPr.Size = new Size(50, 20);
            lblCodigoPr.TabIndex = 2;
            lblCodigoPr.Text = "label1";
            lblCodigoPr.Visible = false;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(322, 480);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(36, 20);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "0.00";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(322, 463);
            label14.Name = "label14";
            label14.Size = new Size(36, 20);
            label14.TabIndex = 1;
            label14.Text = "0.00";
            // 
            // lblSubTotal
            // 
            lblSubTotal.AutoSize = true;
            lblSubTotal.Location = new Point(321, 443);
            lblSubTotal.Name = "lblSubTotal";
            lblSubTotal.Size = new Size(36, 20);
            lblSubTotal.TabIndex = 1;
            lblSubTotal.Text = "0.00";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(22, 89);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(70, 20);
            lblDireccion.TabIndex = 0;
            lblDireccion.Text = "direccion";
            lblDireccion.Visible = false;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(7, 257);
            label25.Name = "label25";
            label25.Size = new Size(399, 20);
            label25.TabIndex = 0;
            label25.Text = "-----------------------------------------------------------------";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 421);
            label11.Name = "label11";
            label11.Size = new Size(399, 20);
            label11.TabIndex = 0;
            label11.Text = "-----------------------------------------------------------------";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(8, 500);
            label18.Name = "label18";
            label18.Size = new Size(399, 20);
            label18.TabIndex = 0;
            label18.Text = "-----------------------------------------------------------------";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(3, 205);
            label12.Name = "label12";
            label12.Size = new Size(399, 20);
            label12.TabIndex = 0;
            label12.Text = "-----------------------------------------------------------------";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(335, 229);
            label24.Name = "label24";
            label24.Size = new Size(42, 20);
            label24.TabIndex = 0;
            label24.Text = "Neto";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(282, 229);
            label23.Name = "label23";
            label23.Size = new Size(50, 20);
            label23.TabIndex = 0;
            label23.Text = "Precio";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(171, 229);
            label21.Name = "label21";
            label21.Size = new Size(38, 20);
            label21.TabIndex = 0;
            label21.Text = "Lote";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(213, 229);
            label22.Name = "label22";
            label22.Size = new Size(69, 20);
            label22.TabIndex = 0;
            label22.Text = "Cantidad";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(72, 229);
            label20.Name = "label20";
            label20.Size = new Size(87, 20);
            label20.TabIndex = 0;
            label20.Text = "Descripcion";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(13, 229);
            label19.Name = "label19";
            label19.Size = new Size(58, 20);
            label19.TabIndex = 0;
            label19.Text = "Codigo";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(22, 129);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(65, 20);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "telefono";
            lblTelefono.Visible = false;
            // 
            // lblCiudad
            // 
            lblCiudad.AutoSize = true;
            lblCiudad.Location = new Point(22, 109);
            lblCiudad.Name = "lblCiudad";
            lblCiudad.Size = new Size(54, 20);
            lblCiudad.TabIndex = 0;
            lblCiudad.Text = "ciudad";
            lblCiudad.Visible = false;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(22, 49);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(56, 20);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "codigo";
            lblCodigo.Visible = false;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(22, 69);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(64, 20);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            lblNombre.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(278, 480);
            label10.Name = "label10";
            label10.Size = new Size(42, 20);
            label10.TabIndex = 0;
            label10.Text = "Neto";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 461);
            label9.Name = "label9";
            label9.Size = new Size(42, 20);
            label9.TabIndex = 0;
            label9.Text = "ITBIS";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(255, 441);
            label8.Name = "label8";
            label8.Size = new Size(67, 20);
            label8.TabIndex = 0;
            label8.Text = "SubTotal";
            // 
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(268, 169);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(123, 20);
            lblVendedor.TabIndex = 0;
            lblVendedor.Text = "Carlos Rhadames";
            lblVendedor.Visible = false;
            // 
            // lblPedido
            // 
            lblPedido.AutoSize = true;
            lblPedido.Location = new Point(336, 149);
            lblPedido.Name = "lblPedido";
            lblPedido.Size = new Size(41, 20);
            lblPedido.TabIndex = 0;
            lblPedido.Text = "6712";
            // 
            // lblTerminos
            // 
            lblTerminos.AutoSize = true;
            lblTerminos.Location = new Point(320, 129);
            lblTerminos.Name = "lblTerminos";
            lblTerminos.Size = new Size(67, 20);
            lblTerminos.TabIndex = 0;
            lblTerminos.Text = "terminos";
            lblTerminos.Visible = false;
            // 
            // lblNumFactura
            // 
            lblNumFactura.AutoSize = true;
            lblNumFactura.Location = new Point(330, 53);
            lblNumFactura.Name = "lblNumFactura";
            lblNumFactura.Size = new Size(41, 20);
            lblNumFactura.TabIndex = 0;
            lblNumFactura.Text = "0000";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(293, 73);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(45, 20);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "fecha";
            // 
            // lblNcf
            // 
            lblNcf.AutoSize = true;
            lblNcf.Location = new Point(327, 93);
            lblNcf.Name = "lblNcf";
            lblNcf.Size = new Size(49, 20);
            lblNcf.TabIndex = 0;
            lblNcf.Text = "10101";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(217, 29);
            label13.Name = "label13";
            label13.Size = new Size(172, 20);
            label13.TabIndex = 0;
            label13.Text = "Facturado para consumo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(22, 29);
            label7.Name = "label7";
            label7.Size = new Size(88, 20);
            label7.TabIndex = 0;
            label7.Text = "Facturado A";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(838, 12);
            label4.Name = "label4";
            label4.Size = new Size(154, 32);
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
            cbFacturaDe.Location = new Point(35, 103);
            cbFacturaDe.Margin = new Padding(3, 4, 3, 4);
            cbFacturaDe.MinimumSize = new Size(171, 40);
            cbFacturaDe.Name = "cbFacturaDe";
            cbFacturaDe.Padding = new Padding(1);
            cbFacturaDe.Size = new Size(203, 40);
            cbFacturaDe.TabIndex = 2;
            cbFacturaDe.Texts = "";
            cbFacturaDe.OnSelectedIndexChanged += cbFacturaDe_OnSelectedIndexChanged;
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
            cbTerminos.Items.AddRange(new object[] { "Crédito", "Contado" });
            cbTerminos.ListBackColor = Color.FromArgb(230, 228, 245);
            cbTerminos.ListTextColor = Color.DimGray;
            cbTerminos.Location = new Point(515, 103);
            cbTerminos.Margin = new Padding(3, 4, 3, 4);
            cbTerminos.MinimumSize = new Size(171, 40);
            cbTerminos.Name = "cbTerminos";
            cbTerminos.Padding = new Padding(1);
            cbTerminos.Size = new Size(171, 40);
            cbTerminos.TabIndex = 2;
            cbTerminos.Texts = "";
            cbTerminos.OnSelectedIndexChanged += cbTerminos_OnSelectedIndexChanged;
            // 
            // cbFacturaPara
            // 
            cbFacturaPara.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbFacturaPara.BackColor = Color.WhiteSmoke;
            cbFacturaPara.BorderColor = SystemColors.Control;
            cbFacturaPara.BorderSize = 1;
            cbFacturaPara.DropDownStyle = ComboBoxStyle.DropDown;
            cbFacturaPara.Font = new Font("Segoe UI", 10F);
            cbFacturaPara.ForeColor = Color.DimGray;
            cbFacturaPara.IconColor = Color.FromArgb(248, 169, 96);
            cbFacturaPara.ListBackColor = Color.FromArgb(230, 228, 245);
            cbFacturaPara.ListTextColor = Color.DimGray;
            cbFacturaPara.Location = new Point(275, 103);
            cbFacturaPara.Margin = new Padding(3, 4, 3, 4);
            cbFacturaPara.MinimumSize = new Size(171, 40);
            cbFacturaPara.Name = "cbFacturaPara";
            cbFacturaPara.Padding = new Padding(1);
            cbFacturaPara.Size = new Size(191, 40);
            cbFacturaPara.TabIndex = 2;
            cbFacturaPara.Texts = "";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(35, 205);
            label5.Name = "label5";
            label5.Size = new Size(142, 37);
            label5.TabIndex = 3;
            label5.Text = "Productos";
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
            txtNeto.Location = new Point(461, 276);
            txtNeto.Margin = new Padding(3, 4, 3, 4);
            txtNeto.Multiline = false;
            txtNeto.Name = "txtNeto";
            txtNeto.Padding = new Padding(11, 9, 11, 9);
            txtNeto.PasswordChar = false;
            txtNeto.PlaceholderColor = Color.DarkGray;
            txtNeto.PlaceholderText = "Neto";
            txtNeto.Size = new Size(87, 40);
            txtNeto.TabIndex = 4;
            txtNeto.Texts = "";
            txtNeto.UnderlinedStyle = false;
            // 
            // btnAgregarProd
            // 
            btnAgregarProd.FlatAppearance.BorderSize = 0;
            btnAgregarProd.FlatStyle = FlatStyle.Flat;
            btnAgregarProd.Image = (Image)resources.GetObject("btnAgregarProd.Image");
            btnAgregarProd.Location = new Point(553, 273);
            btnAgregarProd.Margin = new Padding(3, 4, 3, 4);
            btnAgregarProd.Name = "btnAgregarProd";
            btnAgregarProd.Size = new Size(47, 53);
            btnAgregarProd.TabIndex = 6;
            btnAgregarProd.UseVisualStyleBackColor = true;
            btnAgregarProd.Click += btnAgregarProd_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(34, 353);
            label6.Name = "label6";
            label6.Size = new Size(139, 32);
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
            txtDescrip.Location = new Point(35, 391);
            txtDescrip.Margin = new Padding(3, 4, 3, 4);
            txtDescrip.Multiline = true;
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Padding = new Padding(11, 9, 11, 9);
            txtDescrip.PasswordChar = false;
            txtDescrip.PlaceholderColor = Color.DarkGray;
            txtDescrip.PlaceholderText = "Descripción";
            txtDescrip.Size = new Size(265, 120);
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
            btnCrear.Location = new Point(275, 532);
            btnCrear.Margin = new Padding(3, 4, 3, 4);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(171, 53);
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
            cbProductNombre.Location = new Point(35, 276);
            cbProductNombre.Margin = new Padding(3, 4, 3, 4);
            cbProductNombre.MinimumSize = new Size(171, 40);
            cbProductNombre.Name = "cbProductNombre";
            cbProductNombre.Padding = new Padding(1);
            cbProductNombre.Size = new Size(224, 40);
            cbProductNombre.TabIndex = 2;
            cbProductNombre.Texts = "Nombre";
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = Color.White;
            txtPrecio.BorderColor = Color.DarkGray;
            txtPrecio.BorderFocusColor = Color.HotPink;
            txtPrecio.BorderRadius = 6;
            txtPrecio.BorderSize = 1;
            txtPrecio.Enabled = false;
            txtPrecio.Font = new Font("Segoe UI", 9.5F);
            txtPrecio.ForeColor = Color.DimGray;
            txtPrecio.Location = new Point(266, 276);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Multiline = false;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Padding = new Padding(11, 9, 11, 9);
            txtPrecio.PasswordChar = false;
            txtPrecio.PlaceholderColor = Color.DarkGray;
            txtPrecio.PlaceholderText = "Precio";
            txtPrecio.Size = new Size(95, 40);
            txtPrecio.TabIndex = 9;
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
            txtCantidad.Location = new Point(367, 276);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Multiline = false;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Padding = new Padding(11, 9, 11, 9);
            txtCantidad.PasswordChar = false;
            txtCantidad.PlaceholderColor = Color.DarkGray;
            txtCantidad.PlaceholderText = "Cantidad";
            txtCantidad.Size = new Size(87, 40);
            txtCantidad.TabIndex = 10;
            txtCantidad.Texts = "";
            txtCantidad.UnderlinedStyle = false;
            // 
            // is_ncf
            // 
            is_ncf.AutoSize = true;
            is_ncf.BackColor = SystemColors.ButtonFace;
            is_ncf.Depth = 0;
            is_ncf.Location = new Point(621, 171);
            is_ncf.Margin = new Padding(0);
            is_ncf.MouseLocation = new Point(-1, -1);
            is_ncf.MouseState = MaterialSkin.MouseState.HOVER;
            is_ncf.Name = "is_ncf";
            is_ncf.ReadOnly = false;
            is_ncf.Ripple = true;
            is_ncf.Size = new Size(65, 37);
            is_ncf.TabIndex = 11;
            is_ncf.Text = "NCF";
            is_ncf.UseVisualStyleBackColor = false;
            // 
            // lblNcfVence
            // 
            lblNcfVence.AutoSize = true;
            lblNcfVence.Location = new Point(246, 122);
            lblNcfVence.Name = "lblNcfVence";
            lblNcfVence.Size = new Size(43, 20);
            lblNcfVence.TabIndex = 14;
            lblNcfVence.Text = "venci";
            lblNcfVence.Visible = false;
            // 
            // AddInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1112, 600);
            Controls.Add(is_ncf);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(btnCrear);
            Controls.Add(label6);
            Controls.Add(btnAgregarProd);
            Controls.Add(txtNeto);
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
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddInvoice";
            Text = "AddInvoice";
            Load += AddInvoice_Load;
            panelEjemplo.ResumeLayout(false);
            panelEjemplo.PerformLayout();
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
        private CustomComponents.MainFormComponents.CustomTextBox txtNeto;
        private Button btnAgregarProd;
        private Label label6;
        private CustomComponents.MainFormComponents.CustomTextBox txtDescrip;
        private CustomComponents.MainFormComponents.CustomButton btnCrear;
        private CustomComponents.MainFormComponents.CustomComboBox cbProductNombre;
        private CustomComponents.MainFormComponents.CustomTextBox txtPrecio;
        private CustomComponents.MainFormComponents.CustomTextBox txtCantidad;
        private Label label7;
        private Label lblNombre;
        private Label lblDireccion;
        private Label lblCiudad;
        private Label label12;
        private Label lblTelefono;
        private Label lblNcf;
        private Label label13;
        private Label lblPedido;
        private Label lblTerminos;
        private Label lblVendedor;
        private Label label18;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label25;
        private Label lblFecha;
        private Label lblNumFactura;
        private Label lblCodigo;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label14;
        private Label lblSubTotal;
        private Label lblTotal;
        private Label label11;
        private Label lblCantidad;
        private Label lblLote;
        private Label lblDescrPr;
        private Label lblCodigoPr;
        private Label lblNeto;
        private Label lblPrecio;
        private Label label17;
        private Label label16;
        private Label label15;
        private Label lblEmail;
        private Label lblRnc;
        private Label lblFax;
        private Label lblClienteId;
        private MaterialSkin.Controls.MaterialCheckbox is_ncf;
        private Label lblNcfVence;
    }
}