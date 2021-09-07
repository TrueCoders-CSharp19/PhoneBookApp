using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{

    //TODO: Ask joey if he thinks we should tie Owners to Contacts at this level?

    interface IOwnable
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LastNameFirstName { get { return OwnerLastName + ", " + OwnerFirstName; } }

        public void TransferOwnership();

    }
}
