using CoreAdditional.Models;
using Estore.CoreAdditional.Models;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Estore.UITests.StepDefinitions.Base
{
    [Binding]
    public class Transformations
    {
        [StepArgumentTransformation]
        public List<ProductModel> TableToProductsInfo(Table table) =>
              table.CreateSet<ProductModel>().ToList();

        [StepArgumentTransformation]
        public IList<string> TableToListOfString(Table table) =>
            table.Rows.Select(row => row.Values.First().ToString()).ToList();

        [StepArgumentTransformation]
        public IList<OrderInfo> TableToOrderInfo(Table table)
        {
            var orderInfos = new List<OrderInfo>();

            var groupedItems = table.Rows.GroupBy(row => row["N of order"]).OrderBy(group => group.Key);
            
            foreach (var group in groupedItems)
            {
                var orderInfo = new OrderInfo
                {
                    MainInfo = new OrderMainInfo(),
                    Items = new List<OrderItemInfo>()
                };

                foreach (var row in group)
                {
                    int quantity = int.Parse(row["quantity"]);
                    decimal price = decimal.Parse(row["price"]);
                    decimal result = quantity * price;
                    var orderItem = new OrderItemInfo
                    {
                        Name = row["name"],
                        Manufactor = row["manufactor"],
                        DisplayedName = $"{row["manufactor"]} - {row["name"]}",
                        Quantity = int.Parse(row["quantity"]),
                        Price = decimal.Parse(row["price"]),
                        Total = Math.Round(result, 2)
                    };                    
                    orderInfo.Items.Add(orderItem);                    
                }
                orderInfo.MainInfo.GrandTotal = orderInfo.Items.Sum(item => item.Total);
                orderInfos.Add(orderInfo);
            }

            return orderInfos;
        }
    }
}