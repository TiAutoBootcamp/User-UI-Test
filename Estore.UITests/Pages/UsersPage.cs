using Estore.Models.DataModels.User;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

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

        [FindsBy(How = How.CssSelector, Using = "tbody tr")]
        private IList<IWebElement> _tableRows;

        [FindsBy(How = How.Id, Using = "id_column")]
        private IList<IWebElement> _idColumn;

        [FindsBy(How = How.Id, Using = "first_name_column")]
        private IList<IWebElement> _firstNameColumn;

        [FindsBy(How = How.Id, Using = "last_name_column")]
        private IList<IWebElement> _lastNameColumn;

        [FindsBy(How = How.Id, Using = "add_user_button")]
        private IWebElement _addUserButton;

        public UsersPage(IWebDriver driver) : base(driver)
        {
            Title = "Estore - User management";
            Wait.Until(d => d.Title == Title);
        }

        public void ClickAddUserButton()
        {
            _addUserButton.Click();
        }

        public bool CreateUserModalIsOpen()
        {
            return Wait.Until(_ => Body.GetAttribute("style").Contains("overflow: hidden"));             
        }
        public bool CreateUserModalIsClosed()
        {
            return Wait.Until(_ => Body.GetAttribute("style").Contains("overflow: auto"));
        }

        public void LoadUserTable()
        {
            Wait.Until((_) => _userTable.Displayed);
        }

        public void SearchUser(UserModel user)
        {
            _firstNameInput.SendKeys(user.MainInfo.FirstName);
            _lastNameInput.SendKeys(user.MainInfo.LastName);
            Wait.Until((_) => _searchButton.Enabled);
            ClickSearchButton();
            LoadUserTable();
        }

        public IList<UserModel> GetSearchedUsers()
        {
            IList<UserModel> userModels = _tableRows.Select((row, index) => new UserModel
            {
                Id = int.Parse(_idColumn[index].Text),
                MainInfo = new CustomerUserMainInfo
                {
                    FirstName = _firstNameColumn[index].Text,
                    LastName = _lastNameColumn[index].Text
                }
            }).ToList();
            return userModels;
        }

        public void ClickSearchButton()
        {
            _searchButton.Click();
        }
    }
}