using BusinessLayer.Interfaces.IServices;
using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;

namespace BusinessLayer.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductsRepository _repository;
        public ProductServices() 
        {
            _repository = new ProductsRepository();
        }

        public void AddProduct(ProductsDTO productDTO)
        {
            var product = new Products
            {
                ProductsId = productDTO.ProductsId,
                ProductName = productDTO.ProductName,
                Code = productDTO.Code,
                Description = productDTO.Description,
                ExpirationDate = productDTO.ExpirationDate,
                Price = productDTO.Price,
                Lote = productDTO.Lote,
                CategoryId = productDTO.CategoryId,
                StatusId = productDTO.StatusId
            };
            _repository.AddProduct(product);
        }

        public void UpdateProduct(ProductsDTO productDTO)
        {
            var product = new Products
            {
                ProductsId = productDTO.ProductsId,
                ProductName = productDTO.ProductName,
                Code = productDTO.Code,
                Description = productDTO.Description,
                ExpirationDate = productDTO.ExpirationDate,
                Price = productDTO.Price,
                Lote = productDTO.Lote,
                CategoryId = productDTO.CategoryId,
                StatusId = productDTO.StatusId
            };
            _repository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            _repository.DeleteProduct(id);
        }

        public List<ProductsDTO> GetAllProduct()
        {
            var productDTO = new List<ProductsDTO>();
            var product = _repository.GetAllProduct();
            foreach (var item in product)
            {
                productDTO.Add(new ProductsDTO
                {
                    ProductsId = item.ProductsId,
                    ProductName = item.ProductName,
                    Code = item.Code,
                    Description = item.Description,
                    ExpirationDate = item.ExpirationDate,
                    Price = item.Price,
                    Lote = item.Lote,
                    CategoryId = item.CategoryId,
                    StatusId = item.StatusId
                });
            }
            return productDTO;

        }

        public ProductsDTO GetByIdProduct(int id)
        {
            var products = _repository.GetByIdProduct(id);
            var productsDTO = new ProductsDTO
            {
                ProductsId = products.ProductsId,
                ProductName = products.ProductName,
                Code = products.Code,
                Description = products.Description,
                ExpirationDate = products.ExpirationDate,
                Price = products.Price,
                Lote = products.Lote,
                CategoryId = products.CategoryId,
                StatusId = products.StatusId
            };

            return productsDTO;

        }
    }
}
