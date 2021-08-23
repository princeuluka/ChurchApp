
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    class CourseClass
    { 
        DBConnect connect = new DBConnect();

        public bool InsertCourse(string cName, int hr, string desc)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `course`(`CourseName`, `CourseHour`, `Description`) VALUES (@cn,@ch,@desc)",connect.getConnection);

            command.Parameters.Add("@cn",MySqlDbType.VarChar).Value = cName;
            command.Parameters.Add("@ch", MySqlDbType.Int32).Value = hr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;

            connect.openConnect();

            if(command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public DataTable getCourseList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `members`", connect.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool updateCourse(int id, string Cname, int Chr, string desc)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `course` SET " +
                "`CourseName`=@Cname,`CourseHour`=@Chr,`Description`=@desc WHERE `CourseId` = @id", connect.getConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@Cname", MySqlDbType.VarChar).Value = Cname;
            command.Parameters.Add("@Chr", MySqlDbType.Int32).Value = Chr;
            command.Parameters.Add("@desc", MySqlDbType.VarChar).Value = desc;

            connect.openConnect();

            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }
        }

        public bool DeleteCourse(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `course` WHERE `CourseId` = @id", connect.getConnection);

            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            connect.openConnect();
            if (command.ExecuteNonQuery() == 1)
            {
                connect.closeConnect();
                return true;
            }
            else
            {
                connect.closeConnect();
                return false;
            }

        }

        public DataTable getList(MySqlCommand command)
        {
            command.Connection = connect.getConnection;
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
