using CatalogServiceAPI.Models.Requests;
using Core.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using UITests;

namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public static async Task OneTimeSetUp(DataContext context)
        {
            context.ProductArticles = new List<string>();
            context.ProductRequestsAndStatuses = new List<(CreateProductRequest, ProductStatus)>();
            var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArgument("headless");
            context.Driver = new ChromeDriver(chromeOptions);
            context.Driver.Manage().Window.Maximize();
            context.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            chromeOptions.PageLoadStrategy = PageLoadStrategy.None;
        }

        [AfterScenario]
        public static async Task TearDown(DataContext context)
        {
            context.Driver.Quit();
        }

        [AfterScenario]
        public static async Task CleanUp(DataContext context)
        {
            if (context.CatalogServiceClient != null)
            {
                foreach (var article in context.ProductArticles)
                {
                    await context.CatalogServiceClient.DeleteProductInfo(article);
                }
                foreach (var element in context.ProductRequestsAndStatuses)
                {
                    await context.CatalogServiceClient.DeleteProductInfo(element.Item1.Article);
                }
            }
        }
    }
}