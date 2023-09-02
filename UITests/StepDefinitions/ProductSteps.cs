using CatalogServiceAPI.Client;
using CatalogServiceAPI.Models.StepsModels;
using CatalogServiceAPI.Providers;
using CatalogServiceAPI.Utils;


namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public class ProductSteps
    {
        private readonly DataContext _context;
        private readonly ProductGenerator _productGenerator = new ProductGenerator();
        private readonly CatalogServiceProvider _catalogProvider;

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
            await _catalogProvider.CreateActiveProductWithSomePrice(productRequest, 950);
            _context.ProductArticles.Add(productRequest.Article);
        }

        [Given(@"Valid products are created")]
        public async Task GivenValidProductsAreCreated(List<ProductModel> products)
        {
            Random rnd = new Random();
            var productRequest = _catalogProvider.CreateProductsList(products);
            _context.ProductRequest = productRequest.First();
            await _catalogProvider.CreateActiveProductsWithSomePrice(productRequest, rnd.Next(100, 500));
            _context.ProductArticles.AddRange(productRequest.Select(product => product.Article));
        }


    }
}
