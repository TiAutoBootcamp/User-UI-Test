using Estore.CoreAdditional.Models;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Globalization;
using UITests.Pages;

namespace Estore.UITests.Pages
{
    public class OrdersPage : BasePage
    {
        
        [FindsBy(How = How.XPath, Using = "//div[@class='mud-expand-panel-header']/parent::div")]
        private IList<IWebElement> _orderRows;

        [FindsBy(How = How.Id, Using = "no_orders_yet_message")]
        private IWebElement _notOrdersMessage;

        [FindsBy(How = How.CssSelector, Using = "p b")]
        private IWebElement _orderNumbersMessage;
        
        private By _orderItemRows = By.CssSelector("div[style='height:auto;'] div.mud-grid");
        private By _orderId = By.Id("order_id_value");
        private By _createTime = By.Id("create_time_value");
        private By _grandTotalValue = By.Id("grand_total_value");
        private By _productImage = By.Id("product_image");
        private By _displayedName = By.Id("name_value");
        private By _productPrice = By.Id("price_value");
        private By _quantity = By.Id("qty_value");
        private By _totalPrice = By.Id("total_value");
        private By _expandPanel = By.CssSelector("div[style='height:auto;']");
        private By _collapsedPanel = By.CssSelector("div[style='']");

        public OrdersPage(IWebDriver driver) : base(driver)
        {
            Title = "Estore - Orders history";
            Wait.Until(d => d.Title == Title);
        }

        public bool IsMessageNotOrdersYetDisplayed()
        {
            return Wait.Until((_) => _notOrdersMessage.Displayed);
        }

        public string GetNotOrdersMessage()
        {
            return _notOrdersMessage.Text;
        }

        public int GetOrderNumbers()
        {
            return _orderRows.Count;
        }

        public int GetOrderNumbersFromMessage()
        {
            var message = _orderNumbersMessage.Text;
            return int.Parse(message.Split(" ").First());
        }

        public IList<OrderMainInfo> GetOrderMainInfos()
        {
            var orderMainInfos = new List<OrderMainInfo>();
            foreach (var orderRow in _orderRows)
            {
                var orderId = Guid.Parse(orderRow.FindElement(_orderId).Text);
                var createTime = DateTime.ParseExact(orderRow.FindElement(_createTime).Text, "yy.MM.dd hh:mm", CultureInfo.InvariantCulture);
                var grandTotalValue = decimal.Parse(orderRow.FindElement(_grandTotalValue).Text.Split(" ").Last());

                var orderMainInfo = new OrderMainInfo
                {
                    OrderId = orderId,
                    CreateTime = createTime,
                    GrandTotal = grandTotalValue
                };

                orderMainInfos.Add(orderMainInfo);
            }
            return orderMainInfos;
        }

        public string GetCreateTimeStringForOrder(Guid orderId)
        {
            var orderRow = FindOrderRowByOrderId(orderId);
            return orderRow.FindElement(_createTime).Text;
        }

        public decimal GetOrderGrandTotal(Guid orderId)
        {
            var orderRow = FindOrderRowByOrderId(orderId);
            return decimal.Parse(orderRow.FindElement(_grandTotalValue).Text.Split(" ").Last());
        }

        public void ClickOnTheOrderLine(Guid orderId)
        {            
            var orderElement = FindOrderRowByOrderId(orderId).FindElement(_orderId);
            orderElement.Click();
        }

        public bool IsOrderExpanded(Guid orderId)
        {
            var orderRow = FindOrderRowByOrderId(orderId);
            return Wait.Until(driver => orderRow.FindElement(_expandPanel).Displayed);
        }

        public bool IsOrderCollapsed(Guid orderId)
        {
            var orderRow = FindOrderRowByOrderId(orderId);
            return Wait.Until(driver => !orderRow.FindElement(_collapsedPanel).Displayed);
        }

        public List<OrderItemInfo> GetOrderDetailedInfos(Guid orderId)
        {
            var orderRow = FindOrderRowByOrderId(orderId);
            var orderItems = orderRow.FindElements(_orderItemRows);
            var orderItemsInfo = new List<OrderItemInfo>();
            foreach (var itemRow in orderItems)
            {
                var displayedName = itemRow.FindElement(_displayedName).Text;
                var quantity = int.Parse(itemRow.FindElement(_quantity).Text);
                var price = decimal.Parse(itemRow.FindElement(_productPrice).Text.Split(" ").Last());
                var total = decimal.Parse(itemRow.FindElement(_totalPrice).Text.Split(" ").Last());

                var orderItemInfo = new OrderItemInfo
                {
                    DisplayedName = displayedName,
                    Quantity = quantity,
                    Price = price,
                    Total = total,
                };

                orderItemsInfo.Add(orderItemInfo);
            }
            return orderItemsInfo;
        }

        public List<string> GetImageSource(Guid orderId, string displayedName)
        {
            var orderRow = FindOrderRowByOrderId(orderId);

            return orderRow
                .FindElements(_orderItemRows)
                .Where(row => row.FindElements(_displayedName)
                    .Any(displayedNameElement => displayedNameElement.Text.Contains(displayedName)))
                .Select(i => i
                    .FindElement(_productImage)
                    .GetAttribute("src"))
                .ToList();                                 
        }

        private IWebElement FindOrderRowByOrderId(Guid orderId)
        {
            return _orderRows
                .Where(row => row
                    .FindElement(_orderId)
                    .Text.Contains(orderId.ToString()))
                .Single();
        }
    }
}