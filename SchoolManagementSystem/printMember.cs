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
    public partial class printMember : Form
    {
        MemberClass student = new MemberClass();
        DGVPrinter printer = new DGVPrinter();

        public printMember()
        {
            InitializeComponent();
        }

        private void printStudent_Load(object sender, EventArgs e)
        {
            showData(new MySqlCommand ("Select * from `members` ") );
        }

        public void showData(MySqlCommand command)
        {
            DataGridView_student.ReadOnly = true;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
           // DataGridView_student.RowTemplate.Height = 80;

            DataGridView_student.DataSource = student.getList(command);
          //  imageColumn = (DataGridViewImageColumn)DataGridView_student.Columns[7];
          //  imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string SelectQuery;
            if(radioButton_all.Checked == true)
            {
                SelectQuery = "Select * from `members`";
            }else if (radioButton_Male.Checked)
            {
                SelectQuery = "Select * from `members` WHERE Gender = 'Male'";
            }else
            {
                SelectQuery = "Select * from `members` WHERE Gender = 'Female'";
            }
            showData(new MySqlCommand(SelectQuery));
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "Church List";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "UNITED EVANGELICAL CHURCH";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_student);
        }

 
    }
}
