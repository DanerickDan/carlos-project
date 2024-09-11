using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using DomainLayer.Entities;
using PresentationLayer.AddForms;
using PresentationLayer.Features;
using PresentationLayer.UpdateForms;
using System.ComponentModel;

namespace PresentationLayer
{
    public partial class ClientManagementForm : Form
    {
        private readonly IClientService clientService;
        private BindingList<ClientDTO> ClientBindingList;
        private readonly CreateCSV _createCSV;
        public ClientManagementForm()
        {
            InitializeComponent();
            clientService = new ClientServices();
            this.Load += new EventHandler(this.ClientManagementForm_Load);
            // Maneja el evento MouseWheel del DataGridView
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
            _createCSV = new CreateCSV();
        }

        #region CRUD
        private void btnAnadir_Click(object sender, EventArgs e)
        {

            AddClient newClient = new();
            newClient.MaximizeBox = false;
            newClient.MinimizeBox = false;
            var result = newClient.ShowDialog();
            if (result == DialogResult.OK)
            {
                DataGridSettings();
                LoadData();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Código para eliminar el cliente
                EliminarCliente();
            }

        }

        private void EliminarCliente()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int clientId = (int)dataGridView1.SelectedRows[0].Cells["ClientID"].Value; // Ajusta "" según tu columna

                // Llama al servicio para eliminar el producto de la base de datos
                clientService.DeleteClient(clientId);

                // Elimina el producto de la lista de binding
                ClientBindingList.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int clientId = (int)dataGridView1.SelectedRows[0].Cells["ClientID"].Value;
                int code = Convert.ToInt32(selectedRow.Cells[1].Value);
                string clientName = selectedRow.Cells[2].Value.ToString();
                string address = selectedRow.Cells[3].Value.ToString();
                string phone = selectedRow.Cells[4].Value.ToString();
                string rnc = selectedRow.Cells[5].Value.ToString();
                string email = selectedRow.Cells[6].Value.ToString();
                string city = selectedRow.Cells[7].Value.ToString();
                string fax = selectedRow.Cells[8].Value.ToString();
                ClientDTO clientDTO = new ClientDTO
                {
                    ClientId = clientId,
                    Code = code,
                    ClientName = clientName,
                    Address = address,
                    City = city,
                    PhoneNumber = phone,
                    Fax = fax,
                    Rnc = rnc,
                    Email = email
                };
                UpdateClient updateClient = new UpdateClient(clientDTO);
                updateClient.MaximizeBox = false;
                updateClient.MinimizeBox = false;
                var result = updateClient.ShowDialog();
                if (result == DialogResult.OK)
                {
                    DataGridSettings();
                    LoadData();
                }
            }
        }
        #endregion

        #region DataGrid Settings
        private void DataGridSettings()
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        public void LoadData()
        {
            if (dataGridView1 != null)
            {
                var client = clientService.GetAllCLient();
                ClientBindingList = new BindingList<ClientDTO>(client);
                dataGridView1.DataSource = ClientBindingList;
                lblFiltrados.Text = client.Count.ToString();
                lblTotalRegistros.Text = client.Count.ToString();
            }
        }

        private void ClientManagementForm_Load(object sender, EventArgs e)
        {
            DataGridSettings();
            LoadData();
        }
        #endregion

        #region ScrollBar
        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            int newRowIndex = Math.Min(e.NewValue, dataGridView1.Rows.Count - 1);
            if (newRowIndex >= 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            int newValue = materialScrollBar1.Value;

            if (e.Delta > 0 && newValue > materialScrollBar1.Minimum)
            {
                newValue--;
            }
            else if (e.Delta < 0 && newValue < materialScrollBar1.Maximum)
            {
                newValue++;
            }

            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            if (newValue >= 0 && newValue < dataGridView1.RowCount)
            {
                materialScrollBar1.Value = newValue;
                dataGridView1.FirstDisplayedScrollingRowIndex = newValue;
            }
        }

        #endregion

        private void customButton1_Click(object sender, EventArgs e)
        {
            _createCSV.ExportarDataGridViewAExcel(dataGridView1);
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {
            // Obtén el término de búsqueda del TextBox
            string searchTerm = txtSearch.Texts.Trim();

            // Filtra los datos en memoria usando LINQ sobre ClientBindingList
            var filteredClients = ClientBindingList
                .Where(c => c.ClientName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.Rnc.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            c.PhoneNumber.Contains(searchTerm))
                .ToList();

            // Actualiza el DataGridView con los resultados filtrados
            UpdateDataGridView(filteredClients);

        }

        private void UpdateDataGridView(List<ClientDTO> filteredClients)
        {
            // Asigna los resultados filtrados al DataGridView
            dataGridView1.DataSource = new BindingList<ClientDTO>(filteredClients);

            // Actualiza los labels de conteo
            lblFiltrados.Text = filteredClients.Count.ToString();
        }

    }
}
