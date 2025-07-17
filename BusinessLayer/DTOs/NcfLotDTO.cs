namespace BusinessLayer.DTOs
{
    public class NcfLotDTO
    {
        public int Id { get; set; }
        public string TipoNCF { get; set; } // Ejemplo: B01, B02, etc.
        public string PrefijoNCF { get; set; } // Ej: B0100000001
        public int SecuenciaInicio { get; set; }
        public int SecuenciaFin { get; set; }
        public int SecuenciaActual { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Disponible { get; set; }
    }
}
