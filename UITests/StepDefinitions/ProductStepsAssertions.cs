using CatalogServiceAPI.Models.StepsModels;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace UserManagementServiceUITests.StepDefinitions
{
    [Binding]
    public class ProductStepsAssertions
    {
        private readonly DataContext _context;

        public ProductStepsAssertions(DataContext context)
        {
            _context = context;
        }

        [StepDefinition(@"The product with a certain data is displayed on the page")]
        public void ThenTheProductWithACertainDataIsDisplayedOnThePage(List<ProductModel> productsInfo)
        {
                _context.MainPage.WaitAmountOfExpectedProducts(productsInfo.Count);

                var actualNames = _context.MainPage.GetProductNamesText();
                var actualManufactors = _context.MainPage.GetProductManufactorsText();
               
                Assert.Multiple(() =>
                {
                    CollectionAssert.AreEquivalent(actualNames, productsInfo.Select(product => product.Name).ToList());
                    CollectionAssert.AreEquivalent(actualManufactors, productsInfo.Select(product => product.Manufactor).ToList());
                });
        }

        [Then(@"Search button is disabled")]
        public void ThenSearchButtonIsDisabled()
        {
            Assert.IsFalse(_context.MainPage.IsSearchButtonEnabled());
        }


        [Then(@"Info message '([^']*)' is presented")]
        public void ThenInfoMessageIsPresented(string infoMessage)
        {
            Assert.AreEqual(infoMessage,_context.MainPage.GetInfoMessage());
        }

        [Then(@"The order of products on the main page are correct")]
        public void ThenTheOrderOfProductsOnTheMainPageAreCorrect()
        {
            _context.MainPage.WaitAmountOfExpectedProducts(_context.ProductRequestsAndStatuses.Count);
            var expectedList = _context.ProductRequestsAndStatuses.OrderByDescending(status => status.Item2).ThenBy(request => request.Item1.Article);

            var actualNames = _context.MainPage.GetProductNamesText();

            CollectionAssert.AreEqual(actualNames, expectedList.Select(el => el.Item1.Name).ToList());
        }

        [Then(@"Error message '([^']*)' is presented")]
        public void ThenErrorMessageIsPresented(string errorMessage)
        {
            Assert.AreEqual(errorMessage,_context.MainPage.GetErrorMessage());
        }
    }
}
