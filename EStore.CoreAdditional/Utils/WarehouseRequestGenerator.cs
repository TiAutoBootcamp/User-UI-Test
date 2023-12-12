using Estore.Models.Request.Warehouse;

namespace Estore.CoreAdditional.Utils
{
    public class WarehouseRequestGenerator
    {
        public List<AddWarehouseItemInfoRequest> GenerateProductItemsList(Dictionary<string, int> items)
        {
            var productItemsList = new List<AddWarehouseItemInfoRequest>();
            foreach (var item in items)
            {
                for (int i = 0; i < item.Value; i++)
                {
                    productItemsList.Add(
                       new AddWarehouseItemInfoRequest
                       {
                           SerialNumber = Guid.NewGuid().ToString(),
                           ModelArticle = item.Key,
                           CreateTime = DateTime.Now
                       });
                }
            }
            return productItemsList;
        }
    }
}
