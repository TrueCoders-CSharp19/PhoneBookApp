namespace PhoneBookConsoleUI
{
    /*Account

        Feature Owner: Daniel Aguirre

        Feature Start Date : 9/6/2021

        Feature DeadLine : 

        Feature Goal: Store a list of contacts that are tied to a user account.

    */

    internal abstract class Account : IHaveAnOwner
    {
        //TODO: use logger to add new account to list when created.

        public Contact AccountOwner { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }

        public Account(Contact AccountOwner)
        {

        }


        /*

        account - string ownerName, list contacts, primary contact
        contact - string first name, string last name
        searchFeature
        ScreenPrinter
        LoggerClass - when we add to the contacts file

         */

    }
}