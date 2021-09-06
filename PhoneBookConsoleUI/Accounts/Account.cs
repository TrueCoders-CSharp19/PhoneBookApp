namespace PhoneBookConsoleUI
{
    /*Account

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature Goal: Store a list of contacts that are tied to a user account.

    */

    internal abstract class Account : IOwnable
    {
        /// <summary>
        /// Primary Contact - AccountOwner - will be used to search for accounts by the Contact.PhoneNumber, or Contact.LastNameFirstName
        /// </summary>
        public Contact AccountOwner { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }

        /// <summary>
        /// List of Contacts that are registered to this account.
        /// </summary>
        public ContactList AccountContacts { get; set; }

        /// <summary>
        /// Account Constructor requires a Contact that will be stored as the accountOwner.
        /// </summary>
        /// <param name="accountOwner"></param>
        public Account(Contact accountOwner)
        {
            AccountOwner = accountOwner;
            OwnerFirstName = AccountOwner.OwnerFirstName;
            OwnerLastName = AccountOwner.OwnerLastName;
        }

        /// <summary>
        /// Add a contact to the account.
        /// </summary>
        public abstract void AddContact();
        
        /// <summary>
        /// View the Contacts listed this accounts AccountContacts ContactList.
        /// </summary>
        public abstract void ViewAccountContacts();



    }
}