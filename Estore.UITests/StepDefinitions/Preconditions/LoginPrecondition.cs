using OpenQA.Selenium;
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
            navigationSteps.OpenLoginPage();
            navigationSteps.LoginPageIsOpen();
            await userSteps.UserFillsEmailAndPasswordFieldsWithCredentials("Admin");
            userSteps.UserClicksLoginButton();
            navigationSteps.MainPageIsOpen();
            userSteps.SetCurrentUserToken();
        }

        [Scope(Tag = "CustomerLoggedIn")]
        [BeforeScenario]
        public static async Task LogInAsCustomer(NavigationSteps navigationSteps,
            UserSteps userSteps)
        {
            navigationSteps.OpenLoginPage();
            navigationSteps.LoginPageIsOpen();
            await userSteps.UserFillsEmailAndPasswordFieldsWithCredentials("Customer");
            userSteps.UserClicksLoginButton();
            navigationSteps.MainPageIsOpen();
            userSteps.SetCurrentUserToken();
        }
    }
}