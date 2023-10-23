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
        private readonly TokenManager _credentials;

        public UserSteps(DataContext context,
            UserServiceProvider userProvider,
            TokenManager credentials)
        {
            _context = context;
            _userProvider = userProvider;
            _credentials = credentials;
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

        [Given(@"User opens login page clicking on the Login button")]
        public void GivenUserOpensLoginPageClickingOnTheLoginButton()
        {
            _context.CurrentPage.ClickLoginLink();                        
        }

        [Given(@"User fills email and password fields with '([^']*)' credentials")]
        [When(@"User fills email and password fields with '([^']*)' credentials")]
        public async Task WhenUserFillsEmailAndPasswordFieldsWithValidCredentialsAsA(string userRole)
        {
            switch (userRole)
            {
                case "Customer":
                    _context.CurrentUser = await _userProvider.RegisterCustomer();
                    _context.LoginPage.FillEmailAndPasswordFields(_context.CurrentUser.Credentials.Email,
                        _context.CurrentUser.Credentials.Password);
                    break;
                case "Admin":
                    _context.CurrentUser = _credentials.GetAdminCredentials();
                    _context.LoginPage.FillEmailAndPasswordFields(_context.CurrentUser.Credentials.Email,
                        _context.CurrentUser.Credentials.Password);
                    break;
                case "Empty":
                    _context.LoginPage.FillEmailAndPasswordFields("", "");
                    break;
            }
        }

        [Given(@"User clicks Login button")]
        [When(@"User clicks Login button")]
        public void WhenUserClicksLoginButton()
        {
            _context.LoginPage.ClickLoginButton();
        }

        [Given(@"User logs in")]
        public async Task GivenUserLogsIn()
        {           
            GivenUserOpensLoginPageClickingOnTheLoginButton();
            await WhenUserFillsEmailAndPasswordFieldsWithValidCredentialsAsA("Admin");
            WhenUserClicksLoginButton();
        }

        [When(@"User moves to Welcome message")]
        public void WhenUserMovesToWelcomeMessage()
        {
            _context.CurrentPage.MoveToAccountButton();
        }

        [When(@"User clicks Sign out button")]
        public void WhenClickSignOutButtonInTheDropDownList()
        {
            _context.CurrentPage.ClickSignOutButton();
        }

        [When(@"User fills email field in (.*)")]
        public void WhenUserFillsEmailFieldInInvalidFormat(string invalidEmail)
        {
            _context.LoginPage.FillEmailField(invalidEmail);
        }
    }
}