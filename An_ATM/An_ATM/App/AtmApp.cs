using An_ATM.Domain.Entities;
using An_ATM.Domain.Enum;
using An_ATM.Domain.Interfaces;
using An_ATM.UI;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace An_ATM
{
    public class AtmApp : IUserLogin, IAccountActioins, Itransation
    {
        private List<UserAccount> userAccountList;
        private UserAccount selectedAccount;
        private List<Transation> _listOfTransations;
        private const decimal minimumKeptAmount = 500;
        private readonly AppScreen screen;

        public AtmApp()
        {
            screen = new AppScreen();
        }
        public void Run()
        {
            AppScreen.Welcome();
            CheckUserCardNumberAndPassword();
            AppScreen.WelcomeCustomer(selectedAccount.FullName);

            while (true)
            {
              
                AppScreen.DisplayAppMenu();
                ProcessMenuOption();
            }
            
        }
        public void InitializeData()
        {
            userAccountList = new List<UserAccount>
            {
                new UserAccount{Id=1, FullName = "Obinna Ezeh", AccountNumber=123456,CardNumber =321321, CardPin=123123,AccountBalance=50000.00m,IsLocked=false},
                new UserAccount{Id=2, FullName = "Amaka Hope", AccountNumber=456789,CardNumber =654654, CardPin=456456,AccountBalance=4000.00m,IsLocked=false},
                new UserAccount{Id=3, FullName = "Femi Sunday", AccountNumber=123555,CardNumber =987987, CardPin=789789,AccountBalance=2000.00m,IsLocked=true},
            };

            _listOfTransations = new List<Transation>();
        }

        public void CheckUserCardNumberAndPassword()
        {
            bool isCorrectLogin = false;

            while(isCorrectLogin == false)
            {
                UserAccount inputAccount = AppScreen.UserLoginForm();
                AppScreen.LoginProgress();
                foreach(UserAccount account in userAccountList)
                {
                    selectedAccount = account;
                    if (inputAccount.CardNumber.Equals(selectedAccount.CardNumber))
                    {
                        selectedAccount.TotalLogin++;
                        if (inputAccount.CardPin.Equals(selectedAccount.CardPin))
                        {
                            selectedAccount = account;
                            if(selectedAccount.IsLocked || selectedAccount.TotalLogin > 3)
                            {
                                //print a lock message
                                AppScreen.PrintLockScreen();
                            }
                            else
                            {
                                selectedAccount.TotalLogin = 0;
                                isCorrectLogin = true;
                                break;
                            }
                        }
                    }
                    if(isCorrectLogin == false)
                    {
                        Utility.PrintMessage("\n Invalid card number or pin", false);
                        selectedAccount.IsLocked = selectedAccount.TotalLogin == 3;
                        if (selectedAccount.IsLocked)
                        {
                            AppScreen.PrintLockScreen();
                        }
                    }
                    Console.Clear();
                }
            }

        }

        private void ProcessMenuOption()
        {
            switch(Validator.Convert<int>("Enter an option: "))
            {
                case (int)Appmenu.CheckBalance:
                    CheckBalance();
                    break;

                case (int)Appmenu.PlaceDeposit:
                    PlaceDeposit();
                    break;

                case (int)Appmenu.MakeWithdrawl:
                   MakeWithdrawl();
                    break;

                case (int)Appmenu.InteralTransfer:
                    var internalTransfer = screen.InternalTransferForm();
                    ProcessInternalTransfer(internalTransfer);
                    break;

                case (int)Appmenu.ViewTransations:
                    ViewTransation();
                    break;

                case (int)Appmenu.Logout:
                    AppScreen.LogOutProgress();
                    Utility.PrintMessage("You have successfully loggedout", true);
                    Run();
                    break;

                default:
                    Utility.PrintMessage("Invalid option", false);
                    break;
            }
        }

        public void CheckBalance()
        {
            Utility.PrintMessage($"Your account balance is: {Utility.FormatAmount(selectedAccount.AccountBalance)}", true);
        }

        public void PlaceDeposit()
        {
            Console.WriteLine("\nOnly myltiples of 500 and 1000 INR allowed.\n");
            var transation_amt = Validator.Convert<int>($"amount {AppScreen.cur}");


            Console.WriteLine("\nChecking and counting the notes. ");
            Utility.PrintDotAnimation();
            Console.WriteLine("");

            if (transation_amt <= 0)
            {
                Utility.PrintMessage("Amount needs to be greater than zero", false);
                return;
            }
            if (transation_amt % 500 != 0)
            {
                Utility.PrintMessage($"Enter deposit amount in multiple of 500 of 1000. try again", false);
                return;
            }
            if (PreviewBankNotesCount(transation_amt) == false)
            {
                Utility.PrintMessage("You have calcelled your action", false);
                return;
            }

            //bank transation details to transation obj
            InsertTransation(selectedAccount.Id, TransationType.Deposit, transation_amt, "");

            //update balance
            selectedAccount.AccountBalance += transation_amt;

            Utility.PrintMessage($"Your deposit of amoutn {Utility.FormatAmount(transation_amt)} is successfully done", true);

        }

        public void MakeWithdrawl()
        {
            var transation_amt = 0;
            int selectedAmount = AppScreen.SelectAmount();
            if ( selectedAmount == -1)
            {
                MakeWithdrawl();
                return;
            }
            else if ( selectedAmount != 0)
            {
                transation_amt = selectedAmount;
            }
            else
            {
                transation_amt = Validator.Convert<int>($"amount {AppScreen.cur}");

            }

            //iniput validation
            if(selectedAmount <= 0)
            {
                Utility.PrintMessage("Amout is to be greater than zero. Try again", false);
                return;
            }
            if(transation_amt % 500 != 0)
            {
                Utility.PrintMessage("you can only withdraw amount in multiple of 500 or 1000. try again", false);
                return ;
            }

            //bussiness logic validations
            if(transation_amt > selectedAccount.AccountBalance)
            {
                Utility.PrintMessage("Failed! your balance is too low to withdraw. try again", false);
                return;
            }
            if(selectedAccount.AccountBalance - transation_amt < minimumKeptAmount)
            {
                Utility.PrintMessage($"Withdrawl failed. your accound needs to have minimum {Utility.FormatAmount(minimumKeptAmount)}",false);
                return;
            }

            //bind withdrawn details to transation obj

            InsertTransation(selectedAccount.Id, TransationType.Withdrawl, -transation_amt, "");

            //updated account balance
            selectedAccount.AccountBalance -= transation_amt;
            Utility.PrintMessage($"you have successfully withdrawn {Utility.FormatAmount(transation_amt)} now you have {Utility.FormatAmount(selectedAccount.AccountBalance)}", true);


        }
        private bool PreviewBankNotesCount(int amount)
        {
            int thousandNotesCount = amount / 1000;
            int fiveHundredNotesCount = (amount % 1000) / 500;

            Console.WriteLine("\nsummary ");
            Console.WriteLine("-------");
            Console.WriteLine($"{AppScreen.cur}1000 x {thousandNotesCount} = {1000 * thousandNotesCount}");
            Console.WriteLine($"{AppScreen.cur}500 x {fiveHundredNotesCount} = {500 * fiveHundredNotesCount}");
            Console.WriteLine($"Total amount: {Utility.FormatAmount(amount)}\n");

            int opt = Validator.Convert<int>("1 to confirm");
            return opt.Equals(1);
        }

        public void InsertTransation(long _userBankAccountId, TransationType _tranType, decimal _tranAmount, string _description)
        {
            //create new transation obj
            var transation = new Transation()
            {
                TransationId = Utility.GetTransationId(),
                UserBankAccountId = _userBankAccountId,
                TransationDate = DateTime.Now,
                TransationType = _tranType,
                TransationAmount = _tranAmount,
                Description = _description
            };

            _listOfTransations.Add(transation);

        }

        public void ViewTransation()
        {
            var filteredTransationList = _listOfTransations.Where(t => t.UserBankAccountId == selectedAccount.Id).ToList();

            //check if there is a transation
            if(filteredTransationList.Count <= 0)
            {
                Utility.PrintMessage("You have no transation yet", true);
            }
            else
            {
                var table = new ConsoleTable("Id","TransationDate","type","Descriptions", "Amount" + AppScreen.cur);
                foreach(var transation in filteredTransationList)
                {
                    table.AddRow(transation.TransationId, transation.TransationDate, transation.TransationType, transation.Description, transation.TransationAmount);
                }
                table.Options.EnableCount = false;
                table.Write();
                Utility.PrintMessage($"You have {filteredTransationList.Count} transations. ", true);

            }
        }

        private void ProcessInternalTransfer(InternalTransfer internalTransfer)
        {
            if(internalTransfer.TransferAmount <= 0)
            {
                Utility.PrintMessage("Amount needs to be more than Zero. try again.", false);
                return;
            }

            //check senders account balance
            if(internalTransfer.TransferAmount > selectedAccount.AccountBalance)
            {
                Utility.PrintMessage($"transfer failed. You do not have enough balance to transfer {Utility.FormatAmount(internalTransfer.TransferAmount)}", false);
                return ;
            }

            //check the minimum kept amount
            if((selectedAccount.AccountBalance - internalTransfer.TransferAmount) < minimumKeptAmount)
            {
                Utility.PrintMessage("transfer failed your account needs to have minimum" + $"{Utility.FormatAmount(minimumKeptAmount)}", false);
                return ;
            }

            //check reciever bank account no is valid
            var selectedBankAccountReceiver = (from userAcc in userAccountList
                                               where userAcc.AccountNumber == internalTransfer.RecepientBankAccountNumber
                                               select userAcc).FirstOrDefault();
            if(selectedBankAccountReceiver == null)
            {
                Utility.PrintMessage("Transfer failed. Receiver bank account no is invalid.", false);
                return;
            }

            //check receivers name
            if(selectedBankAccountReceiver.FullName != internalTransfer.RecepientBankAccountName)
            {
                Utility.PrintMessage("Transfer failed. receipent banc account name does not match.", false);
                return;
            }

            //add transaction to receipent and transation record sender
            InsertTransation(selectedAccount.Id, TransationType.Transfer, -internalTransfer.TransferAmount, $"Transfered  to {selectedBankAccountReceiver.AccountNumber}");

            //update senders account balance
            selectedAccount.AccountBalance -= internalTransfer.TransferAmount;

            //add transation recored receiver
            InsertTransation(selectedBankAccountReceiver.Id, TransationType.Transfer, internalTransfer.TransferAmount, $"transfered from ${selectedAccount.AccountNumber}");

            //update receiver account balance
            selectedBankAccountReceiver.AccountBalance += internalTransfer.TransferAmount;

            Utility.PrintMessage($"you have successfully transfered " +
                $"{Utility.FormatAmount(internalTransfer.TransferAmount)} to" +
                $"{internalTransfer.RecepientBankAccountName} ", true);

        }
    }
}
