using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PhoneBookConsoleUI.Contacts;

namespace PhoneBookConsoleUI.Accounts
{
    class PersonalAccount 
    {
        List<Contact> Contacts { get; set; }

        public PersonalAccount(Contact accountContacts) 
        {
            var consoleStrings = new ConsolePrinter();   
        }


        public void AddContact()
        {
            Contacts.Add(new Contact());
        }

        public void RemoveContact()
        {
            var searchResults = SearchContacts();
            var deleteIt = ChooseContact(searchResults);
            Contacts.Remove(deleteIt);
        }

        public void EditContact()
        {
            var searchResults = SearchContacts();
            var editIt = ChooseContact(searchResults);
            foreach(var contact in Contacts)
            {
                if(editIt.FullName == contact.FullName && editIt.FullName == contact.PhoneNumber)
                {
                    Contacts.Remove(contact);
                }
            }
            var editing = true;
            while (editing)
            {
                Console.WriteLine("Please choose the number for the field to would like to edit.");
                Console.WriteLine($"1. First name\n2. Last Name\n3. Phone number");
                var field = Console.ReadLine();
                switch (field)
                {
                    case "1":
                        editIt.FirstName = ContactFactory.EnterFirstName();
                        break;

                    case "2":
                        editIt.FirstName = ContactFactory.EnterLastName();
                        break;

                    case "3":
                        editIt.FirstName = ContactFactory.EnterPhoneNumber();
                        break;
                }
                Console.WriteLine("Would you like to make any more edits to this contact? yes/no");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    editing = false;
                }
            }
            Contacts.Add(editIt);
        }

        public List<Contact> SearchContacts()
        {
            List<Contact> searchResults = new List<Contact>();

            Console.WriteLine("Please enter the number for the type of search you would like to make:");
            Console.WriteLine($"1. By first name\n2. By Last name\n3. By full name\n By phone number");
            var searchType = Console.ReadLine().ToLower();
            switch (searchType)
            {
                case "1":
                    Console.WriteLine("Please enter the first name of the contact you are searching for.");
                    var searchVariable = Console.ReadLine().ToLower();
                    foreach(var savedContact in Contacts)
                    {
                        if(searchVariable == savedContact.FirstName.ToLower())
                        {
                            searchResults.Add(savedContact);
                        }
                    }
                    return searchResults;
                case "2":
                    Console.WriteLine("Please enter the last name of the contact you are searching for.");
                    searchVariable = Console.ReadLine().ToLower();
                    foreach (var savedContact in Contacts)
                    {
                        if (searchVariable == savedContact.LastName)
                        {
                            searchResults.Add(savedContact);
                        }
                    }
                    return searchResults;

                case "3":
                    Console.WriteLine("Please enter the phone number of the contact you are searching for.");
                    searchVariable = Console.ReadLine().ToLower();
                    foreach (var savedContact in Contacts)
                    {
                        if (searchVariable == savedContact.FullName.ToLower())
                        {
                            searchResults.Add(savedContact);
                        }
                    }
                    return searchResults;

                case "4":
                    Console.WriteLine("Please enter the phone number of the contact you are searching for.");
                    searchVariable = Regex.Replace(Console.ReadLine(), "[^.0-9]", "");
                    foreach (var savedContact in Contacts)
                    {
                        if (searchVariable == Regex.Replace(savedContact.PhoneNumber, "[^.0-9]", ""))
                        {
                            searchResults.Add(savedContact);
                        }
                    }
                    return searchResults;
            }
            return searchResults;
        }

        public void ReturnSearchResults()
        {
            var searchResults = SearchContacts();
            var number = 1;
            if (searchResults.Count != 0)
            {
                foreach (var result in searchResults)
                {
                    Console.WriteLine($"{number}. First Name: {result.FirstName}\n  Last Name: {result.LastName}\n  Phone Number: {result.PhoneNumber}\n\n");
                    number++;
                }
            }
            else
            {
                Console.WriteLine("There were no entries in your contact list that matched your search.");
            }
        }

        public Contact ChooseContact(List<Contact> searchResults)
        {
            Console.WriteLine("Please choose the contact you are searching for from the list below.");
            if(searchResults.Count > 1)
            {
                ReturnSearchResults();
                return searchResults.ElementAt(int.Parse(Console.ReadLine()) - 1);
            }

            return searchResults.ElementAt(0);
        }

        public void TransferOwnership()
        {
            throw new NotImplementedException();
        }

        public void UpdatePrimaryNumber()
        {
            throw new NotImplementedException();
        }
    }
}
