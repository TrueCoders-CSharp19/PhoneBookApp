using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PhoneBookConsoleUI
{
    class ConsolePrinter
    {

        public static Dictionary<string, string[]> MenuMessages = new Dictionary<string, string[]>
        {
            {"FirstMessage", new string[] {
                "Welcome to our Phone Book Application", "", 
                "Created by Joey Stilley and Daniel Aguirre", "",
                "Press any key to continue."} },
            
            {"SecondMessage", new string[] {
                "Please select what you would like to do next: ", "",
                "1) Show all contacts  ",
                "2) Access my account  ",
                "3) End the application"} }
        };

        /// <summary>
        /// List of StringBuilders so that I can remove them or add them as needed based on console size.
        /// </summary>
        List<StringBuilder> StringRows;

        public ConsolePrinter ()
        {
            StringRows = new List<StringBuilder>() { new StringBuilder(Console.WindowWidth) };
            UpdateStringRowsCount();
        }

        /// <summary>
        /// Take in a string key and write a message corresponding to that key in the dictionary 
        /// </summary>
        /// <param name="key"></param>
        public void PrintCentered(string key)
        {
            CheckRowCount();
            var messages = MenuMessages[key].Select(x => PadToCenter(x)).ToArray();
            var startIndex = (Console.WindowHeight / 2) - (messages.Length / 2);
            UpdateRows(ref StringRows, startIndex, messages);
            PrintAll(StringRows);
        }

        /// <summary>
        /// Foreach row in the provided list, call a Console.WriteLine()
        /// </summary>
        /// <param name="stringRows"></param>
        void PrintAll(List<StringBuilder> stringRows)
        {
            foreach (var row in StringRows)
            {
                Console.WriteLine(row);
            }
        }

        /// <summary>
        /// First clear all strings, then add each string in the message provided
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="startIndex"></param>
        /// <param name="messages"></param>
        void UpdateRows(ref List<StringBuilder> rows, int startIndex, string[] messages)
        {
            ClearAllStrings();
            for (int i = 0; i < messages.Length; i++)
            {
                StringRows[i + startIndex].Insert(0, messages[i]);
            }
        }

        /// <summary>
        /// Check the current count of rows. If not enough for console, will create more.
        /// </summary>
        void CheckRowCount()
        {
            if(StringRows.Count < Console.WindowHeight)
            {
                UpdateStringRowsCount();
            }
        }

        /// <summary>
        /// Clear all rows to ensure no messages are being displayed when printing a new screen.
        /// </summary>
        void ClearAllStrings()
        {
            StringRows = StringRows.Select(x => x.Clear()).ToList();
        }

        /// <summary>
        /// Add more rows of StringBuilders while the count is less than the Console.WindowWidth
        /// </summary>
        void UpdateStringRowsCount()
        {
           
            while (StringRows.Count < Console.WindowHeight)
            {
                StringRows.Add(new StringBuilder(Console.WindowWidth));
            }
            
        }

        /// <summary>
        /// Return the provided string with padding to the left to center it horiziontally.
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        string PadToCenter(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }


    }
}
