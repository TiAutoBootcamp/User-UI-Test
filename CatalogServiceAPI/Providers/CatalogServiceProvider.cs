using CatalogServiceAPI.Client;
using CatalogServiceAPI.Models.Requests;
using CatalogServiceAPI.Models.StepsModels;
using CatalogServiceAPI.Utils;
using System.Timers;

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

        public async Task CreateActiveProductWithSomePrice(CreateProductRequest request, double price)
        {
            await _catalogServiceClient.CreateProduct(request);
            await _catalogServiceClient.UpdateProductPrice(request.Article, price);
            await _catalogServiceClient.SetProductStatus(request.Article, 1);
        }

        public async Task CreateActiveProductsWithSomePrice(List<CreateProductRequest> products, double price)
        {
            foreach (var product in products)
            {
                await CreateActiveProductWithSomePrice(product, price);
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
