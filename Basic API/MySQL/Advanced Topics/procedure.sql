CREATE DATABASE demoMB;
USE demoMB;

-- Table Creation
CREATE TABLE students(
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    Age INT,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Insert Data
INSERT INTO students VALUES (101, 'Ram', 20, NOW()), (102, 'Shyam', 22, NOW());

-- Retrieve Data
SELECT * FROM students;

-- Simple Procedure to Select All Students
DELIMITER $$
CREATE PROCEDURE GetStudents()
BEGIN
    SELECT * FROM students;
END $$
DELIMITER ;

CALL GetStudents();

-- Procedure with IN Parameter (Select Student by ID)
DELIMITER $$
CREATE PROCEDURE GetStudentByID(IN studentID INT)
BEGIN
    SELECT * FROM students WHERE ID = studentID;
END $$
DELIMITER ;

CALL GetStudentByID(101);

-- Procedure with OUT Parameter (Get Count of Students)
DELIMITER $$
CREATE PROCEDURE GetStudentsCount(OUT student_count INT)
BEGIN
    SELECT COUNT(ID) INTO student_count FROM students;
END $$
DELIMITER ;

CALL GetStudentsCount(@total_student);
SELECT @total_student;

-- Procedure with INOUT Parameter (Increment Age by Given Number)
DELIMITER $$
CREATE PROCEDURE IncrementStudentAge(IN studentID INT, INOUT increment_value INT)
BEGIN
    UPDATE students SET Age = Age + increment_value WHERE ID = studentID;
    SELECT Age INTO increment_value FROM students WHERE ID = studentID;
END $$
DELIMITER ;

SET @age_increment = 2;
CALL IncrementStudentAge(101, @age_increment);
SELECT @age_increment;

DROP PROCEDURE IF EXISTS GetStudents;
DROP PROCEDURE IF EXISTS GetStudentByID;
DROP PROCEDURE IF EXISTS GetStudentsCount;
DROP PROCEDURE IF EXISTS ShowStudentNames;
DROP PROCEDURE IF EXISTS IncrementStudentAge;