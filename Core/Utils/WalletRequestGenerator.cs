using Estore.Models.Request.Wallet;

namespace CoreAdditional.Utils
{
    public class WalletRequestGenerator
    {
        public AddBalanceRequest GenerateBalanceChargeRequest(int userId, decimal amount)
        {
            return new AddBalanceRequest()
            {
                UserId = userId,
                Amount = amount
            };
        }
    }
}
