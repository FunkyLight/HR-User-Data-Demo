-- Create Database
CREATE schema IF NOT EXISTS human_resource;
USE human_resource;

-- Disable foreign key checks for bulk operations
SET FOREIGN_KEY_CHECKS = 0;

-- 1. Departments
DROP TABLE IF EXISTS departments;
CREATE TABLE departments (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL
);

-- 2. Ranks
DROP TABLE IF EXISTS ranks;
CREATE TABLE ranks (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(50) NOT NULL,
    rankLevel INT NOT NULL -- Lower number might mean higher rank, or vice versa. Let's assume 0 is System/Admin, 1 is Manager, 2 is Staff
);

-- 3. Permissions
DROP TABLE IF EXISTS permissions;
CREATE TABLE permissions (
    permCode VARCHAR(50) PRIMARY KEY,
    description VARCHAR(100)
);

-- 4. RolePermissions (Dept + Rank -> Permissions)
DROP TABLE IF EXISTS dept_rank_perm;
CREATE TABLE dept_rank_perm (
    deptID INT NOT NULL,
    rankID INT NOT NULL,
    permCode VARCHAR(50) NOT NULL,
    PRIMARY KEY (deptID, rankID, permCode),
    FOREIGN KEY (deptID) REFERENCES departments(ID),
    FOREIGN KEY (rankID) REFERENCES ranks(ID)
);

-- 5. Employees
DROP TABLE IF EXISTS staffs;
CREATE TABLE staffs (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    account VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(100) NOT NULL, -- Store plain for demo or hash? Demo usually implies plain or simple hash. Sticking to plain for absolute demo simplicity unless requested otherwise, but plan said password.
    name VARCHAR(50) NOT NULL,
    gender VARCHAR(10),
    birthday DATETIME,
    email VARCHAR(100),
    mobile VARCHAR(20),
    joinDate DATETIME,
    leaveDate DATETIME,
    isEmployed BOOLEAN DEFAULT TRUE,
    note TEXT,
    deptID INT,
    rankID INT,
    createDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (deptID) REFERENCES departments(ID),
    FOREIGN KEY (rankID) REFERENCES ranks(ID)
);

SET FOREIGN_KEY_CHECKS = 1;


INSERT INTO departments (ID, name) VALUES (1, '人事'), (2, '行政');

INSERT INTO ranks (ID, name, rankLevel) VALUES (1, '主管', 1), (2, '職員', 2);

INSERT INTO permissions (permCode, description) VALUES 
('ADD_USER', '新增員工'),
('DELETE_USER', '刪除員工'),
('EDIT_USER', '修改員工'),
('SET_RESIGNED', '設為離職'),
('VIEW_ALL', '查看所有員工資料'),
('VIEW_SELF', '只能查看自己的資料'),
('VIEW_DEPT', '只能查看自己的部門員工資料'),
('WRITE_NOTE', '修改與檢視員工備註');

-- 1. 人事主管 (Dept=1, Rank=1)
INSERT INTO dept_rank_perm (deptID, rankID, permCode) VALUES 
(1, 1, 'VIEW_ALL'), (1, 1, 'ADD_USER'), (1, 1, 'EDIT_USER'), (1, 1, 'SET_RESIGNED'), (1, 1, 'WRITE_NOTE');

-- 2. 人事職員 (Dept=1, Rank=2)
INSERT INTO dept_rank_perm (deptID, rankID, permCode) VALUES 
(1, 2, 'VIEW_ALL'), (1, 2, 'ADD_USER'), (1, 2, 'EDIT_USER'), (1, 2, 'WRITE_NOTE');

-- 3. 行政主管 (Dept=2, Rank=1)
INSERT INTO dept_rank_perm (deptID, rankID, permCode) VALUES 
(2, 1, 'VIEW_DEPT'), (2, 1, 'WRITE_NOTE');

-- 4. 行政職員 (Dept=2, Rank=2)
INSERT INTO dept_rank_perm (deptID, rankID, permCode) VALUES 
(2, 2, 'VIEW_SELF');

INSERT INTO Employees (account, password, name, gender, deptID, rankID, isEmployed, joinDate) VALUES 
('admin', 'admin', '黃同學', '男', 1, 1, 1, NOW()),
('a0000000', '00000000', '張先生', '男', 1, 2, 1, NOW()),
('b0000000', '00000000', '龔襄里', '男', 2, 1, 1, NOW()),
('b1111111', '11111111', '林小妹', '女', 2, 2, 1, NOW());


