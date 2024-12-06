-- INSERT QUERIES --

-- 1. Insert a new city
INSERT INTO city VALUES (3, 'Delhi');

-- 2. Insert a new student with complete details
INSERT INTO student (student_id, student_name, age, city_id, marks, grade)
VALUES (107, 'Rahul', 22, 3, 75, 'B');

-- 3. Insert a student without specifying city_id (NULL)
INSERT INTO student (student_id, student_name, age, marks, grade)
VALUES (108, 'Neha', 19, 60, 'C');

-- 4. Insert multiple cities at once
INSERT INTO city VALUES 
(4, 'Kolkata'),
(5, 'Chennai');

-- 5. Insert multiple students at once
INSERT INTO student VALUES
(109, 'Siddharth', 25, 4, 88, 'A'),
(110, 'Meera', 23, 5, 72, 'B');

-- UPDATE QUERIES --

-- 6. Update the name of a city
UPDATE city 
SET city_name = 'Ahmedabad' 
WHERE city_id = 2;

-- 7. Update marks of a specific student
UPDATE student 
SET marks = 95 
WHERE student_id = 103;


-- Set SQL_SAFE_UPDATES
Set SQL_SAFE_UPDATES=0;

-- 8. Update grade of students based on marks

UPDATE student
SET grade = CASE
    WHEN marks >= 90 THEN 'O'
    WHEN marks >= 80 THEN 'A'
    WHEN marks >= 70 THEN 'B'
    WHEN marks >= 60 THEN 'C'
    ELSE 'D'
END;

-- 9. Update city_id for students with NULL city_id
UPDATE student 
SET city_id = 3 
WHERE city_id IS NULL;

-- 10. Update the city_id of all students in a specific city
UPDATE student 
SET city_id = 4 
WHERE city_id = 1;

-- DELETE QUERIES --

-- 11. Delete a specific student record
DELETE FROM student 
WHERE student_id = 106;

-- 12. Delete all students belonging to a specific city
DELETE FROM student 
WHERE city_id = 2;

-- 13. Delete a city record (cascades to related student records)
DELETE FROM city 
WHERE city_id = 3;

-- 14. Delete students with marks below a threshold
DELETE FROM student 
WHERE marks < 60;

-- 15. Delete all records from the student table
DELETE FROM student;

-- 16. Delete all records from the city table
DELETE FROM city;


