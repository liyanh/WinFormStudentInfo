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

namespace WindowsFormsTest
{
    public partial class AddForm : Form
    {
        private static bool groupBoxVisable = false;
        private SqlServerHelper sqlServerSingleton = SqlServerHelper.GetInstance();
        public AddForm(int grade, int clss)
        {
            InitializeComponent();
            SetTexVBoxId();
            comboBoxGrade.DataSource = InitComboBox.getComboBoxGradeDataTable();
            comboBoxGrade.DisplayMember = "grade";
            comboBoxGrade.ValueMember = "val";
            comboBoxGrade.SelectedIndex = -1;
            comboBoxClass.DataSource = InitComboBox.getComboBoxClassDataTable();
            comboBoxClass.DisplayMember = "clss";
            comboBoxClass.ValueMember = "val";
            comboBoxClass.SelectedIndex = -1;
            if (grade != 0)
            {
                this.comboBoxGrade.SelectedValue = grade;
            }
            if (clss != 0)
            {
                this.comboBoxClass.SelectedValue = clss;
            }
            this.buttonSubmit.Enabled = false;
            groupBoxVisable = false;
            groupBoxAddDetail.Visible = groupBoxVisable;           
        }       

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            StudentInfo addStudent = new StudentInfo();
            addStudent.Id = int.Parse(this.textBoxId.Text);
            addStudent.Name = textBoxName.Text;
            addStudent.Grade = int.Parse(comboBoxGrade.SelectedValue.ToString());
            addStudent.Class = int.Parse(comboBoxClass.SelectedValue.ToString());
            addStudent.Telephone = textBoxTelephone.Text;
            sqlServerSingleton.InsertStudent(addStudent);
            if ((this.textBoxAddress.Text + this.textBoxBlood.Text + this.textBoxHeight.Text + this.textBoxHeight.Text + this.textBoxIntro.Text) != "")
            {
                StudentDetail std = new StudentDetail();
                std.Id = addStudent.Id;
                std.Address = this.textBoxAddress.Text;
                std.Blood = this.textBoxBlood.Text;
                if (this.textBoxHeight.Text != "")
                    std.Height = int.Parse(this.textBoxHeight.Text);
                if (this.textBoxWeight.Text != "")
                    std.Weight = int.Parse(this.textBoxWeight.Text);
                std.Intro = this.textBoxIntro.Text;
                sqlServerSingleton.InsertDetail(std);
            }
            if (this.textBoxUploadFile.Text != "")
            {
                Picture studentPic = new Picture();
                studentPic.Id = addStudent.Id;
                studentPic.Path = this.textBoxUploadFile.Text;
                sqlServerSingleton.InsertPicture(studentPic);
            }
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }      

        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("请输入阿拉伯数字！");
            }
            buttonSubmitOk();
        }

        private void textBoxTelephone_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "" && tb.Text.Length != 11)
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("电话号码必须是11为数字！");
                buttonSubmitOk();
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                buttonSubmitOk();
            }
        }

        private void textBoxNotNull_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("姓名不能为空！");
                buttonSubmitOk();
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                buttonSubmitOk();
            }
        }

        private void buttonSubmitOk()
        {
            if (this.textBoxId.Text != "" && this.textBoxName.Text != ""  && this.textBoxTelephone.BackColor != Color.Red && this.comboBoxGrade.SelectedItem != null && this.comboBoxGrade.SelectedItem != null)
                this.buttonSubmit.Enabled = true;
            else
                this.buttonSubmit.Enabled = false;
        }

        private void buttonAddDetail_Click(object sender, EventArgs e)
        {
            groupBoxVisable = !groupBoxVisable;
            groupBoxAddDetail.Visible = groupBoxVisable;
        }

        private void buttonUpLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择上传的图片";
            ofd.Filter = "图片格式|*.jpg";
            ofd.Multiselect = false;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                string newPath = "";
                using (Stream stream = ofd.OpenFile())
                {
                    newPath = System.Environment.CurrentDirectory + @"/Images/" + this.textBoxId.Text + ".jpg";
                    using (FileStream fs = new FileStream(newPath, FileMode.CreateNew))
                    {
                        stream.CopyTo(fs);
                        fs.Flush();
                    }
                }
                this.textBoxUploadFile.Text = newPath;
            }           
        }

        private void AddForm_MouseUp(object sender, MouseEventArgs e)
        {
            buttonSubmitOk();
        }     

        private void SetTexVBoxId()
        {
            SqlDataReader idReader = sqlServerSingleton.GetId();
            if (idReader.Read())
            {
                this.textBoxId.Text = (int.Parse(idReader["id"].ToString()) + 1).ToString();
            }
            idReader.Close();
        }
    }
}
