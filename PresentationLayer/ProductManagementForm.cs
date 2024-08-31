using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using BusinessLayer.Services;
using PresentationLayer.AddForms;
using System.ComponentModel;


namespace PresentationLayer
{
    public partial class ProductManagementForm : Form
    {
        private readonly IProductService productService;
        private BindingList<ProductsDTO> ProductBindingList;

        public ProductManagementForm()
        {
            productService = new ProductServices();
            InitializeComponent();
            this.Load += new EventHandler(this.ProductManagementForm_Load);
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;
        }


        // Add button
        private void btnAnadir_Click(object sender, EventArgs e)
        {

            AddProduct addProduct = new();
            addProduct.MaximizeBox = false;
            addProduct.MinimizeBox = false;
            var result = addProduct.ShowDialog();
            if(result == DialogResult.OK)
            {
                DataGridSettings();
                LoadData();
                MessageBox.Show("DataGrid Actualizado");
            }
            else
            {
                MessageBox.Show(result.ToString());
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
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                int productId = (int)dataGridView1.SelectedRows[0].Cells["ProductID"].Value;
                productService.DeleteProduct(productId);

                ProductBindingList.RemoveAt(rowIndex);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
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
                string code = selectedRow.Cells[2].Value.ToString();
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
                var products = productService.GetAllProduct();
                ProductBindingList = new BindingList<ProductsDTO>(products);
                dataGridView1.DataSource = ProductBindingList;
            }
        }

        private void ProductManagementForm_Load(object sender, EventArgs e)
        {
            DataGridSettings();
            LoadData();
        }

        private void materialScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            int newRowIndex = Math.Min(e.NewValue, dataGridView1.Rows.Count - 1);
            if (newRowIndex >= 0)
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = newRowIndex;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Ajustar el máximo del scrollbar al número de filas - 1 para evitar IndexOutOfRange
            materialScrollBar1.Maximum = Math.Max(0, dataGridView1.RowCount - 1);
        }


        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            int newValue = materialScrollBar1.Value;

            if (e.Delta > 0 && newValue > materialScrollBar1.Minimum)
            {
                newValue--;
            }
            else if (e.Delta < 0 && newValue < materialScrollBar1.Maximum)
            {
                newValue++;
            }

            // Verificar que el índice no sea mayor que la cantidad de filas disponibles
            if (newValue >= 0 && newValue < dataGridView1.RowCount)
            {
                materialScrollBar1.Value = newValue;
                dataGridView1.FirstDisplayedScrollingRowIndex = newValue;
            }
        }

    }
}
