using WalletServiceAPI.Models.Requests;

namespace WalletServiceAPI.Utils
{
    public class BalanceChargeGenerator
    {
        public BalanceChargeRequest GenerateBalanceChargeRequest(int userId, double amount)
        {
            return new BalanceChargeRequest()
            {
                userId = userId,
                amount = amount
            };
        }
    }
}