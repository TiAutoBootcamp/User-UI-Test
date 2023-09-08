using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;


namespace Core.Extentions
{
    public static class WebDriverExtension
    {
        public static bool FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElements(by).Count() == 0);
                
            }
            return false;
        }
    }
}
