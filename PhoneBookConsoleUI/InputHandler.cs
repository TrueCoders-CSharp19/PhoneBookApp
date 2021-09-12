using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class InputHandler
    {

        /// <summary>
        /// Return true or false based on if Console.ReadLine matches string[] options. If true, out will provide the index that has the first match. Else will out null. If bool contains is true, then will check based on contains instead of exact matches.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="optionIndex"></param>
        /// <returns></returns>
        public static bool ValidateInput(string[] options, out int? optionIndex, bool contains)
        {
            if (contains)
            {
                var input = Console.ReadLine();
                for (int i = 0; i < options.Length; i++)
                {
                    if (options[i].ToLower().Contains(input.ToLower()))
                    {
                        optionIndex = i;
                        return true;
                    }
                }
                optionIndex = null;
                return false;
            }
            else return ValidateInput(options, out optionIndex);
        }

        /// <summary>
        /// Return true or false based on if Console.ReadLine matches string[] options. If true, out will provide the index that has the first match. Else will out null.
        /// </summary>
        /// <param name="options"></param>
        /// <param name="optionIndex"></param>
        /// <returns></returns>
        public static bool ValidateInput(string[] options, out int? optionIndex)
        {
            var input = Console.ReadLine();
            for (int i = 0; i < options.Length ; i++)
            {
                if(options[i].ToLower() == input.ToLower())
                {
                    optionIndex = i;
                    return true;
                }
            }
            optionIndex = null;
            return false;

        }


        #region Invalid Input Messages

        /// <summary>
        /// Invalid message to display if the entry is longer than the provided charLimit.
        /// </summary>
        /// <param name="charLimit"></param>
        static void InvalidInputMessage(int charLimit)
        {
            var limit = charLimit;
            ConsoleController.PrintVerticalHorizontal(new string[]
            {
                "I'm sorry, but I cannot accept your entry.", "",
                $"Your entry must be greater than 0 and less than {charLimit}", "",
                "Press any key to return. "
            }, true, true);
        }

        /// <summary>
        /// Clear Screen and print a message stating the input received and that it was invalid. Wait for keypress then clear.
        /// </summary>
        /// <param name="inputReceived"></param>
        static void InvalidInputMessage(char inputReceived)
        {
            var input = ConvertEnterChar(inputReceived);

            ConsoleController.PrintVerticalHorizontal(new string[] {
                $"I'm sorry, {input} is not a valid option.", "",
                "Press any key to return. "
            }, true, true);
        }

        #endregion

        /// <summary>
        /// Used to convert enter char to prevent issues with printing to the console.
        /// </summary>
        /// <param name="charToConvert"></param>
        /// <returns></returns>
        static string ConvertEnterChar(char charToConvert)
        {
            string lastInput = charToConvert.ToString();
            if (charToConvert == ((char)ConsoleKey.Enter))
            {
                lastInput = "Enter";
            }
            return lastInput;
        }


    }
}
