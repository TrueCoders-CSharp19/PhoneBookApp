using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class ConsoleController
    {

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

        #region PrintCenteredHorizontal

        /// <summary>
        /// Print the provided string, centered horizontally, in a Console.WriteLine.
        /// </summary>
        public static void PrintHorizontal(string textToPrint)
        {
            Console.WriteLine(CenterHorizontal(textToPrint));
        }

        /// <summary>
        /// Print an array of strings, each centered horizontally on their current line.
        /// </summary>
        /// <param name="arrayOfStringsToPrint"></param>
        public static void PrintHorizontal(string[] arrayOfStringsToPrint)
        {
            foreach (var str in arrayOfStringsToPrint)
            {
                PrintHorizontal(str);
            }
        }

        /// <summary>
        /// Print the provided string, centered horizontally. If dontEndLine is true, then will use Console.Write() instead of WriteLine.
        /// </summary>
        /// <param name="textToPrint"></param>
        /// <param name="dontEndLine"></param>
        public static void PrintHorizontal(string textToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(textToPrint));
            }
            else PrintHorizontal(textToPrint);
        }

        /// <summary>
        /// Print an array of strings centered horizontally, each on their own line.  If dontEndLine then the last string will use Console.Write() instead of WriteLine(). 
        /// </summary>
        /// <param name="arrayOfStringsToPrint"> </param>
        /// <param name="dontEndLine"></param>
        public static void PrintHorizontal(string[] arrayOfStringsToPrint, bool dontEndLine)
        {
            if (dontEndLine)
            {
                for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != arrayOfStringsToPrint.Length - 1)
                    {
                        Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                    }
                    else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
            }
            else PrintHorizontal(arrayOfStringsToPrint);
        }

        /// <summary>
        /// Print an array of strings centered horizontally, each on their own line. If dontEndLine then the last string will use Console.Write() instead of WriteLine(). If trimEnd then will remove white spaces from the end of each string before printing.
        /// </summary>
        /// <param name="arrayOfStringsToPrint"></param>
        /// <param name="dontEndLine"></param>
        /// <param name="trimEnd"></param>
        public static void PrintHorizontal(string[] arrayOfStringsToPrint, bool dontEndLine, bool trimEnd)
        {
            if (dontEndLine && trimEnd)
            {
                for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
                {
                    // if it's not on the last cycle
                    if (i != arrayOfStringsToPrint.Length - 1)
                    {
                        Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i].TrimEnd()));
                    }
                    else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i].TrimEnd()));
                }
            }
            else if (!dontEndLine && trimEnd)
            {
                foreach (var str in arrayOfStringsToPrint)
                {
                    if (str != null)
                    {
                        // adding special if statement to not trim the first array to avoid issues with the cards being printed.
                        if (str == arrayOfStringsToPrint[0])
                        {
                            PrintHorizontal(str);
                        }
                        else
                        {
                            PrintHorizontal(str.TrimEnd());
                        }
                    }

                }
            }
            else if (dontEndLine && !trimEnd)
            {
                PrintHorizontal(arrayOfStringsToPrint, dontEndLine);
            }
            else PrintHorizontal(arrayOfStringsToPrint);
        }

        #endregion

        #region PrintCenteredVerticalHorizontal

        public static void PrintVerticalHorizontal(string stringToPrint)
        {
            Console.Clear();
            SkipLines();
            Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        public static void PrintVerticalHorizontal(string stringToPrint, bool dontEndLine)
        {
            Console.Clear();
            SkipLines(Console.WindowHeight / 2);
            if (dontEndLine)
            {
                Console.Write(CenterHorizontal(stringToPrint));
            }
            else Console.WriteLine(CenterHorizontal(stringToPrint));
        }
        public static void PrintVerticalHorizontal(string stringToPrint, bool dontEndLine, bool clearAfterReadKey)
        {
            PrintVerticalHorizontal(stringToPrint, dontEndLine);
            if (clearAfterReadKey)
            {
                Clear(true);
            }
        }
        public static void PrintVerticalHorizontal(string[] arrayOfStringsToPrint)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            foreach (var textLine in arrayOfStringsToPrint)
            {
                Console.WriteLine(CenterHorizontal(textLine));
            }
        }

        public static void PrintVerticalHorizontal(string[] arrayOfStringsToPrint, bool dontEndLastLine)
        {
            Console.Clear();
            SkipLines(arrayOfStringsToPrint);
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(CenterHorizontal(arrayOfStringsToPrint[i]));
            }
        }

        public static void PrintVerticalHorizontal(string[] arrayOfStringsToPrint, bool dontEndLastLine, bool clearAfterReadkey)
        {
            PrintVerticalHorizontal(arrayOfStringsToPrint, dontEndLastLine);
            if (clearAfterReadkey)
            {
                Clear(true);
            }
        }


        public static void PrintVerticalHorizontal(string[] arrayOfStringsToPrint, int lengthOfStringToMatchPaddingOf)
        {
            Clear();
            for (int i = 0; i < (Console.WindowHeight / 2) - (arrayOfStringsToPrint.Length); i++)
            {
                Console.WriteLine();
            }
            for (int i = 0; i < arrayOfStringsToPrint.Length; i++)
            {
                // if it's not on the last cycle
                if (i != arrayOfStringsToPrint.Length - 1)
                {
                    Console.WriteLine(CenterHorizontal(arrayOfStringsToPrint[i]));
                }
                else Console.Write(arrayOfStringsToPrint[i].PadLeft((Console.WindowWidth / 2) - ((lengthOfStringToMatchPaddingOf / 2) - arrayOfStringsToPrint[i].Length)));
            }
        }

        #endregion

        /// <summary>
        /// Return the provided string, with padding to the left to center it horizontally on the screen based on Console.WindowWidth
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        public static string CenterHorizontal(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }

        /// <summary>
        /// Clear Console
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// Clear Console after key press.
        /// </summary>
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
            PrintVerticalHorizontal(ArrayToReprintAfterClear);
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


    }
}
