using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using 聯成宇辰培訓班_WinForms_Demo;
using 聯成宇辰培訓班_WinForms_Demo.Functions;

namespace 聯成宇辰培訓班_WinForms_Demo.NewFolder
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }

    public class Result<T> : Result
    {
        internal T? Data { get; set; }
    }

    internal class UserSum
    {
        public int ID { get; set; }
        public string? Account { get; set; }
        public string? StaffName { get; set; }
        public string? Gender { get; set; }
        public int RankID { get; set; }
        public string? RankName { get; set; }
        public int DeptID { get; set; }
        public string? DeptName { get; set; }
        public bool IsEmployeed { get; set; }
    }
    internal class UserInfo : UserSum
    {
        public int RankLevel { get; set; }
        private string? PermsString { get; set; }
        public List<string>? PermCodes => string.IsNullOrEmpty(PermsString) ? null : new(PermsString.Split(','));
        public DateTime? CreateDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public string? Note { get; set; }
    }
    

    internal class Tools : IDb
    {
        //連線字串
        private readonly string connectionString = "Server=localhost;User=root;Password=123456789;Database=human_resource";

        //登入 帳號密碼驗證
        Result<UserInfo> IDb.Login(string account, string password)
        {
            if (string.IsNullOrEmpty(account)) return new Result<UserInfo> { IsSuccess = false, Message = "請輸入帳號" };
            else if (string.IsNullOrEmpty(password)) return new Result<UserInfo> { IsSuccess = false, Message = "請輸入密碼" };

            var result = ((IDb)this).GetUserInfo<UserInfo>(new { account, password });

            return new Result<UserInfo>
            {
                IsSuccess = result.IsSuccess,
                Message = result.IsSuccess ? "登入成功" : "帳號或密碼錯誤",
                Data = result.Data
            };
        }

        //使用Dapper簡化程式碼
        //取得使用者資訊
        Result<T> IDb.GetUserInfo<T>(object parameter)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                var user = connection.QueryFirstOrDefault<T>(SqlQuery.GetSelfInfo, parameter);
                return new Result<T>
                {
                    IsSuccess = user != null,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new Result<T> { IsSuccess = false, Message = "資料庫連線錯誤：\n" + ex.Message };
            }
        }

        Result<DataTable> IDb.GetUserDataTable(int ID, int deptID, int rankID, string? searchName, int page, int pageSize)
        {
            int offset = (page - 1) * pageSize;
            try
            {
                using var connection = new MySqlConnection(connectionString);
                var reader = connection.ExecuteReader(SqlQuery.GetStaffsSum, new { CurrentUserID = ID, DeptID = deptID, RankID = rankID, SearchName = searchName, Offset = offset, PageSize = pageSize });

                var dt = new DataTable("使用者簡表");
                dt.Load(reader);

                return new Result<DataTable>
                {
                    IsSuccess = true,
                    Data = dt
                };
            }
            catch (Exception ex)
            {
                return new Result<DataTable> { IsSuccess = false, Message = "查詢失敗：" + ex.Message };
            }
        }

        public Result SaveUserInfo(UserInfo userInfo)
        {
            throw new NotImplementedException();
        }
    }
}
