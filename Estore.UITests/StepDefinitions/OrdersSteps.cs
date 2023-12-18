using CoreAdditional.Providers;
using Estore.CoreAdditional.Models;
using Estore.CoreAdditional.Providers;
using Estore.Models.Enum;
using System.Net;
using TechTalk.SpecFlow;
using UITests.Context;
using Estore.Core.Extensions;
using Estore.CoreAdditional.Extensions;
using UITests.TestData;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public class OrdersSteps
    {
        private readonly DataContext _context;
        private readonly CatalogServiceProvider _catalogProvider;
        private readonly WarehouseServiceProvider _warehouseProvider;
        private readonly OrderServiceProvider _orderProvider;
        private readonly TokenManager _tokenManager;

        public OrdersSteps(DataContext context,
            CatalogServiceProvider catalogProvider,
            WarehouseServiceProvider warehouseProvider,
            OrderServiceProvider orderProvider,
            TokenManager tokenManager)
        {
            _context = context;
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
                    item.Article = product.Article;
                    productItems.Add(product.Article, item.Quantity);
                }
                await _warehouseProvider.AddProductItems(productItems, token).ThrowIfNotTargetStatus(HttpStatusCode.Created);
                var createOrderResponse = await _orderProvider.CreateNewOrder(productItems, _context.CurrentUserToken)
                    .ThrowIfNotTargetStatus(HttpStatusCode.OK);
                order.MainInfo.OrderId = createOrderResponse.Body.OrderId.Value;
            }
            _context.CreatedOrders = orders.Reverse().ToList();
        }

        [When(@"Add valid image to the created product with '(.*)' and '(.*)' in order '(.*)'")]
        public async Task AdImageToCreatedProductWithNameAndManufactorInOrder(string name, string manufactor, int orderNumber)
        {
            var articles = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber]
                .Items
                .Where(i => i.Name == name && i.Manufactor == manufactor)
                .Select(i => i.Article);
            var adminToken = await _tokenManager.GetValidAdminToken();
            foreach (var article in articles)
            {
                await _catalogProvider.AddImage(article, TestCasesData.ValidImageFilePath, adminToken)
                    .ThrowIfNotTargetStatus(HttpStatusCode.Created);
            }            
            _context.CurrentProductImage = FileExtension.GetByteArray(TestCasesData.ValidImageFilePath);
        }
    }
}