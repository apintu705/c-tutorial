using An_ATM.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_ATM.Domain.Interfaces
{
    public interface Itransation
    {
        void InsertTransation(long _userBankAccountId, TransationType _tranType, decimal _tranAmount, string _description);
        void ViewTransation();

    }
}
