using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
        static List<StringBuilder> ScreenRows;

        static ConsolePrinter ()
        {
            ScreenRows = new List<StringBuilder>() { new StringBuilder(Console.WindowWidth) };
            AddMinimumRowsNeeded();
        }


        #region Input Messages


        /// <summary>
        /// Clear the screen then Cycle through the newMessage until the user confirms their input. baseMessage reflects all strings above where the user types. inputRequestMessage reflects the text that appears directly in front of where the user types their response.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="inputRequestMessage"></param>
        /// <returns></returns>
        public static string NewStringRequestMessage(string[] newMessage, string inputRequestMessage)
        {
            
            bool inputconfirmed = false;
            bool removeExtraMessage = false;
            string input = string.Empty;
            while (!inputconfirmed)
            {
                NewMessage(newMessage, inputRequestMessage);
                input = Console.ReadLine();
                if (input == ConsoleKey.Enter.ToString())
                {
                    input = "Enter";
                }
                AddToScreen($"Your entered: {input}.", "Is this correct? ");
                // if users input does not start  with y, is correct, or is true (with a couple typos allowed)
                if (!new Regex(@"(^y+|corr?ect|true?)").IsMatch(Console.ReadLine().ToLower()))
                {
                    //TODO: test the countToRemove with using a string[] base message instead of just a string message.
                    // if it doesn't work properly, then logic for countToRemove should be changed to be dependant
                    // on the baseMessage.Length ..... Pretty sure this will need to be implemented.
                    // change the number of rows to remove based on if we have already looped before, to remove the message printed next.
                    int countToRemove = removeExtraMessage ? 6 : 4;
                    RemoveLastRows(countToRemove);
                    AddToScreen("Alright then, lets try this again...");
                    removeExtraMessage = true;
                }
                else
                {
                    inputconfirmed = true;
                }
            }
            return input;
        }


        /// <summary>
        /// Cycle through a message that is displayed below the current screen until the user confirms their input. baseMessage reflects all strings above where the user types. inputRequestMessage reflects the text that appears directly in front of where the user types their response.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="inputRequestMessage"></param>
        /// <returns></returns>
        public static string StackedStringRequestMessage(string[] newMessage, string inputRequestMessage)
        {
            bool inputconfirmed = false;
            bool removeExtraMessage = false;
            string input = string.Empty;
            while (!inputconfirmed)
            {
                AddToScreen(newMessage, inputRequestMessage);
                input = Console.ReadLine();
                if (input == ConsoleKey.Enter.ToString())
                {
                    input = "Enter";
                }
                AddToScreen($"Your entered: {input}.", "Is this correct? ");
                // if users input does not start  with y, is correct, or is true (with a couple typos allowed)
                if (!new Regex(@"(^y+|corr?ect|true?)").IsMatch(Console.ReadLine().ToLower()))
                {
                    //TODO: test the countToRemove with using a string[] base message instead of just a string message.
                    // if it doesn't work properly, then logic for countToRemove should be changed to be dependant
                    // on the baseMessage.Length ..... Pretty sure this will need to be implemented.
                    // change the number of rows to remove based on if we have already looped before, to remove the message printed next.
                    int countToRemove = removeExtraMessage ? 6 : 4;
                    RemoveLastRows(countToRemove);
                    AddToScreen("Alright then, lets try this again...");
                    removeExtraMessage = true;
                }
                else
                {
                    inputconfirmed = true;
                }
            }
            return input;
        }

        /// <summary>
        /// Cycle through a message that is displayed below the current screen until the user confirms their input. baseMessage reflects all strings above where the user types. inputRequestMessage reflects the text that appears directly in front of where the user types their response.
        /// </summary>
        /// <param name="newMessage"></param>
        /// <param name="inputRequestMessage"></param>
        /// <returns></returns>
        public static string StackedStringRequestMessage(string newMessage, string inputRequestMessage)
        {
            bool inputconfirmed = false;
            bool removeExtraMessage = false;
            string input = string.Empty;
            while (!inputconfirmed)
            {
                AddToScreen(newMessage, inputRequestMessage);
                input = Console.ReadLine();
                if (input == ConsoleKey.Enter.ToString())
                {
                    input = "Enter";
                }
                AddToScreen($"Your entered: {input}", "Is this correct? ");
                // if users input does not start  with y, is correct, or is true (with a couple typos allowed)
                if (!new Regex(@"(^y+|corr?ect|true?)").IsMatch(Console.ReadLine().ToLower()))
                {
                    // change the number of rows to remove based on if we have already looped before, to remove the message printed next.
                    int countToRemove = removeExtraMessage ? 6 : 4;
                    RemoveLastRows(countToRemove);
                    AddToScreen("Alright then, lets try this again...");
                    removeExtraMessage = true;
                }
                else
                {
                    inputconfirmed = true;
                }
            }
            return input;
        }

        /// <summary>
        /// Print the message provided on a loop until the player provides a valid input option. Numbers available is dependant on how many messages match @"[\d]+)"
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static int NewOptionListMessage(string[] message)
        {
            int maxNumber = message.Where(x => new Regex(@"^[\d]+\)").IsMatch(x)).Count();
            char input = ' ';
            bool firstLoop = true;
            int result = 0;
            do
            {
                // print screen
                NewMessage(message);
                // if not the first loop, display invalid entry message.
                if (!firstLoop)
                {
                    // TODO: ternary
                    string invalid = input.ToString();
                    if (input == (char)ConsoleKey.Enter)
                    {
                        invalid = "Enter";
                    }
                    AddToScreen($"I'm sorry, {invalid} is not a valid entry.");
                }
                // get single char input from user
                input = Console.ReadKey().KeyChar;
                // if input is a one char digit
                if (new Regex(@"^[\d]$").IsMatch(input.ToString()))
                {
                    // then parse the input
                    result = int.Parse(input.ToString());
                    // if result is less than zero and is greater than option count then
                    // set result to zero so that we can go back through loop.
                    if (result < 0 | result > maxNumber)
                    {
                        result = 0;
                    }
                }
                if (result == 0)
                {
                    firstLoop = false;
                }
            } while (result == 0);

            return result;
        }

        #endregion

        #region Standard Messages

        /// <summary>
        /// Take in a Dictionary to search, and a key, then print a message centered vertically corresponding to that key.
        /// </summary>
        /// <param name="key"></param>
        public static void NewMessage(string[] newMessage)
        {
            AddMinimumRowsNeeded();
            var startIndex = (Console.WindowHeight / 2) - (newMessage.Length / 2);
            UpdateRows(startIndex, newMessage.Select(x => PadToCenter(x)).ToArray()); ;
            PrintAll();
        }

        /// <summary>
        /// Take in a Dictionary to search, and a key, then print a message followed by the inputRequestMessage centered vertically corresponding to that key. 
        /// </summary>
        /// <param name="key"></param>
        public static void NewMessage(string[] newMessage, string inputRequestMessage)
        {
            AddMinimumRowsNeeded();
            var messages = newMessage.Select(x => PadToCenter(x)).ToArray();
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
            AddToStringRows(newMessages);
            PrintAll(inputRequestMessage);
        }


        #endregion

        #region Internal Methods for Printing Screen.

        /// <summary>
        /// Clears console and then prints all ScreenRows to the console. the provided inputRequestMessage will be printed below the last newMessage line, with a space between the two.
        /// </summary>
        /// <param name="inputRequesetMessage"></param>
        static void PrintAll(string inputRequesetMessage)
        {

            Console.Clear();
            for (int i = 0; i < ScreenRows.Count; i++)
            {
                // if it's the last cycle of string rows.
                if (i == ScreenRows.Count - 1)
                {
                    // print last row and add two new lines for spacing
                    Console.WriteLine(ScreenRows[i] + "\n");
                    // then print "Selection: " before where the user types their input
                    Console.Write(inputRequesetMessage.PadLeft(Console.WindowWidth / 2));
                }
                else
                {
                    // otherwise if it's not the last row being printed then just keep printing rows
                    Console.WriteLine(ScreenRows[i]);
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
            foreach (var message in ScreenRows)
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
            ScreenRows.Clear();
            AddMinimumRowsNeeded();
            // start adding more rows with messages for however many messages being passed.
            for (int i = 0; i < messages.Length; i++)
            {
                try
                {
                    ScreenRows[i + startIndex].Insert(0, messages[i]);
                }
                catch (ArgumentOutOfRangeException)
                {
                    ScreenRows.Add(new StringBuilder(messages[i]));
                }
            }
        }

        /// <summary>
        /// Check the current count of rows. If not enough for console, will create more.
        /// </summary>
        static void AddMinimumRowsNeeded()
        {
            while (ScreenRows.Count < Console.WindowHeight / 2)
            {
                ScreenRows.Add(new StringBuilder(Console.WindowWidth));
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

        /// <summary>
        /// Remove a screen row from the top of the console, and then add the provided message to the bottom. This is used to stack a new message below an existing message.
        /// </summary>
        /// <param name="message"></param>
        static void AddToStringRows(string message)
        {
            ScreenRows.RemoveAt(0);
            ScreenRows.Add(new StringBuilder(PadToCenter(message)));
        }

        /// <summary>
        /// Remove a screen row (for each string) from the top of the console, and then add the string[] message to the bottom. This is used to stack new messages below an existing message.
        /// </summary>
        /// <param name="message"></param>
        static void AddToStringRows(string[] message)
        {
            foreach (var item in message)
            {
                AddToStringRows(item);
            }
        }

        /// <summary>
        /// Remove x many rows from bottom of the screen (most recent messages) based on countToRemove provided. Rows are inserted at the top of the screen to make up for those being removed.
        /// </summary>
        /// <param name="countToRemove"></param>
        static void RemoveLastRows(int countToRemove)
        {
            ScreenRows.RemoveRange(ScreenRows.Count - countToRemove, countToRemove);
            ScreenRows.InsertRange(0, new StringBuilder[countToRemove]);
        }

        #endregion

    }
}
