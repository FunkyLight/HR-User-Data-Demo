using System;
using System.Collections.Generic;
using System.Text;
using 聯成宇辰培訓班_WinForms_Demo.NewFolder;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace 聯成宇辰培訓班_WinForms_Demo
{
    internal class SqlQuery
    {
        internal const string GetSelfInfo =
            @"SELECT
                s.ID,
                s.account AS Account,
                s.name AS StaffName,
                s.gender AS Gender,
                s.rankID,
                r.name AS RankName,
                r.rankLevel AS RankLevel,
                s.deptID,
                d.name AS DeptName,
                s.isEmployeed AS IsEmployeed,
                GROUP_CONCAT(p.PermCode) AS PermsString,
                s.createDate AS CreateDate,
                s.joinDate AS JoinDate,
                s.leaveDate AS LeaveDate,
                s.mobile AS Mobile,
                s.email AS Email,
                s.note AS Note
                FROM `human_resource`.staffs s
                INNER JOIN `human_resource`.departments d ON s.deptID = d.ID
                INNER JOIN `human_resource`.ranks r ON s.rankID = r.ID
                LEFT JOIN `human_resource`.dept_rank_perm p ON s.deptID = p.deptID AND s.rankID = p.rankID
                WHERE s.account = @account AND s.password = @password
                GROUP BY s.ID,
                s.account,
                s.name,
                s.gender,
                r.name,
                r.rankLevel,
                d.name,
                s.isEmployeed,
                s.createDate,
                s.joinDate,
                s.leaveDate,
                s.mobile,
                s.email,
                s.note";

        internal const string GetStaffsSum =
            @"SELECT
                s.ID,
                s.account AS '使用者編號',
                s.name AS '姓名',
                d.name AS '部門',
                r.name AS '職級',    
                s.gender AS '性別',
                CASE
                    WHEN s.isEmployeed = 1 THEN '在職'
                    ELSE '離職' 
                END AS '狀態',
                s.createDate AS CreateDate,
                s.joinDate AS JoinDate,
                s.leaveDate AS LeaveDate,
                s.mobile AS Mobile,
                s.email AS Email,
                s.note AS Note
                FROM `human_resource`.staffs s
                LEFT JOIN `human_resource`.ranks r ON S.rankID = r.ID
                LEFT JOIN `human_resource`.departments d ON s.deptID = d.ID
                WHERE
                (@SearchName IS NULL OR s.name LIKE CONCAT('%', @SearchName, '%')) 
                AND (@deptID = 0 OR s.deptID = @DeptID)
                AND (@rankID = 0 OR s.rankID = @RankID)
                AND s.ID <> @CurrentUserID
                ORDER BY s.ID
                LIMIT @Offset, @PageSize";

    }
}
