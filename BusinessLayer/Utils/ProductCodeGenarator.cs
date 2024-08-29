using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Utils
{
    public class ProductCodeGenarator
    {
        private readonly IProductsRepository _productsRepository;
        private readonly SuffixGenerator _suffixGenerator;

        public ProductCodeGenarator() 
        {
            _suffixGenerator = new SuffixGenerator();
            _productsRepository = new ProductsRepository();
        }

        public string GenerateProductCode()
        {
            string newCode;
            bool isUnique = false;

            do
            {
                newCode = _suffixGenerator.GenerarSufijoAleatorio(2) + new Random().Next(1000, 9999);
                isUnique = _productsRepository.ExistCode(newCode, "codigo");
            } while (!isUnique);
            return newCode;
        }

        public string GenerateLoteCode()
        {
            string newCode;
            bool isUnique = false;

            do
            {
                newCode = new Random().Next(1000, 9999).ToString();
                isUnique = _productsRepository.ExistCode(newCode,"lote");
            } while (!isUnique);

            return newCode;
        }
    }
}
