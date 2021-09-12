using System;
using System.Collections.Generic;
using System.Text;
using PhoneBookConsoleUI.Contacts;

namespace PhoneBookConsoleUI
{
    public static class ApplicationManager
    {
        static bool ApplicationRunning { get; set; } = true;

        public static void RunApplication()
        {
            GreetUser();
            //Primary loop to keep application running.
            while(ApplicationRunning)
            {
                MainMenu();
            }
        }



        static void MainMenu()
        {

            ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "SecondMessage", true);
            var input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    //TODO: Show all contacts.
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "ContentNotCreated", false);
                    Console.ReadKey();
                    break;
                case '2':
                    //TODO: Create a new contact
                    ContactFactory.CreateContact();
                    Console.ReadKey();
                    break;
                case '3':
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "EndApplication", false);
                    Console.ReadKey();
                    Console.Clear();
                    ApplicationRunning = false;
                    break;
                // if no match then will display no valid entry and then the loop in RunApplication() will return the user to the main menu screen.
                default:
                    ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "ReturnForInvalidEntry", false);
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

        }

        public static void GreetUser()
        {

            ConsolePrinter.NewMessage(ConsolePrinter.MenuMessages, "FirstMessage", false);
            Console.ReadKey();

        }



    }
}
