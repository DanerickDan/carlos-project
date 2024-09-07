using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Globalization;

namespace PresentationLayer.AddForms
{
    public partial class AddProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ProductCodeGenarator _productCodeGenarator;
        private DateTimeFormater _dateFormater;
        public AddProduct()
        {
            InitializeComponent();
            _productService = new ProductServices();
            _productCodeGenarator = new ProductCodeGenarator();
            _dateFormater = new();
            vencimientoTxt.Validating += textBoxFecha_Validating;
            precioTxt.KeyPress += ValidarSoloNumeros;
            loteTxt.KeyPress += ValidarSoloNumeros;
            cantidadTxt.KeyPress += ValidarSoloNumeros;

        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadListBoxView();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (nombreTxt.Texts != "" && codigoTxt.Texts != "" && cantidadTxt.Texts != "" && vencimientoTxt.Texts != "" && loteTxt.Texts != "" && precioTxt.Texts != "")
            {
                ProductsDTO productsDTO = new()
                {
                    ProductName = nombreTxt.Texts,
                    Code = codigoTxt.Texts,
                    Description = descriptxt.Texts,
                    Quantity = Convert.ToInt32(cantidadTxt.Texts),
                    ExpirationDate = DateTime.ParseExact(vencimientoTxt.Texts, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Lote = Convert.ToInt32(loteTxt.Texts),
                    Price = Convert.ToDouble(precioTxt.Texts),
                    ProductNeto = Convert.ToInt32(cantidadTxt.Texts) * Convert.ToDouble(precioTxt.Texts)
                };
                _productService.AddProduct(productsDTO);
                CleanTextBox();
                materialListBox1.Items.Clear();
                LoadListBoxView();
                MessageBox.Show("Producto agregado correctamente");
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void textBoxFecha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Obtiene el texto del TextBox
            string fechaTexto = vencimientoTxt.Texts;

            // Valida la fecha
            if (!_dateFormater.ValidarFecha(fechaTexto))
            {
                // Muestra un mensaje de error si la fecha no es válida
                MessageBox.Show("El formato de la fecha debe ser dd/MM/yyyy y debe ser una fecha válida.", "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela el evento de validación
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

        private void CleanTextBox()
        {
            loteTxt.Texts = "";
            nombreTxt.Texts = "";
            descriptxt.Texts = "";
            cantidadTxt.Texts = "";
            vencimientoTxt.Texts = "";
            precioTxt.Texts = "";
            codigoTxt.Texts = _productCodeGenarator.GenerateProductCode();
        }

        private void LoadListBoxView()
        {
            var data = _productService.GetAllProductName();
            codigoTxt.Texts = _productCodeGenarator.GenerateProductCode();
            materialListBox1.Style = MaterialListBox.ListBoxStyle.TwoLine;
            foreach (var item in data)
            {
                MaterialListBoxItem listBoxItem = new MaterialListBoxItem();
                listBoxItem.Text = item.ProductName;
                listBoxItem.SecondaryText = item.Price.ToString();
                materialListBox1.Items.Add(listBoxItem);
            }
        }
    }
}
