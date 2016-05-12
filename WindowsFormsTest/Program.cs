//数据库中包含三个表，分别存储学生的基本信息 students表， 学生的详细信息 sutdents_detail表
//学生的头像图片路径 students_logo
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsTest
{
    static class Program
    {       
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {                       
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            SqlServerHelper.ConClose();
        }
    }
}
