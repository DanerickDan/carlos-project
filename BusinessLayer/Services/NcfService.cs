using BusinessLayer.DTOs;
using BusinessLayer.Interfaces.IServices;
using DataLayer.IRepository;
using DataLayer.Repositories;
using DomainLayer.Entities;
using System;

namespace BusinessLayer.Services
{
    public class NcfService : INcfService
    {
        private readonly INcfRepository _ncfRepository;

        public NcfService()
        {
            _ncfRepository = new NcfRepository();
        }

        public NcfLotDTO GetFirstAvailableLot(string tipoNCF)
        {
            var lot = _ncfRepository.GetFirstAvailableLot(tipoNCF);

            if (lot == null)
                throw new Exception("No hay lotes disponibles para el tipo NCF: " + tipoNCF);

            // Validar que la secuencia actual esté dentro del rango
            if (string.Compare(lot.SecuenciaActual.ToString("D8"), lot.SecuenciaFin.ToString()) > 0)
                throw new Exception("La secuencia del NCF ha llegado a su límite.");

            if (DateTime.Now > lot.FechaExpiracion)
                throw new Exception("Este lote de NCF ha expirado.");
            var ncfLotDto = new NcfLotDTO()
            {
                Id = lot.Id,
                TipoNCF = lot.TipoNCF,
                PrefijoNCF = lot.PrefijoNCF,
                SecuenciaActual = lot.SecuenciaActual,
                SecuenciaInicio = lot.SecuenciaInicio,
                SecuenciaFin = lot.SecuenciaFin,
                FechaExpiracion = lot.FechaExpiracion,
                Disponible = lot.Disponible,
            };
            return ncfLotDto;
        }

        public void UpdateLot(NcfLotDTO lote)
        {
            // Avanza la secuencia
            string nuevaSecuencia = IncrementarSecuencia(lote.SecuenciaActual.ToString("D8")); 

            // Verifica si se alcanzó el final del lote
            bool disponible = string.Compare(nuevaSecuencia, lote.SecuenciaFin.ToString("D8")) <= 0;

            lote.SecuenciaActual = Convert.ToInt32(nuevaSecuencia);
            lote.Disponible = disponible;

            var ncfLot = new NcfLot()
            {
                Id = lote.Id,
                TipoNCF = lote.TipoNCF,
                PrefijoNCF = lote.PrefijoNCF,
                SecuenciaActual = lote.SecuenciaActual,
                SecuenciaInicio = lote.SecuenciaInicio,
                SecuenciaFin = lote.SecuenciaFin,
                FechaExpiracion = lote.FechaExpiracion,
                Disponible = lote.Disponible,
            };

            _ncfRepository.UpdateLot(ncfLot);
        }

        public void AddLot(NcfLotDTO lote)
        {
            // Validaciones básicas
            if (string.Compare(lote.SecuenciaInicio.ToString("D8"), lote.SecuenciaFin.ToString("D8")) > 0)
                throw new ArgumentException("La secuencia inicial no puede ser mayor que la final.");

            lote.SecuenciaActual = lote.SecuenciaInicio;
            lote.Disponible = true;

            var ncfLot = new NcfLot()
            {
                Id = lote.Id,
                TipoNCF = lote.TipoNCF,
                PrefijoNCF = lote.PrefijoNCF,
                SecuenciaActual = lote.SecuenciaActual,
                SecuenciaInicio = lote.SecuenciaInicio,
                SecuenciaFin = lote.SecuenciaFin,
                FechaExpiracion = lote.FechaExpiracion,
                Disponible = lote.Disponible,
            };

            _ncfRepository.AddLot(ncfLot);
        }

        public NcfLotDTO GetNcfLotDTOById(int id)
        {
            var lot = _ncfRepository.GetNcfLotDTOById(id);
            if (lot == null)
                return null;

            return new NcfLotDTO
            {
                Id = lot.Id,
                TipoNCF = lot.TipoNCF,
                PrefijoNCF = lot.PrefijoNCF,
                SecuenciaInicio = lot.SecuenciaInicio,
                SecuenciaFin = lot.SecuenciaFin,
                SecuenciaActual = lot.SecuenciaActual,
                FechaExpiracion = lot.FechaExpiracion,
                Disponible = lot.Disponible
            };
        }


        // Incrementador de secuencia alfanumérica del NCF
        private string IncrementarSecuencia(string actual)
        {
            // Ej: B0100000001 → B0100000002
            string letras = actual.Substring(0, 3);
            string numeros = actual.Substring(3);

            if (!long.TryParse(numeros, out long numeroSecuencia))
                throw new Exception("Error al procesar la secuencia del NCF.");

            numeroSecuencia++;
            return letras + numeroSecuencia.ToString(new string('0', numeros.Length));
        }

    }
}
