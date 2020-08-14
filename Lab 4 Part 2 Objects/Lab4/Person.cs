using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab4
{
    class Person
    {
        //Would in real application add constructors and add methods to get things like statecode, phone num in different formats or phone/zipcode in num data type or to get full name
        public string fName, mName, lName, streetOne, streetTwo, city, stateCode, zipCode, phoneNum, emailAddress;
        public string FName
        {
            get
            {
                return fName;
            }
            set
            {
                fName = value;
            }
        }
        public string MName
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }
        public string LName
        {
            get
            {
                return lName;
            }
            set
            {
                lName = value;
            }
        }
        public string StreetOne
        {
            get
            {
                return streetOne;
            }
            set
            {
                streetOne = value;
            }
        }
        public string StreetTwo
        {
            get
            {
                return streetTwo;
            }
            set
            {
                streetTwo = value;
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }
        }
        public string StateCode
        {
            get
            {
                return stateCode;
            }
            set
            {
                //Conditional sets all copy paste from do while loops in previous assignment now while condition is while value is ""
                if (value.Length == 2)
                    stateCode = value.ToUpper();
                else
                    stateCode = "";
            }
        }
        public string ZipCode
        {
            get
            {
                return zipCode;
            }
            set
            {
                long temp;
                if (value.Length == 5 && Int64.TryParse(value, out temp))
                    zipCode = value;
                else
                    zipCode = "";
            }
        }
        public string PhoneNum
        {
            get
            {
                return phoneNum;
            }
            set
            {
                long temp;
                if (value.Length == 10 && Int64.TryParse(value, out temp))
                    phoneNum = value;
                else
                    phoneNum = "";
            }
        }
        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                //got this idea from stackOverflow https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
                EmailAddressAttribute foo = new EmailAddressAttribute();//weirdly enoguh was not allowed to have var of type var in code for an object or maybe outside main method instead need to be specific with type EmailAddressAttribute at declaration
                if (foo.IsValid(value))
                    emailAddress = value;
                else
                    emailAddress = "";
            }
        }
    }
}
