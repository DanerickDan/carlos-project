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
        public AddProduct()
        {
            _productService = new ProductServices();
            _productCodeGenarator = new ProductCodeGenarator();
            InitializeComponent();
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
