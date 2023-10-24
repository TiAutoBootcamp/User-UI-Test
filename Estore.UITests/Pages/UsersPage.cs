﻿using Estore.Models.Enum;
using Estore.Models.Response.Wallet;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace UITests.Pages
{
    public class UsersPage : BasePage
    {
        [FindsBy(How = How.ClassName, Using = "table")]
        private IWebElement _userTable;

        [FindsBy(How = How.Id, Using = "first_name_search")]
        private IWebElement _firstNameInput;

        [FindsBy(How = How.Id, Using = "last_name_search")]
        private IWebElement _lastNameInput;

        [FindsBy(How = How.Id, Using = "search_product")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='action_column']//button")]
        private IWebElement _buttonDetails;

        [FindsBy(How = How.ClassName, Using = "blazored-modal")]
        private IWebElement _detailsModal;

        [FindsBy(How = How.ClassName, Using = "bm-title")]
        private IWebElement _idField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'First name:')]/following-sibling::*")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Last name:')]/following-sibling::*")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Status:')]/following-sibling::*")]
        private IWebElement _statusField;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Birth date:')]/following-sibling::*")]
        private IWebElement _birthDateField;

        [FindsBy(How = How.ClassName, Using = "bm-close")]
        private IWebElement _primaryCloseButton;

        [FindsBy(How = How.ClassName, Using = "btn-secondary")]
        private IWebElement _secondaryCloseButton;

        [FindsBy(How = How.CssSelector, Using = "span[id$='_title']")]
        private IList<IWebElement> _tittleModalFields;

        [FindsBy(How = How.XPath, Using = "//div[contains(@class, 'mud-ripple') and contains(text(), 'Transactions')]")]
        private IWebElement _transactionsTab;

        [FindsBy(How = How.Id, Using = "create_time_column")]
        private IList<IWebElement> _transactionsCreateTime;

        [FindsBy(How = How.CssSelector, Using = ".bm-content p em")]
        private IWebElement _messageTransaction;

        [FindsBy(How = How.Id, Using = "transaction_id_column")]
        private IList<IWebElement> _transactionsIds;

        [FindsBy(How = How.Id, Using = "amount_column")]
        private IList<IWebElement> _transactionsAmounts;

        [FindsBy(How = How.CssSelector, Using = ".bm-content #status_column")]
        private IList<IWebElement> _transactionStatus;

        [FindsBy(How = How.CssSelector, Using = ".bm-content .table")]
        private IList<IWebElement> _transactionTable;

        [FindsBy(How = How.Id, Using = "add_user_button")]
        private IWebElement _addUserButton;
        
        public UsersPage(IWebDriver driver) : base(driver)
        {
            Title = "Estore - User management";
            Wait.Until(d => d.Title == Title);
        }

        public void LoadUserTable()
        {
            Wait.Until((_) => _userTable.Displayed);
        }

        public void SearchUser(string firstName, string secondName)
        {
            _firstNameInput.SendKeys(firstName);
            _lastNameInput.SendKeys(secondName);
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
        }

        public void ClickDetailsButton()
        {
            _buttonDetails.Click();
            Wait.Until((_) => _detailsModal.Displayed);
        }

        public int GetId()
        {
            var tittle = _idField.Text;
            Match match = Regex.Match(tittle, @"\d+");
            return int.Parse(match.Value);
        }

        public string GetFirtsName()
        {
            return _firstNameField.Text ?? string.Empty;
        }

        public string GetLastName()
        {
            return _lastNameField.Text ?? string.Empty;
        }

        public bool GetStatusUser()
        {
            bool status = _statusField.Text == "Active";
            return status;
        }

        public string GetBirthDate()
        {
            string _birthDate = _birthDateField.Text ?? string.Empty;
            return _birthDate;
        }

        public void ClickOnPrimaryCloseButton()
        {
            _primaryCloseButton.Click();
        }

        public void ClickOnSecondaryCloseButton()
        {
            _secondaryCloseButton.Click();
        }

        public void ClickAddUserButton()
        {
            _addUserButton.Click();
        }

        public void ClickOnTransactionsTab()
        {
            Wait.Until((_) => _transactionsTab.Displayed);
            _transactionsTab.Click();
            WaitPageLoading();
        }

        public void ClickOnSpecificPosition()
        {
            Actions actions = new Actions(Driver);
            actions.MoveByOffset(10, 10);
            actions.Click();
            actions.Perform();

            WaitForUserDetailsModalClosed();
        }

        public void WaitForUserDetailsModalClosed()
        {
            Wait.Until((_) => !IsModalDisplayed());
        }

        public void WaitForTableVisible()
        {
            Wait.Until((_) => _transactionTable.Where(rowElement => rowElement.Displayed).ToList());
        }

        public List<TransactionInfoResponse> GetTableInformation()
        {
            List<Guid> idTransaction = TransactionsIds();
            List<decimal> amount = TransactionsAmounts();
            List<TransactionStatus> status = TransactionsStatus();
            List<DateTime> createTime = TransactionsCreateTime();

            List<TransactionInfoResponse> tableInformation = _transactionTable
             .Select((rowElement, index) => new TransactionInfoResponse
             {
                 TransactionId = idTransaction[index],
                 Amount = amount[index],
                 Time = createTime[index],
                 Status = status[index],
             })
             .ToList();

            return tableInformation;
        }

        private object GetCellValue(IWebElement rowElement, int columnIndex)
        {
            var cellElements = rowElement.FindElements(By.TagName("td"));

            if (cellElements.Count > columnIndex)
            {
                return cellElements[columnIndex].Text;
            }

            return string.Empty;
        }

        public List<string> GetFieldsTittle()
        {

            List<string> fields = new List<string>();
            foreach (var tittle in _tittleModalFields)
            {
                fields.Add(tittle.Text.ToString());
            }
            return fields;
        }

        public bool IsModalDisplayed()
        {
            try
            {
                return _detailsModal.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsTransactionsTabClickable()
        {
            return _transactionsTab.Enabled;
        }

        public List<DateTime> TransactionsCreateTime()
        {
            return _transactionsCreateTime.Select(element => DateTime.Parse(element.Text)).ToList();
        }

        public List<Guid> TransactionsIds()
        {
            return _transactionsIds.Select(element => Guid.Parse(element.Text)).ToList();
        }

        public List<decimal> TransactionsAmounts()
        {
            return _transactionsAmounts.Select(element => decimal.Parse(element.Text)).ToList();
        }

        public List<TransactionStatus> TransactionsStatus()
        {
            List<TransactionStatus> transactionStatusList = _transactionStatus
                .Select(webElement =>
                {
                    string text = webElement.Text.Trim().ToLower();
                    if (text == "active")
                    {
                        return TransactionStatus.Active;
                    }
                    else if (text == "reverted")
                    {
                        return TransactionStatus.Reverted;
                    }
                    else
                    {
                        throw new Exception("Unknown user status");
                    } 
                })
                .ToList();

            return transactionStatusList;
        }

        public string MessageTransactions()
        {
            Wait.Until(ExpectedConditions.TextToBePresentInElement(_messageTransaction, "User does not have transactions"));
            return _messageTransaction.Text ?? string.Empty;
        }
    }
}