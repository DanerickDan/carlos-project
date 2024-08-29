namespace BusinessLayer.Model
{
    public class ProductsDTO
    {
        public int ProductsId { get; set; }
        public string ProductName { get; set; }
        public string Code { get; set; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double Price { get; set; }
        public int Lote { get; set; }
        public double ProductNeto { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
