using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallATM
{
    internal class Program
    {
        static void Main()
        {
            
            void PrintOptions()
            {
                Console.WriteLine("please choose from one of the floowing options ...");
                Console.WriteLine("1 deposit");
                Console.WriteLine("2 withdraw");
                Console.WriteLine("3 showbalance");
                Console.WriteLine("4 exit");
            }

            void Deposit(CardHolder currentUser)
            {
                Console.WriteLine("how much money would you like to deposit ");
                double depositAmount=Double.Parse(Console.ReadLine());

                currentUser.setBalance(depositAmount);
                Console.WriteLine("thanks for depositinh");
            }

            void WithDraw(CardHolder currentUser)
            {
                Console.WriteLine("How much you want to withdraw: ");
                double WithDrawl=Double.Parse(Console.ReadLine());
                if (currentUser.getBalance() > WithDrawl)
                {
                    Console.WriteLine("insufficient balance : ");
                }
                else
                {
                    double newBalance=currentUser.getBalance()-WithDrawl;
                    currentUser.setBalance(newBalance);
                    Console.WriteLine("you are good to go thanks");
                }
            }

            void Balance(CardHolder currentUser)
            {
                Console.WriteLine("current balance: " + currentUser.getBalance());
            }

            List<CardHolder> cardHolders=new List<CardHolder>();
            cardHolders.Add(new CardHolder("4321",1234,"john","grifitch",150.31));


            Console.WriteLine("welcome to simple ATM");
            Console.WriteLine("please enter your debit card: ");
            string debitCardNo="";
            CardHolder currentUser;

            while (true)
            {
                try 
                {
                    debitCardNo = Console.ReadLine();

                    currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNo);
                    if (currentUser != null) { break;}
                    else
                    {
                        Console.WriteLine("card is not recognize please try again");
                    }
                }
                catch 
                { 
                    Console.WriteLine("card is not recognize please try again");
                }

                Console.WriteLine("please enter your pin");
                int UserPin=0;
                try 
	            {	        
		            UserPin=int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == UserPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("incorrect pin please try again: ");
                    }

	            }
	            catch 
	            {

		            Console.WriteLine("incorrect pin please try again: ");
	            }
                Console.WriteLine("welcome " + currentUser.getFirstName() );
                int option = 0;
                do
                {
                    PrintOptions();
                    try 
	                {	        
		                option = int.Parse(Console.ReadLine());

	                }
	                catch 
	                {

		                
	                }
                    if (option == 1)
                    {
                        Deposit(currentUser);
                    }
                    else if (option == 2)
                    {
                        WithDraw(currentUser);
                    }
                    else if (option == 3)
                    {
                        Balance(currentUser);
                    }
                    else if (option == 4)
                    {
                        break;
                    }
                    else
                    {
                        option = 0;
                    }
                }
                while(option != 4);

                Console.WriteLine( "thank you have a nice day");
            }

        }
    }
}
