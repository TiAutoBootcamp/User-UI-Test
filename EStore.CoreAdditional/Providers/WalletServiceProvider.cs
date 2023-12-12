using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.CoreAdditional.Utils;

namespace Estore.CoreAdditional.Providers
{
    public class WalletServiceProvider
    {
        private readonly WalletClient _walletClient;
        private readonly WalletRequestGenerator _walletGenerator;

        public WalletServiceProvider(WalletClient client,
           WalletRequestGenerator generator)
        {
            _walletClient = client;
            _walletGenerator = generator;
        }

        public async Task<CommonResponse<Guid>> BalanceCharge(int userId, decimal amount, string token)
        {
            var balanceChargeRequest = _walletGenerator.GenerateBalanceCharge(userId, amount);
            var commonResponse = await _walletClient.Charge(balanceChargeRequest, token);
            
            return commonResponse;
        }
    }
}
