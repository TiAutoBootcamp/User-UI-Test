
using CoreAdditional.Providers;
using Estore.UITests.Pages;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;
using UITests.Context;
using UITests.Pages;

namespace Estore.UITests.StepDefinitions.Preconditions
{
    [Binding]
    public sealed class LoginPrecondition
    {
        [Scope(Tag = "AdminLoggedIn")]
        [BeforeScenario]
        static async Task LogIn(DataContext context, 
            IConfiguration configuration,
            TokenManager credentials)
        {
            context.Driver.Navigate().GoToUrl($"{configuration["BaseUrl"]}{configuration["Pages:login"]}");
            context.LoginPage = new LoginPage(context.Driver);
            context.CurrentUser = credentials.GetAdminCredentials();
            context.LoginPage.FillEmailAndPasswordFieldsAndClickLoginButton(context.CurrentUser.Credentials.Email,
                context.CurrentUser.Credentials.Password);
            context.MainPage = new MainPage(context.Driver);
        }

        [Scope(Tag = "CustomerLoggedIn")]
        [BeforeScenario]
        static async Task LogIn(DataContext context)
        {
        }
    }
}
