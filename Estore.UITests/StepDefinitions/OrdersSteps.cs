using CoreAdditional.Providers;
using Estore.CoreAdditional.Models;
using Estore.CoreAdditional.Providers;
using Estore.Models.Enum;
using System.Net;
using TechTalk.SpecFlow;
using UITests.Context;
using Estore.Core.Extensions;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public class OrdersSteps
    {
        private readonly DataContext _context;
        private readonly UserServiceProvider _userProvider;
        private readonly WalletServiceProvider _walletProvider;
        private readonly CatalogServiceProvider _catalogProvider;
        private readonly WarehouseServiceProvider _warehouseProvider;
        private readonly OrderServiceProvider _orderProvider;
        private readonly TokenManager _tokenManager;

        public OrdersSteps(DataContext context,
            UserServiceProvider userProvider,
            WalletServiceProvider walletProvider,
            CatalogServiceProvider catalogProvider,
            WarehouseServiceProvider warehouseProvider,
            OrderServiceProvider orderProvider,
            TokenManager tokenManager)
        {
            _context = context;
            _userProvider = userProvider;
            _walletProvider = walletProvider;
            _catalogProvider = catalogProvider;
            _warehouseProvider = warehouseProvider;
            _orderProvider = orderProvider;
            _tokenManager = tokenManager;
        }

        [When(@"Create order[s]? with following item[s]?")]
        public async Task CustomerCreatesOrdersWithFollowingItems(IList<OrderInfo> orders)
        {
            var token = await _tokenManager.GetValidAdminToken();
            foreach (var order in orders)
            {
                var productItems = new Dictionary<string, int>();
                foreach (var item in order.Items)
                {
                    var product = await _catalogProvider.CreateNotActiveProduct(item.Name, item.Manufactor, token);
                    await _catalogProvider.UpdateProductPrice(product.Article, item.Price, token);
                    await _catalogProvider.SetProductStatus(product.Article, ProductStatus.Active, token).ThrowIfNotTargetStatus(HttpStatusCode.OK);
                    productItems.Add(product.Article, item.Quantity);
                }
                await _warehouseProvider.AddProductItems(productItems, token).ThrowIfNotTargetStatus(HttpStatusCode.Created);
                var createOrderResponse = await _orderProvider.CreateNewOrder(productItems, _context.CurrentUserToken)
                    .ThrowIfNotTargetStatus(HttpStatusCode.OK);
                order.MainInfo.OrderId = createOrderResponse.Body.OrderId.Value;
            }
            _context.CreatedOrders = orders.Reverse().ToList();
        }
    }
}
