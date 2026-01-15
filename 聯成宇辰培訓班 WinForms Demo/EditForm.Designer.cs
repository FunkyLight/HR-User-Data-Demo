namespace 聯成宇辰培訓班_WinForms_Demo
{
    partial class EditForm
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
            dataGridView1 = new DataGridView();
            label10 = new Label();
            textBoxResign = new TextBox();
            dateTimePickerJoinDate = new DateTimePicker();
            buttonResign = new Button();
            buttonSave = new Button();
            label9 = new Label();
            textBoxNote = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBoxEmail = new TextBox();
            textBoxMobile = new TextBox();
            label6 = new Label();
            label5 = new Label();
            comboBoxRank = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label1 = new Label();
            comboBoxDept = new ComboBox();
            textBoxName = new TextBox();
            textBoxPassword = new TextBox();
            textBoxAccount = new TextBox();
            label12 = new Label();
            comboBoxGender = new ComboBox();
            textBoxCreateDate = new TextBox();
            label13 = new Label();
            buttonNew = new Button();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripTextBox1 = new ToolStripTextBox();
            buttonCancel = new Button();
            monthCalendarResign = new MonthCalendar();
            textBoxSearch = new TextBox();
            label11 = new Label();
            label14 = new Label();
            comboBox1 = new ComboBox();
            label15 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(21, 113);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(667, 679);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // label10
            // 
            label10.Font = new Font("Microsoft JhengHei UI", 12F);
            label10.Location = new Point(735, 325);
            label10.Name = "label10";
            label10.Size = new Size(89, 20);
            label10.TabIndex = 52;
            label10.Text = "就職狀態";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxResign
            // 
            textBoxResign.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxResign.Location = new Point(830, 322);
            textBoxResign.MaxLength = 8;
            textBoxResign.Name = "textBoxResign";
            textBoxResign.ReadOnly = true;
            textBoxResign.Size = new Size(175, 28);
            textBoxResign.TabIndex = 51;
            // 
            // dateTimePickerJoinDate
            // 
            dateTimePickerJoinDate.Enabled = false;
            dateTimePickerJoinDate.Font = new Font("Microsoft JhengHei UI", 12F);
            dateTimePickerJoinDate.Location = new Point(830, 259);
            dateTimePickerJoinDate.Name = "dateTimePickerJoinDate";
            dateTimePickerJoinDate.Size = new Size(175, 28);
            dateTimePickerJoinDate.TabIndex = 50;
            // 
            // buttonResign
            // 
            buttonResign.Enabled = false;
            buttonResign.Font = new Font("Microsoft JhengHei UI", 12F);
            buttonResign.Location = new Point(1011, 322);
            buttonResign.Name = "buttonResign";
            buttonResign.Size = new Size(53, 28);
            buttonResign.TabIndex = 48;
            buttonResign.Text = "離職";
            buttonResign.UseVisualStyleBackColor = true;
            buttonResign.Visible = false;
            buttonResign.Click += ButtonResign_Click;
            // 
            // buttonSave
            // 
            buttonSave.Font = new Font("Microsoft JhengHei UI", 12F);
            buttonSave.Location = new Point(1194, 752);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 40);
            buttonSave.TabIndex = 47;
            buttonSave.Text = "編輯";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += ButtonSave_Click;
            // 
            // label9
            // 
            label9.Font = new Font("Microsoft JhengHei UI", 12F);
            label9.Location = new Point(735, 609);
            label9.Name = "label9";
            label9.Size = new Size(89, 20);
            label9.TabIndex = 46;
            label9.Text = "備註";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxNote
            // 
            textBoxNote.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxNote.Location = new Point(830, 511);
            textBoxNote.MaxLength = 8;
            textBoxNote.Multiline = true;
            textBoxNote.Name = "textBoxNote";
            textBoxNote.ReadOnly = true;
            textBoxNote.Size = new Size(534, 217);
            textBoxNote.TabIndex = 45;
            // 
            // label7
            // 
            label7.Font = new Font("Microsoft JhengHei UI", 12F);
            label7.Location = new Point(735, 388);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 44;
            label7.Text = "行動電話";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.Font = new Font("Microsoft JhengHei UI", 12F);
            label8.Location = new Point(735, 451);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 43;
            label8.Text = "電子信箱";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxEmail.Location = new Point(830, 448);
            textBoxEmail.MaxLength = 8;
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(230, 28);
            textBoxEmail.TabIndex = 42;
            // 
            // textBoxMobile
            // 
            textBoxMobile.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxMobile.Location = new Point(830, 385);
            textBoxMobile.MaxLength = 8;
            textBoxMobile.Name = "textBoxMobile";
            textBoxMobile.ReadOnly = true;
            textBoxMobile.Size = new Size(175, 28);
            textBoxMobile.TabIndex = 41;
            // 
            // label6
            // 
            label6.Font = new Font("Microsoft JhengHei UI", 12F);
            label6.Location = new Point(751, 199);
            label6.Name = "label6";
            label6.Size = new Size(73, 20);
            label6.TabIndex = 40;
            label6.Text = "建立日期";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Font = new Font("Microsoft JhengHei UI", 12F);
            label5.Location = new Point(1087, 262);
            label5.Name = "label5";
            label5.Size = new Size(41, 20);
            label5.TabIndex = 39;
            label5.Text = "職級";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoxRank
            // 
            comboBoxRank.Enabled = false;
            comboBoxRank.Font = new Font("Microsoft JhengHei UI", 12F);
            comboBoxRank.FormattingEnabled = true;
            comboBoxRank.Location = new Point(1134, 259);
            comboBoxRank.Name = "comboBoxRank";
            comboBoxRank.Size = new Size(121, 28);
            comboBoxRank.TabIndex = 38;
            // 
            // label3
            // 
            label3.Font = new Font("Microsoft JhengHei UI", 12F);
            label3.Location = new Point(783, 137);
            label3.Name = "label3";
            label3.Size = new Size(41, 20);
            label3.TabIndex = 37;
            label3.Text = "姓名";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.Font = new Font("Microsoft JhengHei UI", 12F);
            label4.Location = new Point(1087, 202);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 36;
            label4.Text = "部門";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft JhengHei UI", 12F);
            label2.Location = new Point(1087, 74);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 35;
            label2.Text = "密碼";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft JhengHei UI", 12F);
            label1.Location = new Point(735, 74);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 34;
            label1.Text = "使用者編號";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoxDept
            // 
            comboBoxDept.Enabled = false;
            comboBoxDept.Font = new Font("Microsoft JhengHei UI", 12F);
            comboBoxDept.FormattingEnabled = true;
            comboBoxDept.Location = new Point(1134, 199);
            comboBoxDept.Name = "comboBoxDept";
            comboBoxDept.Size = new Size(121, 28);
            comboBoxDept.TabIndex = 33;
            // 
            // textBoxName
            // 
            textBoxName.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxName.Location = new Point(830, 133);
            textBoxName.MaxLength = 8;
            textBoxName.Name = "textBoxName";
            textBoxName.ReadOnly = true;
            textBoxName.Size = new Size(121, 28);
            textBoxName.TabIndex = 32;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxPassword.Location = new Point(1134, 70);
            textBoxPassword.MaxLength = 8;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.ReadOnly = true;
            textBoxPassword.Size = new Size(175, 28);
            textBoxPassword.TabIndex = 31;
            // 
            // textBoxAccount
            // 
            textBoxAccount.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxAccount.Location = new Point(830, 70);
            textBoxAccount.MaxLength = 8;
            textBoxAccount.Name = "textBoxAccount";
            textBoxAccount.ReadOnly = true;
            textBoxAccount.Size = new Size(175, 28);
            textBoxAccount.TabIndex = 30;
            // 
            // label12
            // 
            label12.Font = new Font("Microsoft JhengHei UI", 12F);
            label12.Location = new Point(1087, 137);
            label12.Name = "label12";
            label12.Size = new Size(41, 20);
            label12.TabIndex = 55;
            label12.Text = "性別";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBoxGender
            // 
            comboBoxGender.Enabled = false;
            comboBoxGender.Font = new Font("Microsoft JhengHei UI", 12F);
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Location = new Point(1134, 133);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(121, 28);
            comboBoxGender.TabIndex = 56;
            // 
            // textBoxCreateDate
            // 
            textBoxCreateDate.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxCreateDate.Location = new Point(830, 196);
            textBoxCreateDate.MaxLength = 8;
            textBoxCreateDate.Name = "textBoxCreateDate";
            textBoxCreateDate.ReadOnly = true;
            textBoxCreateDate.Size = new Size(175, 28);
            textBoxCreateDate.TabIndex = 57;
            // 
            // label13
            // 
            label13.Font = new Font("Microsoft JhengHei UI", 12F);
            label13.Location = new Point(751, 264);
            label13.Name = "label13";
            label13.Size = new Size(73, 20);
            label13.TabIndex = 58;
            label13.Text = "入職日期";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // buttonNew
            // 
            buttonNew.Enabled = false;
            buttonNew.Font = new Font("Microsoft JhengHei UI", 12F);
            buttonNew.Location = new Point(1106, 752);
            buttonNew.Name = "buttonNew";
            buttonNew.Size = new Size(82, 40);
            buttonNew.TabIndex = 59;
            buttonNew.Text = "新增";
            buttonNew.UseVisualStyleBackColor = true;
            buttonNew.Visible = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Menu;
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripTextBox1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1399, 28);
            menuStrip1.TabIndex = 60;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2 });
            toolStripMenuItem1.Font = new Font("Microsoft JhengHei UI", 12F);
            toolStripMenuItem1.ForeColor = SystemColors.ControlText;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(101, 24);
            toolStripMenuItem1.Text = "使用者管理";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(110, 24);
            toolStripMenuItem2.Text = "登出";
            toolStripMenuItem2.Click += ToolStripMenuItemLogout_Click;
            // 
            // toolStripTextBox1
            // 
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.ReadOnly = true;
            toolStripTextBox1.Size = new Size(200, 24);
            // 
            // buttonCancel
            // 
            buttonCancel.Enabled = false;
            buttonCancel.Font = new Font("Microsoft JhengHei UI", 12F);
            buttonCancel.Location = new Point(1282, 752);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(82, 40);
            buttonCancel.TabIndex = 61;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // monthCalendarResign
            // 
            monthCalendarResign.Location = new Point(1012, 351);
            monthCalendarResign.Name = "monthCalendarResign";
            monthCalendarResign.TabIndex = 63;
            monthCalendarResign.DateSelected += MonthCalendarResign_DateSelected;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxSearch.Location = new Point(101, 70);
            textBoxSearch.MaxLength = 8;
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(121, 28);
            textBoxSearch.TabIndex = 64;
            // 
            // label11
            // 
            label11.Font = new Font("Microsoft JhengHei UI", 12F);
            label11.Location = new Point(21, 73);
            label11.Name = "label11";
            label11.Size = new Size(74, 20);
            label11.TabIndex = 65;
            label11.Text = "搜尋姓名";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            label14.Font = new Font("Microsoft JhengHei UI", 12F);
            label14.Location = new Point(330, 73);
            label14.Name = "label14";
            label14.Size = new Size(41, 20);
            label14.TabIndex = 67;
            label14.Text = "部門";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.Font = new Font("Microsoft JhengHei UI", 12F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(377, 70);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 28);
            comboBox1.TabIndex = 66;
            // 
            // label15
            // 
            label15.Font = new Font("Microsoft JhengHei UI", 12F);
            label15.Location = new Point(520, 73);
            label15.Name = "label15";
            label15.Size = new Size(41, 20);
            label15.TabIndex = 69;
            label15.Text = "職級";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox2
            // 
            comboBox2.Enabled = false;
            comboBox2.Font = new Font("Microsoft JhengHei UI", 12F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(567, 70);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 28);
            comboBox2.TabIndex = 68;
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft JhengHei UI", 12F);
            button1.Location = new Point(228, 70);
            button1.Name = "button1";
            button1.Size = new Size(53, 28);
            button1.TabIndex = 70;
            button1.Text = "搜尋";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 823);
            Controls.Add(button1);
            Controls.Add(label15);
            Controls.Add(comboBox2);
            Controls.Add(label14);
            Controls.Add(comboBox1);
            Controls.Add(label11);
            Controls.Add(textBoxSearch);
            Controls.Add(monthCalendarResign);
            Controls.Add(buttonCancel);
            Controls.Add(buttonNew);
            Controls.Add(label13);
            Controls.Add(textBoxCreateDate);
            Controls.Add(comboBoxGender);
            Controls.Add(label12);
            Controls.Add(label10);
            Controls.Add(textBoxResign);
            Controls.Add(dateTimePickerJoinDate);
            Controls.Add(buttonResign);
            Controls.Add(buttonSave);
            Controls.Add(label9);
            Controls.Add(textBoxNote);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxMobile);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBoxRank);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(comboBoxDept);
            Controls.Add(textBoxName);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxAccount);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "EditForm";
            Text = "MainForm";
            Load += ListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label10;
        private TextBox textBoxResign;
        private DateTimePicker dateTimePickerJoinDate;
        private Button buttonResign;
        private Button buttonSave;
        private Label label9;
        private TextBox textBoxNote;
        private Label label7;
        private Label label8;
        private TextBox textBoxEmail;
        private TextBox textBoxMobile;
        private Label label6;
        private Label label5;
        private ComboBox comboBoxRank;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label1;
        private ComboBox comboBoxDept;
        private TextBox textBoxName;
        private TextBox textBoxPassword;
        private TextBox textBoxAccount;
        private Label label12;
        private ComboBox comboBoxGender;
        private TextBox textBoxCreateDate;
        private Label label13;
        private Button buttonNew;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripTextBox toolStripTextBox1;
        private Button buttonCancel;
        private MonthCalendar monthCalendarResign;
        private TextBox textBoxSearch;
        private Label label11;
        private Label label14;
        private ComboBox comboBox1;
        private Label label15;
        private ComboBox comboBox2;
        private Button button1;
    }
}