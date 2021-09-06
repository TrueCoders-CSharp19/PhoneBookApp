using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{


    class ContactList
    {
        public List<Contact> Contacts { get; set; }

        public void RegisterContact(Contact contactToRegister)
        {
            Contacts.Add(contactToRegister);
        }

    }
}
