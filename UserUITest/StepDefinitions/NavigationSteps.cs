using UserUITest.Pages;

namespace UserUITest.StepDefinitions
{
    [Binding]
    public sealed class NavigationSteps
    {
        private readonly DataContext _context;

        public NavigationSteps(DataContext context)
        {
            _context = context;
        }

        [Given(@"open users page")]
        public void GivenOpenUsersPage()
        {
            _context.Driver.Navigate().GoToUrl("https://estore-uat.azurewebsites.net/users");

            _context.UserPage = new UserPage(_context.Driver, _context);
            _context.CurrentPage = _context.UserPage;

            _context.UserPage.LoadUserTable();
        }
    }
}