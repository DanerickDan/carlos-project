using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;


namespace PresentationLayer
{
    public partial class ProductManagementForm : Form
    {
        private readonly IProductService productService;
        public ProductManagementForm()
        {
            InitializeComponent();
            productService = new ProductServices();
        }


        // Add button
        private void btnAnadir_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                string productName = selectedRow.Cells[1].Value.ToString();
                int code = Convert.ToInt32(selectedRow.Cells[2].Value);
                string description = selectedRow.Cells[3].Value.ToString();
                DateTime expirationTime = Convert.ToDateTime(selectedRow.Cells[4].Value);
                double price = Convert.ToDouble(selectedRow.Cells[5].Value);
                int lote = Convert.ToInt32(selectedRow.Cells[6].Value);
                ProductsDTO productsDTO = new ProductsDTO
                {
                    ProductName = productName,
                    Code = code,
                    Description = description,
                    ExpirationDate = expirationTime,
                    Price = price,
                    Lote = lote
                };
                productService.AddProduct(productsDTO);
            }
        }
        // Delete Button
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                productService.DeleteProduct(productId);
            }
        }

        // Update button
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                string productName = selectedRow.Cells[1].Value.ToString();
                int code = Convert.ToInt32(selectedRow.Cells[2].Value);
                string description = selectedRow.Cells[3].Value.ToString();
                DateTime expirationTime = Convert.ToDateTime(selectedRow.Cells[4].Value);
                Double price = Convert.ToDouble(selectedRow.Cells[5].Value);
                int lote = Convert.ToInt32(selectedRow.Cells[6].Value);
                ProductsDTO productsDTO = new ProductsDTO
                {
                    ProductsId = productId,
                    ProductName = productName,
                    Code = code,
                    Description = description,
                    ExpirationDate = expirationTime,
                    Price = price,
                    Lote = lote
                };
                productService.UpdateProduct(productsDTO);
            }

        }
    }
}
