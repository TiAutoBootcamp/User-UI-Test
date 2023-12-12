namespace Estore.CoreAdditional.Models
{
    public class OrderInfo
    {
        public OrderMainInfo MainInfo { get; set; }
        public IList<OrderItemInfo> Items { get; set; }
    }
}
