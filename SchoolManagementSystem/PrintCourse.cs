using DGVPrinterHelper;
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
    public partial class PrintCourse : Form
    {
        CourseClass course = new CourseClass();
        DGVPrinter printer = new DGVPrinter();
        public PrintCourse()
        {
            InitializeComponent();
        }

        private void PrintCourse_Load(object sender, EventArgs e)
        {
            ShowData(new MySqlCommand("Select * from `course` "));
        }

        private void ShowData(MySqlCommand command)
        {
            DataGridView_course.ReadOnly = true;
            DataGridView_course.DataSource = course.getList(command);
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "Mdemy Course List";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "foxlearn";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_course);
        }
    }
}
