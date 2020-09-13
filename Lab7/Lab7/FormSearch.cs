using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab5;
using Lab5Part3;

namespace Lab7
{
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            PersonV2 temp = new PersonV2();
            //Run the search using 
            DataSet ds = temp.SearchPersonV2(txtFNameSearch.Text, txtLNameSearch.Text);
            //output
            dataGrid.DataSource = ds;                                  //point datagrid to dataset
            dataGrid.DataMember = ds.Tables["PersonV2"].ToString();     // What table in the dataset?

        }

        private void dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Gathers the row clicked, then chooses the first cell's data
            string strPersonID = dataGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            MessageBox.Show(strPersonID);

            int intPersonID = Convert.ToInt32(strPersonID);

            Form1 Editor = new Form1(intPersonID);
            Editor.ShowDialog();
        }
    }
}
