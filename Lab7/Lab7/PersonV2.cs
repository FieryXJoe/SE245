using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MidTermProject;
using System.Data;
using System.Data.SqlClient;

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
                if (BasicTools.isValidInstaURL(value))
                    instagramURL = value;
                else
                {
                    instagramURL = "";
                    Feedback += "\n Error: Instagram URL";
                }
            }
        }

        public string AddARecord()
        {
            string strResult = "";

            SqlConnection Conn = new SqlConnection();

            Conn.ConnectionString = GetConnectionStr(); 

            string strSQL = "INSERT INTO PersonV2 (FName, MName, LName, StreetOne, StreetTwo, City, StateCode, ZipCode, PhoneNum, Email, CellNum, InstagramUrl) VALUES (@FName, @MName, @LName, @StOne, @StTwo, @City, @StCode, @ZipCode, @PhoneNum, @Email, @CellNum, @InstaURL)";

            SqlCommand comm = new SqlCommand();
            comm.CommandText = strSQL; 
            comm.Connection = Conn;
            comm.Parameters.AddWithValue("@FName", FName);
            comm.Parameters.AddWithValue("@MName", MName);
            comm.Parameters.AddWithValue("@LName", LName);
            comm.Parameters.AddWithValue("@StOne", StreetOne);
            comm.Parameters.AddWithValue("@StTwo", StreetTwo);
            comm.Parameters.AddWithValue("@City", City);
            comm.Parameters.AddWithValue("@StCode", StateCode);
            comm.Parameters.AddWithValue("@ZipCode", ZipCode);
            comm.Parameters.AddWithValue("@PhoneNum", PhoneNum);
            comm.Parameters.AddWithValue("@Email", EmailAddress);
            comm.Parameters.AddWithValue("@CellNum", CellNum);
            comm.Parameters.AddWithValue("@InstaURL", InstagramURL);

            //attempt to connect to the server
            try
            {
                Conn.Open();                                        
                int intRecs = comm.ExecuteNonQuery();
                strResult = $"\nSUCCESS: Inserted {intRecs} records.";    
                Conn.Close();                                    
            }
            catch (Exception err)                                  
            {
                strResult = "\nERROR: " + err.Message;               
            }
            finally{}

            return strResult;
        }

        public DataSet SearchPersonV2(String strFName, String strLName)
        {
            //dataset to edit & return
            DataSet ds = new DataSet();

            SqlCommand comm = new SqlCommand();

            String strSQL = "SELECT PersonID, FName, MName, LName, StreetOne FROM PersonV2 WHERE 0=0";

            //If the First/Last Name is filled in include it as search criteria
            if (strFName.Length > 0)
            {
                strSQL += " AND FName LIKE @FName";
                comm.Parameters.AddWithValue("@FName", "%" + strFName + "%");
            }
            if (strLName.Length > 0)
            {
                strSQL += " AND LName LIKE @LName";
                comm.Parameters.AddWithValue("@LName", "%" + strLName + "%");
            }

            SqlConnection conn = new SqlConnection();
            string strConn = GetConnectionStr();
            conn.ConnectionString = strConn;

            comm.Connection = conn;
            comm.CommandText = strSQL;

            //Create Data Adapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comm;    //translator(dataAdapter)

            //retrieve matching data
            conn.Open();
            da.Fill(ds, "PersonV2");//Not 100% sure if this should be _Temp or not, c# description of this function confuses me more as to why its needed
            conn.Close();

            return ds;
        }

        public SqlDataReader FindOnePersonV2(int intPersonID)
        {
            //Create and Initialize the DB Tools we need
            SqlConnection conn = new SqlConnection();
            SqlCommand comm = new SqlCommand();
            string strConn = GetConnectionStr();
            string sqlString = "SELECT * FROM PersonV2 WHERE PersonID = @PersonID;";

            conn.ConnectionString = strConn;
            comm.Connection = conn;
            comm.CommandText = sqlString;
            comm.Parameters.AddWithValue("@PersonID", intPersonID);
            conn.Open();
            return comm.ExecuteReader();   //Return the dataset to be used by others
        }

        private string GetConnectionStr()
        {
            return @"Server=sql.neit.edu\sqlstudentserver,4500;Database=SE245_JSherry;User Id=SE245_JSherry;Password=005501736;";
        }
    }
}