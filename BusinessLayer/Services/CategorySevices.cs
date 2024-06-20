using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Services
{
    public class CategorySevices
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategorySevices() 
        {
            _categoryRepository = new CategoryRepository();
        }

        public List<CategoriesDTO> GetAllCategory()
        {
            var categories = _categoryRepository.GetAllCategory();
            var categoryDTO = new List<CategoriesDTO>();
            foreach (var category in categories)
            {
                categoryDTO.Add(new CategoriesDTO
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName,
                });
            }
            return categoryDTO;

        }

        public CategoriesDTO GetCategoryById(int id) 
        {
            var category = _categoryRepository.GetCategoryById(id);
            var categoryDTO = new CategoriesDTO
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
            };
            return categoryDTO;
        }
    }
}
