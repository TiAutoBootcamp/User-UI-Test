using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.CoreAdditional.Utils;
using Estore.Models.Response.Order;

namespace Estore.CoreAdditional.Providers
{
    public class OrderServiceProvider
    {
        private readonly OrderClient _orderClient;
        private readonly OrderRequestGenerator _orderGenerator;

        public OrderServiceProvider(OrderClient client,
           OrderRequestGenerator generator)
        {
            _orderClient = client;
            _orderGenerator = generator;
        }

        public async Task<CommonResponse<CreateOrderResponse>> CreateNewOrder(Dictionary<string, int> orderItems, string customerToken)
        {
            var request = _orderGenerator.GenerateOrderRequest(orderItems);
            return await _orderClient.CreateOrder(request, customerToken);
        }

        public async Task<CommonResponse<IEnumerable<Order>>> GetMyOrders(string customerToken = null)
        {
            return await _orderClient.GetMyOrders(customerToken);
        }
    }
}