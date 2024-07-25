using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;

namespace PresentationLayer
{
    public partial class ClientManagementForm : Form
    {
        private readonly IClientService clientService;
        public ClientManagementForm()
        {
            clientService = new ClientServices();
            InitializeComponent();
            this.Load += new EventHandler(this.ClientManagementForm_Load);
            // Maneja el evento MouseWheel del DataGridView
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[0];
                string clientName = selectedRow.Cells[1].Value.ToString();
                string address = selectedRow.Cells[2].Value.ToString();
                string city = selectedRow.Cells[3].Value.ToString();
                string phone = selectedRow.Cells[4].Value.ToString();
                string fax = selectedRow.Cells[5].Value.ToString();
                string rnc = selectedRow.Cells[6].Value.ToString();
                ClientDTO clientDTO = new ClientDTO
                {
                    ClientName = clientName,
                    Address = address,
                    City = city,
                    PhoneNumber = phone,
                    Fax = fax,
                    Rnc = rnc
                };
                clientService.AddClient(clientDTO);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[0];
                int clientId = Convert.ToInt32(selectedRow.Cells[0].Value);
                clientService.DeleteClient(clientId);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[0];
                int clientId = Convert.ToInt32(selectedRow.Cells[0].Value);
                string clientName = selectedRow.Cells[1].Value.ToString();
                string address = selectedRow.Cells[2].Value.ToString();
                string city = selectedRow.Cells[3].Value.ToString();
                string phone = selectedRow.Cells[4].Value.ToString();
                string fax = selectedRow.Cells[5].Value.ToString();
                string rnc = selectedRow.Cells[6].Value.ToString();
                ClientDTO clientDTO = new ClientDTO
                {
                    ClientId = clientId,
                    ClientName = clientName,
                    Address = address,
                    City = city,
                    PhoneNumber = phone,
                    Fax = fax,
                    Rnc = rnc
                };
                clientService.AddClient(clientDTO);
            }
        }

        private void DataGridSettings()
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        public void LoadData()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = clientService.GetAllCLient();
            }
        }

        private void ClientManagementForm_Load(object sender, EventArgs e)
        {
            LoadData();
            DataGridSettings();
        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.NewValue].Index;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && materialScrollBar1.Value > materialScrollBar1.Minimum)
            {
                materialScrollBar1.Value--;
            }
            else if (e.Delta < 0 && materialScrollBar1.Value < materialScrollBar1.Maximum)
            {
                materialScrollBar1.Value++;
            }

            dataGridView1.FirstDisplayedScrollingRowIndex = materialScrollBar1.Value;
        }


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }

    }
}
