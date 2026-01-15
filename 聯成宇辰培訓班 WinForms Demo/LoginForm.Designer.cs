namespace 進銷存系統_Demo
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxAccount = new TextBox();
            textBoxPassword = new TextBox();
            label2 = new Label();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 12F);
            label1.Location = new Point(66, 140);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "使用者編號";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxAccount
            // 
            textBoxAccount.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxAccount.Location = new Point(161, 137);
            textBoxAccount.MaxLength = 8;
            textBoxAccount.Name = "textBoxAccount";
            textBoxAccount.Size = new Size(174, 28);
            textBoxAccount.TabIndex = 1;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Font = new Font("Microsoft JhengHei UI", 12F);
            textBoxPassword.Location = new Point(161, 180);
            textBoxPassword.MaxLength = 8;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(174, 28);
            textBoxPassword.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 12F);
            label2.Location = new Point(114, 183);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 2;
            label2.Text = "密碼";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonLogin
            // 
            buttonLogin.Font = new Font("Microsoft JhengHei UI", 12F);
            buttonLogin.Location = new Point(354, 137);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(82, 71);
            buttonLogin.TabIndex = 4;
            buttonLogin.Text = "登入";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += ButtonLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = buttonLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(522, 367);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(label2);
            Controls.Add(textBoxAccount);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "進銷存系統 Demo";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxAccount;
        private TextBox textBoxPassword;
        private Label label2;
        private Button buttonLogin;
    }
}
