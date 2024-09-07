using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;

namespace PresentationLayer.UpdateForms
{
    public partial class UpdateProduct : Form
    {
        private readonly IProductService _productService;
        private int _id;
        private DateTimeFormater _dateTimeFormater;
        public UpdateProduct(ProductsDTO productDTO)
        {
            InitializeComponent();
            _productService = new ProductServices();
            _id = productDTO.ProductsId;
            nombreTxt.Texts = productDTO.ProductName;
            codigoTxt.Texts = productDTO.Code;
            descripTxt.Texts = productDTO.Description;
            vencimientoTxt.Texts = productDTO.ExpirationDate.ToString("dd/MM/yyyy");
            precioTxt.Texts = productDTO.Price.ToString();
            loteTxt.Texts = productDTO.Lote.ToString();
            cantidadTxt.Texts = productDTO.Quantity.ToString();
            _dateTimeFormater = new();
            vencimientoTxt.Validating += textBoxFecha_Validating;
            precioTxt.KeyPress += ValidarSoloNumeros;
            loteTxt.KeyPress += ValidarSoloNumeros;
            cantidadTxt.KeyPress += ValidarSoloNumeros;
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            if (nombreTxt.Texts != "" && codigoTxt.Texts != "" && vencimientoTxt.Texts != "" && precioTxt.Texts != "" && loteTxt.Texts != "")
            {
                ProductsDTO productsDTO = new()
                {
                    ProductsId = _id,
                    ProductName = nombreTxt.Texts,
                    Code = codigoTxt.Texts,
                    Description = descripTxt.Texts,
                    ExpirationDate = Convert.ToDateTime(vencimientoTxt.Texts),
                    Price = Convert.ToDouble(precioTxt.Texts),
                    Lote = Convert.ToInt32(loteTxt.Texts),
                    Quantity = Convert.ToInt32(cantidadTxt.Texts),
                    ProductNeto = Convert.ToInt32(cantidadTxt.Texts) * Convert.ToDouble(precioTxt.Texts)
                };
                _productService.UpdateProduct(productsDTO);
                MessageBox.Show("Producto actualizado correctamente");
                Close();
            }
            else
            {
                MessageBox.Show("Ha dejado uno o más campos vacíos");
            }
        }

        private void textBoxFecha_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Obtiene el texto del TextBox
            string fechaTexto = vencimientoTxt.Texts;

            // Valida la fecha
            if (!_dateTimeFormater.ValidarFecha(fechaTexto))
            {
                // Muestra un mensaje de error si la fecha no es válida
                MessageBox.Show("El formato de la fecha debe ser dd/MM/yyyy y debe ser una fecha válida.", "Fecha Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancela el evento de validación
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
    }
}
