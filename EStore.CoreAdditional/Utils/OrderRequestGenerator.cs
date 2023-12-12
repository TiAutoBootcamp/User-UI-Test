using Estore.Models.Request.Order;

namespace Estore.CoreAdditional.Utils
{
    public class OrderRequestGenerator
    {
        public CreateOrderRequest GenerateOrderRequest(Dictionary<string, int> items)
        {
            return new CreateOrderRequest
            {
                Items = items.Select(item => new CreateOrderItemRequest
                {
                    Article = item.Key,
                    Count = item.Value
                }).ToList()
            };
        }
    }
}
