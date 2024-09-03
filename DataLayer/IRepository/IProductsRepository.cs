using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IProductsRepository
    {
        void AddProduct(Products product);
        void UpdateProduct(Products product);
        void DeleteProduct(int id);
        List<Products> GetAllProduct();
        Products GetByIdProduct(int id);
        IEnumerable<Products> GetAllProductName();
        public bool ExistCode(string code ,string type);
        public IEnumerable<Products> GetInvoiceProducts();
    }
}
