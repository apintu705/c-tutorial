
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{

    internal class Program
    {
        static void Main()
        {
            var calculator = new Calculator();
            var advanceCalculator =  new AdvancedCalculator();

            Console.WriteLine("created calculator class as per question\nFor Adding two integers: Enter 1\n" +
                "For Adding three integers: Enter 2\nFor Adding two float numbers: Enter 3\n" +
                "For Geting the power of a number: Enter 4\nFor Getting the current stored value: Enter 5\n" +
                "For Getting the current stored value in micros: Enter 6\nEnter x to exit");

            while (true)
            {
                Console.WriteLine("Please select an option");
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter num1: ");
                        var num1 = Console.ReadLine();
                        Console.WriteLine("Enter num2: ");
                        var num2 = Console.ReadLine();
                        try
                        {
                            calculator.AddNumbers(int.Parse(num1), int.Parse(num2));
                            Console.WriteLine(calculator.GetResult());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("invalid input type! ");
                            break;
                        }
                    case "2":
                        Console.WriteLine("Enter num1: ");
                        var input1 = Console.ReadLine();
                        Console.WriteLine("Enter num2: ");
                        var input2 = Console.ReadLine();
                        Console.WriteLine("Enter num3: ");
                        var input3 = Console.ReadLine();

                        try
                        {
                            calculator.AddNumbers(int.Parse(input1), int.Parse(input2), int.Parse(input3));
                            Console.WriteLine(calculator.GetResult());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("invalid input type! ");
                            break;
                        }
                    case "3":
                        Console.WriteLine("Enter decimal num1: ");
                        var inputFloat1 = Console.ReadLine();
                        Console.WriteLine("Enter decimal num2: ");
                        var inputFloat2 = Console.ReadLine();

                        try
                        {
                            calculator.AddTwoFloat(float.Parse(inputFloat1), float.Parse(inputFloat2));
                            Console.WriteLine(calculator.GetResult());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("invalid input type!");
                            break;
                        }
                    case "4":
                        Console.WriteLine("Enter number: ");
                        var num = Console.ReadLine();
                        Console.WriteLine("Enter power: ");
                        var power = Console.ReadLine();
                        try
                        {
                            advanceCalculator.Power(int.Parse(num), int.Parse(power));
                            Console.WriteLine(advanceCalculator.GetResult());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("invalid input type!");
                            break;
                        }                     
                    case "x":
                        return;
                    default:
                        Console.WriteLine("Please enter the valid input");
                        break;
                }
            }
        }
    }
}
