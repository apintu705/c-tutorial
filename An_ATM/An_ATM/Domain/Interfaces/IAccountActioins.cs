using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_ATM.Domain.Interfaces
{
    public interface IAccountActioins
    {
        void CheckBalance();
        void PlaceDeposit();
        void MakeWithdrawl();
    }
}
