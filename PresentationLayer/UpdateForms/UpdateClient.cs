using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;

namespace PresentationLayer.UpdateForms
{
    public partial class UpdateClient : Form
    {
        private readonly IClientService _clientService;
        private readonly int _id;
        private FieldValidator _fieldValidator;

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
            _fieldValidator = new();
            emailTxt.Texts = client.Email;
            rncTxt.Texts = client.Rnc;
            _clientService = new ClientServices();
            AddEvent();
        }

        private void AddEvent()
        {
            emailTxt.CausesValidation = true;
            telefonoTxt.CausesValidation = true;

            rncTxt.KeyPress += ValidarSoloNumeros;
            ciudadTxt._TextChanged += ValidarSoloTexto;
            emailTxt.Leave += textBoxEmail_Validating;
            telefonoTxt.Leave += textBoxTelefono_Validating;
            nombreTxt.Leave += ValidarSoloLetrasEspañol;
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (nombreTxt.Texts != "" && rncTxt.Texts != "" && ciudadTxt.Texts != "" && telefonoTxt.Texts != "" && emailTxt.Texts != "" && direccionTxt.Texts != "")
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
                Close();
            }
            else
            {
                MessageBox.Show("Ha dejado uno o más campos vacíos");
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

        private void textBoxEmail_Validating(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !_fieldValidator.ValidarEmail(emailTxt.Texts))
            {
                MessageBox.Show("El formato del correo electrónico no es válido.", "Correo Electrónico Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                emailTxt.Focus(); // Devuelve el foco al control
            }
        }

        private void textBoxTelefono_Validating(object sender, EventArgs e)
        {
            if (sender is TextBox textBox && !_fieldValidator.ValidarTelefono(telefonoTxt.Texts))
            {
                MessageBox.Show("El formato del número de teléfono debe ser (000)-000-0000.", "Número de Teléfono Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                telefonoTxt.Focus(); // Devuelve el foco al control
            }
        }

        private void ValidarSoloLetrasEspañol(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                string patron = @"^[a-zA-ZáéíóúüñÑ\s]*$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(nombreTxt.Texts, patron))
                {
                    MessageBox.Show("Este campo solo debe contener letras del alfabeto español (incluyendo acentos y ñ).", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nombreTxt.Focus();
                }
            }
        }

    }
}
