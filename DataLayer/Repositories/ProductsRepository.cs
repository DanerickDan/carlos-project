using DataLayer.Connection;
using DomainLayer.Entities;
using System.Data;
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
                    "INSERT INTO Productos (nombre, codigo, descripcion, fecha_vencimiento, precio,lote,category_id, estado_id" +
                    ") VALUES (@Nombre, @Codigo, @Descripcion, @FechaVencimiento, @Precio,@Lote, @Categoria, @Estado)",
                    connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Nombre", product.ProductName);
                    command.Parameters.AddWithValue("@Codigo", product.Code);
                    command.Parameters.AddWithValue("@Descripcion", product.Description);
                    command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate);
                    command.Parameters.AddWithValue("@Precio", product.Price);
                    command.Parameters.AddWithValue("@Lote", product.Lote);
                    command.Parameters.AddWithValue("@Categoria", product.CategoryId);
                    command.Parameters.AddWithValue("@Estado", product.StatusId);


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
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {
                    string query = "UPDATE Productos SET nombre = @Nombre, codigo = @Codigo, descripcion = @Descripcion, " +
                        "fecha_vencimiento = @FechaVencimiento, precio = @Precio, lote = @Lote, category_id = Category, estado_id = @Estado WHERE product_id = @Id";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Id", product.ProductsId);
                        command.Parameters.AddWithValue("@Nombre", product.ProductName);
                        command.Parameters.AddWithValue("@Codigo", product.Code);
                        command.Parameters.AddWithValue("@Descripcion", product.Description);
                        command.Parameters.AddWithValue("@FechaVencimiento", product.ExpirationDate);
                        command.Parameters.AddWithValue("@Precio", product.Price);
                        command.Parameters.AddWithValue("@Lote", product.Lote);
                        command.Parameters.AddWithValue("@Category", product.CategoryId);
                        command.Parameters.AddWithValue("@Estado", product.StatusId);
                        command.ExecuteNonQuery();
                    }
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteProduct(int id)
        {
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {

                    string query = "DELETE FROM Productos WHERE producto_id = @Id";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
                connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Products> GetAllProduct()
        {
            var products = new List<Products>();
            try
            {
                connection.OpenConnection();

                string query = @"
                SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
	            p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento,p.precio as ProductoPrecio,
	            p.lote as Lote, p.cantidad as Cantidad, p.category_id as ProductoCategoriaId,
	            c.category_id as CategoriaId, c.nombre_categoria as CategoriaNombre,
                p.estado_id as ProductoEstadoId, e.estado_id as EstadoId, e.descripcion as EstadoNombre
                FROM Productos p
                INNER JOIN Categorias c ON p.category_id = c.category_id
                INNER JOIN EstadoPedido e ON p.estado_id = e.estado_id";
                using (var command = new SQLiteCommand(query, connection.GetConnection()))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Products
                            {
                                ProductsId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductoId")),
                                Code = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                ExpirationDate = reader.GetDateTime(reader.GetOrdinal("Vencimiento")),
                                Price = reader.GetInt32(reader.GetOrdinal("ProductoPrecio")),
                                Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
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
                connection.CloseConnection();
                return products;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Products GetByIdProduct(int id)
        {
            try
            {
                connection.OpenConnection();
                string query = @"
                SELECT p.producto_id as ProductoId, p.nombre as ProductoNombre, p.codigo as Codigo,
	            p.descripcion as Descripcion, p.fecha_vencimiento as Vencimiento,p.precio as ProductoPrecio,
	            p.lote as Lote, p.category_id as ProductoCategoriaId,
	            c.category_id as CategoriaId, c.nombre_categoria as CategoriaNombre,
                p.estado_id as ProductoEstadoId, e.estado_id as EstadoId, e.descripcion as EstadoNombre
                FROM Productos p 
                INNER JOIN Categorias c ON p.category_id = c.category_id
                INNER JOIN EstadoPedido e ON p.estado_id = e.estado_id
                WHERE p.producto_id = @Id;";
                using (var command = new SQLiteCommand(query, connection.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Products
                            {
                                ProductsId = reader.GetInt32(reader.GetOrdinal("ProductoId")),
                                ProductName = reader.GetString(reader.GetOrdinal("ProductoId")),
                                Code = reader.GetInt32(reader.GetOrdinal("Codigo")),
                                Description = reader.GetString(reader.GetOrdinal("Descripcion")),
                                ExpirationDate = reader.GetDateTime(reader.GetOrdinal("Vencimiento")),
                                Price = reader.GetInt32(reader.GetOrdinal("ProductoPrecio")),
                                Lote = reader.GetInt32(reader.GetOrdinal("Lote")),
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
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
