using DomainLayer.Entities;

namespace DataLayer.IRepository
{
    public interface INcfRepository
    {
        NcfLot GetFirstAvailableLot(string tipoNCF);
        void UpdateLot(NcfLot lote);
        void AddLot(NcfLot lote);
        NcfLot GetNcfLotDTOById(int id);
    }
}
