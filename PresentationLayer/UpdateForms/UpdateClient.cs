using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;

namespace PresentationLayer.UpdateForms
{
    public partial class UpdateClient : Form
    {
        private readonly IClientService _clientService;
        private readonly int _id;
        public UpdateClient(ClientDTO client)
        {
            InitializeComponent();
            _id = client.ClientId;
            faxTxt.Texts = client.Fax;
            codigoTxt.Texts = client.Code.ToString();
            nombreTxt.Texts = client.ClientName;
            direccionTxt.Texts = client.Address;
            ciudadTxt.Texts = client.City;
            telefonoTxt.Texts = client.PhoneNumber;
            emailTxt.Texts = client.Email;
            rncTxt.Texts = client.Rnc;
            _clientService = new ClientServices();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            ClientDTO client = new()
            {
                ClientId = _id,
                Fax = faxTxt.Texts,
                ClientName = nombreTxt.Texts,
                Address = direccionTxt.Texts,
                City = direccionTxt.Texts,
                PhoneNumber = telefonoTxt.Texts,
                Email = emailTxt.Texts,
                Rnc = rncTxt.Texts,
            };
            _clientService.UpdateClient(client);
            MessageBox.Show("Cliente actualizado correctamente");
            this.Close();
        }
    }
}
