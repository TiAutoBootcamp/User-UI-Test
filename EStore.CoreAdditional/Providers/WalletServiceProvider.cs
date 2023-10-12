using CoreAdditional.Utils;
using Estore.Clients.Clients;
using Estore.Core.HTTP.Base;
using Estore.Models.Response.Wallet;

namespace CoreAdditional.Providers
{
    public class WalletServiceProvider
    {
        private readonly WalletClient _walletServiceClient;
        private readonly WalletRequestGenerator _balanceChargeGenerator;

        public WalletServiceProvider(WalletClient client,
           WalletRequestGenerator generator)
        {
            _walletServiceClient = client;
            _balanceChargeGenerator = generator;
        }

        public async Task<CommonResponse<Guid>> BalanceCharge(int userId = 1, decimal amount = 100, string? token = null)
        {
            var balanceChargeRequest = _balanceChargeGenerator.GenerateBalanceChargeRequest(userId, amount);
            var commonResponse = await _walletServiceClient.Charge(balanceChargeRequest, token);
            
            return commonResponse;
        }

        public async Task<Guid> GetChargeTransactionId(int userId = 1, decimal amount = 100, string? token = null)
        {
            var response = await BalanceCharge(userId, amount, token);
            return response.Body;
        }

        public async Task<CommonResponse<Guid>> RevertExistTransaction(Guid transactionId, string? token = null)
        {
            return await _walletServiceClient.Revert(transactionId, token);
        }

        public async Task<Guid> GetRevertTransactionId(Guid transactionId, string? token = null)
        {
            var response = await _walletServiceClient.Revert(transactionId, token);
            return response.Body;
        }

        public async Task<CommonResponse<IEnumerable<TransactionInfoResponse>>> GetTransactions(int? userId, string token = null)
        {
            return await _walletServiceClient.GetAllTransactions(userId.Value, token);
        }
    }
}
