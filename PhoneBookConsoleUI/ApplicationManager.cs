using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookConsoleUI.Accounts;
using PhoneBookConsoleUI.Contacts;

namespace PhoneBookConsoleUI
{
    public static class ApplicationManager 
    {
        static bool ApplicationRunning { get; set; } = true;

        static Account Account { get; set; }

        public static void RunApplication()
        {
            Account = new Account();
            GreetUser();
            //Primary loop to keep application running.
            while(ApplicationRunning)
            {
                MainMenu();
            }
        }


        /// <summary>
        /// Display Main Menu, Take in input, and then print next screen depending on input received.
        /// </summary>
        static void MainMenu()
        {            
            //ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages["SecondMessage"], "Selection: ");
            //var input = Console.ReadKey().KeyChar;
            switch (ConsolePrinter.NewOptionListMessage(ConsolePrinter.MenuMessages["SecondMessage"]))
            {
                case 1:
                    Account.ViewAllContacts();
                    break;
                case 2:
                    Account.AddContact();
                    break;
                case 3:
                    Account.EditContact();
                    break;
                case 4:
                    Account.RemoveContact();
                    break;
                case 5:
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages["EndApplication"]);
                    Console.ReadKey();
                    Console.Clear();
                    ApplicationRunning = false;
                    break;
                //// if no match then will display no valid entry and then the loop in RunApplication() will return the user to the main menu screen.
                //default:
                //    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages["ReturnForInvalidEntry"]);
                //    Console.ReadKey();
                //    Console.Clear();
                //    break;
            }

        }

        public static void GreetUser()
        {

            ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages["FirstMessage"]);
            Console.ReadKey();

        }



    }
}
