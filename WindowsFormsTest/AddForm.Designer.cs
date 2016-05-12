namespace WindowsFormsTest
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelId = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelGrade = new System.Windows.Forms.Label();
            this.labelClass = new System.Windows.Forms.Label();
            this.labelTelephone = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxTelephone = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.buttonAddDetail = new System.Windows.Forms.Button();
            this.groupBoxAddDetail = new System.Windows.Forms.GroupBox();
            this.textBoxUploadFile = new System.Windows.Forms.TextBox();
            this.textBoxIntro = new System.Windows.Forms.TextBox();
            this.buttonUpLoad = new System.Windows.Forms.Button();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.textBoxBlood = new System.Windows.Forms.TextBox();
            this.textBoxHeight = new System.Windows.Forms.TextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelIntro = new System.Windows.Forms.Label();
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelBlood = new System.Windows.Forms.Label();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.groupBoxAddDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(12, 19);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(17, 12);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "Id";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(210, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(29, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Name";
            // 
            // labelGrade
            // 
            this.labelGrade.AutoSize = true;
            this.labelGrade.Location = new System.Drawing.Point(12, 53);
            this.labelGrade.Name = "labelGrade";
            this.labelGrade.Size = new System.Drawing.Size(35, 12);
            this.labelGrade.TabIndex = 2;
            this.labelGrade.Text = "Grade";
            // 
            // labelClass
            // 
            this.labelClass.AutoSize = true;
            this.labelClass.Location = new System.Drawing.Point(204, 53);
            this.labelClass.Name = "labelClass";
            this.labelClass.Size = new System.Drawing.Size(35, 12);
            this.labelClass.TabIndex = 3;
            this.labelClass.Text = "Class";
            // 
            // labelTelephone
            // 
            this.labelTelephone.AutoSize = true;
            this.labelTelephone.Location = new System.Drawing.Point(12, 86);
            this.labelTelephone.Name = "labelTelephone";
            this.labelTelephone.Size = new System.Drawing.Size(59, 12);
            this.labelTelephone.TabIndex = 4;
            this.labelTelephone.Text = "Telephone";
            // 
            // textBoxId
            // 
            this.textBoxId.Location = new System.Drawing.Point(53, 16);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.ReadOnly = true;
            this.textBoxId.Size = new System.Drawing.Size(122, 21);
            this.textBoxId.TabIndex = 5;
            this.textBoxId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            this.textBoxId.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNotNull_Validating);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(245, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(119, 21);
            this.textBoxName.TabIndex = 6;
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNotNull_Validating);
            // 
            // textBoxTelephone
            // 
            this.textBoxTelephone.Location = new System.Drawing.Point(77, 83);
            this.textBoxTelephone.Name = "textBoxTelephone";
            this.textBoxTelephone.Size = new System.Drawing.Size(287, 21);
            this.textBoxTelephone.TabIndex = 9;
            this.textBoxTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            this.textBoxTelephone.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxTelephone_Validating);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(107, 344);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 23);
            this.buttonSubmit.TabIndex = 10;
            this.buttonSubmit.Text = "提交";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(223, 344);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 11;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Location = new System.Drawing.Point(53, 50);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(122, 20);
            this.comboBoxGrade.TabIndex = 12;
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(245, 50);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(119, 20);
            this.comboBoxClass.TabIndex = 13;
            // 
            // buttonAddDetail
            // 
            this.buttonAddDetail.Location = new System.Drawing.Point(12, 115);
            this.buttonAddDetail.Name = "buttonAddDetail";
            this.buttonAddDetail.Size = new System.Drawing.Size(89, 23);
            this.buttonAddDetail.TabIndex = 14;
            this.buttonAddDetail.Text = "添加详细信息";
            this.buttonAddDetail.UseVisualStyleBackColor = true;
            this.buttonAddDetail.Click += new System.EventHandler(this.buttonAddDetail_Click);
            // 
            // groupBoxAddDetail
            // 
            this.groupBoxAddDetail.Controls.Add(this.textBoxUploadFile);
            this.groupBoxAddDetail.Controls.Add(this.textBoxIntro);
            this.groupBoxAddDetail.Controls.Add(this.buttonUpLoad);
            this.groupBoxAddDetail.Controls.Add(this.textBoxWeight);
            this.groupBoxAddDetail.Controls.Add(this.textBoxBlood);
            this.groupBoxAddDetail.Controls.Add(this.textBoxHeight);
            this.groupBoxAddDetail.Controls.Add(this.textBoxAddress);
            this.groupBoxAddDetail.Controls.Add(this.labelIntro);
            this.groupBoxAddDetail.Controls.Add(this.labelWeight);
            this.groupBoxAddDetail.Controls.Add(this.labelBlood);
            this.groupBoxAddDetail.Controls.Add(this.labelHeight);
            this.groupBoxAddDetail.Controls.Add(this.labelAddress);
            this.groupBoxAddDetail.Location = new System.Drawing.Point(14, 144);
            this.groupBoxAddDetail.Name = "groupBoxAddDetail";
            this.groupBoxAddDetail.Size = new System.Drawing.Size(350, 194);
            this.groupBoxAddDetail.TabIndex = 15;
            this.groupBoxAddDetail.TabStop = false;
            this.groupBoxAddDetail.Text = "详细信息";
            // 
            // textBoxUploadFile
            // 
            this.textBoxUploadFile.Location = new System.Drawing.Point(96, 165);
            this.textBoxUploadFile.Name = "textBoxUploadFile";
            this.textBoxUploadFile.Size = new System.Drawing.Size(248, 21);
            this.textBoxUploadFile.TabIndex = 17;
            // 
            // textBoxIntro
            // 
            this.textBoxIntro.Location = new System.Drawing.Point(8, 88);
            this.textBoxIntro.Multiline = true;
            this.textBoxIntro.Name = "textBoxIntro";
            this.textBoxIntro.Size = new System.Drawing.Size(336, 69);
            this.textBoxIntro.TabIndex = 9;
            // 
            // buttonUpLoad
            // 
            this.buttonUpLoad.Location = new System.Drawing.Point(6, 163);
            this.buttonUpLoad.Name = "buttonUpLoad";
            this.buttonUpLoad.Size = new System.Drawing.Size(84, 23);
            this.buttonUpLoad.TabIndex = 16;
            this.buttonUpLoad.Text = "上传图片";
            this.buttonUpLoad.UseVisualStyleBackColor = true;
            this.buttonUpLoad.Click += new System.EventHandler(this.buttonUpLoad_Click);
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(219, 47);
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(125, 21);
            this.textBoxWeight.TabIndex = 8;
            this.textBoxWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // textBoxBlood
            // 
            this.textBoxBlood.Location = new System.Drawing.Point(41, 47);
            this.textBoxBlood.Name = "textBoxBlood";
            this.textBoxBlood.Size = new System.Drawing.Size(120, 21);
            this.textBoxBlood.TabIndex = 7;
            // 
            // textBoxHeight
            // 
            this.textBoxHeight.Location = new System.Drawing.Point(219, 18);
            this.textBoxHeight.Name = "textBoxHeight";
            this.textBoxHeight.Size = new System.Drawing.Size(125, 21);
            this.textBoxHeight.TabIndex = 6;
            this.textBoxHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInt_KeyPress);
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(41, 18);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(120, 21);
            this.textBoxAddress.TabIndex = 5;
            // 
            // labelIntro
            // 
            this.labelIntro.AutoSize = true;
            this.labelIntro.Location = new System.Drawing.Point(6, 73);
            this.labelIntro.Name = "labelIntro";
            this.labelIntro.Size = new System.Drawing.Size(53, 12);
            this.labelIntro.TabIndex = 4;
            this.labelIntro.Text = "个人简介";
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(184, 50);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(29, 12);
            this.labelWeight.TabIndex = 3;
            this.labelWeight.Text = "体重";
            // 
            // labelBlood
            // 
            this.labelBlood.AutoSize = true;
            this.labelBlood.Location = new System.Drawing.Point(6, 50);
            this.labelBlood.Name = "labelBlood";
            this.labelBlood.Size = new System.Drawing.Size(29, 12);
            this.labelBlood.TabIndex = 2;
            this.labelBlood.Text = "血型";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(184, 23);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(29, 12);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "身高";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(6, 23);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(29, 12);
            this.labelAddress.TabIndex = 0;
            this.labelAddress.Text = "籍贯";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 379);
            this.Controls.Add(this.groupBoxAddDetail);
            this.Controls.Add(this.buttonAddDetail);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.comboBoxGrade);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxTelephone);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.labelTelephone);
            this.Controls.Add(this.labelClass);
            this.Controls.Add(this.labelGrade);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AddForm_MouseUp);
            this.groupBoxAddDetail.ResumeLayout(false);
            this.groupBoxAddDetail.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelGrade;
        private System.Windows.Forms.Label labelClass;
        private System.Windows.Forms.Label labelTelephone;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxTelephone;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Button buttonAddDetail;
        private System.Windows.Forms.GroupBox groupBoxAddDetail;
        private System.Windows.Forms.TextBox textBoxIntro;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.TextBox textBoxBlood;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelIntro;
        private System.Windows.Forms.Label labelWeight;
        private System.Windows.Forms.Label labelBlood;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Button buttonUpLoad;
        private System.Windows.Forms.TextBox textBoxUploadFile;
    }
}