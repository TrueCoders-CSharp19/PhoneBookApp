using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI.Accounts
{
    class PersonalAccount : Account
    {      
        /// <summary>
        /// List of Contacts that are registered to this personal account.
        /// </summary>
        ContactList AccountContacts { get; set; }

        public PersonalAccount(Contact accountContacts) : base(accountContacts)
        {
            AccountContacts = new ContactList();
        }


        public override void AddContact()
        {
            throw new NotImplementedException();
        }

        public override void RemoveContact()
        {
            throw new NotImplementedException();
        }

        public override void TransferOwnership()
        {
            throw new NotImplementedException();
        }

        public override void UpdatePrimaryNumber()
        {
            throw new NotImplementedException();
        }

        public override void ViewAccountContacts()
        {
            throw new NotImplementedException();
        }
    }
}
