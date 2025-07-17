namespace PresentationLayer.AddForms
{
    partial class AddLot
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
            label4 = new Label();
            label5 = new Label();
            initial_secuence_txt = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            final_secuence_txt = new PresentationLayer.CustomComponents.MainFormComponents.CustomTextBox();
            expiration_date = new PresentationLayer.CustomComponents.MainFormComponents.CustomDatePicker();
            aviable_check = new MaterialSkin.Controls.MaterialCheckbox();
            ncf_tipe_combo = new PresentationLayer.CustomComponents.MainFormComponents.CustomComboBox();
            customButton1 = new PresentationLayer.CustomComponents.MainFormComponents.CustomButton();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(223, 9);
            label1.Name = "label1";
            label1.Size = new Size(342, 41);
            label1.TabIndex = 2;
            label1.Text = "AGREGAR LOTE DE NCF";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 84);
            label2.Name = "label2";
            label2.Size = new Size(120, 28);
            label2.TabIndex = 3;
            label2.Text = "Tipo de NCF";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(28, 202);
            label3.Name = "label3";
            label3.Size = new Size(153, 28);
            label3.TabIndex = 3;
            label3.Text = "Secuencia Inicial";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(499, 202);
            label4.Name = "label4";
            label4.Size = new Size(157, 28);
            label4.TabIndex = 3;
            label4.Text = "Fecha Expiración";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(499, 84);
            label5.Name = "label5";
            label5.Size = new Size(144, 28);
            label5.TabIndex = 3;
            label5.Text = "Secuencia Final";
            // 
            // initial_secuence_txt
            // 
            initial_secuence_txt.BackColor = Color.White;
            initial_secuence_txt.BorderColor = Color.FromArgb(248, 169, 96);
            initial_secuence_txt.BorderFocusColor = Color.HotPink;
            initial_secuence_txt.BorderRadius = 0;
            initial_secuence_txt.BorderSize = 2;
            initial_secuence_txt.Font = new Font("Segoe UI", 9.5F);
            initial_secuence_txt.ForeColor = Color.DimGray;
            initial_secuence_txt.Location = new Point(28, 233);
            initial_secuence_txt.Multiline = false;
            initial_secuence_txt.Name = "initial_secuence_txt";
            initial_secuence_txt.Padding = new Padding(10, 7, 10, 7);
            initial_secuence_txt.PasswordChar = false;
            initial_secuence_txt.PlaceholderColor = Color.DarkGray;
            initial_secuence_txt.PlaceholderText = "";
            initial_secuence_txt.Size = new Size(239, 36);
            initial_secuence_txt.TabIndex = 5;
            initial_secuence_txt.Texts = "";
            initial_secuence_txt.UnderlinedStyle = true;
            // 
            // final_secuence_txt
            // 
            final_secuence_txt.BackColor = Color.White;
            final_secuence_txt.BorderColor = Color.FromArgb(248, 169, 96);
            final_secuence_txt.BorderFocusColor = Color.HotPink;
            final_secuence_txt.BorderRadius = 0;
            final_secuence_txt.BorderSize = 2;
            final_secuence_txt.Font = new Font("Segoe UI", 9.5F);
            final_secuence_txt.ForeColor = Color.DimGray;
            final_secuence_txt.Location = new Point(499, 115);
            final_secuence_txt.Multiline = false;
            final_secuence_txt.Name = "final_secuence_txt";
            final_secuence_txt.Padding = new Padding(10, 7, 10, 7);
            final_secuence_txt.PasswordChar = false;
            final_secuence_txt.PlaceholderColor = Color.DarkGray;
            final_secuence_txt.PlaceholderText = "";
            final_secuence_txt.Size = new Size(239, 36);
            final_secuence_txt.TabIndex = 5;
            final_secuence_txt.Texts = "";
            final_secuence_txt.UnderlinedStyle = true;
            // 
            // expiration_date
            // 
            expiration_date.BorderColor = Color.PaleVioletRed;
            expiration_date.BorderSize = 0;
            expiration_date.Font = new Font("Segoe UI", 9.5F);
            expiration_date.Location = new Point(499, 234);
            expiration_date.MinimumSize = new Size(0, 35);
            expiration_date.Name = "expiration_date";
            expiration_date.Size = new Size(250, 35);
            expiration_date.SkinColor = Color.White;
            expiration_date.TabIndex = 6;
            expiration_date.TextColor = Color.DimGray;
            // 
            // aviable_check
            // 
            aviable_check.AutoSize = true;
            aviable_check.Depth = 0;
            aviable_check.Location = new Point(639, 307);
            aviable_check.Margin = new Padding(0);
            aviable_check.MouseLocation = new Point(-1, -1);
            aviable_check.MouseState = MaterialSkin.MouseState.HOVER;
            aviable_check.Name = "aviable_check";
            aviable_check.ReadOnly = false;
            aviable_check.Ripple = true;
            aviable_check.Size = new Size(110, 37);
            aviable_check.TabIndex = 7;
            aviable_check.Text = "Disponible";
            aviable_check.UseVisualStyleBackColor = true;
            // 
            // ncf_tipe_combo
            // 
            ncf_tipe_combo.BackColor = Color.WhiteSmoke;
            ncf_tipe_combo.BorderColor = Color.MediumSlateBlue;
            ncf_tipe_combo.BorderSize = 0;
            ncf_tipe_combo.DropDownStyle = ComboBoxStyle.DropDown;
            ncf_tipe_combo.Font = new Font("Segoe UI", 10F);
            ncf_tipe_combo.ForeColor = Color.DimGray;
            ncf_tipe_combo.IconColor = Color.FromArgb(248, 169, 96);
            ncf_tipe_combo.ListBackColor = Color.FromArgb(230, 228, 245);
            ncf_tipe_combo.ListTextColor = Color.DimGray;
            ncf_tipe_combo.Location = new Point(28, 126);
            ncf_tipe_combo.MinimumSize = new Size(200, 30);
            ncf_tipe_combo.Name = "ncf_tipe_combo";
            ncf_tipe_combo.Size = new Size(250, 45);
            ncf_tipe_combo.TabIndex = 8;
            ncf_tipe_combo.Texts = "";
            // 
            // customButton1
            // 
            customButton1.BackColor = Color.FromArgb(248, 169, 96);
            customButton1.BackgroundColor = Color.FromArgb(248, 169, 96);
            customButton1.BorderColor = Color.PaleVioletRed;
            customButton1.BorderRadius = 5;
            customButton1.BorderSize = 0;
            customButton1.FlatAppearance.BorderSize = 0;
            customButton1.FlatStyle = FlatStyle.Flat;
            customButton1.ForeColor = Color.White;
            customButton1.Location = new Point(289, 388);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(188, 50);
            customButton1.TabIndex = 9;
            customButton1.Text = "Agregar";
            customButton1.TextColor = Color.White;
            customButton1.UseVisualStyleBackColor = false;
            customButton1.Click += customButton1_Click;
            // 
            // AddLot
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customButton1);
            Controls.Add(ncf_tipe_combo);
            Controls.Add(aviable_check);
            Controls.Add(expiration_date);
            Controls.Add(final_secuence_txt);
            Controls.Add(initial_secuence_txt);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "AddLot";
            Text = "AddLot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private CustomComponents.MainFormComponents.CustomTextBox initial_secuence_txt;
        private CustomComponents.MainFormComponents.CustomTextBox final_secuence_txt;
        private CustomComponents.MainFormComponents.CustomDatePicker expiration_date;
        private MaterialSkin.Controls.MaterialCheckbox aviable_check;
        private CustomComponents.MainFormComponents.CustomComboBox ncf_tipe_combo;
        private CustomComponents.MainFormComponents.CustomButton customButton1;
    }
}