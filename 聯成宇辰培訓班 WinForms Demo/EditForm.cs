using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using 聯成宇辰培訓班_WinForms_Demo.Functions;
using 聯成宇辰培訓班_WinForms_Demo.NewFolder;

namespace 聯成宇辰培訓班_WinForms_Demo
{
    public partial class EditForm : Form, IPerm
    {
        private readonly UserInfo Info = new();

        private DataTable data = new();
        private int selectedUserID;
        public bool IsLogout { get; private set; } = false;
        internal EditForm(UserInfo userInfo)
        {
            InitializeComponent();
            Info = userInfo; //資料備份
        }

        private void ListForm_Load(object sender, EventArgs e)
        {
            PermInit(Info.PermCodes ?? []);

            if (Info.PermCodes!.Contains("VIEW_ALL"))
            {
                IDb iDb = new Tools();
                Result<DataTable> result = iDb.GetUserDataTable(Info.ID, 0, 0, null, 1, 10);
                if (result.IsSuccess && result.Data != null)
                {
                    DataGridViewSet(result.Data);
                    AddInfo(result.Data!, Info);
                    data = result.Data!;
                }
                else
                {
                    MessageBox.Show(result.Message, "失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DataTable dt = new();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("使用者編號", typeof(string));
                dt.Columns.Add("姓名", typeof(string));
                dt.Columns.Add("部門", typeof(string));
                dt.Columns.Add("職級", typeof(string));
                dt.Columns.Add("性別", typeof(string));
                dt.Columns.Add("狀態", typeof(string));
                dt.Columns.Add("CreateDate", typeof(DateTime));
                dt.Columns.Add("JoinDate", typeof(DateTime));
                dt.Columns.Add("LeaveDate", typeof(DateTime));
                dt.Columns.Add("Mobile", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Note", typeof(string));

                DataGridViewSet(dt);
                AddInfo(dt, Info);
                data = dt;
            }
            LoadInfo(data, Info.ID);

            SelectRowByID(Info.ID);
        }

        private void ToolStripMenuItemLogout_Click(object sender, EventArgs e)
        {
            IsLogout = true;
            this.Close();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (buttonSave.Text == "編輯")
            {
                Edit(Info.PermCodes ?? []);
            }
            else if (IsDataChanged())
            {
                DialogResult result = MessageBox.Show("確定要更改資料嗎？", "變更確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                Save();
            }
        }

        private void ButtonResign_Click(object sender, EventArgs e)
        {
            buttonResign.Enabled = false;
            monthCalendarResign.Visible = true;
        }

        private void MonthCalendarResign_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime date = monthCalendarResign.SelectionStart;
            textBoxResign.Text = $"{date:yyyy年 MM月dd日}離職";
            monthCalendarResign.Visible = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (IsDataChanged())
            {
                DialogResult result = MessageBox.Show("確定要放棄修改嗎？", "變更確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No) return;
                LoadInfo(data, selectedUserID); //還原資料
            }
            PermInit(Info.PermCodes ?? []); //初始權限設定
            buttonCancel.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                var idValue = row.Cells["ID"].Value;

                if (idValue != null)
                {
                    selectedUserID = Convert.ToInt32(idValue);
                    LoadInfo(data, selectedUserID);
                    PermInit(Info.PermCodes ?? []); //初始權限設定
                }
            }
        }

        public void PermInit(List<string> permCodes)
        {
            textBoxAccount.ReadOnly = true;
            textBoxPassword.ReadOnly = true;
            textBoxName.ReadOnly = true;
            textBoxCreateDate.ReadOnly = true;
            textBoxResign.ReadOnly = true;
            textBoxMobile.ReadOnly = true;
            textBoxEmail.ReadOnly = true;
            textBoxNote.ReadOnly = true;

            dateTimePickerJoinDate.Enabled = false;

            monthCalendarResign.Visible = false;

            comboBoxGender.Enabled = false;
            comboBoxDept.Enabled = false;
            comboBoxRank.Enabled = false;

            buttonNew.Visible = permCodes.Contains("ADD_USER");
            buttonResign.Visible = permCodes.Contains("SET_RESIGN");
            buttonResign.Visible = permCodes.Contains("SET_RESIGNED");
            buttonResign.Enabled = false;
            buttonSave.Text = "編輯";

            textBoxNote.Visible = permCodes.Contains("WRITE_NOTE");
            label9.Text = string.Empty;
        }


        private void LoadInfo(DataTable dt, int ID)
        {
            DataRow? row = dt.AsEnumerable().FirstOrDefault(r => Convert.ToInt32(r["ID"]) == ID);

            if (row != null)
            {
                Info.Account = row.Field<string>("使用者編號") ?? "";
                Info.StaffName = row.Field<string>("姓名") ?? "";
                Info.Gender = row.Field<string>("性別") ?? "";
                Info.DeptName = row.Field<string>("部門") ?? "";
                Info.RankName = row.Field<string>("職級") ?? "";
                Info.Mobile = row.Field<string>("Mobile") ?? "";
                Info.Email = row.Field<string>("Email") ?? "";
                Info.Note = row.Field<string>("Note") ?? "";

                Info.CreateDate = row.Field<DateTime?>("CreateDate");
                Info.JoinDate = row.Field<DateTime?>("JoinDate");
                Info.LeaveDate = row.Field<DateTime?>("LeaveDate");

                // 判斷在職狀態
                string statusStr = row.Field<string>("狀態") ?? "離職";
                Info.IsEmployeed = (statusStr == "在職");

                textBoxAccount.Text = Info.Account;
                textBoxPassword.Text = "********";
                textBoxName.Text = Info.StaffName;
                comboBoxGender.Text = Info.Gender;
                comboBoxDept.Text = Info.DeptName;
                comboBoxRank.Text = Info.RankName;

                textBoxCreateDate.Text = Info.CreateDate?.ToString("yyyy年 MM月dd日") ?? "";
                dateTimePickerJoinDate.Value = Info.JoinDate ?? DateTime.Now;

                // 處理離職日顯示
                string leaveDateStr = Info.LeaveDate?.ToString("yyyy年 MM月dd日") ?? "";
                textBoxResign.Text = Info.IsEmployeed ? "在職中" : $"{leaveDateStr}離職";

                textBoxMobile.Text = Info.Mobile;
                textBoxEmail.Text = Info.Email;
                textBoxNote.Text = Info.Note;
            }
        }

        private void Edit(List<string> permCodes)
        {
            textBoxPassword.ReadOnly = Info.ID != selectedUserID;
            textBoxName.ReadOnly = !permCodes.Contains("EDIT_USER");
            textBoxMobile.ReadOnly = !permCodes.Contains("EDIT_USER");
            textBoxEmail.ReadOnly = !permCodes.Contains("EDIT_USER");
            textBoxNote.ReadOnly = !permCodes.Contains("EDIT_USER");

            comboBoxGender.Enabled = permCodes.Contains("EDIT_USER");
            comboBoxDept.Enabled = permCodes.Contains("EDIT_USER");
            comboBoxRank.Enabled = permCodes.Contains("EDIT_USER");

            dateTimePickerJoinDate.Enabled = permCodes.Contains("EDIT_USER");

            buttonSave.Text = "儲存";
            buttonCancel.Enabled = true;
            buttonResign.Enabled = true;
            buttonResign.Enabled = Info.IsEmployeed && permCodes.Contains("SET_RESIGNED");
            buttonNew.Text = permCodes.Contains("DELET_USER") ? "刪除": "新增" ;
            buttonNew.Enabled = permCodes.Contains("DELET_USER");
        }

        private void Save()
        {

        }

        private bool IsDataChanged()
        {
            static bool IsDiff(string uiValue, string? modelValue) => uiValue != (modelValue ?? string.Empty);

            // 比對各個欄位
            if (IsDiff(textBoxName.Text, Info.StaffName)) return true;
            if (IsDiff(textBoxMobile.Text, Info.Mobile)) return true;
            if (IsDiff(textBoxEmail.Text, Info.Email)) return true;
            if (IsDiff(textBoxNote.Text, Info.Note)) return true;

            if (IsDiff(comboBoxGender.Text, Info.Gender)) return true;
            if (IsDiff(comboBoxDept.Text, Info.DeptName)) return true;
            if (IsDiff(comboBoxRank.Text, Info.RankName)) return true;
            // 日期比對
            DateTime originJoin = Info.JoinDate ?? DateTime.MaxValue;
            if (dateTimePickerJoinDate.Value.Date != originJoin.Date) return true;
            if (Info.IsEmployeed && textBoxResign.Text != "在職中") return true;

            // 密碼不是預設掩碼時才算變更
            if (textBoxPassword.Text != "********") return true;

            return false;
        }

        private static void AddInfo(DataTable dt, UserInfo userInfo)
        {
            DataRow dr = dt.NewRow();
            dr["ID"] = userInfo.ID;
            dr["使用者編號"] = userInfo.Account;
            dr["姓名"] = userInfo.StaffName;
            dr["部門"] = userInfo.DeptName;
            dr["職級"] = userInfo.RankName;
            dr["性別"] = userInfo.Gender;
            dr["狀態"] = userInfo.IsEmployeed ? "在職" : "離職";
            dr["CreateDate"] = userInfo.CreateDate ?? DateTime.MinValue;
            dr["JoinDate"] = userInfo.JoinDate ?? DateTime.MinValue;
            dr["LeaveDate"] = userInfo.LeaveDate ?? DateTime.MinValue;
            dr["Mobile"] = userInfo.Mobile ?? "";
            dr["Email"] = userInfo.Email ?? "";
            dr["Note"] = userInfo.Note ?? "";
            dt.Rows.InsertAt(dr, 0);



        }

        private void DataGridViewSet(DataTable dt)
        {
            dataGridView1.DataSource = dt;

            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.RowHeadersVisible = false; //隱藏行標題

            dataGridView1.AllowUserToAddRows = false; //禁止新增行
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 45;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.Control;
            dataGridView1.ColumnHeadersDefaultCellStyle.SelectionBackColor = SystemColors.Control;

            dataGridView1.Columns["ID"]?.Visible = false;
            dataGridView1.Columns["CreateDate"]?.Visible = false;
            dataGridView1.Columns["JoinDate"]?.Visible = false;
            dataGridView1.Columns["LeaveDate"]?.Visible = false;
            dataGridView1.Columns["Mobile"]?.Visible = false;
            dataGridView1.Columns["Email"]?.Visible = false;
            dataGridView1.Columns["Note"]?.Visible = false;
            dataGridView1.ReadOnly = true;


            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridView1.Columns?["使用者編號"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns?["姓名"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns?["部門"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns?["職級"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns?["性別"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns?["狀態"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            dataGridView1.DefaultCellStyle.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Bold);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Height = 35;
            }
        }

        private void SelectRowByID(int targetID)
        {
            // 1. 先清除預設的選取 (避免多選或選錯)
            dataGridView1.ClearSelection();

            // 2. 遍歷所有列尋找目標
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // 確保 ID 欄位有值且轉型正確
                if (row.Cells["ID"].Value != null &&
                    int.TryParse(row.Cells["ID"].Value.ToString(), out int id))
                {
                    if (id == targetID)
                    {
                        // 3. 設定該列為「被選取」狀態 (變色)
                        row.Selected = true;

                        // 4. (選用) 將該列捲動到可視範圍 (如果資料很多，這行很重要)
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;

                        // 5. (選用) 設定焦點游標 (需指定一個 Visible=true 的欄位，例如"姓名")
                        // 這能讓鍵盤上下鍵直接從這一列開始
                        if (dataGridView1.Columns["姓名"]!.Visible)
                        {
                            dataGridView1.CurrentCell = row.Cells["姓名"];
                        }

                        break; // 找到後就跳出迴圈
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. 取得搜尋關鍵字並去除前後空白
            string keyword = textBoxSearch.Text.Trim();

            // 2. 防呆：處理單引號 (因為 RowFilter 語法遇到單引號會報錯)
            // 如果使用者輸入 O'Neal，要變成 O''Neal 才能正常運作
            string safeKeyword = keyword.Replace("'", "''");

            // 3. 設定篩選條件
            if (string.IsNullOrEmpty(safeKeyword))
            {
                // 如果搜尋框是空的，就清除篩選 (顯示全部)
                data.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                // 設定 RowFilter (語法類似 SQL)
                // 意思：在「姓名」欄位中尋找包含 keyword 的資料
                data.DefaultView.RowFilter = $"姓名 LIKE '%{safeKeyword}%'";
            }

            // (選用) 如果您希望搜尋後順便排序
            data.DefaultView.Sort = "姓名 ASC";
        }
    }
}
