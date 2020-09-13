using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MidTermProject;

namespace Lab5
{
    class PersonV2 : Person
    {
        private string cellNum, instagramURL;
        public PersonV2(): base()
        {
            cellNum = "";
            instagramURL = "";
        }
        public PersonV2(Person p): base(p)
        {
            cellNum = "";
            instagramURL = "";
        }
        public PersonV2(Person p, string _cellNum, string _instagramURL): base(p)
        {
            CellNum = _cellNum;
            InstagramURL = _instagramURL;
        }
        public PersonV2(string _fName, string _mName, string _lName, string _streetOne, string _streetTwo, string _city, string _stateCode, string _zipCode, string _phoneNum, string _emailAddress, string _cellNum, string _instagramURL)
        :base(_fName, _mName, _lName, _streetOne, _streetTwo, _city, _stateCode, _zipCode, _phoneNum, _emailAddress)
        {
            CellNum = _cellNum;
            InstagramURL = _instagramURL;
        }
        public string CellNum
        {
            get
            {
                return cellNum;
            }
            set
            {
                if (BasicTools.isValidPhoneNum(value))
                    cellNum = value;
                else
                {
                    cellNum = "";
                    Feedback += "\n Error: Cell Phone Number";
                }
            }
        }
        public string InstagramURL
        {
            get
            {
                return instagramURL;
            }
            set
            {
                if (BasicTools.isValidURL(value))
                    instagramURL = value;
                else
                {
                    instagramURL = "";
                    Feedback += "\n Error: Instagram URL";
                }
            }
        }
    }
}
