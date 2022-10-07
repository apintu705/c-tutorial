namespace SmallATM
{
    public class CardHolder
    {
        string cardNumber;
        int pin;
        string firstName;
        string lastName;
        double balance;

        public CardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
        {
            this.cardNumber = cardNumber;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }

        public string getNum()
        {
            return cardNumber;
        }

        public int getPin() 
        { 
            return pin; 
        }
        public string getFirstName() { return firstName; }  
        public string getLastName() { return lastName; }
        public double getBalance() { return balance; }

        public void setNum(string newCardNumber) { cardNumber = newCardNumber; }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setFirstName(string newFirstName) { firstName = newFirstName; } 
        public void setLastName(string newLastName) { lastName = newLastName; }     
        
        public void setBalance(double newBalance)
        {
            balance += newBalance;
        }

        
    }
}
