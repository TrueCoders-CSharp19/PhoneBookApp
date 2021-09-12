using System;
using System.Text.RegularExpressions;

namespace PhoneBookConsoleUI.Contacts
{
    // The ContactFactory will be used to receive all of the data for a new
    // contact, format it, and return it in a string array for storage in the
    // account phonebook list.
    public static class ContactFactory
    {

        //TODO:     Since you have a method for EnterFirstName, EnterLastName, EnterPhoneNumber, and LoadContactCard,
        //          could we break these down into an abstract factory class, and then I will implement the same methods
        //          in the Account Factory class... This may allow our menu option for updating these properties at a later time
        //          be able to handle both Contacts and Accounts because they both inherit from Factory?

        // Prompt the user to enter the last name of the contact they wish to
        // add and return a string of their response with the first character
        // capitalized.


        
        public static Contact CreateContact()
        {
            return new Contact(EnterFirstName(), EnterLastName(), EnterPhoneNumber());
        }


        internal static string EnterFirstName()
        {
            ConsolePrinter.AddMessage("Please enter the first name for your contact.", true);
            //Console.WriteLine($"\nPlease enter the first name for your contact.");
            var userInput = Console.ReadLine();
            var firstName = $"{char.ToUpper(userInput[0])}{userInput.Substring(1)}";
            return firstName;
        }

        // Prompt the user to enter the last name of the contact they wish to
        // add and return a string of their response with the first character
        // capitalized.
        internal static string EnterLastName()
        {
            Console.WriteLine($"\nPlease enter the last name for your contact.");
            var userInput = Console.ReadLine();
            var lastName = $"{char.ToUpper(userInput[0])}{userInput.Substring(1)}";
            return lastName;
        }

        // Prompt the user to enter the phone number of the contact they wish to
        // add and return string of the number formatted to (XXX) XXX-XXX.
        // Also promts the user to try again if the number they entered is not
        // 10 digits long.
        internal static string EnterPhoneNumber()
        {
            Console.WriteLine($"\nPlease enter the 10 digit phone number for your contact.");
            var unformatted = Regex.Replace(Console.ReadLine(), "[^.0-9]", "");
            if(unformatted.Length == 10)
            {
                var area = unformatted.Substring(0, 3);
                var major = unformatted.Substring(3, 3);
                var minor = unformatted.Substring(6);
                var formatted = string.Format("Phone Number: ({0}) {1}-{2}", area, major, minor);
                return formatted;
            }
            else
            {
                Console.WriteLine($"\nThe number you entered was not 10 digits long.");
                return EnterPhoneNumber();
            }
        }
    }
}
/* This was all for testing the ContactFactory in the main[]
string[] array = ContactFactory.LoadContactCard();
foreach(string value in array)
{
    Console.WriteLine(value);
}*/