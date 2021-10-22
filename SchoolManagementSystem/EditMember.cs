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
        MemberClass member = new MemberClass();
        public string ID;
        
        public EditMember()
        {
            InitializeComponent();
        }
        public void Disable()
        {
            txtId.Enabled = false;
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

        bool Verify()
        {
            if ((txtfirstName.Text == "") || (txtLastName.Text == "") ||
                (txtPhone.Text == "") || (txtAddress.Text == "") ||church_cmb.Text == "")
            {
                return false;
            }
            else
                return true;
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
                    state_cmb.Items.Insert(0,dr["State"].ToString());
                    state_cmb.SelectedIndex = 0;
                    cmb_Superint.Items.Insert(0, dr["superintendency"].ToString());
                    cmb_Superint.SelectedIndex = 0;
                    cmb_StateofOrigin.Items.Insert(0, dr["StateOfOrigin"].ToString());
                    cmb_StateofOrigin.SelectedIndex = 0;

                    church_cmb.Items.Insert(0, dr["church"].ToString());
                    church_cmb.SelectedIndex = 0;
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
                    txtId.Text = ID;
                    
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
            txtId.Enabled = false;
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string fname = txtfirstName.Text;
            string lname = txtLastName.Text;
            string Mname = txt_MiddleName.Text;
            DateTime bdate = txtdob.Value;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string gender = radioButton_Male.Checked ? "Male" : "Female";
            string Soa = cmb_StateofOrigin.Text;
            DateTime DOBP = txt_doBap.Value;
            string position = txtPosition.Text;
            string state = state_cmb.Text;
            string Sint = cmb_Superint.Text;
            string church = church_cmb.Text;

            DialogResult res = MessageBox.Show("Are you sure you want to update record", "Edit Member", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            
            if(res == DialogResult.Yes)
            {
                if (Verify())
                {
                    try
                    {
                        if (member.UpdateMember(id, fname, Mname, lname, bdate, phone,  address,  gender, church, DOBP,  position,  state,  Soa, Sint))
                        {
                            MessageBox.Show("Record updated", "Update Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            this.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill empty sections", "Edit Member", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }
    }
}
