using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class ConsoleController
    {


        public enum TextAlignment { Default, Horizontal, VerticalHorizontal }

        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine()
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintToScreen(string message, bool dontEndLine)
        {
            if (dontEndLine)
            {
                Console.Write(message);
            }
            else
            {
                Console.WriteLine(message);
            }
        }
   
        /// <summary>
        /// Print the provided string with WriteLine or Write dependant upon dontEndLine, and centered based on TextAlignment enum.
        /// </summary>
        public static void PrintToScreen(string message, bool dontEndLine, TextAlignment textAlignment)
        {
            PrintToScreen(AlignText(message, textAlignment), dontEndLine);
        }
 
        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine(). Clear the screen after keypress if clearAfterKeyPress is true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        /// <param name="clearAfterKeypress"></param>
        public static void PrintToScreen(string message, bool dontEndLine, bool clearAfterKeypress)
        {
            PrintToScreen(message, dontEndLine);
            if(clearAfterKeypress)
            {
                Clear(true);
            }
        }

        /// <summary>
        /// Print the provided string with WriteLine or Write dependant upon dontEndLine, and centered based on TextAlignment enum. Clear screen after key press if true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        /// <param name="clearAfterKeypress"></param>
        /// <param name="textAlignment"></param>
        public static void PrintToScreen(string message, bool dontEndLine, bool clearAfterKeypress, TextAlignment textAlignment)
        {
            PrintToScreen(message, dontEndLine, textAlignment);
            if (clearAfterKeypress)
            {
                Clear(true);
            }
        }

        /// <summary>
        /// Print an array of messages to the console, each on their own line.
        /// </summary>
        /// <param name="message"></param>
        public static void PrintToScreen(string[] message)
        {
            foreach (var str in message)
            {
                Console.WriteLine(message);
            }
        }

        /// <summary>
        /// Print an array of messages to the console, each on their own line using the provided textAlignment.
        /// </summary>
        /// <param name="message"></param>
        public static void PrintToScreen(string[] message, TextAlignment textAlignment)
        {           
            foreach (var msg in message)
            {
                Console.WriteLine(AlignText(msg, textAlignment));
            }
        }

        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine()
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintToScreen(string[] message, bool dontEndLine)
        {
            if (dontEndLine)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != message.Length - 1)
                    {
                        Console.WriteLine(message[i]);
                    }
                    else
                    {
                        Console.Write(message[i]);
                    }
                }
            }
            else PrintToScreen(message);
        }

        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine()
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintToScreen(string[] message, bool dontEndLine, TextAlignment textAlignment)
        {
            var alignedMessages = AlignText(message, textAlignment);
            PrintToScreen(alignedMessages, dontEndLine);
        }

        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine(). Clear the screen after keypress if clearAfterKeyPress is true.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintToScreen(string[] message, bool dontEndLine, bool clearAfterKeypress)
        {
            PrintToScreen(message, dontEndLine);
            if(clearAfterKeypress)
            {
                Clear(true);
            }
        }

        /// <summary>
        /// Print the provided string to the console. If dontEndLine then will use Console.Write, else will WriteLine(). Clear the screen after keypress if clearAfterKeyPress is true. Center text based on textAlignment
        /// </summary>
        /// <param name="message"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintToScreen(string[] message, bool dontEndLine, bool clearAfterKeypress, TextAlignment textAlignment)
        {
            AlignText(message, textAlignment);
            PrintToScreen(message, dontEndLine);
            if (clearAfterKeypress)
            {
                Clear(true);
            }
        }


        #region SkipLines

        /// <summary>
        /// Skip lines to center the current line vertically.
        /// </summary>
        public static void SkipLines()
        {
            for (int i = 0; i < (Console.WindowHeight / 2); i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip a specified number of lines.
        /// </summary>
        /// <param name="linesToSkip"></param>
        public static void SkipLines(int linesToSkip)
        {
            for (int i = 0; i < linesToSkip; i++)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Skip lines based on a provided array of strings to center the array of strings vertically.
        /// </summary>
        /// <param name="arrayToReference"></param>
        public static void SkipLines(string[] arrayToReference)
        {
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayToReference.Length / 2); i++)
            {
                Console.WriteLine();
            }
        }

        #endregion

        #region Clear Console

        /// <summary>
        /// If true, wait for user to press a key then clear. Else just clear.
        /// </summary>
        /// <param name="waitForKeyPress"></param>
        public static void Clear(bool waitForKeyPress)
        {
            if (waitForKeyPress)
            {
                Console.ReadKey();
                Console.Clear();
            }
            else
                Console.Clear();
        }
        
        /// <summary>
        /// Clear Console then reprint the provided array of strings.
        /// </summary>
        /// <param name="ArrayToReprintAfterClear"></param>
        public static void Clear(string[] ArrayToReprintAfterClear)
        {
            Console.Clear();
            PrintToScreen(ArrayToReprintAfterClear);
        }
        
        /// <summary>
        /// Wait for KeyPress, Clear Console, and then Reprint the provided array.
        /// </summary>
        /// <param name="waitForKeyPress"></param>
        /// <param name="ArrayToReprintAfterClear"></param>
        public static void Clear(bool waitForKeyPress, string[] ArrayToReprintAfterClear)
        {
            if (waitForKeyPress)
            {
                Console.ReadKey();
                Clear(ArrayToReprintAfterClear);
            }
            else
            {
                Clear(ArrayToReprintAfterClear);
            }
        }

        #endregion

        #region Alignment Helpers
        /// <summary>
        /// Return the provided string, with padding to the left to center it horizontally on the screen based on Console.WindowWidth
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        static string CenterHorizontal(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }
       
        /// <summary>
        /// return text that has been aligned based on the TextAlignment enum provided.
        /// </summary>
        /// <param name="textToAlign"></param>
        /// <param name="textAlignment"></param>
        /// <returns></returns>
        static string AlignText(string textToAlign, TextAlignment textAlignment)
        {
            string text = textToAlign;
            // if not default then will center horizontally.
            if (textAlignment != TextAlignment.Default)
            {
                text = CenterHorizontal(textToAlign);
            }
            // if vertical then will skip lines.
            if (textAlignment == TextAlignment.VerticalHorizontal)
            {
                SkipLines();
            }
            return text;
        }

        /// <summary>
        /// return text that has been aligned based on the TextAlignment enum provided.
        /// </summary>
        /// <param name="textToAlign"></param>
        /// <param name="textAlignment"></param>
        /// <returns></returns>
        static string[] AlignText(string[] textToAlign, TextAlignment textAlignment)
        {
            string[] text = textToAlign;
            // if not default then will center horizontally.
            if (textAlignment != TextAlignment.Default)
            {
                for (int i = 0; i < text.Length - 1; i++)
                {
                    text[i] = CenterHorizontal(text[i]);
                }
            }
            // if vertical then will skip lines.
            if (textAlignment == TextAlignment.VerticalHorizontal)
            {
                SkipLines();
            }
            return text;
        }

        #endregion
    }
}
