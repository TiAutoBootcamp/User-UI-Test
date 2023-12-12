using CoreAdditional.Providers;
using Estore.Core.Extensions;
using Estore.CoreAdditional.Providers;
using System.Net;
using TechTalk.SpecFlow;
using UITests.Context;

namespace Estore.UITests.StepDefinitions
{
    [Binding]
    public sealed class CustomerSteps
    {
        private readonly DataContext _context;
        private readonly UserServiceProvider _userProvider;
        private readonly WalletServiceProvider _walletProvider;
        private readonly TokenManager _tokenManager;

        public CustomerSteps(DataContext context,
            UserServiceProvider userProvider,
            WalletServiceProvider walletProvider,
            TokenManager tokenManager)
        {
            _context = context;
            _userProvider = userProvider;
            _walletProvider = walletProvider;
            _tokenManager = tokenManager;
        }

        [StepDefinition(@"Customer clicks on the Orders submenu button")]
        public void ClickOrdersButtonInTheDropDownList()
        {
            _context.CurrentPage.ClickOrdersButton();
        }

        [StepDefinition(@"Customer has active status")]
        public async Task CustomerHasActiveStatus()
        {
            var token = await _tokenManager.GetValidAdminToken(); 
            await _userProvider.SetUserStatus(_context.CurrentUser.Id.Value, true, token)
                .ThrowIfNotTargetStatus(HttpStatusCode.OK);
        }

        [StepDefinition(@"Customer has enough money '(.*)'")]
        public async Task CustomerHasEnoughMoney(decimal amount)
        {
            var token = await _tokenManager.GetValidAdminToken();
            await _walletProvider.BalanceCharge(_context.CurrentUser.Id.Value, amount, token)
                .ThrowIfNotTargetStatus(HttpStatusCode.OK);
            _context.RegisteredCustomers.Remove(_context.CurrentUser.Id.Value);
        }
        
        [When(@"Customer clicks on the order number '(.*)'")]
        public async Task CustomerClicksOnTheOrderNumber(int orderNumber)
        {
            var orderId = _context.CreatedOrders[_context.CreatedOrders.Count - orderNumber].MainInfo.OrderId;
            _context.OrdersPage.ClickOnTheOrderLine(orderId);
        }
    }
}
