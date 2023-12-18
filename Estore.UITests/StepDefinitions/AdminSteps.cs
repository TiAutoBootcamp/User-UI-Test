using CoreAdditional.Providers;
using CoreAdditional.Utils;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public class AdminSteps
    {
        private readonly DataContext _context;
        private readonly TokenManager _credentials;
        private readonly UserRequestGenerator _userGenerator;
        
        public AdminSteps(DataContext context,
            UserRequestGenerator userGenerator,
            TokenManager credentials)
        {
            _context = context;
            _userGenerator = userGenerator;
            _credentials = credentials;
        }

        [Given(@"Admin click on the Users button")]
        public void AdminClickOnTheUsersButton()
        {
            _context.CurrentPage.ClickUsersNavigationButton();
        }

        [StepDefinition(@"Admin click on the Add User button")]
        public void AdminClickOnTheAddUserButton()
        {
            _context.UserPage.ClickAddUserButton();
        }

        [When(@"Admin fills create user modal window valid data")]
        public void AdminFillsCreateUserModalWindow()
        {
            _context.CurrentUser = _userGenerator.GenerateNewCustomerModel();
            _context.CreateUser.FillModalWindow(_context.CurrentUser);
        }

        [When(@"Admin fills create user modal window with existing email")]
        public async void AdminFillsCreateUserModalWindowWithExistingEmail()
        {
            var newCustomer = _userGenerator.GenerateNewCustomerModel();
            newCustomer.Credentials.Email = _credentials.GetAdminCredentials().Credentials.Email;
            _context.CreateUser.FillModalWindow(newCustomer);
        }

        [When(@"Admin clicks on the Register button")]
        public void AdminClicksOnTheRegisterButton()
        {
            _context.CreateUser.ClickRegisterButton();
        }

        [When(@"Admin click on the Cancel button")]
        public void AdminClickOnTheCancelButton()
        {
            _context.CreateUser.ClickCloseButton();
        }

        [When(@"Admin fills '(First name|Last name|Email|Password|Repeat password)' input field '([^']*)'( and move focus)?")]
        public void AdminFillsInputFieldAndMoveFocus(string fieldName, string value, string moveFocus)
        {
            var isMoveFocus = moveFocus != string.Empty;
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.FillFirstNameInputField(value, isMoveFocus);
                    break;
                case "Last name":
                    _context.CreateUser.FillLastNameInputField(value, isMoveFocus);
                    break;
                case "Email":
                    _context.CreateUser.FillEmailInputField(value, isMoveFocus);
                    break;
                case "Password":
                    FillPasswordField(value, isMoveFocus);
                    break;
                case "Repeat password":
                    if (value == "randomValue")
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(_userGenerator.GenerateValidPassword(), isMoveFocus);
                    }
                    else
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(value, isMoveFocus);
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown field name");                    
            }
        }

        private void FillPasswordField(string value, bool isMoveFocus)
        {
            switch (value)
            {
                case "short":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWith1Letter(), isMoveFocus);
                    break;
                case "long":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithMoreThan32Letters(), isMoveFocus);
                    break;
                case "withoutLowerCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutLowerCaseLetters(), isMoveFocus);
                    break;
                case "withoutUpperCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutUpperCaseLetters(), isMoveFocus);
                    break;
                case "withoutDigits":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutDigits(), isMoveFocus);
                    break;
                case "randomValue":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateValidPassword(), isMoveFocus);
                    break;
                default:
                    _context.CreateUser.FillPasswordInputField(value, isMoveFocus);
                    break;
            }
        }

        [When(@"Admin clears '(First name|Last name|Email|Password|Repeat password)' field( and move focus)?")]
        public void AdminClearsFieldAndMoveFocus(string fieldName, string moveFocus)
        {
            var isMoveFocus = moveFocus != string.Empty;
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.ClearFirstNameField(isMoveFocus);
                    break;
                case "Last name":
                    _context.CreateUser.ClearLastNameField(isMoveFocus);
                    break;
                case "Email":
                    _context.CreateUser.ClearEmailField(isMoveFocus);
                    break;
                case "Password":
                    _context.CreateUser.ClearPasswordField(isMoveFocus);
                    break;
                case "Repeat password":
                    _context.CreateUser.ClearRepeatPasswordField(isMoveFocus);
                    break;
                default:
                    throw new ArgumentException("Unknown field name");
            }
        }
    }
}