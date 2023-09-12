using CatalogServiceAPI.Client;
using CatalogServiceAPI.Models.Requests;
using CatalogServiceAPI.Models.StepsModels;
using CatalogServiceAPI.Utils;
using Core.Enums;

namespace CatalogServiceAPI.Providers
{
    public class CatalogServiceProvider
    {
        private readonly CatalogServiceClient _catalogServiceClient;
        private readonly ProductGenerator _productGenerator;

        public CatalogServiceProvider(CatalogServiceClient client,
           ProductGenerator generator)
        {
            _catalogServiceClient = client;
            _productGenerator = generator;
        }

        public async Task CreateProductWithStatusAndPrice(CreateProductRequest request, ProductStatus status, double price)
        {
            await _catalogServiceClient.CreateProduct(request);
            await _catalogServiceClient.UpdateProductPrice(request.Article, price);
            await _catalogServiceClient.SetProductStatus(request.Article, (int)status);
        }

        public async Task CreateProductWithStatusAndPrice(List<CreateProductRequest> productRequests, List<ProductModel> products, double price)
        {
            for(var i = 0; i < productRequests.Count; i++) 
            {
                await CreateProductWithStatusAndPrice(productRequests[i], products[i].ProductStatus, price);
            }
        }

        public List<CreateProductRequest> CreateProductsList(List<ProductModel> products)
        {
            var productsRequest = new List<CreateProductRequest>();

            foreach(var product in products)
            {
                productsRequest.Add(_productGenerator.GenerateNewProduct(product.Name, product.Manufactor));
            }
            return productsRequest;
        }
    }
}
