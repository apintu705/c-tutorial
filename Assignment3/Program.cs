using Assignment3.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program
    {
        static void Main()
        {
            var imbd = new Imbd();
            Screen.Welcome();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to add movie \nEnter 2 for get movies \nEnter exit to Exit the app");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        imbd.AddMovies();
                        break;
                    case "2":
                        imbd.GetMovies();
                        break;
                    case "exit":
                        Utility.PrintDotAnimation();
                        Utility.PrintMessage("Thanks for using this App",true);
                        return;
                    default:
                        Utility.PrintMessage("please enter valid input",false);
                        break;
                }
            }
            
        }
    }
}
