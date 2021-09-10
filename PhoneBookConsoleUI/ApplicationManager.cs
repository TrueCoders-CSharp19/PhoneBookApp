﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    public static class ApplicationManager
    {
        static bool ApplicationRunning { get; set; } = true;
        static ConsolePrinter Screen = new ConsolePrinter();

        public static void RunApplication()
        {
            GreetUser();
            //Primary loop to keep application running.
            while(ApplicationRunning)
            {
                MainMenu();
            }


        }



        public static void MainMenu()
        {

            Screen.PrintCentered(ConsolePrinter.MenuMessages, "MainMenu");
            var input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    //TODO: Show all contacts.
                    Screen.PrintCentered(ConsolePrinter.MenuMessages, "ContentNotCreated");
                    Console.ReadKey();
                    break;
                case '2':
                    //TODO: Access an account. (Search by phone number ?)
                    Screen.PrintCentered(ConsolePrinter.MenuMessages, "ContentNotCreated");
                    Console.ReadKey();
                    break;
                case '3':
                    Screen.PrintCentered(ConsolePrinter.MenuMessages, "EndApplication");
                    Console.ReadKey();
                    ApplicationRunning = false;
                    break;
                // if no match then will display no valid entry and then the loop in RunApplication() will return the user to the main menu screen.
                default:
                    Screen.PrintCentered(ConsolePrinter.MenuMessages, "ReturnForInvalidEntry");
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

        }

        public static void GreetUser()
        {


            Screen.PrintCentered(ConsolePrinter.MenuMessages, "Greeting");
            Console.ReadKey();

        }



    }
}
