using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Net.NetworkInformation;
using UserUITest.Pages;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
       
        [ThreadStatic]
        private static IWebDriver _driver;
        [ThreadStatic]
        private static UserPage _userPage;

        private readonly DataContext _context;

        public UserSteps(DataContext context)
        {
            _context = context;
        }

        [BeforeTestRun]
        public static async Task OneTimeSetUp(DataContext _context) {

            var chromeOptions = new ChromeOptions();
           // chromeOptions.AddArgument("headless");

            _driver = new ChromeDriver(chromeOptions);

            _driver.Manage().Window.Maximize();

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            _driver.Navigate().GoToUrl("https://estore-uat.azurewebsites.net/users");
            
            _userPage = new UserPage(_driver, _context);
            _userPage.LoadUserTable();

            //_mainPage = new MainPage(_driver);
        }

       

        [Given(@"the users page and opened")]
        public void GivenTheUsersPageAndOpened()
        {
            //throw new PendingStepException();
        }


        [Given(@"the name I search a user '([^']*)' with last name '([^']*)'")]
        public void GivenTheNameISearchAUserWithLastName(string firstName, string lastName)
        {
            _userPage.SearchUser(firstName, lastName);
            _userPage.ClickDeatilsButton();
        }

        [When(@"I click to the details button")]
        public void WhenIClickToTheDetailsButton()
        {
            
        }


        [AfterTestRun]
        public static async Task TearDown()
        {
            _driver.Quit();
        }
    }
}