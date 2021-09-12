using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneBookConsoleUI
{
    public static class ConsolePrinter
    {

        public static Dictionary<string, string[]> MenuMessages = new Dictionary<string, string[]>
        {
            {"FirstMessage", new string[] {
                "Welcome to our Phone Book Application", "",
                "Created by Joey Stilley and Daniel Aguirre", "",
                "Press any key to continue."} },

            {"SecondMessage", new string[] {
                "Please select what you would like to do next: ", "",
                "1) Show all contacts         ",
                "2) Add a new contact         ",
                "3) Edit an existing contact  ",
                "4) Delete an existing contact",
                "5) End the application       "} },

            {"EndApplication", new string[] {
                "Thank you for taking the time to use our Phone Book Application.", "",
                "Created by Joey Stilley and Daniel Aguirre", "",
                "Press any key to finish ending the application."} },

            {"ReturnForInvalidEntry", new string[] {
                    "I'm sorry, the entry you provided is not a valid selection.", "",
                    "Press any key to return to the previous screen."  } },

            { "ContentNotCreated", new string[] {
                    "I'm sorry, this content is not yet created.", "",
                    "Please try this selection again in a later version.", "",
                    "Press any key to return to the previous screen." } },

            {"FirstNamePrompt", new string[] {
                "Please enter the first name of the contact you would like to add."} },

            {"LastNamePrompt", new string[] {
                "Please enter the last name of the contact you would like to add."} },

            {"PhoneNumberPrompt", new string[] {
                "Please enter the 10 digit phone number of the contact you would like to add."} },

            {"InvalidPhone", new string[] {
                "The number you entered was not 10 digits long." } },

            {"AddAnother", new string[]{
                "Would you like to add another contact?" } },

            {"SearchType", new string[] {
                "Please enter the number for the type of search you would like to make:",
                "1. By first name  ",
                "2. By Last name   ",
                "3. By full name   ",
                "4. By phone number" } },

            {"SearchFirst", new string[]{
                "Please enter the first name of the contact you are searching for." } },

            {"SearchLast", new string[]{
                "Please enter the last name of the contact you are searching for." } },

            {"SearchFull", new string[]{
                "Please enter the full name of the contact you are searching for." } },

            {"SearchPhone", new string[]{
                "Please enter the phone number of the contact you are searching for." } },

            {"Choose", new string[]{
                "Please choose the contact you are searching for from the list below." } },

            {"NoEntries", new string[]{
                "There were no entries in your contact list that matched your search." } },

            {"Edit", new string[]{
                "Please choose the number for the field to would like to edit.",
                "1. First Name  ",
                "2. Last Name   ",
                "3. Phone number" } },

            {"StillEditing", new string[]{
                "Would you like to make any more edits to this contact?" } },

            {"EditAnother", new string[]{
                "Would you like to edit a different contact?" } },

            {"DeleteAnother", new string[]{
                "Would you like to delete another contact?" } },

            {"ConfirmPrompt", new string[] {
                "Please confirm the following Contact Card is correct",
                "First Name: ",
                "Last Name: ",
                "Phone Number: "} }
        };

        /// <summary>
        /// List of StringBuilders so that I can remove them or add them as needed based on console size.
        /// </summary>
        static List<StringBuilder> StringRows;

        static ConsolePrinter ()
        {
            StringRows = new List<StringBuilder>() { new StringBuilder(Console.WindowWidth) };
            AddMinimumRowsNeeded();
        }


        /// <summary>
        /// Take in a Dictionary to search, and a key, then print a message centered vertically corresponding to that key.
        /// </summary>
        /// <param name="key"></param>
        public static void NewMessage(Dictionary<string, string[]> dictionaryToSearch, string key)
        {
            AddMinimumRowsNeeded();
            var messages = dictionaryToSearch[key].Select(x => PadToCenter(x)).ToArray();
            var startIndex = (Console.WindowHeight / 2) - (messages.Length / 2);
            UpdateRows(startIndex, messages);
            PrintAll();
        }

        /// <summary>
        /// Take in a Dictionary to search, and a key, then print a message followed by the inputRequestMessage centered vertically corresponding to that key. 
        /// </summary>
        /// <param name="key"></param>
        public static void NewMessage(Dictionary<string, string[]> dictionaryToSearch, string key, string inputRequestMessage)
        {
            AddMinimumRowsNeeded();
            var messages = dictionaryToSearch[key].Select(x => PadToCenter(x)).ToArray();
            var startIndex = (Console.WindowHeight / 2) - (messages.Length / 2);
            UpdateRows(startIndex, messages);
            PrintAll(inputRequestMessage);
        }

        /// <summary>
        /// Add a provided string to the list of StringRows then reprint the page with the provided requestingInput string before where the user types their response.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="requestingInput"></param>
        public static void AddToScreen(string newMessage, string inputRequestMessage)
        {
            // add an empty new row to list of StringRows for spacing
            AddToStringRows("");
            // add the passed message to the list
            AddToStringRows(newMessage);
            // Print the screen again with the input request message before where the user types their input.
            PrintAll(inputRequestMessage);
            // remove two rows from the beginning of list to make up for the two we are adding (this keeps us centered vertically)
        }

        /// <summary>
        /// Add a provided string to the list of StringRows then reprint the page with the provided requestingInput string before where the user types their response.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="requestingInput"></param>
        public static void AddToScreen(string newMessage)
        {
            // add an empty new row to list of StringRows for spacing
            AddToStringRows("");
            // add the passed message to the list
            AddToStringRows(newMessage);
            PrintAll();
        }

        /// <summary>
        /// Add an array of strings to the list of StringRows then reprint the page.
        /// </summary>
        /// <param name="newMessages"></param>
        /// <param name="requestingInput"></param>
        public static void AddToScreen(string[] newMessages, string inputRequestMessage)
        {
            // add an empty new row to list of StringRows for spacing
            AddToStringRows("");
            foreach (var message in newMessages)
            {
                // add the passed message to the list
                AddToStringRows(message);
            }
            PrintAll(inputRequestMessage);
        }

        static void PrintAll(string inputRequesetMessage)
        {

            Console.Clear();
            for (int i = 0; i < StringRows.Count; i++)
            {
                // if it's the last cycle of string rows.
                if (i == StringRows.Count - 1)
                {
                    // print last row and add two new lines for spacing
                    Console.WriteLine(StringRows[i] + "\n");
                    // then print "Selection: " before where the user types their input
                    Console.Write(inputRequesetMessage.PadLeft(Console.WindowWidth / 2));
                }
                else
                {
                    // otherwise if it's not the last row being printed then just keep printing rows
                    Console.WriteLine(StringRows[i]);
                }
                Console.CursorVisible = true;
            }
        }

        /// <summary>
        /// Foreach row in the provided list, call a Console.WriteLine()
        /// </summary>
        /// <param name="stringRows"></param>
        static void PrintAll()
        {

            Console.Clear();
            foreach (var message in StringRows)
            {
                Console.WriteLine(message);
            }
            Console.CursorVisible = false;
        }

        /// <summary>
        /// First clear all strings, then add each string in the message provided
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="startIndex"></param>
        /// <param name="messages"></param>
        static void UpdateRows(int startIndex, string[] messages)
        {
            // reset the StringRows list by clearing it then adding the minimum number of rows needed.
            StringRows.Clear();
            AddMinimumRowsNeeded();
            // start adding more rows with messages for however many messages being passed.
            for (int i = 0; i < messages.Length; i++)
            {
                try
                {
                    StringRows[i + startIndex].Insert(0, messages[i]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    StringRows.Add(new StringBuilder(messages[i]));
                }
            }
        }

        /// <summary>
        /// Check the current count of rows. If not enough for console, will create more.
        /// </summary>
        static void AddMinimumRowsNeeded()
        {
            while (StringRows.Count < Console.WindowHeight/2)
            {
                StringRows.Add(new StringBuilder(Console.WindowWidth));
            }
        }

        /// <summary>
        /// Return the provided string with padding to the left to center it horiziontally.
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        static string PadToCenter(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }


        static void AddToStringRows(string message)
        {
            StringRows.RemoveAt(0);
            StringRows.Add(new StringBuilder(PadToCenter(message)));
        }

        static void AddToStringRows(string[] message)
        {
            foreach (var item in message)
            {
                AddToStringRows(item);
            }
        }

    }
}
