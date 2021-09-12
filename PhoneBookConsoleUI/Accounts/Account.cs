namespace PhoneBookConsoleUI
{
    /* Class Details

          Feature Owner:  Daniel Aguirre
    Feature Start Date :  9/6/2021
          Feature Goal :  Stores a list of related Contacts that are tied to a user account. 
                            Must be created using a Contact to list as the AccountOwner. Other
                            than storing the primary account holder information, should only 
                            provide a list of contacts that belong to the account, and the 
                            ability to make changes to the properties of this class.
    */

    public abstract class Account : IOwnable
    {
        /// <summary>
        /// Primary Contact - AccountOwner - will be used to search for accounts by the Contact.PhoneNumber, or Contact.LastNameFirstName
        /// </summary>
        public Contact AccountOwner { get; set; }
        public string[] ContactDetails { get { return UpdatedContactDetails(); } private set { ContactDetails = value; } }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LastNameFirstName { get { return OwnerLastName + ", " + OwnerFirstName; } }
        public string PrimaryNumber { get; set; }

        public string[] UpdatedContactDetails()
        {
            return new string[] { OwnerFirstName, OwnerLastName, LastNameFirstName, PrimaryNumber };
        }

        /// <summary>
        /// Account Constructor requires a Contact that will be stored as the accountOwner.
        /// </summary>
        /// <param name="accountOwner"></param>
        public Account(Contact accountOwner)
        {
            AccountOwner = accountOwner;
            OwnerFirstName = AccountOwner.FirstName;
            OwnerLastName = AccountOwner.LastName;
            ContactDetails = UpdatedContactDetails();
        }

        /// <summary>
        /// Add a contact to the account.
        /// </summary>
        public abstract void AddContact(Contact contact);

        /// <summary>
        /// Remove a contact from the account.
        /// </summary>
        public abstract void RemoveContact();

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