using System;
using System.Collections.Generic;

namespace Assignment1
{
    public class Assignment
    {
        public static void QuestionOne()
        {
            int sum = 0;
            while (true)
            {
                try
                {
                    Console.Write("Enter a number or type ok to exit: ");
                    var input = Console.ReadLine();
                    if (input.ToLower() == "ok")
                    {
                        break;
                    }
                    if (!string.IsNullOrEmpty(input))
                    {
                        sum += Convert.ToInt32(input);
                    }

                    Console.WriteLine("sum is : " + sum);
                }
                catch
                {
                    throw new Exception("Please enter a valid Input");
                }

            }
        }


        public static void QuestionTwo()
        {

            Console.Write("Enter series of numbers seperated by comma:  ");

            var input = Console.ReadLine();
            var arrOfInput = input.Split(',');
            var maximumOfInput = Convert.ToInt32(arrOfInput[0]);

            try
            {

                foreach (var item in arrOfInput)
                {
                    var inputElement = Convert.ToInt32(item);
                    if (inputElement > maximumOfInput)
                    {
                        maximumOfInput = inputElement;
                    }

                }
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message);
            }

            Console.WriteLine("Maximum of the numbers is: " + maximumOfInput);
        }


        public static void QuestionThree()
        {
            string[] elementsOfInput;

            while (true)
            {
                Console.Write("Enter a list of more than five comma separated numbers: ");
                var input = Console.ReadLine();

                if (!String.IsNullOrWhiteSpace(input))
                {
                    elementsOfInput = input.Split(',');
                    if (elementsOfInput.Length >= 5)
                    {
                        break;
                    }
                }
                Console.WriteLine("invalid input");
            }

            var listOfInput = new List<int>();
            foreach (var element in elementsOfInput)
            {
                try
                {
                    listOfInput.Add(Convert.ToInt32(element));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message);
                }

            };
            listOfInput.Sort();

            var answer = new List<int>();

            for (var i = 0; i < 3; i++)
            {
                answer.Add(listOfInput[i]);
            }

            Console.WriteLine("The three smallest numbers in the list is: " + string.Join(",", answer));
        }

        public static void QuestionFour()
        {
            var listOfInput = new List<int>();
            Console.Write("Enter comma-separated list of numbers as input: ");
            var input = Console.ReadLine();
            var inputArray = input.Split(',');
            foreach (var element in inputArray)
            {
                try
                {

                    listOfInput.Add(Convert.ToInt32(element));
                }
                catch (Exception e)
                {
                    throw new InvalidOperationException(e.Message);
                }
            }
            listOfInput.Sort();
            listOfInput.Reverse();
            Console.WriteLine("Descending order of your input is: " + string.Join(",", listOfInput));
        }


    }
}
