using BusinessLayer.Model;
using DataLayer.IRepository;
using DataLayer.Repositories;

namespace BusinessLayer.Services
{
    public class StatusServices
    {
        private readonly IStatusRepository _repository;
        public StatusServices() 
        {
            _repository = new StatusRepository();
        }

        public List<StatusDTO> GetAllStatus()
        {
            var statusDTO = new List<StatusDTO>();
            var status =  _repository.GetAllStatus();

            foreach (var item in status)
            {
                statusDTO.Add(new StatusDTO
                {
                    StatusId = item.StatusId,
                    Descripcion = item.Descripcion
                });
            }
            return statusDTO;
        }

        public StatusDTO GetStatusById(int id)
        {
            var status = _repository.GetStatusById(id);
            var statusDTO = new StatusDTO
            {
                StatusId = status.StatusId,
                Descripcion = status.Descripcion
            };

            return statusDTO;
        }
    }
}
