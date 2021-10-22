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
    public partial class PrintTithe : Form
    {
        TitheClass course = new TitheClass();
        DGVPrinter printer = new DGVPrinter();
        MemberClass member = new MemberClass();
        public PrintTithe()
        {
            InitializeComponent();
        }

        private void PrintCourse_Load(object sender, EventArgs e)
        {
            ShowData(new MySqlCommand("Select * from `tithe` "));
        }

        private void ShowData(MySqlCommand command)
        {
            DataGridView_tithe.ReadOnly = true;
            DataGridView_tithe.DataSource = course.getList(command);
        }

        private void button_Print_Click(object sender, EventArgs e)
        {
            printer.Title = "TITHE";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "UNITED EVANGELICAL CHURCH";
            printer.FooterSpacing = 15;
            printer.printDocument.DefaultPageSettings.Landscape = true;
            printer.PrintDataGridView(DataGridView_tithe);
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string data =txt_Search.Text;
            DataGridView_tithe.DataSource = member.SearchTithe(data);
        }
    }
}
