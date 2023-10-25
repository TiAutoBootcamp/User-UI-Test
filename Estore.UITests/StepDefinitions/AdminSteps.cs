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
        private readonly UserRequestGenerator _usergenerator;
        
        public AdminSteps(DataContext context,
            UserRequestGenerator userGenerator)
        {
            _context = context;
            _usergenerator = userGenerator;
        }

        [Given(@"Admin click on the Users button")]
        public void GivenAdminClickOnTheUsersButton()
        {
            _context.CurrentPage.ClickUsersNavigationButton();
        }

        [Given(@"Admin click on the Add User button")]
        [When(@"Admin click on the Add User button")]
        public void GivenAdminClickOnTheAddUserButton()
        {
            _context.UserPage.ClickAddUserButton();
        }

        [When(@"Admin fills modal window and registers new customer")]
        public void WhenAdminFillsModalWindowAndRegistersNewCustomer()
        {
            _context.CurrentUser = _usergenerator.GenerateNewCustomerModel();
            _context.CreateUser.FillModalWindowAndClickRegisterButton(_context.CurrentUser);
        }

        [When(@"Admin click on the Cancel button")]
        public void WhenAdminClickOnTheCancelButton()
        {
            _context.CreateUser.ClickCloseButton();
        }

        [When(@"Admin fills '([^']*)' input field: '([^']*)'")]
        public void WhenAdminFillsInputField(string fieldName, string value)
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
                        _context.CreateUser.FillRepeatPasswordInputField(_usergenerator.GenerateValidPassword());
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
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateInvalidPasswordWith1Letter());
                    break;
                case "long":
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateInvalidPasswordWithMoreThan32Letters());
                    break;
                case "withoutLowerCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateInvalidPasswordWithoutLowerCaseLetters());
                    break;
                case "withoutUpperCaseLetters":
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateInvalidPasswordWithoutUpperCaseLetters());
                    break;
                case "withoutDigits":
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateInvalidPasswordWithoutDigits());
                    break;
                case "randomValue":
                    _context.CreateUser.FillPasswordInputField(_usergenerator.GenerateValidPassword());
                    break;
                default:
                    _context.CreateUser.FillPasswordInputField(value);
                    break;
            }
        }
    }
}