using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PhoneBookConsoleUI.Contacts;

namespace PhoneBookConsoleUI.Accounts
{
    //TODO: Integrate the ConsolePrinter for all messaging sent to the user.
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
        public Account(Contact primaryContact) 
        {
            PrimaryContact = primaryContact;
        }

        // 1. Adds a new contact to the account holder's list of contacts
        public void AddContact()
        {
            var adding = true;
            while (adding)
            {
                ContactFactory.CreateContact();
                Console.WriteLine("Would you like to add another contact? yes/no");
                if (Console.ReadLine().ToLower() != "")
                {
                    adding = false;
                }
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
                foreach (var contact in Contacts)
                {
                    if (deleteIt.FullName == contact.FullName && deleteIt.FullName == contact.PhoneNumber)
                    {
                        Contacts.Remove(contact);
                    }
                }
                Console.WriteLine("Would you like to delete another contact? yes/no");
                if(Console.ReadLine().ToLower() != "yes")
                {
                    removing = false;
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
            Console.WriteLine("Would you like to edit a different contact? yes/no");
            if(Console.ReadLine().ToLower() == "yes")
            {
                EditContact();
            }
        }

        // 1. Allows the account holder to search their list of contacts.
        // 2. Returns a list of contacts matching the search parameter.
        public List<Contact> SearchContacts()
        {
            var searchResults = new List<Contact>();

            Console.WriteLine("Please enter the number for the type of search you would like to make:");
            Console.WriteLine($"1. By first name\n2. By Last name\n3. By full name\n By phone number");
            var searchType = Console.ReadLine().ToLower();
            switch (searchType)
            {
                case "1":
                    Console.WriteLine("Please enter the first name of the contact you are searching for.");
                    var searchVariable = Console.ReadLine().ToLower();
                    searchResults = Contacts.Where(contact => contact.FirstName.ToLower() == searchVariable.ToLower()).ToList();
                    return searchResults;
                case "2":
                    Console.WriteLine("Please enter the last name of the contact you are searching for.");
                    searchVariable = Console.ReadLine().ToLower();
                    searchResults = Contacts.Where(contact => contact.LastName.ToLower() == searchVariable.ToLower()).ToList();
                    return searchResults;

                case "3":
                    Console.WriteLine("Please enter the first and last name of the contact you are searching for.");
                    searchVariable = Console.ReadLine().ToLower();
                    searchResults = Contacts.Where(contact => contact.FullName.ToLower() == searchVariable.ToLower()).ToList();
                    return searchResults;

                case "4":
                    Console.WriteLine("Please enter the phone number of the contact you are searching for.");
                    searchVariable = Regex.Replace(Console.ReadLine(), "[^.0-9]", "");
                    searchResults = Contacts.Where(contact => Regex.Replace(contact.PhoneNumber, "[^.0-9]", "") == searchVariable).ToList();
                    return searchResults;
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
                    Console.WriteLine($"{number}. First Name: {result.FirstName}\n  Last Name: {result.LastName}\n  Phone Number: {result.PhoneNumber}\n\n");
                    number++;
                }
            }
            else
            {
                Console.WriteLine("There were no entries in your contact list that matched your search.");
            }
        }

        // 1. Allows the user to pick a specific contact from a list of contacts
        //    to return.
        // 2. If there is only one contact in the list, returns the lone contact.
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
            
        }

        public void UpdatePrimaryNumber()
        {
            throw new NotImplementedException();
        }
    }
}
