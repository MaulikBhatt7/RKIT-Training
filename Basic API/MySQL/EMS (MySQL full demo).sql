-- SQL Basics: Creating a database
CREATE DATABASE EmployeeManagementSystem;
USE EmployeeManagementSystem;

-- DDL: Creating tables 

-- Table: Departments
CREATE TABLE dpt01 (
       t01f01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'DepartmentID',
       t01f02 VARCHAR(50) NOT NULL COMMENT 'DepartmentName'
);

-- Table: Employees
CREATE TABLE emp01 (
       p01f01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'EmployeeID',
       p01f02 VARCHAR(50) NOT NULL COMMENT 'FirstName',
       p01f03 VARCHAR(50) COMMENT 'LastName',
       p01f04 INT COMMENT 'DepartmentID',
       p01f05 DECIMAL(10, 2) DEFAULT NULL COMMENT 'Salary',
       p01f06 DATE NOT NULL COMMENT 'HireDate',
       FOREIGN KEY (p01f04) REFERENCES dpt01(t01f01)
);

-- Table: Projects
CREATE TABLE prj01 (
       j01f01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ProjectID',
       j01f02 VARCHAR(100) NOT NULL COMMENT 'ProjectName',
       j01f03 INT COMMENT 'DepartmentID',
       FOREIGN KEY (j01f03) REFERENCES dpt01(t01f01)
);

-- Table: Employee-Projects
CREATE TABLE epr01 (
       r01f01 INT AUTO_INCREMENT PRIMARY KEY COMMENT 'ID',
       r01f02 INT NOT NULL COMMENT 'EmployeeID',
       r01f03 INT NOT NULL COMMENT 'ProjectID',
       r01f04 DATE COMMENT 'AssignmentDate',
       FOREIGN KEY (r01f02) REFERENCES emp01(p01f01),
       FOREIGN KEY (r01f03) REFERENCES prj01(j01f01)
);

-- DML: Inserting data

-- Inserting data into Departments
INSERT INTO dpt01 (t01f02) 
VALUES 
       ('HR'), 
       ('Engineering'), 
       ('Marketing');

-- Inserting data into Employees
INSERT INTO emp01 (p01f02, p01f03, p01f04, p01f05, p01f06)
VALUES 
       ('Ram', 'Chopra', 1, 50000, '2020-01-15'),
       ('Shyam', NULL, 2, 60000, '2019-03-20'),
       ('Raj', 'Dube', 3, NULL, '2021-06-10'),
       ('Ramesh', 'Kumar', 2, 75000, '2018-11-05');

-- Inserting data into Projects
INSERT INTO prj01 (j01f02, j01f03)
VALUES 
       ('Recruitment Drive', 1),
       ('AI Development', 2),
       ('Marketing Campaign', 3);

-- Inserting data into Employee-Projects
INSERT INTO epr01 (r01f02, r01f03, r01f04)
VALUES 
       (1, 1, '2020-02-01'),
       (2, 2, '2019-04-01'),
       (3, 3, '2021-06-15'),
       (4, 2, '2018-12-01');

-- Data Sorting: Sorting Employees by Salary in descending order
SELECT 
       p01f01, 
       p01f02, 
       p01f03, 
       p01f04, 
       p01f05, 
       p01f06 
FROM 
       emp01 
ORDER BY 
       p01f05 DESC;

-- Null Value & Keyword: Selecting Employees with NULL Salary
SELECT 
       p01f02, 
       p01f03 
FROM 
       emp01 
WHERE 
       p01f05 IS NULL;

-- DQL: Querying data from Employees table
SELECT 
       p01f01, p01f02, p01f03, p01f04, p01f05, p01f06 
FROM 
       emp01;

-- Aggregate Functions: Calculating average salary by department
SELECT 
       p01f04, 
       AVG(p01f05) AS AvgSalary 
FROM 
       emp01 
GROUP BY 
       p01f04;

-- Limit: Limiting query result to 2 records
SELECT 
       p01f01, p01f02, p01f03, p01f04, p01f05, p01f06 
FROM 
       emp01 
LIMIT 
       2;

-- Sub-Queries: Selecting Employees earning more than average salary
SELECT 
       p01f01, p01f02, p01f03, p01f04, p01f05, p01f06 
FROM 
       emp01 
WHERE 
       p01f05 > (
           SELECT 
                  AVG(p01f05) 
           FROM 
                  emp01
       );

-- Joins: Joining Employees and Departments to get department names
SELECT 
       p01f02 AS FirstName, 
       p01f03 AS LastName, 
       t01f02 AS DepartmentName 
FROM 
       emp01 
JOIN 
       dpt01 
ON 
       p01f04 = t01f01;

-- Unions: Selecting Employees from HR and Marketing departments
SELECT 
       p01f02, p01f03 
FROM 
       emp01 
WHERE 
       p01f04 = 1
UNION
SELECT 
       p01f02, p01f03 
FROM 
       emp01 
WHERE 
       p01f04 = 3;

-- Index: Creating index on DepartmentID in Employees table
CREATE INDEX idx_p01f04 
ON 
       emp01(p01f04);

-- View: Creating a view for EmployeeDetails with department information
CREATE VIEW vws_emp01 AS
SELECT 
       p01f01 AS EmployeeID, 
       p01f02 AS FirstName, 
       p01f03 AS LastName, 
       t01f02 AS DepartmentName, 
       p01f05 AS Salary
FROM 
       emp01 
JOIN 
       dpt01 
ON 
       p01f04 = t01f01;

-- Using the view to select data
SELECT 
       EmployeeID, 
       FirstName, 
       LastName, 
       DepartmentName, 
       Salary 
FROM 
       EmployeeDetails;

-- DCL: Granting permissions to a user
GRANT 
       SELECT, INSERT, UPDATE 
ON 
       EmployeeManagementSystem.* 
TO 
       'user'@'localhost';

-- TCL: Transaction control for updating employee salaries
START TRANSACTION;
UPDATE 
       emp01 
SET 
       p01f05 = p01f05 + 5000 
WHERE 
       p01f04 = 2;
ROLLBACK;

START TRANSACTION;
UPDATE 
       emp01 
SET 
       p01f05 = p01f05 + 5000 
WHERE 
       p01f04 = 2;
COMMIT;

-- Explain Keyword: Explaining the query plan for selecting employees
EXPLAIN 
SELECT 
       p01f01, 
       p01f02, 
       p01f03,
       p01f04, 
       p01f05, 
       p01f06 
FROM 
       emp01;
