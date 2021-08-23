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
    public partial class CourseForm : Form
    {
        CourseClass course = new CourseClass();
        public CourseForm()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
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

        public void showTable()
        {
            DataGridView_Course.DataSource = course.getCourseList();
            //DataGridView_student.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
          //  imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
           // imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;

        }

        private void CourseForm_Load(object sender, EventArgs e)
        {
            showTable();
        }
    }
}
