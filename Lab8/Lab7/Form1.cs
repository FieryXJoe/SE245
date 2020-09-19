using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

using MidTermProject;
using Lab5;

namespace Lab5Part3
{
    public partial class Form1 : Form
    {
        List<Person> people = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Function for displaying a persons data using the "Enter a New Person" Form
         * Which I kinda think seems like a terrible way to do it.
         */
        public Form1(int intPersonID)
        {
            InitializeComponent();

            PersonV2 temp = new PersonV2();
            SqlDataReader dr = temp.FindOnePersonV2(intPersonID);

            while (dr.Read())
            {
                //Add all string data to form
                txtFName.Text = dr["FName"].ToString();
                txtMName.Text = dr["MName"].ToString();
                txtLName.Text = dr["LName"].ToString();
                txtStreetOne.Text = dr["StreetOne"].ToString();
                txtStreetTwo.Text = dr["StreetTwo"].ToString();
                txtCity.Text = dr["City"].ToString();
                txtStateCode.Text = dr["StateCode"].ToString();
                txtZipCode.Text = dr["ZipCode"].ToString();
                txtPhoneNum.Text = dr["PhoneNum"].ToString();
                txtEmailAddress.Text = dr["Email"].ToString();
                txtCellPhoneNum.Text = dr["CellNum"].ToString();
                txtInstagramURL.Text = dr["InstagramURL"].ToString();
                lblPersonID.Text = "PersonID: " + dr["PersonID"].ToString();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            PersonV2 c = new PersonV2();//keeping this called c instead of pv2 for ease of conversion
            c.FName = txtFName.Text;
            c.MName = txtMName.Text;
            c.LName = txtLName.Text;
            c.StreetOne = txtStreetOne.Text;
            c.StreetTwo = txtStreetTwo.Text;
            c.City = txtCity.Text;
            c.StateCode = txtStateCode.Text;
            c.ZipCode = txtZipCode.Text;
            c.PhoneNum = txtPhoneNum.Text;
            c.EmailAddress = txtEmailAddress.Text;
            c.CellNum = txtCellPhoneNum.Text;
            c.InstagramURL = txtInstagramURL.Text;
            /*Was previously taking advantage of polymorphism that a Customer without any customer 
             * unique data was essentially a PersonV2 object with access to all its stuff so I 
             * kept it Customer and treated it like a PV2 and passed it to PV2 feedback function*/

            //This code vastly shortened by moving error feedback to object
            if (c.Feedback.Contains("Error"))
            {
                lblErrorMsg.Text = c.Feedback;
                c.Feedback = "";
            }
            //Successful submission code
            else
            {
                lblErrorMsg.Text = "Input Errors: NONE";
                lblErrorMsg.Text += c.AddARecord();

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

    //            checkBoxDiscountMember.Checked = false;
    //            txtRewardsEarned.Text = "";
    //            txtTotalPurchases.Text = "";

                setFeedbackV2(c);
                people.Add(c);
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

        //NEW for Lab 8
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //If it is empty, they didnt get here from search and this should do nothing
            if (lblPersonID.Text != "PersonID:")
            {
                string idStr = lblPersonID.Text;
                idStr = idStr.Replace("PersonID: ", "");//strip string down to just a number
                int id = Convert.ToInt32(idStr);

                PersonV2 temp = new PersonV2();

                lblFeedback.Text = temp.DeleteOnePersonV2(id);
            }
            else//this runs if they try to delete with a form they filled out by hand
                lblFeedback.Text = "Cant delete record not accessed through search";
        }

        //New for Lab 8
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblPersonID.Text != "PersonID:")
            {
                string idStr = lblPersonID.Text;
                idStr = idStr.Replace("PersonID: ", "");//strip string down to just a number
                int id = Convert.ToInt32(idStr);

                PersonV2 temp = new PersonV2();

                temp.FName = txtFName.Text;
                temp.MName = txtMName.Text;
                temp.LName = txtLName.Text;
                temp.StreetOne = txtStreetOne.Text;
                temp.StreetTwo = txtStreetTwo.Text;
                temp.City = txtCity.Text;
                temp.StateCode = txtStateCode.Text;
                temp.ZipCode = txtZipCode.Text;
                temp.PhoneNum = txtPhoneNum.Text;
                temp.EmailAddress = txtEmailAddress.Text;
                temp.CellNum = txtCellPhoneNum.Text;
                temp.InstagramURL = txtInstagramURL.Text;

                if (!temp.Feedback.Contains("ERROR:"))
                {
                    lblFeedback.Text = temp.UpdateAPersonV2(id);
                }
                else
                {
                    lblFeedback.Text = temp.Feedback;
                }
            }
            else
                lblFeedback.Text = "Cant update record not accessed through search";
        }
    }
}
