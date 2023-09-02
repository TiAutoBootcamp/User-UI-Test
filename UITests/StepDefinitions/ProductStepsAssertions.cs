using CatalogServiceAPI.Models.StepsModels;
using NUnit.Framework;

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


        [Then(@"Error message '([^']*)' is presented")]
        public void ThenErrorMessageIsPresented(string errorMessage)
        {
            // Will be implemented after https://ti-bootcamp.atlassian.net/browse/DS-39
            // Assert.IsTrue(errorMessage.Equals());
        }

    }
}
