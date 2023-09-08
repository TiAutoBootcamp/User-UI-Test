using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extentions
{
    public static class WebElementExtension
    {
        public static bool WaitForElementToBeInvisible(this IWebElement element, int timeoutSecond = 10)
        {
            IWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromSeconds(timeoutSecond);
            wait.PollingInterval = TimeSpan.FromMilliseconds(300);
            try
            {
                wait.Until((_) => !element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

            return true;
        }
    }
}
