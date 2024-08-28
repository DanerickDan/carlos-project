using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ConnectionManager connectionManager;

        public ProductsRepository()
        {
            connectionManager = new ConnectionManager();
        }

        public void AddProduct(Products product)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    using (var command = new SQLiteCommand(
                    "INSERT INTO Productos (nombre, codigo, descripcion, fecha_vencimiento, precio, lote, cantidad, category_id, estado_id) " +
                    "VALUES (@Nombre, @Codigo, @Descripcion, @FechaVencimiento, @Precio, @Lote, @Cantidad, @Categoria, @Estado)", connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", product.ProductName);
                        command.Parameters.AddWithValue("@Codigo", product.Code);
                        command.Parameters.AddWithValue("@Descripcion", product.Description);
                        command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate.ToString("yyyy-MM-dd")); // Ajuste para fechas
                        command.Parameters.AddWithValue("@Precio", product.Price);
                        command.Parameters.AddWithValue("@Lote", product.Lote);
                        command.Parameters.AddWithValue("@Cantidad", product.Quantity);
                        command.Parameters.AddWithValue("@Categoria", product.CategoryId);
                        command.Parameters.AddWithValue("@Estado", product.StatusId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in AddProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public void UpdateProduct(Products product)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "UPDATE Productos SET nombre = @Nombre, codigo = @Codigo, descripcion = @Descripcion, " +
                        "fecha_vencimiento = @FechaVencimiento, precio = @Precio, lote = @Lote, cantidad = @Cantidad, category_id = @Category, estado_id = @Estado WHERE producto_id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", product.ProductsId);
                        command.Parameters.AddWithValue("@Nombre", product.ProductName);
                        command.Parameters.AddWithValue("@Codigo", product.Code);
                        command.Parameters.AddWithValue("@Descripcion", product.Description);
                        command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate.ToString("yyyy-MM-dd")); // Ajuste para fechas
                        command.Parameters.AddWithValue("@Precio", product.Price);
                        command.Parameters.AddWithValue("@Lote", product.Lote);
                        command.Parameters.AddWithValue("@Cantidad", product.Quantity);
                        command.Parameters.AddWithValue("@Category", product.CategoryId);
                        command.Parameters.AddWithValue("@Estado", product.StatusId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in UpdateProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "DELETE FROM Productos WHERE producto_id = @Id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in Delete Product: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public List<Products> GetAllProduct()
        {
            var products = new List<Products>();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"
                SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
	            p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento, p.precio as ProductoPrecio,
	            p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId,
	            c.category_id as CategoriaId, c.nombre_categoria as CategoriaNombre,
                p.estado_id as ProductoEstadoId, e.estado_id as EstadoId, e.descripcion as EstadoNombre
                FROM Productos p
                INNER JOIN Categorias c ON p.category_id = c.category_id
                INNER JOIN EstadoPedido e ON p.estado_id = e.estado_id";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Products
                                {
                                    ProductsId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductoNombre")),
                                    Code = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                    Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    ExpirationDate = reader.GetDateTime(reader.GetOrdinal("Vencimiento")),
                                    Price = reader.GetDouble(reader.GetOrdinal("ProductoPrecio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("ProductoCategoriaId")),
                                    StatusId = reader.GetInt32(reader.GetOrdinal("ProductoEstadoId")),
                                    Category = new Categories
                                    {
                                        CategoryId = reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                                        CategoryName = reader.GetString(reader.GetOrdinal("CategoriaNombre"))
                                    },
                                    Statu = new Status
                                    {
                                        StatusId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                                        Descripcion = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                    }
                                });
                            }
                        }
                    }
                }

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public Products GetByIdProduct(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"
                SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
	            p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento, p.precio as ProductoPrecio,
	            p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId,
	            c.category_id as CategoriaId, c.nombre_categoria as CategoriaNombre,
                p.estado_id as ProductoEstadoId, e.estado_id as EstadoId, e.descripcion as EstadoNombre
                FROM Productos p 
                INNER JOIN Categorias c ON p.category_id = c.category_id
                INNER JOIN EstadoPedido e ON p.estado_id = e.estado_id
                WHERE p.producto_id = @Id;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Products
                                {
                                    ProductsId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductoNombre")),
                                    Code = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                    Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    ExpirationDate = reader.GetDateTime(reader.GetOrdinal("Vencimiento")),
                                    Price = reader.GetDouble(reader.GetOrdinal("ProductoPrecio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    CategoryId = reader.GetInt32(reader.GetOrdinal("ProductoCategoriaId")),
                                    StatusId = reader.GetInt32(reader.GetOrdinal("ProductoEstadoId")),
                                    Category = new Categories
                                    {
                                        CategoryId = reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                                        CategoryName = reader.GetString(reader.GetOrdinal("CategoriaNombre"))
                                    },
                                    Statu = new Status
                                    {
                                        StatusId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                                        Descripcion = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                    }
                                };
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetByIdProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public IEnumerable<Products> GetAllProductName()
        {
            List<Products> productNames = new();

            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT Nombre, Precio FROM VerProductos";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Products products = new()
                                {
                                    ProductName = reader.GetString(0),
                                    Price = reader.GetDouble(1)
                                };
                                productNames.Add(products);
                            }
                            return productNames;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in GetAllProductName: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public bool ExistCode(string code, string type)
        {
            try
            {

                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT COUNT(1) FROM Productos WHEHRE @Type = @Code";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Code", code);
                        var count = command.ExecuteScalar();

                        if (count != null)
                        {
                            return true;
                        }

                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ExistCode: {ex.Message} at {ex.StackTrace}", ex);
            }
        }
    }
}
