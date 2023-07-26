using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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