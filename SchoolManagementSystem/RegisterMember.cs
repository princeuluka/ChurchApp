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
        MemberClass student = new MemberClass();
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
            church_cmb.ResetText();
            state_cmb.ResetText();
            cmb_State.ResetText();
            
        }

        bool Verify()
            {
                if ((txtfirstName.Text == "") || (txtLastName.Text == "") ||
                    (txtPhone.Text == "") || (txtAddress.Text == "") ||
                    (pictureBox1.Image == null))
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

        private void button_clear_Click_1(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            string fname = txtfirstName.Text;
            string lname = txtLastName.Text;
            DateTime bdate = txtdob.Value;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string gender = radioButton_Male.Checked ? "Male" : "Female";
           




            int born_year = txtdob.Value.Year;
            int this_year = DateTime.Now.Year;
            if ((this_year - born_year) < 10 || (this_year - born_year) > 100)
            {
                MessageBox.Show("The student age must be between 10 and 100", "INVALID BIRTH DATE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (Verify())
            {
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (student.insertStudent(fname, lname, bdate, phone, address, gender, img))
                    {
                       
                        MessageBox.Show("New Student Added", "New Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Empty Field", "New Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cmd.CommandText = "SELECT StateId from state where State = '" + state_cmb.Text +"'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                 StateId =Convert.ToString(dr["StateId"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Name from superintendency where State = '" + StateId + "'";

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
                cmd.CommandText = "SELECT ID from superintendency where Name = '" + cmb_Superint.Text + "'";

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    SuperintId = Convert.ToString(dr["ID"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }

            try
            {
                con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=church");
                cmd = new MySqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = "SELECT Name from churches where superintendencyId  = '" + SuperintId + "'";

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

      
    }
}
