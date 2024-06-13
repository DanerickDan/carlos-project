using DataLayer.Connection;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class ProductsRepository
    {
        private readonly ConnectionManager connection = new();
        public ProductsRepository()
        {

        }

        public void AddProduct(Products product)
        {
            try
            {
                connection.OpenConnection();

                using (var command = new SQLiteCommand(
                    "INSERT INTO Productos (nombre, codigo, descripcion, fecha_vencimiento, precio,lote, cantidad) VALUES (@Nombre, @Codigo, @Descripcion, @FechaVencimiento, @Precio,@Lote , @Cantidad)",
                    connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Nombre", product.ProductName);
                    command.Parameters.AddWithValue("@Codigo", product.Code);
                    command.Parameters.AddWithValue("@Descripcion", product.Description);
                    command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate);
                    command.Parameters.AddWithValue("@Precio", product.Price);
                    command.Parameters.AddWithValue("@Lote", product.Lote);
                    command.Parameters.AddWithValue("@Cantidad", product.Quantity);

                    command.ExecuteNonQuery();
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateProduct(Products product)
        {

        }

        public void DeleteProduct(Products product)
        {

        }

        public Products GetAllProduct()
        {
            return null;
        }

        public Products GetByIdProduct(int id)
        {
            return null;
        }
    }
}
