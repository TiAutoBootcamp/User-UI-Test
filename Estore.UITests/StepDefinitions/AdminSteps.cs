using CoreAdditional.Providers;
using CoreAdditional.Utils;
using NUnit.Framework;
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

        [When(@"Admin fills '([^']*)' input field: '([^']*)'")]
        public void AdminFillsInputField(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.FillFirstNameInputField(value);
                    break;
                case "Last name":
                    _context.CreateUser.FillLastNameInputField(value);
                    break;
                case "Email":
                    _context.CreateUser.FillEmailInputField(value);
                    break;
                case "Password":
                    FillPasswordField(value);
                    break;
                case "Repeat password":
                    if (value == "randomValue")
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(_userGenerator.GenerateValidPassword());
                    }
                    else
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(value);
                    }
                    break;
                default:
                    Assert.Fail("Unknown field name");
                    break;
            }            
        }

        private void FillPasswordField(string value)
        {
            switch (value)
            {
                case "short":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWith1Letter());
                    break;
                case "long":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithMoreThan32Letters());
                    break;
                case "withoutLowerCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutLowerCaseLetters());
                    break;
                case "withoutUpperCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutUpperCaseLetters());
                    break;
                case "withoutDigits":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateInvalidPasswordWithoutDigits());
                    break;
                case "randomValue":
                    _context.CreateUser.FillPasswordInputField(_userGenerator.GenerateValidPassword());
                    break;
                default:
                    _context.CreateUser.FillPasswordInputField(value);
                    break;
            }
        }

        [When(@"Admin fills '([^']*)' input field '([^']*)' and move focus")]
        public void AdminFillsInputFieldAndMoveFocus(string fieldName, string value)
        {
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.FillFirstNameInputField(value, true);
                    break;
                case "Last name":
                    _context.CreateUser.FillLastNameInputField(value, true);
                    break;
                case "Email":
                    _context.CreateUser.FillEmailInputField(value, true);
                    break;
                case "Password":
                    FillPasswordFieldAndMoveFocus(value, true);
                    break;
                case "Repeat password":
                    if (value == "randomValue")
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(_userGenerator.GenerateValidPassword(), true);
                    }
                    else
                    {
                        _context.CreateUser.FillRepeatPasswordInputField(value, true);
                    }
                    break;
                default:
                    Assert.Fail("Unknown field name");
                    break;
            }
        }

        private void FillPasswordFieldAndMoveFocus(string value, bool isMoveFocus)
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

        [When(@"Admin clears '([^']*)' field")]
        public void AdminClearsField(string fieldName)
        {
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.ClearFirstNameField();
                    break;
                case "Last name":
                    _context.CreateUser.ClearLastNameField();
                    break;
                case "Email":
                    _context.CreateUser.ClearEmailField();
                    break;
                case "Password":
                    _context.CreateUser.ClearPasswordField();
                    break;
                case "Repeat password":
                    _context.CreateUser.ClearRepeatPasswordField();
                    break;
                default:
                    Assert.Fail("Unknown field name");
                    break;
            }
        }

        [When(@"Admin clears '([^']*)' field and move focus")]
        public void AdminClearsFieldAndMoveFocus(string fieldName)
        {
            switch (fieldName)
            {
                case "First name":
                    _context.CreateUser.ClearFirstNameField(true);
                    break;
                case "Last name":
                    _context.CreateUser.ClearLastNameField(true);
                    break;
                case "Email":
                    _context.CreateUser.ClearEmailField(true);
                    break;
                case "Password":
                    _context.CreateUser.ClearPasswordField(true);
                    break;
                case "Repeat password":
                    _context.CreateUser.ClearRepeatPasswordField(true);
                    break;
                default:
                    Assert.Fail("Unknown field name");
                    break;
            }
        }
    }
}