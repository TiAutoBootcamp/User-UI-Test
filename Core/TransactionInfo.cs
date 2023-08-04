using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TransactionInfo
    {
       
            public Guid IdTransaction { get; set; }
            public double amount { get; set; }
            public DateTime CreateTime { get; set; }
            public string Status { get; set; }
            public int UserId { get; set; }
       
    }
}
