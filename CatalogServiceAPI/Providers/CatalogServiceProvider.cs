using CatalogServiceAPI.Client;
using CatalogServiceAPI.Models.Requests;
using CatalogServiceAPI.Utils;


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
                var request = _productGenerator.GenerateNewProduct(product.Article);
                await CreateActiveProductWithSomePrice(request, price);
            }
        }

        public List<CreateProductRequest> CreateProductsList(int itemsCount)
        {
            var products = new List<CreateProductRequest>();
            for (int i = 0; i < itemsCount; i++)
            {
                products.Add(_productGenerator.GenerateNewProduct());
            }
            return products;
        }
    }
}
