using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
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
