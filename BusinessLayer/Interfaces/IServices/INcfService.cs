using BusinessLayer.DTOs;
using System.Runtime.InteropServices;

namespace BusinessLayer.Interfaces.IServices
{
    public interface INcfService
    {
        NcfLotDTO GetFirstAvailableLot(string tipoNCF);
        void UpdateLot(NcfLotDTO lote);
        void AddLot(NcfLotDTO lote);

        NcfLotDTO GetNcfLotDTOById(int id);
    }
}
