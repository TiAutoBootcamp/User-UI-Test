﻿using CatalogServiceAPI.Models.StepsModels;
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

        [StepDefinition(@"Products with a certain data are displayed on the page")]
        [StepDefinition(@"The product with a certain data is displayed on the page")]
        public void ThenProductsWithACertainDataAreDisplayedOnThePage(List<ProductModel> productsInfo)
        {
            // _context.MainPage.WaitAmountOfExpectedProducts(productsInfo.Count);

            _context.MainPage.WaitPageLoading();
            var actualNames = _context.MainPage.GetProductNamesText();
            var actualManufactors = _context.MainPage.GetProductManufactorsText();

            Assert.Multiple(() =>
            {
                CollectionAssert.IsSubsetOf(productsInfo.Select(product => product.Name).ToList(), actualNames);
                CollectionAssert.IsSubsetOf(productsInfo.Select(product => product.Manufactor).ToList(), actualManufactors);
            });
        }

        [Then(@"One created product is existed others not")]
        [Then(@"Some created product are existed one not")]
        public void ThenCreatedProductExistSomeNot(List<ProductModel> productsInfo)
        {
            _context.MainPage.WaitPageLoading();
            var actualNames = _context.MainPage.GetProductNamesText();
            var actualManufactors = _context.MainPage.GetProductManufactorsText();

            Assert.Multiple(() =>
            {
                CollectionAssert.IsSubsetOf(productsInfo.Where(el => el.isPresented.Equals(true))
                    .Select(product => product.Name)
                    .ToList(), actualNames);
                CollectionAssert.IsSubsetOf(productsInfo
                    .Where(el => el.isPresented.Equals(true))
                    .Select(product => product.Manufactor)
                    .ToList(), actualManufactors);
                CollectionAssert.IsNotSubsetOf(productsInfo
                    .Where(el => el.isPresented.Equals(false))
                    .Select(product => product.Name)
                    .ToList(), actualNames);
                CollectionAssert.IsNotSubsetOf(productsInfo
                    .Where(el => el.isPresented.Equals(false))
                    .Select(product => product.Manufactor)
                    .ToList(), actualManufactors);
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
            Assert.AreEqual(infoMessage, _context.MainPage.GetInfoMessage());
        }

        [Then(@"The order of products on the main page are correct")]
        public void ThenTheOrderOfProductsOnTheMainPageAreCorrect()
        {
            //_context.MainPage.WaitAmountOfExpectedProducts(_context.ProductRequestsAndStatuses.Count);
            _context.MainPage.WaitPageLoading();
            var expectedList = _context.ProductRequestsAndStatuses.OrderByDescending(status => status.Item2).ThenBy(request => request.Item1.Article);

            var actualNames = _context.MainPage.GetProductNamesText();

            CollectionAssert.AreEqual(actualNames, expectedList.Select(el => el.Item1.Name).ToList());
        }

        [Then(@"Error message '([^']*)' is presented")]
        public void ThenErrorMessageIsPresented(string errorMessage)
        {
            Assert.AreEqual(errorMessage, _context.MainPage.GetErrorMessage());
        }
    }
}
