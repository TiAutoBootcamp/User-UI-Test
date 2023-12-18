using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.CoreAdditional.Utils;

namespace Estore.CoreAdditional.Providers
{
    public class WarehouseServiceProvider
    {
        private readonly WarehouseClient _warehouseClient;
        private readonly WarehouseRequestGenerator _warehouseGenerator;

        public WarehouseServiceProvider(WarehouseClient client,
           WarehouseRequestGenerator generator)
        {
            _warehouseClient = client;
            _warehouseGenerator = generator;
        }

        public async Task<CommonResponse<EmptyModel>> AddProductItems(Dictionary<string, int> items, string token)
        {
            var request = _warehouseGenerator.GenerateProductItemsList(items);
            var response = await _warehouseClient.Add(request, token);
            
            return response;
        }
    }
}