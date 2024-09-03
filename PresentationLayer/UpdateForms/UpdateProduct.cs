using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;

namespace PresentationLayer.UpdateForms
{
    public partial class UpdateProduct : Form
    {
        private readonly IProductService _productService;
        private int _id;
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
        }

        private void customButton1_Click(object sender, EventArgs e)
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
                Quantity = Convert.ToInt32(cantidadTxt.Texts)
            };
            _productService.UpdateProduct(productsDTO);
            MessageBox.Show("Producto actualizado correctamente");
            Close();
        }
    }
}
