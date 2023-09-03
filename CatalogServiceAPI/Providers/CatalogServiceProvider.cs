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

        public async Task CreateActiveProductWithSomePrice(CreateProductRequest request, ProductModel product, double price)
        {
            await _catalogServiceClient.CreateProduct(request);
            await _catalogServiceClient.UpdateProductPrice(request.Article, price);
            await _catalogServiceClient.SetProductStatus(request.Article, (int)product.ProductStatus);
        }

        public async Task CreateActiveProductsWithSomePrice(List<CreateProductRequest> productRequests, List<ProductModel> products, double price)
        {
            for(var i = 0; i < productRequests.Count; i++) 
            {
                await CreateActiveProductWithSomePrice(productRequests[i], products[i], price);
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
