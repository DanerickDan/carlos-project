using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Utils
{
    public class ClientCodeGenerator
    {
        private readonly IClientRepository _clientRepository;

        public ClientCodeGenerator()
        {
            _clientRepository = new ClientRepository();
        }

        public string ClientCode()
        {
            int newCode;
            bool isUnique = false;

            do
            {
                newCode = new Random().Next(1000, 9999) ;
                isUnique = _clientRepository.ExistCode(newCode,"codigo") ;
            } while (!isUnique);
            return newCode.ToString();
        }
    }
}
