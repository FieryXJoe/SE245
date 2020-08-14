using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    class Program
    {
        struct Person
        {
            public string fName, mName, lName, streetOne, streetTwo, city, stateCode, zipCode, phoneNum, emailAddress ;//Can't think of any reason this shouldn't work
        }
        static void Main(string[] args)
        {
            bool flag = true; //toggled by every do while once user input matches expectations
            long temp;//used for TryParse output to have a place to go, data never retrieved or used only written

            Person tempPerson = new Person();

            Console.Write("\nPlease enter the person's first name: ");
            tempPerson.fName = Console.ReadLine();

            Console.Write("\nPlease enter the person's middle name: ");
            tempPerson.mName = Console.ReadLine();

            Console.Write("\nPlease enter the person's last name: ");
            tempPerson.lName = Console.ReadLine();

            Console.Write("\nPlease enter the person's street address: ");
            tempPerson.streetOne = Console.ReadLine();

            Console.Write("\nPlease enter the person's secondary address info ex. Apt #: ");
            tempPerson.streetTwo = Console.ReadLine();

            Console.Write("\nPlease enter the person's city:");
            tempPerson.city = Console.ReadLine();

            do
            {
                Console.Write("\nPlease enter the person's state code:");
                tempPerson.stateCode = Console.ReadLine().ToUpper();
                if (tempPerson.stateCode.Length == 2)
                    flag = false;
            } while (flag);
            do
            {
                Console.Write("\nPlease enter the person's zip code:");
                tempPerson.zipCode = Console.ReadLine();
                if (tempPerson.zipCode.Length == 5 && Int64.TryParse(tempPerson.zipCode , out temp))
                    flag = true;
            } while (!flag);

            do
            {
                Console.Write("\nPlease enter the person's phone number (10 digit no format:");
                tempPerson.phoneNum = Console.ReadLine();
                if (tempPerson.phoneNum.Length == 10 && Int64.TryParse(tempPerson.phoneNum, out temp))
                    flag = false;
            } while (flag);

            do
            {
                Console.Write("\nPlease enter the person's email address:");
                tempPerson.emailAddress = Console.ReadLine();
                //Logic for if this is an email address I'll figure it out later
                var foo = new EmailAddressAttribute(); //got this idea from stackOverflow https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
                flag = foo.IsValid(tempPerson.emailAddress);
            } while (!flag);

            System.Console.Clear();

            Console.Write("\n\nThe Person object contains the following data...");
            Console.Write($"\n Name: {tempPerson.fName} {tempPerson.mName} {tempPerson.lName}");
            Console.Write($"\n Address: {tempPerson.streetOne} {tempPerson.streetTwo} , {tempPerson.city} {tempPerson.stateCode} , {tempPerson.zipCode}");
            Console.Write($"\n Phone Number: {tempPerson.phoneNum}");
            Console.Write($"\n EMail: {tempPerson.emailAddress}");

            BasicTools.pause();
        }
    }
}
