using BddAssignment3.utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.UserInterface
{
    public class ProducerSelection
    {
        public static string SelectProducer()
        {
            Console.WriteLine("\nSelect producer");
            Console.WriteLine(":1.Yes Raj              5.Disney");
            Console.WriteLine(":2.Dharma         6.Enternment");
            Console.WriteLine(":3.Red Chellie    7.Media Rights");
            Console.WriteLine(":4.SKF                     8.YVf");
            Console.WriteLine(":0.Other");
            Console.WriteLine("");

            string selectedAmount = Console.ReadLine();
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
