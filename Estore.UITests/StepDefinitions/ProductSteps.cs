using CoreAdditional.Models;
using CoreAdditional.Utils;
using CoreAdditional.Providers;
using TechTalk.SpecFlow;
using Estore.Models.Enum;
using UITests.Context;
using Estore.CoreAdditional.Extensions;
using System.Text;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly DataContext _context;
        private readonly CatalogRequestGenerator _productGenerator;
        private readonly CatalogServiceProvider _catalogProvider;
        private readonly TokenManager _tokenManager;
        private readonly Random _rnd = new Random();

        public ProductSteps(DataContext context,
            CatalogServiceProvider catalogProvider,
            CatalogRequestGenerator productGenerator,
            TokenManager tokenManager)
        {
            _context = context;
            _catalogProvider = catalogProvider;
            _productGenerator = productGenerator;
            _tokenManager = tokenManager;
        }

        [Given(@"Valid product is created")]
        public async Task ValidProductIsCreated()
        {
            var adminToken = await _tokenManager.GetValidAdminToken();
            var productRequest = _productGenerator.GenerateNewProduct();
            _context.ProductRequest = productRequest;
            await _catalogProvider.CreateProductWithStatusAndPrice(productRequest, ProductStatus.Active, _rnd.Next(100, 500), adminToken);
            _context.ProductArticles.Add(productRequest.Article);
        }

        [Given(@"Product is created")]
        public async Task ProductIsCreated()
        {
            var adminToken = await _tokenManager.GetValidAdminToken();    
            _context.ProductRequest =  await _catalogProvider.CreateNotActiveProduct(adminToken);
        }

        [Given(@"Valid products are created")]
        [Given(@"Products with diffrent status are created")]
        public async Task ProductsWithDiffrentStatusAreCreated(List<ProductModel> products)
        {
            var adminToken = await _tokenManager.GetValidAdminToken();
            var productRequests = _catalogProvider.CreateProductsList(products);
            _context.ProductRequest = productRequests.First();
            await _catalogProvider.CreateProductWithStatusAndPrice(productRequests, products, _rnd.Next(100, 500), adminToken);
            _context.ProductRequestsAndStatuses
                .AddRange(productRequests
                    .Zip(products, (request, product) => (request, product.ProductStatus))
                    .ToList());
        }

        [When(@"Created product is displayed")]
        public void CreatedProductIsDisplayed()
        {
            if (!_context.MainPage.IsProductDisplayed(_context.ProductRequest))
            {
                throw new Exception("Created product is not displayed");
            }
        }

        [Given(@"Image is added to the created product: '(.*)'")]
        [Given(@"New image is added to the created product: '(.*)'")]
        public async Task ImageIsAddedToTheCreatedProduct(string filePath)
        {
            var adminToken = await _tokenManager.GetValidAdminToken();
            await _catalogProvider.AddImage(_context.ProductRequest.Article, filePath, adminToken);
            _context.CurrentProductImage = FileExtension.GetByteArray(filePath);
        }
    }
}
