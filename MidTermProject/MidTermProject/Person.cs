using System;
using System.Collections.Generic;
using System.Text;

namespace MidTermProject
{
    class Person
    {
        //Would in real application add constructors and add methods to get things like statecode, phone num in different formats or phone/zipcode in num data type or to get full name
        private string fName, mName, lName, streetOne, streetTwo, city, stateCode, zipCode, phoneNum, emailAddress;//Since I already made the gets and sets this is literally the only line of code that changes between parts 2 & 3 
        //Already know the differences between public and private from java experience
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
                if (BasicTools.isValidEmail(value))
                    emailAddress = value;
                else
                    emailAddress = "";
            }
        }
    }
}
