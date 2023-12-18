using Estore.Models.Request.Wallet;

namespace Estore.CoreAdditional.Utils
{
    public class WalletRequestGenerator
    {
        public AddBalanceRequest GenerateBalanceCharge(int userId, decimal amount)
        {
            return new AddBalanceRequest()
            {
                UserId = userId,
                Amount = amount
            };
        }
    }
}
