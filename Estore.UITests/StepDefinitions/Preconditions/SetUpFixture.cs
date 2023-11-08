using CoreAdditional.Modules;
using Estore.Models.Enum;
using Estore.Models.Request.Catalog;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using Autofac;
using SpecFlow.Autofac;
using UITests.Modules;
using UITests.Context;
using Estore.Clients.Clients;
using CoreAdditional.Providers;

namespace Estore.UITests.StepDefinitions.Preconditions
{
    [Binding]
    public sealed class SetUpFixture
    {
        [ScenarioDependencies]
        public static ContainerBuilder ScenarioDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CoreAdditionalDependencyModule>();
            builder.RegisterModule<TestDependencyModule>();
            return builder;
        }

        [BeforeScenario(Order = 0)]
        public static async Task OneTimeSetUp(DataContext context)
        {
            context.ProductArticles = new List<string>();
            context.RegisteredCustomers = new List<int>();
            context.ProductRequestsAndStatuses = new List<(AddProductRequest, ProductStatus)>();
            var chromeOptions = new ChromeOptions();
           // chromeOptions.AddArgument("headless");
            context.Driver = new ChromeDriver(chromeOptions);
            context.Driver.Manage().Window.Maximize();
            context.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
        }

        [AfterScenario]
        public static async Task TearDown(DataContext context)
        {
            context.Driver.Quit();
        }

        [AfterScenario]
        public static async Task CleanUp(DataContext context,
            CatalogClient catalogClient, 
            UserServiceProvider userProvider,
            TokenManager tokenManager)
        {
            var adminToken = await tokenManager.GetValidAdminToken();
            if (context.ProductArticles != null)
            {
                foreach (var article in context.ProductArticles)
                {
                    await catalogClient.DeleteProduct(article, adminToken);
                }
            }
            if (context.ProductRequestsAndStatuses != null)
            {
                foreach (var element in context.ProductRequestsAndStatuses)
                {
                    await catalogClient.DeleteProduct(element.Item1.Article, adminToken);
                }
            }
            if (context.RegisteredCustomers != null)
            {
                foreach (var userId in context.RegisteredCustomers)
                {
                    await userProvider.DeleteExistUser(userId, adminToken);
                }
            }
        }
    }
}