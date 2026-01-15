using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using 聯成宇辰培訓班_WinForms_Demo.NewFolder;

namespace 聯成宇辰培訓班_WinForms_Demo.Functions
{
    interface IDb
    {
        Result<UserInfo> Login(string account, string password);
        Result<T> GetUserInfo<T>(object parameter);
        Result<DataTable> GetUserDataTable(int ID,int deptId, int rankId, string? searchName, int page, int pageSize);
    }
    internal interface IPerm
    {
        void PermInit(List<string> permCodes);
    }
}
