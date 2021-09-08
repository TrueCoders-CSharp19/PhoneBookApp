using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    /*Contact

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature DeadLine : 

        Feature Goal: Contact will represent a listing in the phone book and also will represent an
            entity that can access the phone book. They should have access to their own Favorite
            Contacts, Last Ten Searches, and other features such as that.

    */

    /// <summary>
    /// Contact represents a phone number, Owner (firstName and lastName) and a ParentAccount that it is tied to.
    /// </summary>
    public abstract class Contact : IOwnable
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LastNameFirstName { get { return OwnerLastName + ", " + OwnerFirstName; } }
        public string PhoneNumber { get; set; }
        public Account ParentAccount { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber)
        {
            OwnerFirstName = firstName;
            OwnerLastName = lastName;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Allow the contact to be moved to a new Parent Account. Either create a new account or search for and move to an existing account.
        /// </summary>
        /// <param name="createNewAccount"></param>
        public abstract void SwitchParentAccount(bool createNewAccount);

        /// <summary>
        /// Delete this contact, ensure it is removed from the parent account and any favorite lists
        /// that it may exist in.
        /// </summary>
        public abstract void DeleteContact();

        
        public abstract void TransferOwnership();
    }
}
