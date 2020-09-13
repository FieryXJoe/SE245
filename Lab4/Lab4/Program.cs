using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            //flag no longer needed comparing to default value "" now instead
            long temp;//used for TryParse output to have a place to go, data never retrieved or used only written

            Person tempPerson = new Person();

            Console.Write("\nPlease enter the person's first name: ");
            tempPerson.FName = Console.ReadLine();

            Console.Write("\nPlease enter the person's middle name: ");
            tempPerson.MName = Console.ReadLine();

            Console.Write("\nPlease enter the person's last name: ");
            tempPerson.LName = Console.ReadLine();

            Console.Write("\nPlease enter the person's street address: ");
            tempPerson.StreetOne = Console.ReadLine();

            Console.Write("\nPlease enter the person's secondary address info ex. Apt #: ");
            tempPerson.StreetTwo = Console.ReadLine();

            Console.Write("\nPlease enter the person's city:");
            tempPerson.City = Console.ReadLine();

            do
            {
                Console.Write("\nPlease enter the person's state code:");
                tempPerson.StateCode = Console.ReadLine().ToUpper();
            } while (tempPerson.StateCode == "");
            do
            {
                Console.Write("\nPlease enter the person's zip code:");
                tempPerson.ZipCode = Console.ReadLine();
            } while (tempPerson.ZipCode == "");

            do
            {
                Console.Write("\nPlease enter the person's phone number (10 digit no format:)");// forgot to add closing parenthese inside string in part 1 too lazy to fix
                tempPerson.PhoneNum = Console.ReadLine();
            } while (tempPerson.PhoneNum == "");

            do
            {
                Console.Write("\nPlease enter the person's email address:");
                tempPerson.EmailAddress = Console.ReadLine();
            } while (tempPerson.EmailAddress == "");

            System.Console.Clear();

            tempPerson.FName += "Poopy";//This code worked just fine no issues so don't understand the weakness mentioned

            Console.Write("\n\nThe Person object contains the following data...");
            Console.Write($"\n Name: {tempPerson.FName} {tempPerson.MName} {tempPerson.LName}");
            Console.Write($"\n Address: {tempPerson.StreetOne} {tempPerson.StreetTwo} , {tempPerson.City} {tempPerson.StateCode} , {tempPerson.ZipCode}");
            Console.Write($"\n Phone Number: {tempPerson.PhoneNum}");
            Console.Write($"\n EMail: {tempPerson.EmailAddress}");

            BasicTools.pause();
        }
    }
}
