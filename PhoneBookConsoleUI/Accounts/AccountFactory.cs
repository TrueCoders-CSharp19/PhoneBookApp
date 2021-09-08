using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI.Accounts
{
    public static class AccountFactory
    {


        static List<Account> Accounts { get; set; }

        static AccountFactory()
        {
            Accounts = new List<Account>();
        }

        //TODO Expand this to ask what type of account to create, and to either obtain an existing contact or create a new contact to create the account with.
        public static Account CreateAccount(Contact primaryContactForNewAccount)
        {
            var account = new PersonalAccount(primaryContactForNewAccount);
            Accounts.Add(account);
            return account;
        }

        /// <summary>
        /// Search the AccountsList until we find an account by the primaryContact provided. Return true/false based on if Accounts contains a match. If a match is found then will out the match, otherwise will out null. 
        /// </summary>
        /// <param name="primaryContact"></param>
        /// <param name="accountFound"></param>
        /// <returns></returns>
        public static bool FindAccount(Contact primaryContact, out Account accountFound)
        {
            foreach (var account in Accounts)
            {
                if (account.AccountOwner == primaryContact)
                {
                    accountFound = account;
                    return true;
                }
            }
            accountFound = null;
            return false;
        }

    }
}
