using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{

    interface IOwnable
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LastNameFirstName { get; }

        public void TransferOwnership();
    }
}
