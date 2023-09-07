using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Core.Extentions
{
    public static class WaitExtention
    {
        public static bool WaitUntilElementDisappears(this WebDriverWait wait, By elementLocator)
        {
            try
            {
                wait.Until(driver =>
                {
                    try
                    {
                        var element = driver.FindElement(elementLocator);
                        return !element.Displayed;
                    }
                    catch (NoSuchElementException)
                    {
                        return true;
                    }
                    catch (StaleElementReferenceException)
                    {
                        return true;
                    }
                });
                return true; 
            }
            catch (TimeoutException)
            {
                return false; 
            }
        }
    }
}
