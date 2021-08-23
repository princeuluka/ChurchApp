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
    public partial class EditMember : Form
    {
        ManageMember Manage = new ManageMember();
        public string ID;
        
        public EditMember()
        {
            InitializeComponent();
        }
        public void Disable()
        {
            txtAddress.Enabled = false;
            txtdob.Enabled = false;
            txtfirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtPhone.Enabled = false;
            txtPosition.Enabled = false;
            txt_doBap.Enabled = false;
            txt_MiddleName.Enabled = false;
            cmb_StateofOrigin.Enabled = false;
            cmb_Superint.Enabled = false;
            church_cmb.Enabled = false;
            state_cmb.Enabled = false;
        }
        
        public void LoadData(string ID)
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
                cmd.CommandText = "SELECT * from Members where MemberId = '"+ID+"'";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    txtfirstName.Text = dr["FirstName"].ToString();
                    txt_MiddleName.Text = dr["MiddleName"].ToString();
                    txtLastName.Text = dr["LastName"].ToString();
                    txtdob.Text = dr["DOB"].ToString();
                    txt_doBap.Text = dr["DateOfBaptism"].ToString();
                    txtPhone.Text = dr["Phone"].ToString();
                    txtPosition.Text = dr["Position"].ToString();
                    txtAddress.Text = dr["Address"].ToString();
                    string gender = dr["Gender"].ToString();
                    if (gender == "Male")
                    {
                        radioButton_Female.Checked = false;
                        radioButton_Male.Checked = true;
                    }
                    else
                    {
                        radioButton_Female.Checked = true;
                        radioButton_Male.Checked = false;
                    }
                    Disable();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void EditMember_Load(object sender, EventArgs e)
        {
            LoadData(ID);
            LoadState();
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
                    cmb_StateofOrigin.Items.Add(dr["State"]);
                    state_cmb.Items.Add(dr["State"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void state_cmb_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT Name from superintendency where State = '" + state_cmb.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_Superint.Items.Add(dr["Name"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

        }

        private void cmb_Superint_SelectedIndexChanged(object sender, EventArgs e)
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
                cmd.CommandText = "SELECT Name from churches  where superintendency = '" + cmb_Superint.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    church_cmb.Items.Add(dr["Name"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            txtAddress.Enabled = true;
            txtdob.Enabled = true;
            txtfirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtPhone.Enabled = true;
            txtPosition.Enabled = true;
            txt_doBap.Enabled = true;
            txt_MiddleName.Enabled = true;
            cmb_StateofOrigin.Enabled = true;
            cmb_Superint.Enabled = true;
            church_cmb.Enabled = true;
            state_cmb.Enabled = true;
        }
    }
}
