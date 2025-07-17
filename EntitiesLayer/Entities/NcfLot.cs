namespace DomainLayer.Entities
{
    public class NcfLot
    {
        public int Id { get; set; }
        public string TipoNCF { get; set; } // Ejemplo: B01
        public string PrefijoNCF { get; set; } // Prefijo de NCF
        public int SecuenciaInicio { get; set; }
        public int SecuenciaFin { get; set; }
        public int SecuenciaActual { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Disponible { get; set; } = true;
    }
}
