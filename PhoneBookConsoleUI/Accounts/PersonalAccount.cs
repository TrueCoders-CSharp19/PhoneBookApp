using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI.Accounts
{
    class PersonalAccount : Account
    {      

        public PersonalAccount(Contact accountContacts) : base(accountContacts)
        {

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
    }
}
