using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsTest
{
    internal class DataSource
    {
        public static DataSource dataSource = new DataSource();
        private DataSource()
        {
            this.studentList = this.initStudentList();
        }
        private List<StudentInfo> studentList;
        private List<StudentInfo> initStudentList()
        {
            List<StudentInfo> init = new List<StudentInfo>();
            init.Add(new StudentInfo()
            {
                Id = 1,
                Name = "Kai Lun",
                Grade = 1,
                Class = 1,
                Telephone ="18888888888"                
            });

            init.Add(new StudentInfo()
            {
                Id = 2,
                Name = "Liu Neng",
                Grade = 1,
                Class = 2,
                Telephone = "18888888887"
            });

            init.Add(new StudentInfo()
            {
                Id = 3,
                Name = "Hai Feng",
                Grade = 2,
                Class = 1,
                Telephone = "18888888889"
            });
            return init;
        }

        public List<StudentInfo> GetStudent(int grade, int clas)
        {
            List<StudentInfo> showList = new List<StudentInfo>();
            if (0 == grade)
            {
                return this.studentList;
            }
            if (0 != grade && 0 ==clas)
            {               
                foreach (StudentInfo si in this.studentList)
                {
                    if (grade == si.Grade)
                    {
                        showList.Add(si);
                    }
                }
            }
            if(0 != grade && 0 != clas)
            {
                foreach (StudentInfo si in this.studentList)
                {
                    if (grade == si.Grade && clas == si.Class)
                    {
                        showList.Add(si);
                    }
                }
            }
            return showList;
        }       

        public void AddStudent(StudentInfo addStu)
        {
            studentList.Add(addStu);
        }
    }
}
