using Bogus;
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
            _context.CreateUser.ClickAddUserButton();
        }

        [When(@"Admin fills modal window and registers new customer")]
        public void WhenAdminFillsModalWindowAndRegistersNewCustomer()
        {
            _context.CreateUser.FillModalWindowAndClickRegisterButton(_usergenerator.GenerateNewCustomerModel());
        }
    }
}
