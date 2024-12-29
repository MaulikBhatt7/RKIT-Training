DELIMITER $$

-- Procedure to retrieve all students from the student table
CREATE PROCEDURE GetAllStudents()
BEGIN
   SELECT 
       student_id,
       student_name,
       age,
       city_id,
       marks,
       grade
   FROM
       student;
END$$

DELIMITER ;

-- Procedure to retrieve a student by their ID

DELIMITER $$ 

CREATE PROCEDURE GetStudentById(IN studentId INT)
BEGIN
   SELECT 
       student_id,
       student_name,
       age,
       city_id,
       marks,
       grade
   FROM
       student
   WHERE
       student_id = studentId;
END$$

DELIMITER ;

-- Procedure to add a new student to the student table

DELIMITER $$

CREATE PROCEDURE AddStudent(
	In studentId INT,
    IN studentName VARCHAR(100),
    IN studentAge INT,
    IN cityId INT,
    IN studentMarks INT,
    IN studentGrade CHAR(1)
)
BEGIN
   INSERT INTO student (
	   student_id,
       student_name,
       age,
       city_id,
       marks,
       grade
   ) 
   VALUES (
	   studentId,
       studentName,
       studentAge,
       cityId,
       studentMarks,
       studentGrade
   );
END$$

DELIMITER ;

-- Procedure to update an existing student's information

DELIMITER $$ 

CREATE PROCEDURE UpdateStudent(
    IN studentId INT,
    IN studentName VARCHAR(100),
    IN studentAge INT,
    IN cityId INT,
    IN studentMarks INT,
    IN studentGrade CHAR(1)
)
BEGIN
   UPDATE student
   SET
       student_name = studentName,
       age = studentAge,
       city_id = cityId,
       marks = studentMarks,
       grade = studentGrade
   WHERE
       student_id = studentId;
END$$

DELIMITER ;

-- Procedure to delete a student by their ID

DELIMITER $$
CREATE PROCEDURE DeleteStudent(IN studentId INT)
BEGIN
   DELETE FROM student
   WHERE
       student_id = studentId;
END$$

DELIMITER ;


drop procedure AddStudent;
