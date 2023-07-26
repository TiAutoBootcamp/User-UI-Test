using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Concurrent;
using TechTalk.SpecFlow;
using UserServiceAPI.Client;
using UserUITest.Pages;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public static async Task OneTimeSetUp(DataContext context)
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("headless");
            context.Driver = new ChromeDriver(chromeOptions);
            context.Driver.Manage().Window.Maximize();
            context.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

        }

        [AfterScenario]
        public static async Task TearDown(DataContext context)
        {
            context.Driver.Quit();
        }

    //  [OneTimeTearDown]
    //  public async Task OneTimeTearDown()
    //  {
    //
    //      var client = new UserServiceClient();
    //      var tasks = TestDataStorage
    //          .GetAllIds()
    //          .Select(id => client.DeleteUser(id));
    //
    //      await Task.WhenAll(tasks);
    //  }
    //
    //  public static class TestDataStorage
    //  {
    //      private static readonly ConcurrentBag<int> _storage = new ConcurrentBag<int>();
    //      public static void Add(int id)
    //      {
    //          _storage.Add(id);
    //      }
    //      public static IEnumerable<int> GetAllIds()
    //      {
    //
    //          return _storage.ToArray();
    //      }
    //  }
    }
}