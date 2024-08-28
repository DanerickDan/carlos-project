using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Services;
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
        public AddProduct()
        {
            _productService = new ProductServices();
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            var data = _productService.GetAllProductName();
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
