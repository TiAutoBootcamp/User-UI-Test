﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletServiceAPI.Models.Requests
{
    public class BalanceChargeRequest
    {
        public int? userId;
        public double? amount;
    }
}