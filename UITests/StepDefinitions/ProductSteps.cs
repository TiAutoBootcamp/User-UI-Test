using CatalogServiceAPI.Client;
using CatalogServiceAPI.Models.StepsModels;
using CatalogServiceAPI.Providers;
using CatalogServiceAPI.Utils;
using Core.Enums;
using TechTalk.SpecFlow;
using UITests;

namespace UITests.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly DataContext _context;
        private readonly ProductGenerator _productGenerator = new ProductGenerator();
        private readonly CatalogServiceProvider _catalogProvider;
        private readonly Random rnd = new Random();

        public ProductSteps(DataContext context)
        {
            _context = context;
            _context.CatalogServiceClient = new CatalogServiceClient();
            _catalogProvider = new CatalogServiceProvider(_context.CatalogServiceClient, _productGenerator);
        }

        [Given(@"Valid product is created")]
        public async Task GivenValidProductIsCreated()
        {
            var productRequest = _productGenerator.GenerateNewProduct();
            _context.ProductRequest = productRequest;
            await _catalogProvider.CreateProductWithStatusAndPrice(productRequest, ProductStatus.Active, rnd.Next(100, 500));
            _context.ProductArticles.Add(productRequest.Article);
        }

        [Given(@"Valid products are created")]
        [Given(@"Products with diffrent status are created")]
        public async Task GivenProductsWithDiffrentStatusAreCreated(List<ProductModel> products)
        {
            var productRequests = _catalogProvider.CreateProductsList(products);
            _context.ProductRequest = productRequests.First();
            await _catalogProvider.CreateProductWithStatusAndPrice(productRequests, products, rnd.Next(100, 500));
            _context.ProductRequestsAndStatuses
                .AddRange(productRequests
                    .Zip(products, (request, product) => (request, product.ProductStatus))
                    .ToList());
        }
    }
}
