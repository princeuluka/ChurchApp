using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem
{
    class MemberClass
    {
        DBConnect connect = new DBConnect();

        public bool insertStudent(string fname,string lname, DateTime bdate, string phone, string address, string gender, byte[] img)
        {
            MySqlCommand command = new MySqlCommand("INSERT INTO `student`(`StdFirstName`, `StdLastName`, `BirthDate`, `Phone`, `Address`, `Gender`,  `Photo`) VALUES(@fn, @ln, @bd, @ph, @Adr,@gd, @img)", connect.getConnection);
           

            command.Parameters.Add("@fn",MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@img", MySqlDbType.Blob).Value = img;

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

        public DataTable getMembersList()
        {
            MySqlCommand command = new MySqlCommand("SELECT MemberId,FirstName,MiddleName, LastName,DOB, Gender,Address,DateOfBaptism, Position,Phone FROM `members`" , connect.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public string exeCount(string query)
        {
            MySqlCommand command = new MySqlCommand(query, connect.getConnection);
            connect.openConnect();
            string count = command.ExecuteScalar().ToString();
            connect.closeConnect();
            return count;
        }

        public string TotalMembers()
        {
            return exeCount("select count(*) from `members`");
        }

        public string MaleStudent()
        {
            return exeCount("SELECT count(*) FROM `members` WHERE Gender = 'Male' ");
        }

        public string FemaleStudent()
        {
            return exeCount("SELECT count(*) FROM `members` WHERE Gender = 'Female'");
        }

        public DataTable SearchMember(string SearchData)
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `members` WHERE CONCAT(`FirstName`,`LastName`,`Address`) LIKE '%"+SearchData+"%'", connect.getConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool UpdateMember(int id, string fname, string Mname ,string lname, DateTime bdate, string phone, string address, string gender,string church, DateTime DOBP,string position, string state,string Soa, string Sint)
        {
            MySqlCommand command = new MySqlCommand("UPDATE `members` SET " +
                "`State` = @St,`superintendency`=@Si,`church` = @ch,`FirstName`=@fn,`MiddleName` = @Mn,`LastName`=@ln," +
                "`DOB`=@bd,`Gender`=@gd,`StateOfOrigin` = @soa,`Address`=@adr,`DateOfBaptism` = @dop,`position` = @pos,`Phone`=@ph " +
                "WHERE `members`.`MemberId` =@id", connect.getConnection);


            command.Parameters.Add("@St", MySqlDbType.VarChar).Value = state;
            command.Parameters.Add("@Si", MySqlDbType.VarChar).Value = Sint;
            command.Parameters.Add("@ch", MySqlDbType.VarChar).Value = church;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@fn", MySqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@Mn", MySqlDbType.VarChar).Value = Mname;
            command.Parameters.Add("@ln", MySqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bd", MySqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gd", MySqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@soa", MySqlDbType.VarChar).Value = Soa;
            command.Parameters.Add("@adr", MySqlDbType.VarChar).Value = address;
            command.Parameters.Add("@dop", MySqlDbType.Date).Value = DOBP;
            command.Parameters.Add("@pos", MySqlDbType.VarChar).Value = position;
            command.Parameters.Add("@ph", MySqlDbType.VarChar).Value = phone;
  
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
    
        public bool DeleteMember(int id)
        {
            MySqlCommand command = new MySqlCommand("DELETE FROM `student` WHERE `Stdid` = @id", connect.getConnection);
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
