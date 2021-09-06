using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBookConsoleUI
{
    /*Account

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature DeadLine : 

        Feature Goal: Contact will store an entity that has a collection of phone numbers

    */

    class Contact : IHaveAnOwner
    {
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public string PhoneNumber { get; set; }


        public Contact(string firstName, string lastName, string phoneNumber)
        {
            OwnerFirstName = firstName;
            OwnerLastName = lastName;
            PhoneNumber = phoneNumber;
        }



    }
}
