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
            if (ActiveForm != null)
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
            btnAnadir.Visible = true;
            btnBorrar.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible = false;
            txtBuscar2.Texts = "Buscar producto";
            txtBuscar2.Visible = true;
            OpenChildForm(new ProductManagementForm(), sender);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            btnAnadir.Visible = false;
            btnBorrar.Visible = false;
            btnEditar.Visible = false;
            btnImprimir.Visible = false;
            ActiveForm.Close();
            txtBuscar2.Visible = false;
            lblPrincipal.Text = "DashBoard";
        }

        private void btnFacturas_Click(object sender, EventArgs e)
        {
            btnAnadir.Visible = true;
            btnBorrar.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible = true;
            txtBuscar2.Texts = "Buscar factura";
            txtBuscar2.Visible = true;
            OpenChildForm(new InvoiceForm(), sender);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            btnAnadir.Visible = true;
            btnBorrar.Visible = true;
            btnEditar.Visible = true;
            btnImprimir.Visible= false;;
            txtBuscar2.Texts = "Buscar cliente";
            txtBuscar2.Visible = true;
            OpenChildForm(new ClientManagementForm(), sender);
        }
        private void btnCloseChildForm(object sender, EventArgs e)
        {
            if (ActiveForm != null)
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            btnImprimir.Visible = false;
            btnAnadir.Visible = false;
            btnBorrar.Visible = false;
            btnEditar.Visible = false;
            txtBuscar2.Visible = false;
        }
    }
}