using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using DGVPrinterHelper;
namespace SchoolManagementSystem
{
    public partial class printStudent : Form
    {
        MemberClass student = new MemberClass();
        DGVPrinter printer = new DGVPrinter();

        public printStudent()
        {
            InitializeComponent();
        }

        private void printStudent_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand ("Select * from `student` ") );
        }

        public void showData(MySqlCommand command)
        {
            DataGridView_student.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
           // DataGridView_student.RowTemplate.Height = 80;

            DataGridView_student.DataSource = student.getList(command);
            imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string SelectQuery;
            if(radioButton_all.Checked == true)
            {
                SelectQuery = "Select * from `student`";
            }else if (radioButton_Male.Checked)
            {
                SelectQuery = "Select * from `student` WHERE Gender = 'Male'";
            }else
            {
                SelectQuery = "Select * from `student` WHERE Gender = 'Female'";
            }
            showData(new MySqlCommand(SelectQuery));
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "Mdemy Student List";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxlearn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton_Female_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_class_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_student_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton_all_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
