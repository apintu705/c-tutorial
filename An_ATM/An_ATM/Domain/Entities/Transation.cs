using An_ATM.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_ATM.Domain.Entities
{
    public class Transation
    {
        public long TransationId { get; set; }
        public long UserBankAccountId { get; set; }
        public DateTime TransationDate { get; set; }
        public TransationType TransationType { get; set; }
        public string Description { get; set; }
        public decimal TransationAmount { get; set; }
    }
}
