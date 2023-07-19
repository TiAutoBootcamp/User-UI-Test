using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserUITest.Pages
{
    public class BasePage
    {

        protected readonly IWebDriver _driver;
        protected readonly DataContext _context;

        public BasePage(IWebDriver driver, DataContext context)
        {
            _driver = driver;
            _context = context;
            PageFactory.InitElements(driver, this);
        }

       
    }
}
