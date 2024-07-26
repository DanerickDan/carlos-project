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
            this.Load += new EventHandler(this.ProductManagementForm_Load);
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
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
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                EliminarProducto();
            }
        }

        private void EliminarProducto()
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

        private void DataGridSettings()
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        private void LoadData()
        {
            if (dataGridView1 != null)
            {
                dataGridView1.DataSource = productService.GetAllProduct();
            }
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            DataGridSettings();
            LoadData();
        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.Rows[e.NewValue].Index;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && materialScrollBar1.Value > materialScrollBar1.Minimum)
            {
                materialScrollBar1.Value--;
            }
            else if (e.Delta < 0 && materialScrollBar1.Value < materialScrollBar1.Maximum)
            {
                materialScrollBar1.Value++;
            }

            dataGridView1.FirstDisplayedScrollingRowIndex = materialScrollBar1.Value;
        }


        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            materialScrollBar1.Maximum = dataGridView1.RowCount;
        }
    }
}
