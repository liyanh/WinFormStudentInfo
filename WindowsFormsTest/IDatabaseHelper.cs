using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsTest
{
    interface IDatabaseHelper
    {
        void InsertStudent(StudentInfo addstudent);
        void InsertDetail(StudentDetail studentDetail);
        void InsertPicture(Picture studentPic);
        void UpdateStudent(StudentInfo student);
        void DeleteStudent(string id);
        void DeleteDetail(string id);
        void DeleteLogo(string id);
        DataSet QueryStudents(NodeInfo treeViewNode, int currentPage, string name, bool count);

    }
}
