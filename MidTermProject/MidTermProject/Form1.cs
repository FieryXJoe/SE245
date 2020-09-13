using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTermProject
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.FName = txtFName.Text;
            p.MName = txtMName.Text;
            p.LName = txtLName.Text;
            p.StreetOne = txtStreetOne.Text;
            p.StreetTwo = txtStreetTwo.Text;
            p.City = txtCity.Text;
            p.StateCode = txtStateCode.Text;
            p.ZipCode = txtZipCode.Text;
            p.PhoneNum = txtPhoneNum.Text;
            p.EmailAddress = txtEmailAddress.Text;

            /*Wanted to do a for each loop on p here and use nameOf but couldn't do ...
             "foreach(field in p)" I think because p's fields are all private
             This also doesn't check if fields like Name were left empty but doesn't
            seem required*/
            if (p.StateCode == "")
                lblErrorMsg.Text = "Input Errors: Error with 2 Character State Code";
            else if (p.ZipCode == "")
                lblErrorMsg.Text = "Input Errors: Error with 5 Digit ZIP Code";
            else if (p.PhoneNum == "")
                lblErrorMsg.Text = "Input Errors: Error with 10 Digit Unformatted Phone #";
            else if (p.EmailAddress == "")
                lblErrorMsg.Text = "Input Errors: Error with the Email Address";
            //Successful submission code
            else
            {
                lblErrorMsg.Text = "Input Errors: NONE";
                txtFName.Text = "";
                txtMName.Text = "";
                txtLName.Text = "";
                txtStreetOne.Text = "";
                txtStreetTwo.Text = "";
                txtCity.Text = "";
                txtStateCode.Text = "";
                txtZipCode.Text = "";
                txtPhoneNum.Text = "";
                txtEmailAddress.Text = "";

                setFeedback(p);
                people.Add(p);
            }
        }

        // Takes a person object and formats the data and outputs it in GUI
        private void setFeedback(Person p)
        {
            String s = "";
            s += $"\n Name: {p.FName} {p.MName} {p.LName}";
            s += $"\n Address: {p.StreetOne} {p.StreetTwo} , {p.City} {p.StateCode} , {p.ZipCode}";
            s += $"\n Phone Number: {p.PhoneNum}";
            s += $"\n Email: {p.EmailAddress}";
            lblFeedback.Text = s;
        }
    }
}
