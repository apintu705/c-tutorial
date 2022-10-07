using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_ATM.Domain.Entities
{
    public class InternalTransfer
    {
        public decimal TransferAmount { get; set; }
        public long RecepientBankAccountNumber { get; set; }
        public string RecepientBankAccountName { get; set; }

    }
}
