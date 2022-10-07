using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BddAssignment3.utility
{
    public class Utility
    {
        private static int _movieId;

        public static int GetMovieId()
        {
            return ++_movieId;
        }
        public static T Convert<T>(string prompt)
        {
            bool isValid = false;
            string userInput;
            while (!isValid)
            {
                Console.WriteLine(prompt);
                userInput = Console.ReadLine();
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    if(converter != null)
                    {
                        return (T)converter.ConvertFromString(userInput);
                    }
                    else
                    {
                        return default;
                    }
                }
                catch 
                {
                    PrintMessage("Invalid input type",false);
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
    }
}
