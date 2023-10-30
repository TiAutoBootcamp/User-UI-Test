using UITests.TestData;
using TechTalk.SpecFlow;
using UITests.Context;
using CoreAdditional.Providers;
using NUnit.Framework;
using CoreAdditional.Utils;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class UserSteps
    {
        private readonly DataContext _context;
        private readonly UserServiceProvider _userProvider;
        private readonly TokenManager _credentials;
        private readonly UserRequestGenerator _userInfoGenerator;

        public UserSteps(DataContext context,
            UserServiceProvider userProvider,
            TokenManager credentials,
            UserRequestGenerator userInfoGenerator)
        {
            _context = context;
            _userProvider = userProvider;
            _credentials = credentials;
            _userInfoGenerator = userInfoGenerator;
        }

        [StepDefinition(@"User search product by '(.*)'")]
        public void UserSearchProductBy(string searchedString)
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

        [Given(@"User clicks on the Login link")]
        public void UserClicksOnTheLoginLink()
        {
            _context.CurrentPage.ClickLoginLink();                        
        }

        [StepDefinition(@"User fills email and password fields with '([^']*)' credentials")]
        public async Task UserFillsEmailAndPasswordFieldsWithCredentials(string userRole)
        {
            switch (userRole)
            {
                case "Customer":
                    _context.CurrentUser = await _userProvider.RegisterCustomer();
                    _context.RegisteredCustomers.Add(_context.CurrentUser.Id.Value);
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

        [StepDefinition(@"User clicks Login button")]
        public void UserClicksLoginButton()
        {
            _context.LoginPage.ClickLoginButton();
        }

        [When(@"User moves to Welcome message")]
        public void UserMovesToWelcomeMessage()
        {
            _context.CurrentPage.MoveToAccountButton();
        }

        [When(@"User clicks Sign out button")]
        public void ClickSignOutButtonInTheDropDownList()
        {
            _context.CurrentPage.ClickSignOutButton();
        }

        [When(@"User fills email field with (.*)")]
        public void UserFillsEmailFieldWithInvalidFormat(string invalidEmail)
        {
            _context.LoginPage.FillEmailField(invalidEmail);
        }

        [When(@"User fills (.*) and (.*) fields")]
        public void UserFillsEmailAndPasswordFields(string email, string password)
        {
            FillEmailField(email);
            FillPasswordField(password);            
        }

        private void FillEmailField(string email)
        {
            var adminModel = _credentials.GetAdminCredentials();
            switch (email)
            {
                case "registered":
                    _context.LoginPage.FillEmailField(adminModel.Credentials.Email);
                    break;
                case "unregistered":
                    _context.LoginPage.FillEmailField(_userInfoGenerator.GenerateEmail());
                    break;
                case "wrong":
                    _context.LoginPage.FillEmailField(adminModel.Credentials.Email.Substring(1));
                    break;
                default:
                    Assert.Fail("Unknown option for email field");
                    break;
            }
        }

        private void FillPasswordField(string password)
        {
            var adminModel = _credentials.GetAdminCredentials();
            switch (password)
            {
                case "wrong":
                    _context.LoginPage.FillPasswordField(adminModel.Credentials.Password.ToLower());
                    break;
                case "exist":
                    _context.LoginPage.FillPasswordField(adminModel.Credentials.Password);
                    break;
                default:
                    Assert.Fail("Unknown option for password field");
                    break;
            }
        }
    }
}