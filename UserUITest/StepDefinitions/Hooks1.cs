using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using UserUITest.Pages;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class Hooks1
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks


      //[BeforeTestRun]
      //public static async Task OneTimeSetUp(DataContext _context)
      //{
      //
      //    var chromeOptions = new ChromeOptions();
      //    // chromeOptions.AddArgument("headless");
      //
      //
      //    _driver = new ChromeDriver(chromeOptions);
      //    _driver.Manage().Window.Maximize();
      //    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
      //    _driver.Navigate().GoToUrl("https://estore-uat.azurewebsites.net/users");
      //
      //    _userPage = new UserPage(_driver, _context);
      //
      //    Thread.Sleep(15000);
      //    _userPage.LoadUserTable();

        

    }
}