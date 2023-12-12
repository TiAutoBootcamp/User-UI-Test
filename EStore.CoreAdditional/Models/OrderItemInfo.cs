namespace Estore.CoreAdditional.Models
{
    public class OrderItemInfo
    {
        public string DisplayedName { get; set; }
        public string Name { get; set; }
        public string Manufactor { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
