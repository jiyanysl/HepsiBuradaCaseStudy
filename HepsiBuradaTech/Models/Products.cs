namespace HepsiBuradaTech.Models
{
    public class Products : BaseEntity
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
