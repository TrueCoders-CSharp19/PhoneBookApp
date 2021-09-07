using System;
namespace PhoneBookConsoleUI
{
    /*
        Feature: Logger  
            
        Feature Owner: Joey Stilley
                
        Feature Start Date : 9/6/21
                
        Feature DeadLine : 
                
        Feature Goal: Class that formats contacts into organized and readable format based on user input.
    */




    public static class Logger
    {

     

        private static string EnterFirstName()
        {
            Console.WriteLine("Please enter the first name of the contact you would like to add.");
            return Console.ReadLine();
        }


        private static string EnterLastName()
        {
            Console.WriteLine("Please enter the last name of the contact you would like to add.");
            return Console.ReadLine();
        }

        private static string EnterPhoneNumber()
        {
            Console.WriteLine("Please enter the phone number of the contact you would like to add.");
            string unformatted = Console.ReadLine();



            string area = unformatted.Substring(0, 3);
            string major = unformatted.Substring(3, 3);
            string minor = unformatted.Substring(6);
            string formatted = string.Format("{0}-{1}-{2}", area, major, minor);

            return formatted;

        }

        private static string FormatContact(string firstName, string lastName, string phoneNumber)
        {
            string formattedContact = "";
            return formattedContact = $"First Name: {firstName}\nLast Name: {lastName}\nPhone Number: {phoneNumber}";
        }

        private static void LogNewContact()
        {
            string firstName = EnterFirstName();
            string lastName = EnterLastName();
            string phoneNumber = EnterPhoneNumber();
            string formattedContact = FormatContact(firstName, lastName, phoneNumber);



        }







    }
}
