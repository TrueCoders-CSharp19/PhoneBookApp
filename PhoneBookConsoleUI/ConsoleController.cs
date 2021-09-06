using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class ConsoleController
    {
        //TODO: Can set up a param for TextAlignment to allow centering the message printed.
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
        
        public static void PrintToScreen(string[] message)
        {
            foreach (var str in message)
            {
                Console.WriteLine(message);
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
    }
}
