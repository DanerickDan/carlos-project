﻿

namespace PresentationLayer
{
    public partial class MainForm : Form
    {
        private Form ActiveForm;
        public MainForm()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(ActiveForm != null)
            {
                ActiveForm.Close();
            }
            ActiveForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.CenterPanel.Controls.Add(childForm);
            this.CenterPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblPrincipal.Text = childForm.Text;
        }


        private void btnProdutos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ProductManagementForm(), sender);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            OpenChildForm(new InvoiceForm(), sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            OpenChildForm(new ClientManagementForm(), sender);
        }
        private void btnCloseChildForm(object sender, EventArgs e)
        {
            if(ActiveForm != null)
            {
                ActiveForm.Close();
                Reset();
            }
        }

        private void Reset()
        {
            //DisableButton();
            //lblPrincipal = "DashBoard";

        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {
        }
    }
}