using UITests.TestData;
using TechTalk.SpecFlow;
using UITests.Context;
using Estore.UITests.Pages;
using CoreAdditional.Providers;
using Microsoft.Extensions.Configuration;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly DataContext _context;
        private readonly UserServiceProvider _userProvider;
        private readonly IConfiguration _configuration;

        public UserSteps(DataContext context,
            UserServiceProvider userProvider,
            IConfiguration configuration)
        {
            _context = context;
            _userProvider = userProvider;
            _configuration = configuration;
        }

        [Given(@"User search product by '(.*)'")]
        [When(@"User search product by '(.*)'")]
        public void WhenUserSearchProductBy(string searchedString)
        {
            switch (searchedString)
            {
                case "Article":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Article);
                    break;
                case "Name":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Name);
                    break;
                case "Manufactor":
                    _context.MainPage.FillSearchField(_context.ProductRequest.Manufactor);
                    break;
                case "":
                    return;
                case "Long string":
                    _context.MainPage.FillSearchField(TestCasesData.LongString);
                    return;
                default:
                    _context.MainPage.FillSearchField(searchedString);
                    break;
            }
            _context.MainPage.ClickSearchButton();
        }

        [Given(@"User clicks on the Login button in the top right corner")]
        public void GivenUserClicksOnTheLoginButtonInTheTopRightCorner()
        {
            _context.CurrentPage.ClickLoginLink();                        
        }

        [Given(@"User fills email and password fields with valid customer credentials")]
        public async Task GivenUserFillsEmailAndPasswordFieldsWithValidCustomerCredentials()
        {
            var registeredCustomer = await _userProvider.RegisterCustomer();
            _context.LoginPage.FillEmailField(registeredCustomer.Credentials.Email);
            _context.LoginPage.FillPasswordField(registeredCustomer.Credentials.Password);
            _context.WelcomeMessage = $"Welcome, {registeredCustomer.MainInfo.FirstName} " +
                $"{registeredCustomer.MainInfo.LastName}! (Customer)";
        }

        [Given(@"User fills email and password fields with valid admin credentials")]
        public void GivenUserFillsEmailAndPasswordFieldsWithValidAdminCredentials()
        {
            _context.LoginPage.FillEmailField(_configuration["AdminCredentials:email"]);
            _context.LoginPage.FillPasswordField(_configuration["AdminCredentials:password"]);
            _context.WelcomeMessage = $"Welcome, {_configuration["AdminCredentials:email"]}! (Admin)";
        }

        [When(@"User clicks Login button")]
        public void WhenUserClicksLoginButton()
        {
            _context.LoginPage.ClickLoginButton();
        }

        [Given(@"User logs in")]
        public async Task GivenUserLogsIn()
        {
            GivenUserClicksOnTheLoginButtonInTheTopRightCorner();
            await GivenUserFillsEmailAndPasswordFieldsWithValidCustomerCredentials();
            WhenUserClicksLoginButton();
        }

        [When(@"User moves to Welcom message in the top right corner")]
        public void WhenUserMovesToWelcomMessageInTheTopRightCorner()
        {
            _context.MainPage.MoveToAccountButton();
        }

        [When(@"Email and password fields are empty")]
        public void WhenEmailAndPasswordFieldsAreEmpty()
        {
            _context.LoginPage.FillEmailField("");
            _context.LoginPage.FillPasswordField("");
            _context.CurrentPage.ClickOnSpecificPlace();
        }

        [When(@"User clicks Sign out button in the drop down list")]
        public void WhenClickSignOutButtonInTheDropDownList()
        {
            _context.CurrentPage.ClickSignOutButton();
        }

        [When(@"User types email in invalid format")]
        public void WhenUserTypesEmailInInvalidFormat()
        {
            throw new PendingStepException();
        }
    }
}