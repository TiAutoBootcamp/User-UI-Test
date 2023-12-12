namespace Estore.CoreAdditional.Models
{
    public class OrderMainInfo
    {
        public Guid OrderId { get; set; }
        public DateTime CreateTime { get; set; }
        public decimal GrandTotal { get; set; }
    }
}
