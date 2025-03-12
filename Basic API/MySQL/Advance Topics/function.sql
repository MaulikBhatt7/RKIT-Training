-- Function to Get Student Name by ID
DELIMITER $$
CREATE FUNCTION GetStudentNameByID(studentID INT) RETURNS VARCHAR(50) DETERMINISTIC
BEGIN
    DECLARE studentName VARCHAR(50);
    SELECT Name INTO studentName FROM students WHERE ID = studentID;
    RETURN studentName;
END $$
DELIMITER ;

SELECT GetStudentNameByID(101);

-- Function to Get Total Number of Students
DELIMITER $$
CREATE FUNCTION GetTotalStudents() RETURNS INT DETERMINISTIC
BEGIN
    DECLARE total INT;
    SELECT COUNT(*) INTO total FROM students;
    RETURN total;
END $$
DELIMITER ;

SELECT GetTotalStudents();

-- Function to Calculate Average Age of Students
DELIMITER $$
CREATE FUNCTION GetAverageAge() RETURNS DECIMAL(5,2) DETERMINISTIC
BEGIN
    DECLARE avg_age DECIMAL(5,2);
    SELECT AVG(Age) INTO avg_age FROM students;
    RETURN avg_age;
END $$
DELIMITER ;

SELECT GetAverageAge();


DROP FUNCTION IF EXISTS GetStudentNameByID;
DROP FUNCTION IF EXISTS GetTotalStudents;
DROP FUNCTION IF EXISTS GetAverageAge;