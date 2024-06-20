using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface IStatusRepository
    {
        List<Status> GetAllStatus();
        Status GetStatusById(int id);
    }
}
