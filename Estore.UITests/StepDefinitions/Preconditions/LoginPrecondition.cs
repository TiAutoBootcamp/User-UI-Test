using TechTalk.SpecFlow;

namespace Estore.UITests.StepDefinitions.Preconditions
{
    [Binding]
    public sealed class LoginPrecondition
    {        
        [Scope(Tag = "AdminLoggedIn")]
        [BeforeScenario]
        public static async Task LogInAsAdmin(NavigationSteps navigationSteps,
            UserSteps userSteps)
        {
            navigationSteps.GivenOpenLoginPage();
            navigationSteps.LoginPageIsOpen();
            await userSteps.WhenUserFillsEmailAndPasswordFieldsWithCredentials("Admin");
            userSteps.WhenUserClicksLoginButton();
            navigationSteps.MainPageIsOpen();            
        }

        [Scope(Tag = "CustomerLoggedIn")]
        [BeforeScenario]
        public static async Task LogInAsCustomer(NavigationSteps navigationSteps,
            UserSteps userSteps)
        {
            navigationSteps.GivenOpenLoginPage();
            navigationSteps.LoginPageIsOpen();
            await userSteps.WhenUserFillsEmailAndPasswordFieldsWithCredentials("Customer");
            userSteps.WhenUserClicksLoginButton();
            navigationSteps.MainPageIsOpen();
        }
    }
}