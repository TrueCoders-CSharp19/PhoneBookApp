namespace PhoneBookConsoleUI
{
    /*Account

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature Goal: Stores a list of related Contacts that are tied to a user account. Must be
            created using a Contact to list as the AccountOwner. Other than storing the primary
            account holder information, should only provide a list of contacts that belong to
            the account, and the ability to make changes to these properties of the class.

    */

    internal abstract class Account : IOwnable
    {
        /// <summary>
        /// Primary Contact - AccountOwner - will be used to search for accounts by the Contact.PhoneNumber, or Contact.LastNameFirstName
        /// </summary>
        Contact AccountOwner { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string PrimaryNumber { get; set; }


        /// <summary>
        /// List of Contacts that are registered to this account.
        /// </summary>
        ContactList AccountContacts { get; set; }

        /// <summary>
        /// Account Constructor requires a Contact that will be stored as the accountOwner.
        /// </summary>
        /// <param name="accountOwner"></param>
        Account(Contact accountOwner)
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
        /// Remove a contact from the account.
        /// </summary>
        public abstract void RemoveContact();

        /// <summary>
        /// View the Contacts listed this accounts AccountContacts ContactList.
        /// </summary>
        public abstract void ViewAccountContacts();

        /// <summary>
        /// Transfer ownership to new Contact. Requirements may vary based on Account type that inherits from Account.
        /// </summary>
        public abstract void TransferOwnership();

        /// <summary>
        /// Change the Primary Number tied to the account.
        /// </summary>
        public abstract void UpdatePrimaryNumber();
    }
}