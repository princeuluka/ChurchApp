using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class ManageMember : Form
    {
        MemberClass member = new MemberClass();
        public string MemberId; 

        public ManageMember()
        {
            InitializeComponent();
            showTable();
        }

        public void showTable()
        {
            dataGridView_Members.DataSource = member.getMembersList();

        }

        private void dataGridView_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberId = dataGridView_Members.CurrentRow.Cells[0].Value.ToString();
            EditMember edit = new EditMember();
            edit.ID = dataGridView_Members.CurrentRow.Cells[0].Value.ToString();
            edit.Show();
            
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridView_Members.DataSource = member.SearchMember(txtSearch.Text);
        }
    } 
}
     /*   bool Verify()
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

        private void ManageStudent_Form_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void clearFields()
        {
            txtAddress.Clear();
            txtfirstName.Clear();
            txtLastName.Clear();
            txtPhone.Clear();
            pictureBox1.Image = null;
            txtdob.ResetText();
            radioButton_Male.Checked = true;
            txtId.Clear();
        }

        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            txtId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            txtfirstName.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            txtdob.Value = (DateTime)DataGridView_student.CurrentRow.Cells[3].Value;
            txtPhone.Text = DataGridView_student.CurrentRow.Cells[4].Value.ToString();
            txtAddress.Text = DataGridView_student.CurrentRow.Cells[5].Value.ToString();
            if (DataGridView_student.CurrentRow.Cells[6].Value.ToString() == "Male")
            {
                radioButton_Male.Checked = true;
            }
            else if (DataGridView_student.CurrentRow.Cells[6].Value.ToString() == "Female")
            {
                radioButton_Female.Checked = true;
            }
                
            byte[] img = (byte[])DataGridView_student.CurrentRow.Cells[7].Value;
            MemoryStream ms = new MemoryStream(img);
            pictureBox1.Image = Image.FromStream(ms);

        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Photo (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(opf.FileName);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataGridView_student.DataSource = member.SearchStudent(txtSearch.Text);
            DataGridView_student.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
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
                DialogResult res = MessageBox.Show("Are you sure you want to update this course?", "Update Course", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                    try
                {
                    MemoryStream ms = new MemoryStream();
                    pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
                    byte[] img = ms.ToArray();
                    if (member.updateStudent(id,fname, lname, bdate, phone, address, gender, img))
                    {
                        showTable();
                        MessageBox.Show("Student data updated", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Empty Field", "Update Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            try
            {
                DialogResult res = MessageBox.Show("Are you sure you want to update this course?", "Update Course", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                    if (member.DeleteStudent(id))
                {
                    showTable();
                    MessageBox.Show("Student data Deleted", "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                }
            }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


}
    }
}
     */