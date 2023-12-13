using NUnit.Framework;
using TechTalk.SpecFlow;
using UITests.Context;
using FluentAssertions;
using FluentAssertions.Execution;
using Estore.CoreAdditional.Providers;
using OpenQA.Selenium;
using Estore.Core.Extensions;
using System.Net;
using Estore.CoreAdditional.Models;
using Estore.Models.Response.Order;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

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
                    $"Order numbers is {_context.OrdersPage.GetOrderNumbers}, {count}");
                Assert.AreEqual(count, _context.OrdersPage.GetOrderNumbersFromMessage());
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
                    Assert.IsTrue(_context.OrdersPage.IsOrderExpanded(orderId));
                    break;
                case "collapsed":
                    Assert.IsTrue(_context.OrdersPage.IsOrderCollapsed(orderId));
                    break;
                default:
                    Assert.Fail("Unknown option");
                    break;
            }
            
        }   
    }
}
