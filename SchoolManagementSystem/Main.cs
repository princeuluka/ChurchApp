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
    public partial class Main : Form
    {
        MemberClass Student = new MemberClass();

        public Main()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           count();
        }

        private void count()
        {
            label_TotalStd.Text = "Total Members : " + Student.TotalMembers();
            label_maleStd.Text = "Male : " + Student.MaleStudent();
            label_FemaleStd.Text = "Female : " + Student.FemaleStudent();
        }

        private void CustomizeDesign()
        {
            panel_CourseSubMenu.Visible = false;
         
            panel_stdsubmenu.Visible = false;
        }

        private void HideSubMenu()
        {
            if(panel_stdsubmenu.Visible == true)
                panel_stdsubmenu.Visible = false;

            if (panel_CourseSubMenu.Visible == true)
                panel_CourseSubMenu.Visible = false; 
        }

        private void ShowSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                HideSubMenu();
                submenu.Visible = true;
            }else
            {
                submenu.Visible = false;
            }
                
        }
        
        private void button_Std_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_stdsubmenu);
        }

        #region StdSubMenu
        private void button_StdRegistration_Click(object sender, EventArgs e)
        {
            openChildForm(new RegisterMember());
            //...
            //... Your Code
            //...
            HideSubMenu();
            
        }

        private void button_StdManage_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageMember());
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_StdStatus_Click(object sender, EventArgs e)
        {
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_StdPrint_Click(object sender, EventArgs e)
        {
            openChildForm(new printStudent());
            //...
            //... Your Code
            //...
            HideSubMenu();
        }
        #endregion StdSubMenu

        private void button_Course_Click(object sender, EventArgs e)
        {
            ShowSubMenu(panel_CourseSubMenu);
        }
        #region CourseSubMenu
        private void button_NewCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new AddTithe());
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_ManageCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new ManageCourse());
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_PrintCourse_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintCourse());
            //...
            //... Your Code
            //...
            HideSubMenu();
        }
        #endregion CourseSubMenu

       
        #region ScoreSubMenu
        private void button_AddScore_Click(object sender, EventArgs e)
        {
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_ManageScore_Click(object sender, EventArgs e)
        {
            //...
            //... Your Code
            //...
            HideSubMenu();
        }

        private void button_PrintScore_Click(object sender, EventArgs e)
        {
            //...
            //... Your Code
            //...
            HideSubMenu();
        }
        #endregion CourseSubMenu

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_Main.Controls.Add(childForm);
            panel_Main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to EXIT?","APP",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_dashboard_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            panel_Main.Controls.Add(panel_Cover);
            count();

        }
    }
}
