using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using MaterialSkin;

namespace PresentationLayer.AddForms
{
    public partial class AddClient : Form
    {
        private readonly IClientService _clientService;
        private readonly ClientCodeGenerator _clientCodeGenerator;

        public AddClient()
        {
            InitializeComponent();
            _clientCodeGenerator = new ClientCodeGenerator();
            _clientService = new ClientServices();
            rncTxt.KeyPress += ValidarSoloNumeros;
            ciudadTxt._TextChanged += ValidarSoloTexto;
        }

        private void customTextBox1__TextChanged(object sender, EventArgs e)
        {

        }

        private void AddClient_Load(object sender, EventArgs e)
        {
            LoadListBoxView();
        }

        private void ValidarSoloNumeros(object sender, KeyPressEventArgs e)
        {
            // Permite la entrada de teclas numéricas y el retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                // Si la tecla presionada no es un dígito ni una tecla de retroceso, se bloquea
                e.Handled = true;
                // Muestra un mensaje de error si se desea
                MessageBox.Show("Este campo solo debe contener números.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ValidarSoloTexto(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                // Verifica si el texto contiene solo letras y espacios
                if (!System.Text.RegularExpressions.Regex.IsMatch(textBox.Text, @"^[a-zA-Z\s]*$"))
                {
                    // Muestra un mensaje de error y limpia el texto si no es válido
                    MessageBox.Show("Este campo solo debe contener texto (letras y espacios).", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Text = string.Empty;
                }
            }
        }

        private void LoadListBoxView()
        {
            var data = _clientService.GetAllCLientName();
            codigoTxt.Texts = _clientCodeGenerator.ClientCode();
            // Single Line
            foreach (var name in data)
            {
                MaterialListBoxItem item = new();
                item.Text = name.ClientName;
                materialListBox1.Items.Add(item);
                // If i want to add a secondary text the code must be: item.SecondaryText = data and the add still equal
            }
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            if (nombreTxt.Texts != "" && direccionTxt.Texts != "" && ciudadTxt.Texts != "" && telefonoTxt.Texts != "" && emailTxt.Texts != "" && rncTxt.Texts != "")
            {
                ClientDTO clientDTO = new()
                {
                    ClientName = nombreTxt.Texts,
                    Address = direccionTxt.Texts,
                    City = ciudadTxt.Texts,
                    Email = emailTxt.Texts,
                    PhoneNumber = telefonoTxt.Texts,
                    Fax = faxTxt.Texts,
                    Rnc = rncTxt.Texts,
                    Code = Convert.ToInt32(codigoTxt.Texts)
                };
                _clientService.AddClient(clientDTO);
                // Adding to the list Box
                materialListBox1.Items.Clear();
                LoadListBoxView();
                CleanTextBox();
                MessageBox.Show("Cliente agregado correctamente");
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void CleanTextBox()
        {
            nombreTxt.Texts = "";
            direccionTxt.Texts = "";
            ciudadTxt.Texts = "";
            emailTxt.Texts = "";
            telefonoTxt.Texts = "";
            faxTxt.Texts = "";
            rncTxt.Texts = "";
            codigoTxt.Texts = _clientCodeGenerator.ClientCode();
        }
    }
}
