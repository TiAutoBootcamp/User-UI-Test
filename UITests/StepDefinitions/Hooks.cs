using CoreAdditional.Modules;
using Estore.Models.Enum;
using Estore.Models.Request.Catalog;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Autofac;
using SpecFlow.Autofac;


namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        [ScenarioDependencies]
        public static ContainerBuilder ScenarioDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<TestDependencyModule>();
            return builder;
        }

        [BeforeScenario]
        public static async Task OneTimeSetUp(DataContext context)
        {
            var container = ScenarioDependencies().Build();
            context.ProductArticles = new List<string>();
            context.ProductRequestsAndStatuses = new List<(AddProductRequest, ProductStatus)>();
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            context.Driver = new ChromeDriver(chromeOptions);
            context.Driver.Manage().Window.Maximize();
            context.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
                    await context.CatalogServiceClient.DeleteProduct(article);
                }
                foreach (var element in context.ProductRequestsAndStatuses)
                {
                    await context.CatalogServiceClient.DeleteProduct(element.Item1.Article);
                }
            }
        }
    }
}