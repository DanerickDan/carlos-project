using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ConnectionManager connectionManager;
        public CategoryRepository()
        {
            connectionManager = new();
        }


        public List<Categories> GetAllCategory() 
        {
            var categories = new List<Categories>();
            try
            {
                using (var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection();
                    string query = "SELECT * FROM   Categorias";
                    using (var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                    {
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categories.Add(new Categories
                                {
                                    CategoryId = reader.GetInt32(0),
                                    CategoryName = reader.GetString(1)
                                });
                            }
                        }
                    }
                    return categories;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Categories GetCategoryById(int id)
        {
            try
            {
                using(var connection = connectionManager.GetConnection())
                {
                    connectionManager.OpenConnection();
                    string query = "SELECT * FROM Categorias WHERE category_id = @Id";
                    using(var command = new SQLiteCommand(query, connectionManager.GetConnection()))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        using(var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                return new Categories
                                {
                                    CategoryId = reader.GetInt32(0),
                                    CategoryName = reader.GetString(1)
                                };
                            }
                        }
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
