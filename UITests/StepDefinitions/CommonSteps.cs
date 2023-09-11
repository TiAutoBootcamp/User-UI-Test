using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;

namespace UITests.StepDefinitions
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly DataContext _context;

        public CommonSteps(DataContext context)
        {
            _context = context;
        }

        [When(@"press the Esc key")]
        public void WhenPressTheEscKey()
        {
            Actions actions = new Actions(_context.Driver);
            actions.SendKeys(Keys.Escape);
            actions.Perform();
        }
    }
}