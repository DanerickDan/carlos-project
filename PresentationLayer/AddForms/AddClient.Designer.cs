namespace PresentationLayer.AddForms
{
    partial class AddClient
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
            codigoTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            panel2 = new Panel();
            agregarBtn = new CustomComponents.MainFormComponents.CustomButton();
            label9 = new Label();
            label7 = new Label();
            label5 = new Label();
            label3 = new Label();
            label8 = new Label();
            label6 = new Label();
            labl = new Label();
            label2 = new Label();
            rncTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            emailTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            telefonoTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            ciudadTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            direccionTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            nombreTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            faxTxt = new CustomComponents.MainFormComponents.CustomTextBox();
            panel3 = new Panel();
            materialListBox1 = new MaterialSkin.Controls.MaterialListBox();
            label4 = new Label();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // codigoTxt
            // 
            codigoTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            codigoTxt.BackColor = Color.LightGray;
            codigoTxt.BorderColor = Color.FromArgb(224, 224, 224);
            codigoTxt.BorderFocusColor = Color.HotPink;
            codigoTxt.BorderRadius = 6;
            codigoTxt.BorderSize = 1;
            codigoTxt.Enabled = false;
            codigoTxt.Font = new Font("Segoe UI", 9.5F);
            codigoTxt.ForeColor = Color.DimGray;
            codigoTxt.Location = new Point(29, 72);
            codigoTxt.Multiline = false;
            codigoTxt.Name = "codigoTxt";
            codigoTxt.Padding = new Padding(10, 7, 10, 7);
            codigoTxt.PasswordChar = false;
            codigoTxt.PlaceholderColor = Color.DarkGray;
            codigoTxt.PlaceholderText = "";
            codigoTxt.Size = new Size(127, 32);
            codigoTxt.TabIndex = 1;
            codigoTxt.Texts = "";
            codigoTxt.UnderlinedStyle = true;
            codigoTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(agregarBtn);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(labl);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(rncTxt);
            panel2.Controls.Add(emailTxt);
            panel2.Controls.Add(telefonoTxt);
            panel2.Controls.Add(ciudadTxt);
            panel2.Controls.Add(direccionTxt);
            panel2.Controls.Add(nombreTxt);
            panel2.Controls.Add(faxTxt);
            panel2.Controls.Add(codigoTxt);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(460, 450);
            panel2.TabIndex = 1;
            // 
            // agregarBtn
            // 
            agregarBtn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            agregarBtn.BackColor = Color.FromArgb(248, 169, 96);
            agregarBtn.BackgroundColor = Color.FromArgb(248, 169, 96);
            agregarBtn.BorderColor = Color.PaleVioletRed;
            agregarBtn.BorderRadius = 5;
            agregarBtn.BorderSize = 0;
            agregarBtn.FlatAppearance.BorderSize = 0;
            agregarBtn.FlatStyle = FlatStyle.Flat;
            agregarBtn.ForeColor = Color.White;
            agregarBtn.Location = new Point(142, 369);
            agregarBtn.Name = "agregarBtn";
            agregarBtn.Size = new Size(150, 40);
            agregarBtn.TabIndex = 3;
            agregarBtn.Text = "Agregar";
            agregarBtn.TextColor = Color.White;
            agregarBtn.UseVisualStyleBackColor = false;
            agregarBtn.Click += agregarBtn_Click;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(271, 275);
            label9.Name = "label9";
            label9.Size = new Size(42, 21);
            label9.TabIndex = 2;
            label9.Text = "RNC";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(271, 202);
            label7.Name = "label7";
            label7.Size = new Size(68, 21);
            label7.TabIndex = 2;
            label7.Text = "Teléfono";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(271, 122);
            label5.Name = "label5";
            label5.Size = new Size(75, 21);
            label5.TabIndex = 2;
            label5.Text = "Dirección";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(271, 48);
            label3.Name = "label3";
            label3.Size = new Size(32, 21);
            label3.TabIndex = 2;
            label3.Text = "Fax";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Bottom;
            label8.AutoSize = true;
            label8.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(29, 275);
            label8.Name = "label8";
            label8.Size = new Size(48, 21);
            label8.TabIndex = 2;
            label8.Text = "Email";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(29, 202);
            label6.Name = "label6";
            label6.Size = new Size(59, 21);
            label6.TabIndex = 2;
            label6.Text = "Ciudad";
            // 
            // labl
            // 
            labl.Anchor = AnchorStyles.Bottom;
            labl.AutoSize = true;
            labl.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labl.Location = new Point(29, 122);
            labl.Name = "labl";
            labl.Size = new Size(68, 21);
            labl.TabIndex = 2;
            labl.Text = "Nombre";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom;
            label2.AutoSize = true;
            label2.Font = new Font("Nirmala UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 48);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 2;
            label2.Text = "Codigo";
            // 
            // rncTxt
            // 
            rncTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rncTxt.BackColor = Color.White;
            rncTxt.BorderColor = Color.FromArgb(248, 169, 96);
            rncTxt.BorderFocusColor = Color.HotPink;
            rncTxt.BorderRadius = 6;
            rncTxt.BorderSize = 1;
            rncTxt.Font = new Font("Segoe UI", 9.5F);
            rncTxt.ForeColor = Color.DimGray;
            rncTxt.Location = new Point(271, 302);
            rncTxt.Multiline = false;
            rncTxt.Name = "rncTxt";
            rncTxt.Padding = new Padding(10, 7, 10, 7);
            rncTxt.PasswordChar = false;
            rncTxt.PlaceholderColor = Color.DarkGray;
            rncTxt.PlaceholderText = "";
            rncTxt.Size = new Size(127, 32);
            rncTxt.TabIndex = 1;
            rncTxt.Texts = "";
            rncTxt.UnderlinedStyle = true;
            rncTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // emailTxt
            // 
            emailTxt.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            emailTxt.BackColor = Color.White;
            emailTxt.BorderColor = Color.FromArgb(248, 169, 96);
            emailTxt.BorderFocusColor = Color.HotPink;
            emailTxt.BorderRadius = 6;
            emailTxt.BorderSize = 1;
            emailTxt.Font = new Font("Segoe UI", 9.5F);
            emailTxt.ForeColor = Color.DimGray;
            emailTxt.Location = new Point(29, 302);
            emailTxt.Multiline = false;
            emailTxt.Name = "emailTxt";
            emailTxt.Padding = new Padding(10, 7, 10, 7);
            emailTxt.PasswordChar = false;
            emailTxt.PlaceholderColor = Color.DarkGray;
            emailTxt.PlaceholderText = "";
            emailTxt.Size = new Size(127, 32);
            emailTxt.TabIndex = 1;
            emailTxt.Texts = "";
            emailTxt.UnderlinedStyle = true;
            emailTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // telefonoTxt
            // 
            telefonoTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            telefonoTxt.BackColor = Color.White;
            telefonoTxt.BorderColor = Color.FromArgb(248, 169, 96);
            telefonoTxt.BorderFocusColor = Color.HotPink;
            telefonoTxt.BorderRadius = 6;
            telefonoTxt.BorderSize = 1;
            telefonoTxt.Font = new Font("Segoe UI", 9.5F);
            telefonoTxt.ForeColor = Color.DimGray;
            telefonoTxt.Location = new Point(271, 226);
            telefonoTxt.Multiline = false;
            telefonoTxt.Name = "telefonoTxt";
            telefonoTxt.Padding = new Padding(10, 7, 10, 7);
            telefonoTxt.PasswordChar = false;
            telefonoTxt.PlaceholderColor = Color.DarkGray;
            telefonoTxt.PlaceholderText = "";
            telefonoTxt.Size = new Size(127, 32);
            telefonoTxt.TabIndex = 1;
            telefonoTxt.Texts = "";
            telefonoTxt.UnderlinedStyle = true;
            telefonoTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // ciudadTxt
            // 
            ciudadTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ciudadTxt.BackColor = Color.White;
            ciudadTxt.BorderColor = Color.FromArgb(248, 169, 96);
            ciudadTxt.BorderFocusColor = Color.HotPink;
            ciudadTxt.BorderRadius = 6;
            ciudadTxt.BorderSize = 1;
            ciudadTxt.Font = new Font("Segoe UI", 9.5F);
            ciudadTxt.ForeColor = Color.DimGray;
            ciudadTxt.Location = new Point(29, 226);
            ciudadTxt.Multiline = false;
            ciudadTxt.Name = "ciudadTxt";
            ciudadTxt.Padding = new Padding(10, 7, 10, 7);
            ciudadTxt.PasswordChar = false;
            ciudadTxt.PlaceholderColor = Color.DarkGray;
            ciudadTxt.PlaceholderText = "";
            ciudadTxt.Size = new Size(127, 32);
            ciudadTxt.TabIndex = 1;
            ciudadTxt.Texts = "";
            ciudadTxt.UnderlinedStyle = true;
            ciudadTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // direccionTxt
            // 
            direccionTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            direccionTxt.BackColor = Color.White;
            direccionTxt.BorderColor = Color.FromArgb(248, 169, 96);
            direccionTxt.BorderFocusColor = Color.HotPink;
            direccionTxt.BorderRadius = 6;
            direccionTxt.BorderSize = 1;
            direccionTxt.Font = new Font("Segoe UI", 9.5F);
            direccionTxt.ForeColor = Color.DimGray;
            direccionTxt.Location = new Point(271, 146);
            direccionTxt.Multiline = false;
            direccionTxt.Name = "direccionTxt";
            direccionTxt.Padding = new Padding(10, 7, 10, 7);
            direccionTxt.PasswordChar = false;
            direccionTxt.PlaceholderColor = Color.DarkGray;
            direccionTxt.PlaceholderText = "";
            direccionTxt.Size = new Size(127, 32);
            direccionTxt.TabIndex = 1;
            direccionTxt.Texts = "";
            direccionTxt.UnderlinedStyle = true;
            direccionTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // nombreTxt
            // 
            nombreTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            nombreTxt.BackColor = Color.White;
            nombreTxt.BorderColor = Color.FromArgb(248, 169, 96);
            nombreTxt.BorderFocusColor = Color.HotPink;
            nombreTxt.BorderRadius = 6;
            nombreTxt.BorderSize = 1;
            nombreTxt.Font = new Font("Segoe UI", 9.5F);
            nombreTxt.ForeColor = Color.DimGray;
            nombreTxt.Location = new Point(29, 146);
            nombreTxt.Multiline = false;
            nombreTxt.Name = "nombreTxt";
            nombreTxt.Padding = new Padding(10, 7, 10, 7);
            nombreTxt.PasswordChar = false;
            nombreTxt.PlaceholderColor = Color.DarkGray;
            nombreTxt.PlaceholderText = "";
            nombreTxt.Size = new Size(127, 32);
            nombreTxt.TabIndex = 1;
            nombreTxt.Texts = "";
            nombreTxt.UnderlinedStyle = true;
            nombreTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // faxTxt
            // 
            faxTxt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            faxTxt.BackColor = Color.White;
            faxTxt.BorderColor = Color.FromArgb(248, 169, 96);
            faxTxt.BorderFocusColor = Color.HotPink;
            faxTxt.BorderRadius = 6;
            faxTxt.BorderSize = 1;
            faxTxt.Font = new Font("Segoe UI", 9.5F);
            faxTxt.ForeColor = Color.DimGray;
            faxTxt.Location = new Point(271, 72);
            faxTxt.Multiline = false;
            faxTxt.Name = "faxTxt";
            faxTxt.Padding = new Padding(10, 7, 10, 7);
            faxTxt.PasswordChar = false;
            faxTxt.PlaceholderColor = Color.DarkGray;
            faxTxt.PlaceholderText = "";
            faxTxt.Size = new Size(127, 32);
            faxTxt.TabIndex = 1;
            faxTxt.Texts = "";
            faxTxt.UnderlinedStyle = true;
            faxTxt._TextChanged += customTextBox1__TextChanged;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(materialListBox1);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(469, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(331, 450);
            panel3.TabIndex = 2;
            // 
            // materialListBox1
            // 
            materialListBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            materialListBox1.BackColor = Color.White;
            materialListBox1.BorderColor = Color.LightGray;
            materialListBox1.Depth = 0;
            materialListBox1.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialListBox1.Location = new Point(18, 33);
            materialListBox1.MouseState = MaterialSkin.MouseState.HOVER;
            materialListBox1.Name = "materialListBox1";
            materialListBox1.SelectedIndex = -1;
            materialListBox1.SelectedItem = null;
            materialListBox1.Size = new Size(297, 406);
            materialListBox1.TabIndex = 1;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(91, 0);
            label4.Name = "label4";
            label4.Size = new Size(171, 30);
            label4.TabIndex = 0;
            label4.Text = "Lista de Clientes";
            // 
            // AddClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "AddClient";
            Text = "AddClient";
            Load += AddClient_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private CustomComponents.MainFormComponents.CustomTextBox codigoTxt;
        private Panel panel2;
        private Label label9;
        private Label label7;
        private Label label5;
        private Label label3;
        private Label label8;
        private Label label6;
        private Label labl;
        private Label label2;
        private CustomComponents.MainFormComponents.CustomTextBox rncTxt;
        private CustomComponents.MainFormComponents.CustomTextBox emailTxt;
        private CustomComponents.MainFormComponents.CustomTextBox telefonoTxt;
        private CustomComponents.MainFormComponents.CustomTextBox ciudadTxt;
        private CustomComponents.MainFormComponents.CustomTextBox direccionTxt;
        private CustomComponents.MainFormComponents.CustomTextBox nombreTxt;
        private CustomComponents.MainFormComponents.CustomTextBox faxTxt;
        private Panel panel3;
        private Label label4;
        private CustomComponents.MainFormComponents.CustomButton agregarBtn;
        private MaterialSkin.Controls.MaterialListBox materialListBox1;
    }
}