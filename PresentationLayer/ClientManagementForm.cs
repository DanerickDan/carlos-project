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
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
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
            if( dataGridView1.Rows.Count > 0)
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
                    ClienstId = clientId,
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
    }
}
