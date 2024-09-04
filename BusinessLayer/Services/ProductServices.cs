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
                ProductName = productDTO.ProductName,
                Code = productDTO.Code,
                Description = productDTO.Description,
                ExpirationDate = productDTO.ExpirationDate,
                Quantity = productDTO.Quantity,
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
                Quantity = productDTO.Quantity,
                ExpirationDate = productDTO.ExpirationDate,
                Price = productDTO.Price,
                Lote = productDTO.Lote,
                CategoryId = productDTO.CategoryId,
                StatusId = productDTO.StatusId
            };
            _repository.UpdateProduct(product);
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
                    Quantity = item.Quantity,
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
            if(products == null)
            {
                throw new Exception("Es null bro checka bi");
            }
            var productsDTO = new ProductsDTO
            {
                ProductsId = products.ProductsId,
                ProductName = products.ProductName,
                Code = products.Code,
                Description = products.Description,
                ExpirationDate = products.ExpirationDate,
                Price = products.Price,
                Quantity=products.Quantity,
                Lote = products.Lote,
                CategoryId = products.CategoryId,
                StatusId = products.StatusId,
                
            };

            return productsDTO;

        }

        public IEnumerable<ProductsDTO> GetAllProductName()
        {
            List<ProductsDTO> products = new();
            var names  = _repository.GetAllProductName();

            foreach (var item in names)
            {
                ProductsDTO productsDTO = new()
                {
                    ProductName = item.ProductName,
                    Price = item.Price

                };
                products.Add(productsDTO);
            }
            return products;
        }

        public IEnumerable<ProductsDTO> GetInvoiceProducts()
        {
            var products = _repository.GetInvoiceProducts();
            List<ProductsDTO> productsList = new();
            foreach (var item in products)
            {
                ProductsDTO product = new()
                {
                    ProductsId = item.ProductsId,
                    ProductName= item.ProductName,
                    Price = item.Price,
                    Quantity = item.Quantity,
                };
                productsList.Add(product);
            }
            return productsList;
        }
    }
}
