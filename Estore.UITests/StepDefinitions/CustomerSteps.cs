using CoreAdditional.Providers;
using CoreAdditional.Utils;
using Estore.Core.Extensions;
using Estore.CoreAdditional.Models;
using Estore.CoreAdditional.Providers;
using Estore.Models.Enum;
using Estore.Models.Request.Catalog;
using System.Net;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class CustomerSteps
    {
        private readonly DataContext _context;
        private readonly UserServiceProvider _userProvider;
        private readonly WalletServiceProvider _walletProvider;
        private readonly CatalogServiceProvider _catalogProvider;
        private readonly WarehouseServiceProvider _warehouseProvider;
        private readonly OrderServiceProvider _orderProvider;
        private readonly TokenManager _tokenManager;

        public CustomerSteps(DataContext context,
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

        [StepDefinition(@"Customer clicks on the Orders button")]
        public void ClickOrdersButtonInTheDropDownList()
        {
            _context.CurrentPage.ClickOrdersButton();
        }

        [StepDefinition(@"Customer has active status")]
        public async Task CustomerHasActiveStatus()
        {
            var token = await _tokenManager.GetValidAdminToken(); 
            await _userProvider.SetUserStatus(_context.CurrentUser.Id.Value, true, token)
                .ThrowIfNotTargetStatus(HttpStatusCode.OK);
        }

        [StepDefinition(@"Customer has enough money '(.*)'")]
        public async Task CustomerHasEnoughMoney(decimal amount)
        {
            var token = await _tokenManager.GetValidAdminToken();
            await _walletProvider.BalanceCharge(_context.CurrentUser.Id.Value, amount, token)
                .ThrowIfNotTargetStatus(HttpStatusCode.OK);
            _context.RegisteredCustomers.Remove(_context.CurrentUser.Id.Value);
        }

        [When(@"Customer creates '(.*)' order[s]? with following item[s]?")]
        public async Task CustomerCreatesOrdersWithFollowingItems(int orderCount, IList<OrderInfo> orders)
        {
            var token = await _tokenManager.GetValidAdminToken();
            foreach (var order in orders)
            {
                var productItems = new Dictionary<string, int>();
                foreach (var item in order.Items)
                {
                    var product = await _catalogProvider.CreateNotActiveProduct(item.Name, item.Manufactor, token);
                    await _catalogProvider.UpdateProductPrice(product.Article, item.Price, token);
                    await _catalogProvider.SetProductStatus(product.Article, ProductStatus.Active, token);
                    productItems.Add(product.Article, item.Quantity);
                }
                await _warehouseProvider.AddProductItems(productItems, token).ThrowIfNotTargetStatus(HttpStatusCode.Created);
                var createOrderResponse = await _orderProvider.CreateNewOrder(productItems, _context.CurrentUserToken)
                    .ThrowIfNotTargetStatus(HttpStatusCode.OK);
                order.MainInfo.OrderId = createOrderResponse.Body.OrderId.Value;                
            }
            _context.CreatedOrders = orders.Reverse().ToList();
        }

        [When(@"Customer clicks on the order number '(.*)'")]
        public async Task CustomerClicksOnTheOrderNumber(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            _context.OrdersPage.ClickOnTheOrderLine(orderId);
        }
    }
}
