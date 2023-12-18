namespace Estore.CoreAdditional.Models
{
    public class OrderInfo
    {
        public OrderMainInfo MainInfo { get; set; }
        public List<OrderItemInfo> Items { get; set; }
    }
}
