﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using UserUITest.Pages;

namespace UserManagementServiceUITests.Pages
{
    public class MainPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "search")]
        private IWebElement _searchButton;

        [FindsBy(How = How.ClassName, Using = "search")]
        private IWebElement _product;

        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public void WaitProductsLoading()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
            wait.Until((_) => _product.Displayed);
        }
    }
}
