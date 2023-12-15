using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;
using FluentAssertions;
using FluentAssertions.Execution;
using Estore.CoreAdditional.Providers;
using Estore.Core.Extensions;
using System.Net;
using Estore.CoreAdditional.Models;
using UITests.TestData;

namespace Estore.UITests.StepDefinitions.Assertions
{
    [Binding]
    public class OrdersStepsAssertions
    {
        private readonly DataContext _context;
        private readonly OrderServiceProvider _orderProvider;

        public OrdersStepsAssertions(DataContext context, OrderServiceProvider orderProvider)
        {
            _context = context;
            _orderProvider = orderProvider;
        }

        [Then(@"Message '(.*)' is presented")]
        public void MessageIsPresented(string message)
        {
            Assert.IsTrue(_context.OrdersPage.IsMessageNotOrdersYetDisplayed(), "Messages are not equal");
        }

        [Then(@"'(.*)' order[s]? are|is displayed on the page")]
        public void OrdersDisplayedOnThePage(int count)
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual(count, _context.OrdersPage.GetOrderNumbers(),
                    $"Order numbers is {_context.OrdersPage.GetOrderNumbers()}, not {count}");
                Assert.AreEqual(count, _context.OrdersPage.GetOrderNumbersFromMessage(),
                    $"Order numbers in message is {_context.OrdersPage.GetOrderNumbersFromMessage()}, not {count}");
            });
        }

        [Then(@"Main orders information match to orders created by the customer")]
        public async Task MainOrdersInformationMatchToCreatedOrders()
        {
            var actualOrderMainInfos = _context.OrdersPage.GetOrderMainInfos();
            var getMyOrdersResponse = await _orderProvider.GetMyOrders(_context.CurrentUserToken)
                .ThrowIfNotTargetStatus(HttpStatusCode.OK);
            var expectedOrderMainInfos = getMyOrdersResponse.Body
                .Join(_context.CreatedOrders.Select(o => o.MainInfo).ToList(),
                    order => order.Id,
                    orderMainInfo => orderMainInfo.OrderId,
                    (order, orderMainInfo) => new OrderMainInfo
                    {
                        OrderId = orderMainInfo.OrderId,
                        CreateTime = DateTime.ParseExact(order.Date.ToString("yy.MM.dd hh:mm"), "yy.MM.dd hh:mm", null),
                        GrandTotal = orderMainInfo.GrandTotal
                    })
                .ToList();

            using (new AssertionScope())
            {
                actualOrderMainInfos
                .Should()
                .BeEquivalentTo(expectedOrderMainInfos,
                    options =>
                    options.WithStrictOrdering());
            }
        }

        [StepDefinition(@"Detailed information for the order number '(.*)' is (expanded|collapsed)")]
        public async Task DetailedInformationForOrderNumberExpands(int orderNumber, string option)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            switch (option)
            {
                case "expanded":
                    Assert.IsTrue(_context.OrdersPage.IsOrderExpanded(orderId),
                        $"Detailed information for the order number '{orderNumber}' is not expanded");
                    break;
                case "collapsed":
                    Assert.IsTrue(_context.OrdersPage.IsOrderCollapsed(orderId),
                        $"Detailed information for the order number '{orderNumber}' is not collapsed");
                    break;
                default:
                    Assert.Fail("Unknown option");
                    break;
            }            
        }

        [Then(@"Date and time for order number '(.*)' are displayed in the '(.*)' format")]
        public void DateAndTimeAreDisplayedInFormat(int orderNumber, string format)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            var createTimeString = _context.OrdersPage.GetCreateTimeStringForOrder(orderId);
            Assert.IsTrue(DateTime.TryParseExact(createTimeString, format, null, System.Globalization.DateTimeStyles.None, out DateTime result),
                "Format date and time of created order is not 'yy.MM.dd hh:mm'");
        }

        [Then(@"Detailed info for the order number '(.*)' matches to detailed info in created order")]
        public void DeteiledOrderInfoMatchesToIfoInCreatedOrder(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            var actualOrderDetailedInfos = _context.OrdersPage.GetOrderDetailedInfos(orderId);
            var expectedOrderDetailedInfos = _context.CreatedOrders
                .Where(o => o.MainInfo.OrderId == orderId)
                .Select(o => o.Items)
                .FirstOrDefault();

            using (new AssertionScope())
            {
                actualOrderDetailedInfos
                    .Should()
                    .BeEquivalentTo(expectedOrderDetailedInfos,
                        options => options
                            .Excluding(info => info.Article)
                            .Excluding(info => info.Name)
                            .Excluding(info => info.Manufactor));
            }
        }

        [Then(@"Image source for order number '(.*)' with '(.*)' is the same as the (added|new added|default) image")]
        public void ImageSourceForOrderWithDisplayedNameIsSameAsAddedOrDefault(int orderNumber, string displayedName, string image)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            string expectedImageSource;
            if (image.Equals("default"))
            {
                expectedImageSource = TestCasesData.DefaultImageSource;
            }
            else if (image.Equals("added") || image.Equals("new added"))
            {
                expectedImageSource = $"data:image/jpg;base64,{Convert.ToBase64String(_context.CurrentProductImage)}";
            }
            else
            {
                throw new ArgumentException("An unknown value is set for the image");
            }
            bool allEqual = _context.OrdersPage.GetImageSource(orderId, displayedName)
                .All(item => item == expectedImageSource);
            Assert.IsTrue(allEqual,$"Actual image sources doesn't match to expected {expectedImageSource}");
        }

        [Then(@"Item[s]? total for order number '(.*)' is correctly calculated")]
        public void ItemsTotalForOrderNumberIsCorrectlyCalculated(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            var detailedOrderInfo = _context.OrdersPage.GetOrderDetailedInfos(orderId);
            var actualItemsTotalPrice = detailedOrderInfo
                .Select(i => i.Total);
            var actualItemsTotalByProductPriceQty = detailedOrderInfo
                .Select(i => i.Price * i.Quantity);
            var expectedItemsTotalPrice = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber]
                .Items
                .Select(i => i.Total);

            using (new AssertionScope())
            {
                actualItemsTotalPrice
                    .Should()
                    .BeEquivalentTo(expectedItemsTotalPrice);
                actualItemsTotalByProductPriceQty
                    .Should()
                    .BeEquivalentTo(expectedItemsTotalPrice);
            }
        }

        [Then(@"Grand total for the order number '(.*)' is correctly calculated")]
        public void GrandTotalForOrderNumberIsCorrectlyCalculated(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            var actualSumItems= _context.OrdersPage.GetOrderDetailedInfos(orderId)
                .Select(i => i.Total)
                .Sum();
            var actualGrandTotal = _context.OrdersPage.GetOrderGrandTotal(orderId);
            var expectedGrandTotal = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.GrandTotal;
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedGrandTotal, actualGrandTotal, $"Grand Total is {actualGrandTotal}, not {expectedGrandTotal}");
                Assert.AreEqual(expectedGrandTotal, actualSumItems, $"Sum of items is {actualGrandTotal}, not {expectedGrandTotal}");
            });            
        }

        [Then(@"Items for order number '(.*)' are sorted by displayed name")]
        public void ItemsForOrderNumberAreSortedByDisplayedName(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            var actualDisplayedNames = _context.OrdersPage.GetOrderDetailedInfos(orderId)
                .Select(i => i.DisplayedName);
            var expectedDisplayedNames = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber]
                .Items
                .Select(i => i.DisplayedName)
                .OrderBy(displayedName => displayedName);

            using (new AssertionScope())
            {
                actualDisplayedNames
                    .Should()
                    .BeEquivalentTo(expectedDisplayedNames,
                        options =>
                        options.WithStrictOrdering());
            }
        }
    }
}
