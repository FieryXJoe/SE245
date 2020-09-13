using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MidTermProject;

namespace Lab5
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
            PersonV2 pv2 = new PersonV2();
            pv2.FName = txtFName.Text;
            pv2.MName = txtMName.Text;
            pv2.LName = txtLName.Text;
            pv2.StreetOne = txtStreetOne.Text;
            pv2.StreetTwo = txtStreetTwo.Text;
            pv2.City = txtCity.Text;
            pv2.StateCode = txtStateCode.Text;
            pv2.ZipCode = txtZipCode.Text;
            pv2.PhoneNum = txtPhoneNum.Text;
            pv2.EmailAddress = txtEmailAddress.Text;
            //New
            pv2.CellNum = txtCellPhoneNum.Text;
            pv2.InstagramURL = txtInstagramURL.Text;
            //This code vastly shortened by moving error feedback to object
            if (pv2.Feedback.Contains("Error"))
            {
                lblErrorMsg.Text = pv2.Feedback;
                pv2.Feedback = "";
            }
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

                txtCellPhoneNum.Text = "";
                txtInstagramURL.Text = "";

                setFeedbackV2(pv2);
                people.Add(pv2);
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
        private void setFeedbackV2(PersonV2 p)
        {
            String s = "";
            s += $"\n Name: {p.FName} {p.MName} {p.LName}";
            s += $"\n Address: {p.StreetOne} {p.StreetTwo} , {p.City} {p.StateCode} , {p.ZipCode}";
            s += $"\n Phone Number: {p.PhoneNum} ,\n Cell Number: {p.CellNum}";
            s += $"\n Email: {p.EmailAddress} , \n Instagram : {p.InstagramURL}";
            lblFeedback.Text = s;
        }
    }
}
