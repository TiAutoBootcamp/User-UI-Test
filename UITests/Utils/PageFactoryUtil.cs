using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace UITests.Utils
{
    public class PageFactoryUtil
    {
        [FindsBy(How = How.CssSelector, Using = ".mud-progress-circular-svg")]
        private IWebElement progressElement;

        public void WaitForProgressToDisappear(WebDriverWait wait)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(".mud-progress-circular-svg")));
        }
    }
}
