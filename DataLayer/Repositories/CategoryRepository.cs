using DataLayer.Connection;
using DataLayer.IRepository;
using DomainLayer.Entities;
using System.Data.SQLite;

namespace DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ConnectionManager connection;
        public CategoryRepository()
        {
            connection = new();
        }


        public List<Categories> GetAllCategory() 
        {
            var categories = new List<Categories>();
            try
            {
                connection.OpenConnection();
                using (connection.GetConnection())
                {
                    string query = "SELECT * FROM   Categorias";
                    using (var command = new SQLiteCommand(query, connection.GetConnection()))
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
                connection.OpenConnection();
                using(connection.GetConnection())
                {
                    string query = "SELECT * FROM Categorias WHERE category_id = @Id";
                    using(var command = new SQLiteCommand(query, connection.GetConnection()))
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
