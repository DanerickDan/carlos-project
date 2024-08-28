using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Services;
using MaterialSkin;

namespace PresentationLayer.AddForms
{
    public partial class AddClient : Form
    {
        private readonly IClientService _clientService;
        public AddClient()
        {
            InitializeComponent();
            _clientService = new ClientServices();
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            var data = _clientService.GetAllCLientName();
            // Single Line
            foreach (var name in data)
            {
                MaterialListBoxItem item = new();
                item.Text = name;
                materialListBox1.Items.Add(item);
                // If i want to add a secondary text the code must be: item.SecondaryText = data and the add still equal
            }
        }
    }
}
