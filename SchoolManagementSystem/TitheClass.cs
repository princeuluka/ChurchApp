
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    class TitheClass
    { 
        DBConnect connect = new DBConnect();

        public bool InsertTithe(string State, string SuperInt, string Church, string Member,string MemberId, string amount, DateTime Date, string remarks)
        {
            //MySqlCommand command = new MySqlCommand(" INSERT INTO `tithe` (`State`, `Superintendency`, `Church`, `Member`, `MemberId`, `Amount`, `Date`, `Remarks`)  VALUES " +
               // "('"+State+ "','" + SuperInt + "','" + Church + "','" + Member + "','" + MemberId + "','" + amount + "','" + Date + "','" + remarks + "')", connect.getConnection);


            MySqlCommand command = new MySqlCommand (" INSERT INTO `tithe` (`State`, `Superintendency`, `Church`, `Member`, `MemberId`, `Amount`, `Date`, `Remarks`)"+
               " VALUES(@st, @si, @ch, @me, @mi, @am, @dt, @re)", connect.getConnection);
            
             command.Parameters.Add("@st",MySqlDbType.VarChar).Value = State;
             command.Parameters.Add("@si", MySqlDbType.VarChar).Value = SuperInt;
             command.Parameters.Add("@ch", MySqlDbType.VarChar).Value = Church;
             command.Parameters.Add("@me", MySqlDbType.VarChar).Value = Member;
             command.Parameters.Add("@mi", MySqlDbType.VarChar).Value = MemberId;
             command.Parameters.Add("@am", MySqlDbType.VarChar).Value = amount;
             command.Parameters.Add("@dt", MySqlDbType.Date).Value = Date;
             command.Parameters.Add("@re", MySqlDbType.VarChar).Value = remarks;
            
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

        public DataTable getTitheList()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tithe`", connect.getConnection);
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

        public DataTable SearchTithe(string SearchData)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `tithe` WHERE CONCAT(`Church`,`Member`) LIKE '%" + SearchData + "%'", connect.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
