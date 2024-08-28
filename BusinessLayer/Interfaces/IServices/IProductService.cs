using BusinessLayer.Model;

namespace BusinessLayer.Interfaces.IServices
{
    public interface IProductService
    {
        public void AddProduct(ProductsDTO productDTO);
        public void UpdateProduct(ProductsDTO productDTO);
        public void DeleteProduct(int id);
        public List<ProductsDTO> GetAllProduct();
        public ProductsDTO GetByIdProduct(int id);
        IEnumerable<ProductsDTO> GetAllProductName();
    }
}
