using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PhoneBookConsoleUI.Contacts;

namespace PhoneBookConsoleUI.Accounts
{
    class Account 
    {

        // List of contacts that are tied to this specific account
        List<Contact> Contacts { get; set; }
        
        // Primary Contact (or account holder) for this account.
        Contact PrimaryContact { get; set; }


        /// <summary>
        /// constuctor for Account will take in a Primary Contact to list as the account owner.
        /// </summary>
        /// <param name="PrimaryContact"></param>
        public Account()
        {
            Contacts = new List<Contact>()
            {
                new Contact("Joey", "Stilley", "(250) 308-7114"),
                new Contact("Daniel", "Aguirre", "(218) 412-4512"),
                new Contact("Caitlin", "Stilley", "(230) 123-4567")
            };
        }

        // 1. Adds a new contact to the account holder's list of contacts
        public void AddContact()
        {
            var adding = true;
            while (adding)
            {
                var contact = ContactFactory.CreateContact();
                Contacts.Add(contact);
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "AddAnother", "yes / no: ");
                var userResponse = Console.ReadLine().ToLower();
                if (userResponse != "yes")
                {
                    adding = false;
                }
            }
        }

        // 1. Allows the user to search their list of contacts and choose the
        //    specific contact if there are multiple results.
        // 2. Sets a local copy of a chosen contact.
        // 3. Removes the chosen contact from the account holder's list of contacts.
        // 4. Allows the user to edit the local copy of the chosen contact.
        // 5. Adds the edited contact back to the account holders list of
        //    contacts after the user is finished editing.
        public void EditContact()
        {
            var searchResults = SearchContacts();
            var editIt = ChooseContact(searchResults);
            var editing = true;
            while (editing)
            {
                ConsolePrinter.AddToScreen($"First Name: {editIt.FirstName}\n Last Name: {editIt.LastName}\nPhone Number: {editIt.FirstName}");
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "Edit", "Selection: ");
                var field = Console.ReadKey().KeyChar;
                switch (field)
                {
                    case '1':
                        editIt.FirstName = ContactFactory.EnterFirstName();
                        break;

                    case '2':
                        editIt.FirstName = ContactFactory.EnterLastName();
                        break;

                    case '3':
                        editIt.FirstName = ContactFactory.EnterPhoneNumber();
                        break;
                    default:
                        ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "ReturnForInvalidEntry");
                        Console.ReadKey();
                        EditContact();
                        break;
                }
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "StillEditing", "yes/no: ");
                var userInput = Console.ReadLine().ToLower();
                if (userInput != "yes")
                {
                    editing = false;
                }
            }

            ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "EditAnother", "yes/no: ");
            var userResponse = Console.ReadLine().ToLower();
            if (userResponse == "yes")
            {
                EditContact();
            }
        }

        // 1. Removes a specific contact from an acount holder's list of contacts
        public void RemoveContact()
        {
            var removing = true;
            while (removing)
            {
                var searchResults = SearchContacts();
                var deleteIt = ChooseContact(searchResults);
                var index = 0;
                foreach (var contact in Contacts)
                {
                    if (deleteIt.FullName == contact.FullName && deleteIt.PhoneNumber == contact.PhoneNumber)
                    {
                        Contacts.RemoveAt(index);
                    }
                    index++;
                }
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "DeleteAnother", "yes/no: ");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    removing = false;
                }
            }
        }

        // 1. Allows the account holder to search their list of contacts.
        // 2. Returns a list of contacts matching the search parameter.
        public List<Contact> SearchContacts()
        {
            var searchResults = new List<Contact>();

            ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SearchType", "Selection: ");
            var searchType = Console.ReadKey().KeyChar;
            switch (searchType)
            {
                case '1':
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SearchFirst", "First Name: ");
                    var searchVariable = Console.ReadLine().ToLower();
                    searchResults = Contacts.Where(contact => contact.FirstName.ToLower() == searchVariable.ToLower()).ToList();
                    return searchResults;

                case '2':
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SearchLast", "Last Name: ");
                    searchVariable = Console.ReadLine().ToLower();
                    searchResults = Contacts.Where(contact => contact.LastName.ToLower() == searchVariable.ToLower()).ToList();
                    return searchResults;

                case '3':
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SearchFull", "Full Name: ");
                    searchVariable = Regex.Replace(Console.ReadLine().ToLower(), "[^a-z]", "");
                    searchResults = Contacts.Where(contact => contact.FullName.ToLower() == searchVariable).ToList();
                    return searchResults;

                case '4':
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SearchPhone", "Phone Number: ");
                    searchVariable = Regex.Replace(Console.ReadLine(), "[^.0-9]", "");
                    searchResults = Contacts.Where(contact => Regex.Replace(contact.PhoneNumber, "[^.0-9]", "") == searchVariable).ToList();
                    return searchResults;
                default:
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "ReturnForInvalidEntry");
                    Console.ReadKey();
                    SearchContacts();
                    break;
            }
            return searchResults;
        }

        // 1. Prints out a numbered list of the search results
        // 2. If there are no results, tells the user there were no results
        public void ReturnSearchResults()
        {
            var searchResults = SearchContacts();
            var number = 1;
            if (searchResults.Count != 0)
            {
                foreach (var result in searchResults)
                {
                    ConsolePrinter.AddToScreen($"{number}. First Name: {result.FirstName}\nLast Name: {result.LastName}\n  Phone Number: {result.PhoneNumber}");
                    number++;
                }
            }
            else
            {
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "NoEntries");
            }
        }

        // 1. Allows the user to pick a specific contact from a list of contacts
        //    to return.
        // 2. If there is only one contact in the list, returns the lone contact.
        public Contact ChooseContact(List<Contact> searchResults)
        {
            
            if(searchResults.Count > 1)
            {
                ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "Choose", "Selection: ");
                ReturnSearchResults();
                return searchResults.ElementAt(Convert.ToInt32(Console.ReadKey()) - 1);
            }

            return searchResults.ElementAt(0);
        }

        public void TransferOwnership()
        {
            
        }

        public void UpdatePrimaryNumber()
        {
            
        }
    }
}
