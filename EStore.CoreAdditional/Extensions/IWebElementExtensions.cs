using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;

namespace Estore.CoreAdditional.Extensions
{
    public static class IWebElementExtensions
    {
        public static void ClickAndSendKeysViaActions(this IWebElement element, IWebDriver driver, string key)
        {
            element.Click();
            Actions actions = new Actions(driver);
            if (!string.IsNullOrEmpty(key))
            {
                actions.SendKeys(key).Perform();
            }
            actions.SendKeys(Keys.Tab).Perform();
        }

        public static void ClearViaActions(this IWebElement element, IWebDriver driver)
        {
            Actions actions = new Actions(driver);
            actions.Click(element);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            actions.SendKeys(Keys.Delete).Perform();
            actions.KeyDown(Keys.Shift).SendKeys(Keys.Tab).KeyUp(Keys.Shift).Perform();
        }               
    }
}
