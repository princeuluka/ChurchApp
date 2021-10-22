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
    public partial class ManageTithe : Form
    {
        TitheClass course = new TitheClass();
        public ManageTithe()
        {
            InitializeComponent();
        }


        bool Verify()
        {
            if ((txtCourseId.Text == "") || (txtCoursename.Text == "") ||
                (txtDescription.Text == "") || (txtHour.Text == "") )
            {
                return false;
            }
            else
                return true;
        }

        public void showTable()
        {
            DataGridView_student.DataSource = course.getCourseList();
            //DataGridView_student.RowTemplate.Height = 80;
           
        }

        public void Clear()
        {
            txtCourseId.Clear();
            txtCoursename.Clear();
            txtDescription.Clear();
            txtHour.Clear();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void ManageCourse_Load(object sender, EventArgs e)
        {
            showTable();
        }

        private void DataGridView_student_Click(object sender, EventArgs e)
        {
            txtCourseId.Text = DataGridView_student.CurrentRow.Cells[0].Value.ToString();
            txtCoursename.Text = DataGridView_student.CurrentRow.Cells[1].Value.ToString();
            txtHour.Text = DataGridView_student.CurrentRow.Cells[2].Value.ToString();
            txtDescription.Text = DataGridView_student.CurrentRow.Cells[3].Value.ToString();
        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtCourseId.Text);
            string Cname = txtCoursename.Text;
            int Chr = Convert.ToInt32(txtHour.Text);
            string desc = txtDescription.Text;

            DialogResult res = MessageBox.Show("Are you sure you want to update this course?", "Update Course", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)
            if (Verify())
            {
                try
                {
                    if (course.updateCourse(Id, Cname, Chr, desc))
                    {
                        showTable();
                        MessageBox.Show("Course data updated", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field", "Update Course", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCourseId.Text);
            DialogResult res = MessageBox.Show("Are you sure you want to update this course?", "Update Course", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (res == DialogResult.Yes)

                try
            {
                if (course.DeleteCourse(id))
                {
                    showTable();
                    MessageBox.Show("Course data Deleted", "Delete Course", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
