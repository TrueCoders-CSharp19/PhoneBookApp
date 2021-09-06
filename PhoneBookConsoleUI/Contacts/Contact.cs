using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    /*Contact

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature DeadLine : 

        Feature Goal: Contact will store an entity that has a collection of phone numbers

    */

    /// <summary>
    /// Contact represents a phone number, Owner (firstName and lastName) and a ParentAccount that it is tied to.
    /// </summary>
    class Contact : IOwnable
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string PhoneNumber { get; set; }
        public Account ParentAccount { get; set; }

        public Contact(string firstName, string lastName, string phoneNumber)
        {
            OwnerFirstName = firstName;
            OwnerLastName = lastName;
            PhoneNumber = phoneNumber;
        }



    }
}
