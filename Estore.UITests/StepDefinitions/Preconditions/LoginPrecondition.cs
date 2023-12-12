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
            navigationSteps.OpenPage("Login");
            navigationSteps.PageIsOpened("Login");
            await userSteps.UserFillsEmailAndPasswordFieldsWithCredentials("Admin");
            userSteps.UserClicksLoginButton();
            navigationSteps.PageIsOpened("Main");
            userSteps.SetCurrentUserToken();
        }

        [Scope(Tag = "CustomerLoggedIn")]
        [BeforeScenario]
        public static async Task LogInAsCustomer(NavigationSteps navigationSteps,
            UserSteps userSteps)
        {
            navigationSteps.OpenPage("Login");
            navigationSteps.PageIsOpened("Login");
            await userSteps.UserFillsEmailAndPasswordFieldsWithCredentials("Customer");
            userSteps.UserClicksLoginButton();
            navigationSteps.PageIsOpened("Main");
            userSteps.SetCurrentUserToken();
        }
    }
}