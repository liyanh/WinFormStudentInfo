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
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {
        private static int currentPage = 1;
        private static double allPage = 0;
        private static string searchName;
        private NodeInfo treeViewNode = null;
        private DataGridViewRow selectedGrid = null;
        private SqlServerHelper sqlServerSingleton = SqlServerHelper.GetInstance();
        public Form1()
        {
            InitializeComponent();                        
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Fill(this.lYH_student_managementDataSet.students);
            this.buttonPrevious.Enabled = false;
            this.buttonNext.Enabled = false;
            this.buttonAdd.Enabled = false;
            this.buttonEdit.Enabled = false;
            this.buttonDelete.Enabled = false;
            this.buttonGo.Enabled = false;
            this.buttonSearch.Enabled = false;
            this.buttonExcel.Enabled = false;
            this.labelCurrent.Text = "0";
            gradeDataGridViewTextBoxColumn.DisplayMember = "grade";
            gradeDataGridViewTextBoxColumn.ValueMember = "val";
            gradeDataGridViewTextBoxColumn.DataSource = InitComboBox.getComboBoxGradeDataTable();
            classDataGridViewTextBoxColumn.DataSource = InitComboBox.getComboBoxClassDataTable();
            classDataGridViewTextBoxColumn.DisplayMember = "clss";
            classDataGridViewTextBoxColumn.ValueMember = "val";
            groupBoxDetail.Visible = false;
            ChangeSize();
        }

        private void treeViewOrgStudent_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeViewNode = e.Node.Tag as NodeInfo;
            this.textBoxSearchName.Text = "";
            searchName = "";
            currentPage = 1;
            RefeshCountLabel();
            RefeshDataGridView();
            ChangeSize();
        }

        private void LoadChildNode(TreeNode node)
        {
            NodeInfo info = node.Tag as NodeInfo;
            int i = info.Id;
            if (info == null)
                return;

            List<NodeInfo> childList = NodeSource.nodeSource.GetChildNodeList(info.Id);
            foreach (NodeInfo item in childList)
            {
                TreeNode childNode = new TreeNode();
                childNode.Tag = item;
                childNode.Text = item.Name;
                node.Nodes.Add(childNode);
            }
        }

        private void treeViewOrgStudent_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            foreach (TreeNode childNode in e.Node.Nodes)
            {
                this.LoadChildNode(childNode);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {                     
            AddForm addForm = new AddForm(treeViewNode.Grade, treeViewNode.Class);
            addForm.ShowDialog();
            RefeshCountLabel();
            RefeshDataGridView();
            addForm.Dispose();
        }
        
        private void buttonEdit_Click(object sender, EventArgs e)
        {       
            if (dataGridViewShowStudentInfo.SelectedRows.Count != 0)
            {                
                foreach (DataGridViewRow dr in dataGridViewShowStudentInfo.SelectedRows)
                {
                    StudentInfo editStudent = new StudentInfo();
                    if (dr.Cells[0].Value != null)
                        editStudent.Id = int.Parse(dr.Cells[0].Value.ToString());
                    if (dr.Cells[1].Value != null)
                        editStudent.Name = dr.Cells[1].Value.ToString();
                    if (dr.Cells[2].Value != null)
                        editStudent.Grade = int.Parse(dr.Cells[2].Value.ToString());
                    if (dr.Cells[3].Value != null)
                        editStudent.Class = int.Parse(dr.Cells[3].Value.ToString());
                    if (dr.Cells[4].Value != null)
                        editStudent.Telephone = dr.Cells[4].Value.ToString();
                    EditForm editForm = new EditForm(editStudent.Id, editStudent.Name, editStudent.Grade, editStudent.Class, editStudent.Telephone);
                    editForm.ShowDialog();
                    editForm.Dispose();
                }
                RefeshDataGridView();
            }
            else
            {
                MessageBox.Show("请先选中一条记录！");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewShowStudentInfo.SelectedRows.Count != 0)
            {
                foreach (DataGridViewRow dr in dataGridViewShowStudentInfo.SelectedRows)
                {
                    StudentInfo deleteStudent = new StudentInfo();
                    if (dr.Cells[0].Value != null)
                    {
                        string id = dr.Cells[0].Value.ToString();
                        sqlServerSingleton.DeleteDetail(id);
                        sqlServerSingleton.DeleteLogo(id);
                        sqlServerSingleton.DeleteStudent(id);
                        string path = System.Environment.CurrentDirectory + @"/Images/" + deleteStudent.Id + ".jpg";
                        if (File.Exists(path))
                        {
                            File.Delete(path);
                        }
                        dataGridViewShowStudentInfo.Rows.Remove(dr);
                        groupBoxDetail.Visible = false;
                    }                                       
                }
                RefeshCountLabel();
                RefeshDataGridView();
            }
            else
            {
                MessageBox.Show("请先选中一条记录！");
            }
        }

        private void buttonRefesh_Click(object sender, EventArgs e)         //加载数据button
        {
            treeViewOrgStudent.Nodes.Clear();
            searchName = "";
            currentPage = 1;
            TreeNode root = new TreeNode();
            NodeInfo rootInfo = new NodeInfo() { Id = 1, Grade = 0, Class = 0, ParentId = 0, Name = "全部" };
            root.Tag = rootInfo;
            root.Text = rootInfo.Name;
            treeViewOrgStudent.Nodes.Add(root);
            LoadChildNode(root);
            treeViewNode = this.treeViewOrgStudent.Nodes[0].Tag as NodeInfo;
            RefeshCountLabel();
            RefeshDataGridView();
            this.textBoxSearchName.Text = "";
            this.buttonAdd.Enabled = true;
            this.buttonEdit.Enabled = true;
            this.buttonDelete.Enabled = true;
            this.buttonGo.Enabled = true;
            this.buttonSearch.Enabled = true;
            this.buttonExcel.Enabled = true;
            ChangeSize();
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {            
            currentPage--;
            PageStatus();
            RefeshDataGridView();           
            ChangeSize();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {            
            currentPage++;
            PageStatus();
            RefeshDataGridView();            
            ChangeSize();
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            if(this.textBoxChosePage.Text != "" && int.Parse(this.textBoxChosePage.Text)>=1 && int.Parse(this.textBoxChosePage.Text) <= allPage)
            {                
                currentPage = int.Parse(this.textBoxChosePage.Text);
                PageStatus();
                RefeshDataGridView();                
                ChangeSize();
            }
            else
            {
                MessageBox.Show("  页码超界！");
            }
        }

        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
                MessageBox.Show("请输入阿拉伯数字！");
            }
            if (e.KeyChar == 13)
            {
                buttonGo_Click(sender, e);
            }
        }

        private void ChangeSize()
        {
            if(dataGridViewShowStudentInfo.SelectedRows.Count == 0)
            {
                groupBoxDetail.Visible = false;
            }
            else
            {
                groupBoxDetail.Visible = true;
            }
            if (groupBoxDetail.Visible == false)
            {
                this.groupBoxDetail.Visible = false;
                this.Size = new Size(750, 326);
            }
            else
            {
                this.groupBoxDetail.Visible = true;
                this.Size = new Size(750, 605);
            }
        }

        private void dataGridViewShowStudentInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            InitGroupBoxStatus();
            if (dataGridViewShowStudentInfo.SelectedRows.Count != 0)
            {
                groupBoxDetail.Visible = true;
                selectedGrid = dataGridViewShowStudentInfo.SelectedRows[0];
                string id = "";
                if (selectedGrid.Cells[0].Value != null)
                    id = selectedGrid.Cells[0].Value.ToString();
                SqlDataReader reader = sqlServerSingleton.QueryDetail(id);     //执行SQL，返回一个“流”
                if (reader.Read())
                {
                    this.textBoxAddress.Text = reader["ADDRESS"].ToString();
                    this.textBoxBlood.Text = reader["blood"].ToString();
                    if(reader["height(cm)"].ToString() != "0")
                        this.textBoxHeight.Text = reader["height(cm)"].ToString();
                    if(reader["weight(kg)"].ToString() != "0")
                        this.textBoxWeight.Text = reader["weight(kg)"].ToString();
                    this.textBoxIntro.Text = reader["introduction"].ToString();
                }
                else
                {
                    this.textBoxAddress.Text = "";
                    this.textBoxBlood.Text = "";
                    this.textBoxHeight.Text = "";
                    this.textBoxWeight.Text = "";
                    this.textBoxIntro.Text = "";
                }
                reader.Close();
                SqlDataReader logoReader = sqlServerSingleton.QueryLogo(id);     //执行SQL，返回一个“流”
                if (logoReader.Read())
                {
                    if (logoReader["path"].ToString() != "")
                        this.pictureBoxLogo.Image = Image.FromFile(logoReader["path"].ToString());
                    else
                        this.pictureBoxLogo.Image = null;
                }
                else
                {
                    this.pictureBoxLogo.Image = null;
                }
                logoReader.Close();
            }
            ChangeSize();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            this.textBoxAddress.ReadOnly = false;
            this.textBoxBlood.ReadOnly = false;
            this.textBoxWeight.ReadOnly = false;
            this.textBoxHeight.ReadOnly = false;
            this.textBoxIntro.ReadOnly = false;
            this.buttonSave.Enabled = true;
            this.buttonChangeLogo.Enabled = true;
            this.buttonChangeLogo.Visible = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string id = selectedGrid.Cells[0].Value.ToString();
            StudentDetail std = new StudentDetail();
            std.Id = int.Parse(id);
            std.Address = this.textBoxAddress.Text;
            std.Blood = this.textBoxBlood.Text;
            if(this.textBoxHeight.Text != "")
                std.Height = int.Parse(this.textBoxHeight.Text);
            if(this.textBoxWeight.Text != "")
                std.Weight = int.Parse(this.textBoxWeight.Text);
            std.Intro = this.textBoxIntro.Text;
            sqlServerSingleton.DeleteDetail(id);
            sqlServerSingleton.InsertDetail(std);           
            this.dataGridViewShowStudentInfo.Focus();
            this.buttonChangeLogo.Enabled = false;
            this.buttonChangeLogo.Visible = false;
            MessageBox.Show("Success！");
        }

        private void RefeshDataGridView()
        {                          
            DataSet dsPage = sqlServerSingleton.QueryStudents(treeViewNode,currentPage, searchName, false);
            this.dataGridViewShowStudentInfo.DataSource = dsPage.Tables[0];
            if(dsPage.Tables[0].Rows.Count != 0)
                dataGridViewShowStudentInfo.Rows[0].Selected = false;
        }

        private void RefeshCountLabel()
        {           
            DataSet ds = sqlServerSingleton.QueryStudents(treeViewNode,currentPage,searchName,true);            
            double countStudent = (double)ds.Tables[0].Rows.Count;
            this.labelCount.Text = "共 " + countStudent + " 人";
            allPage = Math.Ceiling(countStudent / 10);
            if(allPage == 0)
            {
                this.labelCurrent.Text = 0 + "";
            }
            else
            {
                PageStatus();
            }                                  
        }

        private void PageStatus()
        {
            this.labelCurrent.Text = currentPage + "/" + allPage;
            if (currentPage < allPage)
            {
                this.buttonNext.Enabled = true;
            }
            else
            {
                this.buttonNext.Enabled = false;
            }
            if (currentPage > 1)
            {
                this.buttonPrevious.Enabled = true;
            }
            else
            {
                this.buttonPrevious.Enabled = false;
            }
        }

        private void buttonChangeLogo_Click(object sender, EventArgs e)
        {
            string id = dataGridViewShowStudentInfo.SelectedRows[0].Cells[0].Value.ToString();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg";
            ofd.Multiselect = false;
            string newPath = "";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sqlServerSingleton.DeleteLogo(id);
                string path = System.Environment.CurrentDirectory + @"/Images/" + id + ".jpg";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (Stream stream = ofd.OpenFile())
                {
                    newPath = System.Environment.CurrentDirectory + @"/Images/" + id + ".jpg";
                    using (FileStream fs = new FileStream(newPath, FileMode.CreateNew))
                    {
                        stream.CopyTo(fs);
                        fs.Flush();
                    }
                }
                Picture studentPic = new Picture();
                studentPic.Id = int.Parse(id);
                studentPic.Path = newPath;
                sqlServerSingleton.InsertPicture(studentPic);
            }
            SqlDataReader logoReader = sqlServerSingleton.QueryLogo(id);     //执行SQL，返回一个“流”
            if (logoReader.Read())
            {
                if (logoReader["path"].ToString() != "")
                    this.pictureBoxLogo.Image = Image.FromFile(logoReader["path"].ToString());
                else
                    this.pictureBoxLogo.Image = null;
            }
            else
            {
                this.pictureBoxLogo.Image = null;
            }
            logoReader.Close();
        }

        private void InitGroupBoxStatus()
        {
            this.textBoxAddress.ReadOnly = true;
            this.textBoxBlood.ReadOnly = true;
            this.textBoxWeight.ReadOnly = true;
            this.textBoxHeight.ReadOnly = true;
            this.textBoxIntro.ReadOnly = true;
            this.buttonSave.Enabled = true;
            this.buttonChangeLogo.Enabled = false;
            this.buttonChangeLogo.Visible = false; 
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if(this.textBoxSearchName.Text != "")
            {
                currentPage = 1;
                searchName = this.textBoxSearchName.Text;
                RefeshCountLabel();
                RefeshDataGridView();                
                if(dataGridViewShowStudentInfo.RowCount == 0)
                {
                    MessageBox.Show("未查到符合该姓名的同学！");
                }
            }
            this.treeViewOrgStudent.SelectedNode = null;
        }

        private void buttonExcel_Click(object sender, EventArgs e)
        {
            DataSet ds = sqlServerSingleton.QueryStudents(treeViewNode,currentPage,null,false);
            int rowNumber = ds.Tables[0].Rows.Count;
            int columnNumber = ds.Tables[0].Columns.Count; 
            if (rowNumber == 0) 
            { 
                MessageBox.Show("没有任何数据可以导入到Excel文件！");  
            }
            else
            {
                try
                {                    
                    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                    excel.Visible = false;
                    excel.DisplayAlerts = false;
                    Object missing = System.Reflection.Missing.Value;
                    Workbook objBook = excel.Workbooks.Add(missing);
                    Worksheet objSheet = (Worksheet)objBook.Worksheets.get_Item(1);
                    for (int i = 0; i < ds.Tables[0].Columns.Count; i++)

                    {

                        objSheet.Cells[1, i + 1] = ds.Tables[0].Columns[i].ToString();

                    }
                    for (int c = 0; c < rowNumber; c++)
                    {
                        for (int j = 0; j < columnNumber; j++)
                        {
                            objSheet.Cells[c + 2, j + 1] = ds.Tables[0].Rows[c].ItemArray[j];
                        }
                    }
                    string excelName = "";
                    if(treeViewNode.Grade == 0 && treeViewNode.Class == 0)
                    {
                        excelName = "全部学生";
                    }
                    else
                    {
                        if (treeViewNode.Grade != 0)
                            excelName = excelName + treeViewNode.Grade + "年级";
                        if (treeViewNode.Class != 0)
                            excelName = excelName + treeViewNode.Class + "班";
                    }
                    objBook.SaveCopyAs(System.Environment.CurrentDirectory + "\\" + excelName + ".xlsx");                   
                    excel.Quit();
                    excel = null;
                    MessageBox.Show("导出成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误提示");
                    throw (ex);
                }              
            }
        }

        private void textBoxSearchNameEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                buttonSearch_Click(sender,e);
            }
        }
    }
}
