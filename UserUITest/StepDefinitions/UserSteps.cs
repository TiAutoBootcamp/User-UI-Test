using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UserServiceAPI.Client;
using UserServiceAPI.Utils;
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
        [ThreadStatic]
        private readonly UserServiceClient _userServiceClient = new UserServiceClient();
        [ThreadStatic]

        private readonly UserGenerator _createUser = new UserGenerator();
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

            Thread.Sleep(15000);
            _userPage.LoadUserTable();
            
        }


        [Given(@"a user created")]
        public async Task GivenAUserCreated()
        {
            _context.CreateUserRequest = _createUser.GenerateUserRequest();
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.UserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user created wih birth date ([^']*)")]
        public async Task WhenIWriteAGuidNameToFirstNameFieldWihBirthDateLikeEmpty(string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateCreateUserRequestWithBirthDate(birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.UserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user first name created with (.*) characters and GUID last name with birth date ([^']*)")]
        public async Task GivenAUserFirstNameCreatedWithCharactersAndGUIDLastNameWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomFirstNameWithGuidLastNameRequest(length,birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.UserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user with GUID first name and last name (.*) characters and birth date ([^']*)")]
        public async Task GivenAUserWithGUIDFirstNameAndLastNameCharactersAndBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomLastNameWithGuidLastNameRequest(length, birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.UserId = _context.CreateUserResponse.Body;
        }

        [Given(@"a user first name and last name created with (.*) characters with birth date ([^']*)")]
        public async Task GivenAUserFirstNameAndLastNameCreatedWithCharactersWithBirthDate_(int length, string birthDate)
        {
            _context.CreateUserRequest = _createUser.GenerateRandomUserRequest(length, birthDate);
            _context.CreateUserResponse = await _userServiceClient.CreateUser(_context.CreateUserRequest);
            _context.UserId = _context.CreateUserResponse.Body;
        }



        [When(@"I write a name on the filter")]
        public void WhenIWriteAGuidNameToFirstNameField()
        {
            _userPage.SearchUser(_context.CreateUserRequest.FirstName, _context.CreateUserRequest.LastName);
        }

      

        [When(@"click on the search button")]
        public void WhenClickOnTheSearchButton()
        {
            _userPage.ClickSearchButton(); ;
        }

        [When(@"click on the details button")]
        public void WhenClickOnTheDetailsButton()
        {
            Thread.Sleep(500);
            _userPage.ClickDeatilsButton();
            
        }


        [When(@"get all the information from the modal")]
        public void WhenGetAllTheInformationFromTheModal()
        {
            _userPage.GetAllTheModalInformatio();
        }


        [When(@"click on the primary close button")]
        public void WhenClickOnThePrimaryCloseButton()
        {
            _userPage.ClickOnPrimaryCloseButton();
        }

        [When(@"click on the secondary close button")]
        public void WhenClickOnTheSecondaryCloseButton()
        {
            _userPage.ClickOnSecondaryCloseButton();
        }

        [When(@"check the state of the modal")]
        public void WhenCheckTheStateOfTheModal()
        {
            Thread.Sleep(500);
            _userPage.CheckModalIsDisplayed();
        }

        [Given(@"change the user status to ([^']*)")]
        [Given(@"change second time the user status to ([^']*)")]
        [Given(@"change third time the user status to ([^']*)")]
        public async Task  GivenChangeTheUserStatusToActive(bool status)
        {
            await _userServiceClient.SetUserStatus(_context.UserId, status);
        }

        [When(@"press the Esc key")]
        public void WhenPressTheEscKey()
        {
            _userPage.PressEscKey();
        }

        [When(@"click out side the modal")]
        public void WhenClickOutSideTheModal()
        {
            _userPage.ClickOnSpecificPosition();
        }




        [AfterTestRun]
        public static async Task TearDown()
        {
            _driver.Quit();
        }


     


    }
}