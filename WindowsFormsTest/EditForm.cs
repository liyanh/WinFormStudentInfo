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
    public partial class EditForm : Form
    {
        private SqlServerHelper sqlServerSingleton = SqlServerHelper.GetInstance();
        public EditForm(int id, string name ,int grade,int clss,string telephone)
        {
            InitializeComponent();            
            comboBoxGrade.DataSource = InitComboBox.getComboBoxGradeDataTable();
            comboBoxGrade.DisplayMember = "grade";
            comboBoxGrade.ValueMember = "val";
            comboBoxGrade.SelectedIndex = -1;
            comboBoxClass.DataSource = InitComboBox.getComboBoxClassDataTable();
            comboBoxClass.DisplayMember = "clss";
            comboBoxClass.ValueMember = "val";
            comboBoxClass.SelectedIndex = -1;
            this.textBoxId.Text = id.ToString();
            this.textBoxName.Text = name.ToString();
            this.comboBoxGrade.SelectedValue = grade;
            this.comboBoxClass.SelectedValue = clss;
            this.textBoxTelephone.Text = telephone.ToString();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            StudentInfo editStudent = new StudentInfo();
            editStudent.Id = int.Parse(this.textBoxId.Text);
            editStudent.Name = textBoxName.Text;
            editStudent.Grade = int.Parse(comboBoxGrade.SelectedValue.ToString());
            editStudent.Class = int.Parse(comboBoxClass.SelectedValue.ToString());
            editStudent.Telephone = textBoxTelephone.Text;
            //new XmlHandler().EditStudent(editStudent);
            //string updt = updtCommd + "name=" + "'" + editStudent.Name + "'" + "," + "Grade=" + editStudent.Grade + "," + "Class=" + editStudent.Class + "," + "Telephone=" + "'" + editStudent.Telephone + "'" + " where id=" + editStudent.Id;
            sqlServerSingleton.UpdateStudent(editStudent);
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxNotNull_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("姓名不能为空！");
                buttonSaveOk();
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                buttonSaveOk();
            }
        }

        private void buttonSaveOk()
        {
            if(this.textBoxName.Text != "" && this.textBoxTelephone.BackColor != Color.Red)
                this.buttonSave.Enabled = true;
            else
                this.buttonSave.Enabled = false;
        }

        private void textBoxInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show("请输入阿拉伯数字！");
            }
        }

        private void textBoxTelephone_Validating(object sender, CancelEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Text != "" && tb.Text.Length != 11)
            {
                tb.BackColor = Color.Red;
                MessageBox.Show("电话号码必须为11位数字！");
                buttonSaveOk();
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                buttonSaveOk();
            }
        }
    }
}
