using Estore.Models.Request.Warehouse;

namespace Estore.CoreAdditional.Utils
{
    public class WarehouseRequestGenerator
    {
        public List<AddWarehouseItemInfoRequest> GenerateProductItemsList(Dictionary<string, int> items)
        {
            return items
                .SelectMany(item => Enumerable.Range(0, item.Value)
                .Select(_ => new AddWarehouseItemInfoRequest
                {
                    SerialNumber = Guid.NewGuid().ToString(),
                    ModelArticle = item.Key,
                    CreateTime = DateTime.UtcNow
                }))
                .ToList();
        }
    }
}