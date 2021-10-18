using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class RegisterMember : Form
    {
        MemberClass member = new MemberClass();
        private string StateId;
        private string SuperintId;
        public RegisterMember()
        {
            InitializeComponent();
        }

        private void clearFields()
        {
            txtAddress.Clear();
            txtfirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            pictureBox1.Image = null;
            txtdob.ResetText();
            txt_doBap.ResetText();
            txt_MiddleName.Clear();
            church_cmb.SelectedIndex = -1;
            state_cmb.SelectedIndex = -1;
            cmb_StateofOrigin.SelectedIndex = -1;
            cmb_Superint.SelectedIndex = -1;
            txt_position.Clear();


        }

        bool Verify()
            {
                if ((txtfirstName.Text == "") || (txtLastName.Text == "") ||
                    (txtPhone.Text == "") || (txtAddress.Text == ""))

                {
                    return false;
                }
                else
                    return true;
            }

        private void RegisterForm2_Load(object sender, EventArgs e)
        {
            stateCmb();
        }

        private void stateCmb()
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
            catch(Exception ex)
            {
                string msg = ex.Message;
            }

        }

        private void superint()
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
                cmd.CommandText = "SELECT ID, State from state";
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_StateofOrigin.Items.Add(dr["State"]);
                    state_cmb.Items.Add(dr["State"]);
                    int stateId = Convert.ToInt32(dr["ID"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
        }


        private void button_upload_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(opf.FileName);
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

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

            string fname = txtfirstName.Text;
            string mname = txt_MiddleName.Text;
            string lname = txtLastName.Text;
            DateTime bdate = txtdob.Value;
            string origin = cmb_StateofOrigin.Text;
            DateTime Dbop = txt_doBap.Value;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string gender = radioButton_Male.Checked ? "Male" : "Female";
            string churchState = state_cmb.Text;
            string supint = cmb_Superint.Text;
            string church = church_cmb.Text;
            string position = txt_position.Text;

            if (Verify())
            {
                try
                {
                    // MemoryStream ms = new MemoryStream();
                    //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    //byte[] img = ms.ToArray();
                    if (member.insertMember(fname, mname, lname, bdate, origin, Dbop, phone, position, address, gender, churchState, supint, church))
                    {
                        MessageBox.Show("New Member Added", "New Member", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please input all required fields","Add Member",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
              
            }
            
        

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
