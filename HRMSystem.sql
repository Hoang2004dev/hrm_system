-- Tạo Database
CREATE DATABASE HRMSystem;
GO

USE HRMSystem;
GO

-- Bảng người dùng hệ thống
CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100),
    FullName NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);

CREATE TABLE RefreshTokens (
    Id INT IDENTITY PRIMARY KEY,
    UserId INT NOT NULL,
    Token NVARCHAR(255) NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    RevokedAt DATETIME NULL,
    IsActive AS (CASE WHEN RevokedAt IS NULL AND ExpiresAt > GETDATE() THEN 1 ELSE 0 END),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

-- Bảng vai trò
CREATE TABLE Roles (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) UNIQUE NOT NULL,
    Description NVARCHAR(255)
);

-- Gán vai trò cho người dùng
CREATE TABLE UserRoles (
    UserId INT,
    RoleId INT,
    PRIMARY KEY(UserId, RoleId),
    FOREIGN KEY(UserId) REFERENCES Users(Id),
    FOREIGN KEY(RoleId) REFERENCES Roles(Id)
);

-- Phòng ban
CREATE TABLE Departments (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255)
);

-- Chức vụ
CREATE TABLE Positions (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Level NVARCHAR(50),
    Description NVARCHAR(255)
);

CREATE TABLE CalendarEvents (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Description NVARCHAR(MAX),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    CreatedBy INT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsAllDay BIT DEFAULT 0,
    EventType NVARCHAR(50), -- Ví dụ: Meeting, Birthday, Leave, etc.
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
);

-- Nhân viên
CREATE TABLE Employees (
    Id INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Address NVARCHAR(255),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    HireDate DATE NOT NULL,
    DepartmentId INT,
    PositionId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (PositionId) REFERENCES Positions(Id)
);

-- Lịch sử chuyển phòng/ chức vụ
CREATE TABLE EmployeeTransfers (
    Id INT IDENTITY PRIMARY KEY,
    EmployeeId INT NOT NULL,
    FromDepartmentId INT,
    ToDepartmentId INT,
    FromPositionId INT,
    ToPositionId INT,
    TransferDate DATE NOT NULL,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
    FOREIGN KEY (FromDepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (ToDepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (FromPositionId) REFERENCES Positions(Id),
    FOREIGN KEY (ToPositionId) REFERENCES Positions(Id)
);

-- Hợp đồng lao động
CREATE TABLE Contracts (
    Id INT IDENTITY PRIMARY KEY,
    EmployeeId INT NOT NULL,
    ContractType NVARCHAR(50),
    StartDate DATE NOT NULL,
    EndDate DATE,
    Salary DECIMAL(18, 2),
    Note NVARCHAR(255),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Lương và phụ cấp
CREATE TABLE Salaries (
    Id INT IDENTITY PRIMARY KEY,
    EmployeeId INT NOT NULL,
    BaseSalary DECIMAL(18, 2),
    Bonus DECIMAL(18, 2),
    Allowance DECIMAL(18, 2),
    Month INT,
    Year INT,
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Chấm công
CREATE TABLE Attendance (
    Id INT IDENTITY PRIMARY KEY,
    EmployeeId INT NOT NULL,
    Date DATE NOT NULL,
    CheckInTime TIME,
    CheckOutTime TIME,
    Note NVARCHAR(255),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Đơn nghỉ phép
CREATE TABLE LeaveRequests (
    Id INT IDENTITY PRIMARY KEY,
    EmployeeId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Reason NVARCHAR(255),
    Status NVARCHAR(50) DEFAULT 'Pending', -- Pending, Approved, Rejected
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
);

-- Thông báo nội bộ
CREATE TABLE Notifications (
    Id INT IDENTITY PRIMARY KEY,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX),
    CreatedBy INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CreatedBy) REFERENCES Users(Id)
);

-- Nhật ký hệ thống
CREATE TABLE SystemLogs (
    Id INT IDENTITY PRIMARY KEY,
    UserId INT,
    Action NVARCHAR(255),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);

