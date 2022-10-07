using An_ATM.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace An_ATM.App
{
    public class Entry
    {
        static void Main()
        {
            
            var atmApp = new AtmApp();
            atmApp.InitializeData();
            atmApp.Run();
            
            

        }
    }
}
