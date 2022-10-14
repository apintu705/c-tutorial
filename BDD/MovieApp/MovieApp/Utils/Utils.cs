using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Utils
{
    public class Utils
    {
        public static T Convert<T>(string prompt)
        {
            bool isValid = false;
            string userInput;
            while (!isValid)
            {
                Console.Write($"{prompt}:  ");
                userInput = Console.ReadLine();
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if (converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                }
                catch
                {
                    PrintMessage("Invalid input type", false);
                }
            }
            return default;
        }

        public static void PrintMessage(string msg, bool success)
        {
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void DisplayDashBoard()
        {
            Console.WriteLine(@"Welcome to MovieApp
Enter 1. To get List of movies
Enter 2. To add movie to the list
Enter 3. To add Actors
Enter 4. To add Producers
Enter 5. To delete Movie form the list
Enter 0. To Exit the App");
        }
    }
}
