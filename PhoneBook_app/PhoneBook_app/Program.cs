using System.Text;
using System.Threading.Tasks;
using System;

namespace PhoneBook_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from the PhoneBook App");

            Console.WriteLine("Select Opertation");
            Console.WriteLine("1 Add Contact");
            Console.WriteLine("2 Display contact by number");
            Console.WriteLine("3 View all contacts");
            Console.WriteLine("4 Search for contacts for a given name");
            Console.WriteLine("Enter x to exit");

            
            var phoneBook=new PhoneBook();

            while(true){
                var userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Contact name: ");
                        var name = Console.ReadLine();
                        Console.WriteLine("contact number: ");
                        var number = Console.ReadLine();

                        var newContact = new Contact(name, number);
                        phoneBook.AddContact(newContact);
                        break;

                    case "2":
                        Console.WriteLine("Contact number: ");
                        var searchNumber= Console.ReadLine();
                        phoneBook.DisplayContact(searchNumber);
                        break;

                    case "3":
                        phoneBook.DisplayAllContacts();
                        break;

                    case "4":
                        Console.WriteLine("Search by name: ");
                        var searchPhrase= Console.ReadLine();
                        phoneBook.DisplayMatchingContacts(searchPhrase);
                        break;

                    case "x":
                        return;

                    default:
                        Console.WriteLine("please select a valid operation");
                        break;
                }
                Console.WriteLine("select operation");
            }

            

        }
    }
}
