namespace DomainLayer.Entities
{
    public class PrintView 
    {
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public string InvoiceDescription { get; set; }
        public int CodigoCliente { get; set; }
        public string ClienteDireccion { get; set; }
        public string ClienteCiudad { get; set; }
        public string ClienteTelefono { get; set; }
        public string ClienteRNC { get; set; }
        public string Vendedor { get; set; }
        public string NCF { get; set; }
        public string Terminos { get; set; }
        public int NumeroPedido { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public double SubTotal { get; set; }
        public double Total { get; set; }
        public int CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public int LoteProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Neto { get; set; }
        public List<Products> products { get; set; } = new List<Products>();
    }
}
