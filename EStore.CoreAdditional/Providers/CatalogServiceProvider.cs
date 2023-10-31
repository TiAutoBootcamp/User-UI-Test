using CoreAdditional.Models;
using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Estore.Models.Enum;
using Estore.Models.Request.Catalog;

namespace CoreAdditional.Providers
{
    public class CatalogServiceProvider
    {
        private readonly CatalogClient _catalogServiceClient;
        private readonly CatalogRequestGenerator _catalogGenerator;
        
        public CatalogServiceProvider(CatalogClient client,
           CatalogRequestGenerator catalogGenerator)
        {
            _catalogServiceClient = client;
            _catalogGenerator = catalogGenerator;
        }

        public async Task CreateProductWithStatusAndPrice(AddProductRequest request, ProductStatus status, decimal price, 
            string? token = null)
        {
            await _catalogServiceClient.CreateProduct(request, token);
            await _catalogServiceClient.UpdateProductPrice(request.Article, price, token);
            await _catalogServiceClient.SetProductStatus(request.Article, status, token);
        }

        public async Task CreateProductWithStatusAndPrice(List<AddProductRequest> productRequests, 
            List<ProductModel> products, decimal price, string? token = null)
        {
            for (var i = 0; i < productRequests.Count; i++)
            {
                await CreateProductWithStatusAndPrice(productRequests[i], products[i].ProductStatus, price, token);
            }
        }

        public List<AddProductRequest> CreateProductsList(List<ProductModel> products)
        {
            var productsRequest = new List<AddProductRequest>();

            foreach (var product in products)
            {
                productsRequest.Add(_catalogGenerator.GenerateNewProduct(product.Name, product.Manufactor));
            }
            return productsRequest;
        }
    }
}