-- Users
INSERT INTO Users (Username, PasswordHash, Email, FullName)
VALUES 
('admin', 'hashed_pw1', 'admin@example.com', 'Admin User'),
('john.doe', 'hashed_pw2', 'john@example.com', 'John Doe'),
('jane.smith', 'hashed_pw3', 'jane@example.com', 'Jane Smith');

-- Roles
INSERT INTO Roles (Name, Description)
VALUES 
('Manager', 'Quản lý dự án'),
('Developer', 'Lập trình viên'),
('Tester', 'Kiểm thử viên');

-- Departments
INSERT INTO Departments (Name, Description)
VALUES 
('IT', 'Phòng công nghệ thông tin'),
('HR', 'Phòng nhân sự');

-- Rooms
INSERT INTO Rooms (Name, DepartmentId, Description)
VALUES 
('Phòng Dev 1', 1, 'Phòng làm việc của nhóm Dev 1'),
('Phòng HR', 2, 'Phòng nhân sự');

-- Projects
INSERT INTO Projects (Name, Description)
VALUES 
('Hệ thống ERP', 'Xây dựng hệ thống ERP nội bộ'),
('Website tuyển dụng', 'Phát triển website tuyển dụng công ty');

-- ProjectStatuses
INSERT INTO ProjectStatuses (ProjectId, Status, FromDate, ToDate)
VALUES 
(1, 'Planned', '2025-01-01', '2025-02-01'),
(1, 'InProgress', '2025-02-02', NULL),
(2, 'Planned', '2025-03-01', NULL);

-- Employees
INSERT INTO Employees (UserId, FullName, Email, Phone, Address, DateOfBirth, Gender, HireDate, DepartmentId)
VALUES 
(2, 'John Doe', 'john@example.com', '0123456789', '123 Đường A', '1990-01-01', 'Male', '2022-06-01', 1),
(3, 'Jane Smith', 'jane@example.com', '0987654321', '456 Đường B', '1992-05-10', 'Female', '2023-01-15', 1);

-- EmployeeProjects
INSERT INTO EmployeeProjects (EmployeeId, ProjectId)
VALUES 
(1, 1),
(2, 1),
(2, 2);

-- ProjectRooms
INSERT INTO ProjectRooms (ProjectId, RoomId)
VALUES 
(1, 1),
(2, 2);

-- UserProjectRoles
INSERT INTO UserProjectRoles (UserId, ProjectId, RoleId)
VALUES 
(2, 1, 2),  -- John là Developer dự án 1
(3, 1, 2),  -- Jane là Developer dự án 1
(3, 2, 3);  -- Jane là Tester dự án 2
