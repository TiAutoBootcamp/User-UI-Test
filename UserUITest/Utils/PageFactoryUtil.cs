using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementServiceUITests.Utils
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
