using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface ICategoryRepository
    {
        List<Categories> GetAllCategory();
        Categories GetCategoryById(int id);
    }
}
