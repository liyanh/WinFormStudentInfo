using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace WindowsFormsTest
{
    class XmlHandler
    {
        private string sourcePath = Directory.GetCurrentDirectory() + "//contact.xml";
        public List<StudentInfo> XmlReader()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sourcePath);
            XmlNodeList students = doc.GetElementsByTagName("student");
            List<StudentInfo> readList = new List<StudentInfo>();
            StudentInfo stu;
            foreach(XmlNode student in students)
            {
                XmlNodeList studentInfo = student.ChildNodes;
                stu = new StudentInfo();
                if("".Equals(studentInfo.Item(0).InnerText.ToString()) == false)
                    stu.Id = int.Parse(studentInfo.Item(0).InnerText);
                if(studentInfo.Item(1).InnerText != null)
                    stu.Name = studentInfo.Item(1).InnerText;
                if(studentInfo.Item(2).InnerText != null)
                    stu.Grade = int.Parse(studentInfo.Item(2).InnerText);
                if(studentInfo.Item(3).InnerText != null)
                    stu.Class = int.Parse(studentInfo.Item(3).InnerText);
                if(studentInfo.Item(4).InnerText != null)
                    stu.Telephone = studentInfo.Item(4).InnerText;
                readList.Add(stu);
            }
            return readList;
        }

        public List<StudentInfo> GetStudent(int grade,int clas)
        {
            List<StudentInfo> studentList = XmlReader();
            List<StudentInfo> showList = new List<StudentInfo>();           
            if (0 == grade)
            {
                return studentList;
            }
            if (0 != grade && 0 == clas)
            {
                foreach (StudentInfo si in studentList)
                {
                    if (grade == si.Grade)
                    {
                        showList.Add(si);
                    }
                }
            }
            if (0 != grade && 0 != clas)
            {
                foreach (StudentInfo si in studentList)
                {
                    if (grade == si.Grade && clas == si.Class)
                    {
                        showList.Add(si);
                    }
                }
            }
            return showList;
        }

        public void AddStudent(StudentInfo addStudent)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sourcePath);
            XmlNode root = doc.SelectSingleNode("Users");
            XmlNode student = CreateNode(doc, root, "student", "");
            CreateNode(doc, student, "Id", addStudent.Id.ToString());
            CreateNode(doc, student, "Name", addStudent.Name);
            CreateNode(doc, student, "Grade", addStudent.Grade.ToString());
            CreateNode(doc, student, "Class", addStudent.Class.ToString());
            CreateNode(doc, student, "Telephone", addStudent.Telephone);
            doc.Save(sourcePath);
        }

        public void DeleteStudent(StudentInfo deleteStudent)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sourcePath);
            XmlNodeList allStudents = doc.GetElementsByTagName("student");
            XmlNode root = doc.SelectSingleNode("Users");
            foreach (XmlNode node in allStudents)
            {
                if(int.Parse(node.FirstChild.InnerText) == deleteStudent.Id)
                {
                    root.RemoveChild(node);
                    break;
                }
            }
            doc.Save(sourcePath);
        }

        public void EditStudent(StudentInfo editStudent)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(sourcePath);
            XmlNodeList allStudents = doc.GetElementsByTagName("student");
            foreach (XmlNode node in allStudents)
            {
                if (int.Parse(node.FirstChild.InnerText) == editStudent.Id)
                {
                    XmlNodeList nodeChilds = node.ChildNodes;
                    nodeChilds.Item(0).InnerText = editStudent.Id.ToString();
                    nodeChilds.Item(1).InnerText = editStudent.Name.ToString();
                    nodeChilds.Item(2).InnerText = editStudent.Grade.ToString();
                    nodeChilds.Item(3).InnerText = editStudent.Class.ToString();
                    nodeChilds.Item(4).InnerText = editStudent.Telephone.ToString();
                    break;
                }
            }
            doc.Save(sourcePath);
        }
        public XmlNode CreateNode(XmlDocument xmlDoc, XmlNode parent, string nodeName, string nodeValue)
        {
            XmlNode childNode = xmlDoc.CreateNode(XmlNodeType.Element, nodeName, null);
            childNode.InnerText = nodeValue;
            parent.AppendChild(childNode);
            return childNode;
        }
    }
}
