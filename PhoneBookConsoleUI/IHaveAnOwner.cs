using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{


    interface IHaveAnOwner
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string LastNameFirstName { get { return OwnerLastName + ", " + OwnerFirstName; } }

    }
}
