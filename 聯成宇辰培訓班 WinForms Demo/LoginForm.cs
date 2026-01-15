using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using MySql.Data.MySqlClient;
using 聯成宇辰培訓班_WinForms_Demo;
using 聯成宇辰培訓班_WinForms_Demo.Functions;
using 聯成宇辰培訓班_WinForms_Demo.NewFolder;

namespace 進銷存系統_Demo
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void ButtonLogin_Click(object sender, EventArgs e) //登入按鈕
        { 
            IDb iDb = new Tools();
            var result = iDb.Login(textBoxAccount.Text, textBoxPassword.Text);
            if (result.IsSuccess)
            {
                if (result.Data == null)
                {
                    MessageBox.Show("資料異常", "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textBoxPassword.Text = string.Empty;
                this.Hide();

                EditForm editForm = new(result.Data);
                DialogResult dialogResult = editForm.ShowDialog();
                if (dialogResult != DialogResult.OK && !editForm.IsLogout) 
                {
                    this.Close();
                }
                else
                {
                    this.Show();
                }

            }
            else
            {
                MessageBox.Show(result.Message, "登入失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
