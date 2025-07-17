using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;
using System.Globalization;

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
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = new SQLiteCommand(
                        "INSERT INTO Productos (nombre, codigo, descripcion, fecha_vencimiento, precio, lote, cantidad, activo,category_id, estado_id) " +
                        "VALUES (@Nombre, @Codigo, @Descripcion, @FechaVencimiento, @Precio, @Lote, @Cantidad, @Activo,@Categoria, @Estado)", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Nombre", product.ProductName);
                            command.Parameters.AddWithValue("@Codigo", product.Code);
                            command.Parameters.AddWithValue("@Descripcion", product.Description);
                            command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate.ToString("dd-MM-yyyy")); // Ajuste para fechas
                            command.Parameters.AddWithValue("@Precio", product.Price);
                            command.Parameters.AddWithValue("@Lote", product.Lote);
                            command.Parameters.AddWithValue("@Cantidad", product.Quantity);
                            command.Parameters.AddWithValue("@Activo", 1);
                            command.Parameters.AddWithValue("@Categoria", 1);
                            command.Parameters.AddWithValue("@Estado", 1);

                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        connection.Close();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in AddProduct: {ex.Message} at {ex.StackTrace}", ex);
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
                    using (var transaction = connection.BeginTransaction())
                    {
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", product.ProductsId);
                            command.Parameters.AddWithValue("@Nombre", product.ProductName);
                            command.Parameters.AddWithValue("@Codigo", product.Code);
                            command.Parameters.AddWithValue("@Descripcion", product.Description);
                            command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate.ToString("dd-MM-yyyy")); // Ajuste para fechas
                            command.Parameters.AddWithValue("@Precio", product.Price);
                            command.Parameters.AddWithValue("@Lote", product.Lote);
                            command.Parameters.AddWithValue("@Cantidad", product.Quantity);
                            command.Parameters.AddWithValue("@Category", 1);
                            command.Parameters.AddWithValue("@Estado", 1);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in UpdateProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = "UPDATE Productos SET activo = 0 WHERE producto_id = @Id";
                        using (var command = new SQLiteCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in Delete Product: {ex.Message} at {ex.StackTrace}", ex);
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
                    //string query = @"
                    //    SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
                    // p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento, p.precio as ProductoPrecio,
                    // p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId,
                    // c.category_id as CategoriaId, c.nombre_categoria as CategoriaNombre,
                    //    p.estado_id as ProductoEstadoId, e.estado_id as EstadoId, e.descripcion as EstadoNombre
                    //    FROM Productos p
                    //    INNER JOIN Categorias c ON p.category_id = c.category_id
                    //    INNER JOIN EstadoPedido e ON p.estado_id = e.estado_id
                    //    WHERE activo = 1";
                    string query = @"
                        SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
                        p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento, p.precio as ProductoPrecio,
                        p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId
                        FROM Productos p
                        WHERE activo = 1        
                        ";
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
                                    Code = reader.GetString(reader.GetOrdinal("Codigo")),
                                    Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    ExpirationDate = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Vencimiento")), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                    Price = reader.GetDouble(reader.GetOrdinal("ProductoPrecio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad")),
                                    //CategoryId = reader.GetInt32(reader.GetOrdinal("ProductoCategoriaId")),
                                    //StatusId = reader.GetInt32(reader.GetOrdinal("ProductoEstadoId")),
                                    //Category = new Categories
                                    //{
                                    //    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                                    //    CategoryName = reader.GetString(reader.GetOrdinal("CategoriaNombre"))
                                    //},
                                    //Statu = new Status
                                    //{
                                    //    StatusId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                                    //    Descripcion = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                    //}
                                });
                            }
                        }
                    }
                }

                return products;
            }
            catch (SQLiteException ex)
            {
                throw new Exception($"Error in GetAllProduct: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public Products GetByIdProduct(int id)
        {
            try
            {
                Products products = new Products();
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = @"
                        SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
                        p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento, p.precio as ProductoPrecio,
                        p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId
                        FROM Productos p
                        WHERE p.producto_id = @Id and activo = 1;";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                products = new Products
                                {
                                    ProductsId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                    ProductName = reader.GetString(reader.GetOrdinal("ProductoNombre")),
                                    Code = reader.GetString(reader.GetOrdinal("Codigo")),
                                    Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                    ExpirationDate = DateTime.ParseExact(reader.GetString(reader.GetOrdinal("Vencimiento")), "dd-MM-yyyy", CultureInfo.InvariantCulture),
                                    Price = reader.GetDouble(reader.GetOrdinal("ProductoPrecio")),
                                    Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
                                    Quantity = reader.GetInt32(reader.GetOrdinal("Cantidad"))
                                    //CategoryId = reader.GetInt32(reader.GetOrdinal("ProductoCategoriaId")),
                                    //StatusId = reader.GetInt32(reader.GetOrdinal("ProductoEstadoId")),
                                    //Category = new Categories
                                    //{
                                    //    CategoryId = reader.GetInt32(reader.GetOrdinal("CategoriaId")),
                                    //    CategoryName = reader.GetString(reader.GetOrdinal("CategoriaNombre"))
                                    //},
                                    //Statu = new Status
                                    //{
                                    //    StatusId = reader.GetInt32(reader.GetOrdinal("EstadoId")),
                                    //    Descripcion = reader.GetString(reader.GetOrdinal("EstadoNombre"))
                                    //}
                                };
                            }
                        }
                        return products;
                    }
                }
            }
            catch (SQLiteException ex)
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
                        }
                    }
                }
                return productNames;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetAllProductName: {ex.Message} at {ex.StackTrace}", ex);
            }
        }

        public IEnumerable<Products> GetInvoiceProducts()
        {
            List<Products> products = new();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);

                    string query = "SELECT * FROM ProductosFacturas";
                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Products product = new()
                                {
                                    ProductName = reader.GetString(0),
                                    Price = reader.GetDouble(1),
                                    Quantity = reader.GetInt32(2),
                                    ProductsId = reader.GetInt32(3)
                                };
                                products.Add(product);
                            }
                        }
                    }

                }
                return products;
            }
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in GetAllProductName: {ex.Message} at {ex.StackTrace}", ex);
            }

        }

        public bool ExistCode(string code, string type)
        {
            try
            {

                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection(connection);
                    string query = "SELECT COUNT(1) FROM Productos WHERE @Type = @Code";
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
            catch (SQLiteException ex)
            {
                throw new SQLiteException($"Error in ExistCode: {ex.Message} at {ex.StackTrace}", ex);
            }
        }
    }
}
