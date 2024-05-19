using System;
    class Sandbox {
        static void Main(string[] args)
        {
            Person fred = new Person();
            fred.givenName = "Fred";
            fred.familyName = "Johnson";

            Person steve = new Person();
            steve.givenName = "steve";
            steve.familyName = "Peterson";

            fred.EasternStyleName();
            steve.WesternStyleName();

        }
    }
