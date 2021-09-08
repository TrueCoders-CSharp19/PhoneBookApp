using System;
using System.Text.RegularExpressions;

namespace PhoneBookConsoleUI.Contacts
{
    // The ContactFactory will be used to receive all of the data for a new
    // contact, format it, and return it in a string array for storage in the
    // account phonebook list.
    public static class ContactFactory
    {
        // Prompt the user to enter the last name of the contact they wish to
        // add and return a string of their response with the first character
        // capitalized.
        internal static string EnterFirstName()
        {
            Console.WriteLine("Please enter the first name of the contact you would like to add.");
            var userInput = Console.ReadLine();
            var firstName = $"First Name: {char.ToUpper(userInput[0])}{userInput.Substring(1)}";
            return firstName;
        }

        // Prompt the user to enter the last name of the contact they wish to
        // add and return a string of their response with the first character
        // capitalized.
        internal static string EnterLastName()
        {
            Console.WriteLine($"\nPlease enter the last name of the contact you would like to add.");
            var userInput = Console.ReadLine();
            var lastName = $"Last Name: {char.ToUpper(userInput[0])}{userInput.Substring(1)}";
            return lastName;
        }

        // Prompt the user to enter the phone number of the contact they wish to
        // add and return string of the number formatted to (XXX) XXX-XXX.
        // Also promts the user to try again if the number they entered is not
        // 10 digits long.
        internal static string EnterPhoneNumber()
        {
            Console.WriteLine($"\nPlease enter the 10 digit phone number of the contact you would like to add.");
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

        // Loads all of the formatted contact data into a string array that can
        // be returned to the contact list for the parent account.
        internal static string[] LoadContactCard()
        {
            string[] contactCard = { EnterFirstName(), EnterLastName(), EnterPhoneNumber() };
            return contactCard;
        }
    }
}
/* This was all for testing the ContactFactory in the main[]
string[] array = ContactFactory.LoadContactCard();
foreach(string value in array)
{
    Console.WriteLine(value);
}*/