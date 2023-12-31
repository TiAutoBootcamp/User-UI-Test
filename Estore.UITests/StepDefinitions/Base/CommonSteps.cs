using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions.Base
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
        public void PressTheEscKey()
        {
            Actions actions = new Actions(_context.Driver);
            actions.SendKeys(Keys.Escape);
            actions.Perform();
        }
    }
}