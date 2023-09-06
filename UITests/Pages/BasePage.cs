﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace UserUITest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }  
    }
}