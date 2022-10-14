using BddAssignment3.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.UserInterface
{
    public class ActorSelection
    {
        public static string SelectActors()
        {
            var selectedActors = new List<string>();

            Console.WriteLine(":1.Will Smith      5.Parbhash");
            Console.WriteLine(":2.Salman          6.Vijay");
            Console.WriteLine(":3.Tiger        7.Tamannah");
            Console.WriteLine(":4.Yash          8.Katrina");
            Console.WriteLine(":0.Other");
            Console.WriteLine("Select one or more than one actor and Enter x to finally add to list");
            while (true)
            {
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        selectedActors.Add("Will Smith");
                        break;

                    case "2":
                        selectedActors.Add("Salman");
                        break;

                    case "3":
                        selectedActors.Add("Tiger");
                        break;

                    case "4":
                        selectedActors.Add("Yash");
                        break;

                    case "5":
                        selectedActors.Add("Parbhash");
                        break;

                    case "6":
                        selectedActors.Add("Vijay");
                        break;

                    case "7":
                        selectedActors.Add("Tamannah");
                        break;

                    case "8":
                        selectedActors.Add("Katrina");
                        break;

                    case "0":
                        Console.WriteLine("Enter any actor name");
                        var name = Console.ReadLine();
                        selectedActors.Add(name);
                        break;

                    case "x":
                        return String.Join(",", selectedActors);

                    default:
                        Utility.PrintMessage("Invalid input. Try again.", false);
                        break;
                }
            }

        }
    }
}
