using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{

    //TODO:
    //
    //  Should we have AccountList and ContactList either inherit from the same base class or 
    //  implement the same interface for similar actions such as Registering a new object, Deleting
    //  an object, etc ?
    class AccountList
    {

        static List<Account> AllAccounts { get; set; }

        /// <summary>
        /// Add the provided newAccount to the static list of AllAccounts
        /// </summary>
        /// <param name="newAccount"></param>
        public static void StoreNewAccount(Account newAccount)
        {
            AllAccounts.Add(newAccount);
        }



    }
}
