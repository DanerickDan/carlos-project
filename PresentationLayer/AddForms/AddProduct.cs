using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProductsDTO productsDTO = new()
            {
                ProductName = nombreTxt.Texts,
                Code = codigoTxt.Texts,
                Description = descriptxt.Texts,
                Quantity = Convert.ToInt32(cantidadTxt.Texts),
                ExpirationDate = Convert.ToDateTime(vencimientoTxt.Texts),
                Price = Convert.ToDouble(precioTxt.Texts),
                ProductNeto = Convert.ToInt32(cantidadTxt.Texts) * Convert.ToDouble(precioTxt.Texts)
            };
            _productService.AddProduct(productsDTO);
        }
    }
}
