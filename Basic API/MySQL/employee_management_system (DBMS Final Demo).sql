-- SQL Basics: Creating a database
CREATE DATABASE EmployeeManagementSystem;
USE EmployeeManagementSystem;

-- DDL: Creating tables
CREATE TABLE Departments (
    DepartmentID INT AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL
);

CREATE TABLE Employees (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10, 2) DEFAULT NULL,
    HireDate DATE NOT NULL,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Projects (
    ProjectID INT AUTO_INCREMENT PRIMARY KEY,
    ProjectName VARCHAR(100) NOT NULL,
    DepartmentID INT,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);

CREATE TABLE EmployeeProjects (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    EmployeeID INT NOT NULL,
    ProjectID INT NOT NULL,
    AssignmentDate DATE,
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID)
);

-- DML: Inserting data
INSERT INTO Departments (DepartmentName) VALUES ('HR'), ('Engineering'), ('Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, HireDate)
VALUES 
    ('Ram', 'Chopra', 1, 50000, '2020-01-15'),
    ('Shyam', NULL, 2, 60000, '2019-03-20'),
    ('Raj', 'Dube', 3, NULL, '2021-06-10'),
    ('Ramesh', 'Kumar', 2, 75000, '2018-11-05');

INSERT INTO Projects (ProjectName, DepartmentID)
VALUES 
    ('Recruitment Drive', 1),
    ('AI Development', 2),
    ('Marketing Campaign', 3);

INSERT INTO EmployeeProjects (EmployeeID, ProjectID, AssignmentDate)
VALUES 
    (1, 1, '2020-02-01'),
    (2, 2, '2019-04-01'),
    (3, 3, '2021-06-15'),
    (4, 2, '2018-12-01');

-- Data Sorting
SELECT * FROM Employees ORDER BY Salary DESC;

-- Null Value & Keyword
SELECT FirstName, LastName FROM Employees WHERE Salary IS NULL;


-- DQL: Querying data
SELECT * FROM Employees;

-- Aggregate Functions
SELECT DepartmentID, AVG(Salary) AS AvgSalary FROM Employees GROUP BY DepartmentID;

-- Limit
SELECT * FROM Employees LIMIT 2;

-- Sub-Queries
SELECT * FROM Employees WHERE Salary > (SELECT AVG(Salary) FROM Employees);

-- Joins
SELECT 
    e.FirstName, e.LastName, d.DepartmentName 
FROM 
    Employees e 
JOIN 
    Departments d 
ON 
    e.DepartmentID = d.DepartmentID;

-- Unions
SELECT FirstName, LastName FROM Employees WHERE DepartmentID = 1
UNION
SELECT FirstName, LastName FROM Employees WHERE DepartmentID = 3;

-- Index
CREATE INDEX idx_department ON Employees(DepartmentID);

-- View
CREATE VIEW EmployeeDetails AS
SELECT 
    e.EmployeeID, e.FirstName, e.LastName, d.DepartmentName, e.Salary
FROM 
    Employees e 
JOIN 
    Departments d 
ON 
    e.DepartmentID = d.DepartmentID;

-- Using the view
SELECT * FROM EmployeeDetails;

-- DCL: Granting permissions
GRANT SELECT, INSERT, UPDATE ON EmployeeManagementSystem.* TO 'user'@'localhost';

-- TCL: Transaction control
START TRANSACTION;
UPDATE Employees SET Salary = Salary + 5000 WHERE DepartmentID = 2;
ROLLBACK;

START TRANSACTION;
UPDATE Employees SET Salary = Salary + 5000 WHERE DepartmentID = 2;
COMMIT;

-- Explain Keyword
EXPLAIN SELECT * FROM Employees
