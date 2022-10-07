using System;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook_app
{
    public class PhoneBook
    {
        private List<Contact> _contacts { get; set; } = new List<Contact>();    

        public void AddContact(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void DisplayContact(string number)
        {
            var contact=_contacts.FirstOrDefault(c => c.Number == number);
            if(contact == null)
            {
                Console.WriteLine("Contact not found");
            }
            else
            {
                Console.WriteLine($"Contact: {contact.Name} {contact.Number}");
            }
        }

        public void DisplayAllContacts()
        {
            foreach (var contact in _contacts)
            {
                Console.WriteLine($"Contact: {contact.Name} {contact.Number}");
            }
        }

        public void DisplayMatchingContacts(string searchPhrase)
        {
            //var matchingContacts = _contacts.Where(c => c.Name == searchPhrase);
            var matchingContacts = _contacts.Where(c => c.Name.Contains(searchPhrase)).ToList();

            foreach (var contact in matchingContacts)
            {
                Console.WriteLine($"Contact: {contact.Name} {contact.Number}");
            }
        }

    }
}
