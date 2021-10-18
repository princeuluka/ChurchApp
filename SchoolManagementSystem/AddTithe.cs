using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class AddTithe : Form
    {
        DBConnect connect = new DBConnect();
        CourseClass course = new CourseClass();
        MemberClass member = new MemberClass();
        public string lname;
        public string fname;
        public AddTithe()
        {
            InitializeComponent();
            LoadState();
        }

        private void btn_AddTithe_Click(object sender, EventArgs e)
        {
            if (cmb_State.Text == "" || cmb_SuperInt.Text == "" || cmb_Church.Text == "" || cmb_Member.Text == "" ||txt_Amount.Text == "" || txt_Remarks.Text == "")
            {
                MessageBox.Show("Need Tithe Data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string State = cmb_State.Text;
                string SuperInt = cmb_SuperInt.Text;
                string Church = cmb_Church.Text;
                string Member = cmb_Member.Text;
                DateTime Date = txt_Date.Value;
                int amount = Convert.ToInt32(txt_Amount.Text);
                string remarks = txt_Remarks.Text;
                string MemberId = txt_MemberId.Text;

                try
                {
                    if (course.InsertTithe(State,SuperInt,Church,Member,MemberId,Date,amount,remarks))
                    {
                        MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       // clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void cmb_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;


            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Name from superintendency where State = '" +cmb_State.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_SuperInt.Items.Add(dr["Name"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void cmb_SuperInt_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;


            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Name from churches  where superintendency = '" + cmb_SuperInt.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_Church.Items.Add(dr["Name"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void cmb_Church_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;


            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT FirstName, LastName  from members  where church = '" + cmb_Church.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_Member.Items.Add(dr["LastName"] +"," + dr["FirstName"]);
                    
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void LoadState()
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;
            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT StateId, State from state";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_State.Items.Add(dr["State"]);  
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void cmb_Member_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection con;
            MySqlCommand cmd;
            MySqlDataReader dr;

            string[] names = cmb_Member.Text.Split(',');
            string lname = names[0];
            string fname = names[1];
            foreach (string coma in names)
            {
                lname = names[0];
                 fname = names[1];
            }
            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT MemberId FROM `members` WHERE FirstName = '" +fname+"' AND LastName = '" + lname + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    
                    txt_MemberId.Text = dr["MemberId"].ToString();
                }
                con.Close();
            }
            catch(Exception ex)
            {
                string msg = ex.Message;
            }
             
             
            }

 





        /* private void button_Add_Click(object sender, EventArgs e)
           {
               if (txtCoursename.Text == "" || txtHour.Text == "")
               {
                   MessageBox.Show("Need Course Data", "Field Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               else
               {
                   string cName = txtCoursename.Text;
                   int chr = Convert.ToInt32(txtHour.Text);
                   string desc = txtDescription.Text;
                   try
                   {
                       if (course.InsertCourse(cName, chr, desc))
                       {
                           MessageBox.Show("New Course Inserted", "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           clear();
                       }
                   }
                   catch (Exception ex)
                   {
                       MessageBox.Show(ex.Message, "Add Course", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
               }

           }

           private void button_clear_Click(object sender, EventArgs e)
           {
               clear();
           }

           private void clear()
           {
               txtCoursename.Clear();
               txtDescription.Clear();
               txtHour.Clear();
           }


           private void CourseForm_Load(object sender, EventArgs e)
           {
               showTable();
           }

           private void button_clear_Click_1(object sender, EventArgs e)
           {

           }
        */
    }
}
