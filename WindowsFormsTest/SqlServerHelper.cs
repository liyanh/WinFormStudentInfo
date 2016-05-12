using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsTest
{
    class SqlServerHelper : IDatabaseHelper
    {
        private static SqlConnection connection;
        private static SqlServerHelper sqlServerSingleton;
        private static readonly object locker = new object();
        private SqlServerHelper()
        {
        }
        public static SqlServerHelper GetInstance()
        {
            if (sqlServerSingleton == null)
            {
                lock (locker)
                {
                    if (sqlServerSingleton == null)
                    {                        
                        sqlServerSingleton = new SqlServerHelper();
                    }
                }
            }
            return sqlServerSingleton;
        }
        private SqlConnection Connection
        {
            get
            {
                try
                {
                    string connectionString = @"server=.\LYH_SQLSERVER;database=LYH_student_management;uid=sa;pwd=forever";
                    if (connection == null)
                    {
                        connection = new SqlConnection(connectionString);
                        connection.Open();
                    }
                    else if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    else if (connection.State == System.Data.ConnectionState.Broken)
                    {
                        connection.Close();
                        connection.Open();
                    }
                    return connection;
                }          
                catch(Exception e)
                {
                    MessageBox.Show(e.ToString());
                    return null;
                }
            }
        }
        public void InsertStudent(StudentInfo addStudent)
        {
            try
            {
                string insertStudent = "insert into students values (@name,@grade,@clss,@telephone)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insertStudent;
                cmd.Parameters.AddWithValue("@name", addStudent.Name);
                cmd.Parameters.AddWithValue("@grade", addStudent.Grade);
                cmd.Parameters.AddWithValue("@clss", addStudent.Class);
                cmd.Parameters.AddWithValue("@telephone", addStudent.Telephone);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public  void InsertDetail(StudentDetail studentDetail)
        {
            try
            {
                string insertDetail = "insert into students_detail values (@id,@address,@blood,@height,@weight,@intro)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insertDetail;
                cmd.Parameters.AddWithValue("@id", studentDetail.Id);
                cmd.Parameters.AddWithValue("@address", studentDetail.Address);
                cmd.Parameters.AddWithValue("@blood", studentDetail.Blood);
                cmd.Parameters.AddWithValue("@height", studentDetail.Height);
                cmd.Parameters.AddWithValue("@weight", studentDetail.Weight);
                cmd.Parameters.AddWithValue("@intro", studentDetail.Intro);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void InsertPicture(Picture studentPic)
        {
            try
            {
                string insertPicture = "insert into students_logo values (@id,@path)";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = insertPicture;
                cmd.Parameters.AddWithValue("@id", studentPic.Id);
                cmd.Parameters.AddWithValue("@path", studentPic.Path);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void UpdateStudent(StudentInfo student)
        {
            try
            {
                string editStudent = "update students set name=@name, Grade=@grade, Class=@clss, Telephone=@telephone where id=@id;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = editStudent;
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@grade", student.Grade);
                cmd.Parameters.AddWithValue("@clss", student.Class);
                cmd.Parameters.AddWithValue("@telephone", student.Telephone);
                cmd.Parameters.AddWithValue("@id", student.Id);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteStudent(string id)
        {
            try
            {
                string deleStudent = "delete from students where id=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = deleStudent;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }           
        }
        public void DeleteDetail(string id)
        {
            try
            {
                string deleDetailCommd = "delete from students_detail where id = @id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = deleDetailCommd;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void DeleteLogo(string id)
        {
            try
            {
                string deleLogoCommd = "delete from students_logo where id=@id";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = deleLogoCommd;
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = Connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public DataSet QueryStudents(NodeInfo treeViewNode, int currentPage, string name, bool count)
        {
            string queryCommd = "select * from students";
            int grade = treeViewNode.Grade;
            int clss = treeViewNode.Class;
            if (grade != 0 || clss !=0 || (name != null && "" != name))
            {
                queryCommd += " where";
                if (grade != 0)
                {
                    queryCommd += " grade=@grade";
                }
                if (clss != 0)
                {
                    if (!queryCommd.EndsWith("where"))
                        queryCommd += " and";
                    queryCommd += " class=@clss";
                }
                if (name != null && "" != name)
                {
                    if (!queryCommd.EndsWith("where"))
                        queryCommd += " and";
                    queryCommd += " name like '%" + @name + "%'";
                }
            }
            if (!count)
            {
                queryCommd += " order by id asc offset @count rows fetch next 10 rows only";
            }
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = queryCommd;
                if (grade != 0)
                {
                    cmd.Parameters.AddWithValue("@grade",grade);
                }
                if (clss != 0)
                {
                    cmd.Parameters.AddWithValue("@clss", clss);
                }
                if (name != null && "" != name)
                {
                    cmd.Parameters.AddWithValue("@name", name);
                }
                if (!count)
                {
                    cmd.Parameters.AddWithValue("@count", 10 * (currentPage - 1));
                }
                cmd.Connection = Connection; 
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }       
        public SqlDataReader QueryDetail(string id)
        {
            try
            {
                if (id != "")
                {
                    string singleRecord = "select * from students_detail where id=@id";
                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.CommandText = singleRecord;
                    cmdDetail.Parameters.AddWithValue("@id", id);
                    cmdDetail.Connection = Connection;
                    return cmdDetail.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public SqlDataReader QueryLogo(string id)
        {
            try
            {
                if (id != "")
                {
                    string singleRecord = "select * from students_logo where id=@id";
                    SqlCommand cmdDetail = new SqlCommand();
                    cmdDetail.CommandText = singleRecord;
                    cmdDetail.Parameters.AddWithValue("@id", id);
                    cmdDetail.Connection = Connection;
                    return cmdDetail.ExecuteReader();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public SqlDataReader GetId()
        {
            try
            {
                string idCurrent = "select ident_current('students') id";
                SqlCommand cmdId = new SqlCommand(idCurrent,Connection);
                return cmdId.ExecuteReader();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        public static void ConClose()
        {
            if(connection != null)
                connection.Close();
        } 
    }
}
