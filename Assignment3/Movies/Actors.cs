using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Movies
{
    public class Actors
    {
        public  string SelectActors()
        {
            var selectedActors = new List<string>();
            while (true)
            {
                Console.WriteLine("Select one or more than one actors");
                Console.WriteLine(":1.Will Smith      5.Parbhash");
                Console.WriteLine(":2.Salman          6.Vijay");
                Console.WriteLine(":3.Tiger        7.Tamannah");
                Console.WriteLine(":4.Yash          8.Katrina");
                Console.WriteLine(":0.Other");
                Console.WriteLine("Enter x to finally add all the selected actors");

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
        public static string SelectProducer()
        {
            Console.WriteLine("\n\n\n\n\n\nSelect producer");
            Console.WriteLine(":1.Yes Raj              5.Disney");
            Console.WriteLine(":2.Dharma         6.Enternment");
            Console.WriteLine(":3.Red Chellie    7.Media Rights");
            Console.WriteLine(":4.SKF                     8.YVf");
            Console.WriteLine(":0.Other");
            Console.WriteLine("");

            string selectedAmount = InputValidator.Convert<string>("option:");
            switch (selectedAmount)
            {
                case "1":
                    return "Yes Raj";

                case "2":
                    return "Dharma";

                case "3":
                    return "Red Chellie";

                case "4":
                    return "SKF";

                case "5":
                    return "Disney";

                case "6":
                    return "Enternment";

                case "7":
                    return "Media Rights";

                case "8":
                    return "YVf";

                case "0":
                    Console.WriteLine("Enter any producer");
                    return Console.ReadLine();

                default:
                    Utility.PrintMessage("Invalid input. Try again.", false);
                    return "";

            }
        }

    }
}
