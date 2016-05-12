using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsTest
{
    class InitComboBox
    {
        public static DataTable getComboBoxGradeDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("grade", typeof(String));
            dt.Columns.Add("val", typeof(short));
            DataRow dr = dt.NewRow();
            dr[0] = "一年级";
            dr[1] = 1;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "二年级";
            dr[1] = 2;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "三年级";
            dr[1] = 3;
            dt.Rows.Add(dr);
            return dt;            
        }

        public static DataTable getComboBoxClassDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("clss", typeof(String));
            dt.Columns.Add("val", typeof(short));
            DataRow dr;
            for (short i = 1; i <= 10; i++)
            {
                dr = dt.NewRow();
                dr[0] = i + "班";
                dr[1] = i;
                dt.Rows.Add(dr);
            }
            return dt;
            
        }
    }
}
