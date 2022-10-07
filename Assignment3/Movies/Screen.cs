using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Movies
{
    public class Screen
    {
        internal static void Welcome()
        {
            //clear the console screen
            Console.Clear();

            // set the title of the console window
            Console.Title = "My IMBD App";

            //set the text color or foreground color
            Console.ForegroundColor = ConsoleColor.Yellow;

            //set the welcome msg
            Console.WriteLine("\n-----------Welcome to My IMBD App!-----------\n");

            Utility.PressEnterToContinue();
        }

    }
}
