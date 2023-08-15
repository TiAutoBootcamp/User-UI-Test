using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.Collections.Concurrent;
using TechTalk.SpecFlow;


namespace MainPageSearchUITests.StepDefinitions
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeScenario]
        public static async Task OneTimeSetUp(DataContext context)
        {

            var chromeOptions = new ChromeOptions();
            // chromeOptions.AddArgument("headless");
            context.Driver = new ChromeDriver(chromeOptions);
            context.Driver.Manage().Window.Maximize();
            context.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

        [AfterScenario]
        public static async Task TearDown(DataContext context)
        {
            context.Driver.Quit();
        }
    }
}