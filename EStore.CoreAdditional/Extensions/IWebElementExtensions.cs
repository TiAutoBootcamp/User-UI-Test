using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Estore.CoreAdditional.Extensions
{
    public static class IWebElementExtensions
    {
        public static void ClickAndSendKeysViaActions(this IWebElement element, string key)
        {
            element.Click();
            var driver = element.GetDriver();
            Actions actions = new Actions(driver);
            if (!string.IsNullOrEmpty(key))
            {
                actions.SendKeys(key).Perform();
            }                        
        }

        public static void ClearViaActions(this IWebElement element)
        {
            var driver = element.GetDriver(); 
            Actions actions = new Actions(driver);
            actions.Click(element);
            actions.KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control);
            actions.SendKeys(Keys.Delete).Perform();            
        }      
        
        public static IWebDriver GetDriver(this IWebElement element)
        {
            return ((IWrapsDriver)((IWrapsElement)element).WrappedElement).WrappedDriver;
        }
    }
}
