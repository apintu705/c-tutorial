using An_ATM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace An_ATM.UI
{
    public  class AppScreen
    {
        internal const string cur = "$ ";
        internal static void Welcome()
        {
            //clear the console screen
            Console.Clear();

            // set the title of the console window
            Console.Title = "My ATM App";

            //set the text color or foreground color
            Console.ForegroundColor = ConsoleColor.Yellow;

            //set the welcome msg
            Console.WriteLine("\n-----------Welcome to My ATM App!-----------\n");

            // prompt the user to insert atm card
            Console.WriteLine("Please insert your ATM card");
            Console.WriteLine("Note: Actual ATM machine will accept and validate a phusical ATM card, read the card no and validate it.");
            Utility.PressEnterToContinue();
        }

        internal static UserAccount UserLoginForm()
        {
            UserAccount tempUser = new UserAccount();

            tempUser.CardNumber = Validator.Convert<long>("Your card Number: ");
            tempUser.CardPin = Convert.ToInt32(Utility.GetSecretInput("Enter your card Pin: "));

            return tempUser;
        }

        internal static void LoginProgress()
        {
            Console.WriteLine("\nChecking card number and PIN...");
            Utility.PrintDotAnimation();
        }

        internal static void PrintLockScreen()
        {
            Console.Clear();
            Utility.PrintMessage("Your account is locked. Please go to the nearest branch" +
                " to unlock your account. Thank you.", true);
            Environment.Exit(1);
        }

        internal static void WelcomeCustomer(string fullName)
        {
            Console.WriteLine($"Welcome back, {fullName}");
            Utility.PressEnterToContinue();
        }

        internal static void DisplayAppMenu()
        {
            Console.Clear();
            Console.WriteLine("-------My ATM App menu-------");
            Console.WriteLine(":                            :");
            Console.WriteLine("1. Account Balance           :");
            Console.WriteLine("2. Cash Deposit              :");
            Console.WriteLine("3. Withdraw                  :");
            Console.WriteLine("4. Transfer                  :");
            Console.WriteLine("5. Transactions              :");
            Console.WriteLine("6. Logout                    :");
        }

        internal static void LogOutProgress()
        {
            Console.WriteLine("Thakyou for using My ATM app. ");
            Utility.PrintDotAnimation();
            Console.Clear();
        }
        internal static int SelectAmount()
        {
            Console.WriteLine("");
            Console.WriteLine(":1.{0}500      5.{0}10,000", cur);
            Console.WriteLine(":2.{0}1000     6.{0}15,000", cur);
            Console.WriteLine(":3.{0}2000     7.{0}20,000", cur);
            Console.WriteLine(":4.{0}5000     8.{0}40,000", cur);
            Console.WriteLine(":0.Other");
            Console.WriteLine("");

            int selectedAmount = Validator.Convert<int>("option:");
            switch (selectedAmount)
            {
                case 1:
                    return 500;
                    
                case 2:
                    return 1000;
                    
                case 3:
                    return 2000;
                    
                case 4:
                    return 5000;
                    
                case 5:
                    return 10000;
                    
                case 6:
                    return 15000;
                    
                case 7:
                    return 20000;
                    
                case 8:
                    return 40000;
                    
                case 0:
                    return 0;
                    
                default:
                    Utility.PrintMessage("Invalid input. Try again.", false);
                    return -1;
                    
            }
        }
        internal  InternalTransfer InternalTransferForm()
        {
            var internalTransfer = new InternalTransfer();
            internalTransfer.RecepientBankAccountNumber = Validator.Convert<long>("recipient's account number:");
            internalTransfer.TransferAmount = Validator.Convert<decimal>($"amount {cur}");
            internalTransfer.RecepientBankAccountName = Utility.GetUserInput("recipient's name:");
            return internalTransfer;
        }
        
    }
}
