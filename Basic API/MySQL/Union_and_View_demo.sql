-- UNION DEMO
-- Combine names of all students and cities (removing duplicates)
SELECT student_name AS name, 'Student' AS source
FROM student
UNION
SELECT city_name AS name, 'City' AS source
FROM city;

-- Combine names of all students and cities (including duplicates)
SELECT student_name AS name, 'Student' AS source
FROM student
UNION ALL
SELECT city_name AS name, 'City' AS source
FROM city;

-- VIEW DEMO
-- Create a view for student details with their city names
CREATE VIEW student_with_city AS
SELECT s.student_id, s.student_name, s.marks, s.grade, c.city_name
FROM student s
LEFT JOIN city c ON s.city_id = c.city_id;

-- Query the view to display all students with their city names
SELECT * 
FROM student_with_city;

-- Create a view for students with marks above 80
CREATE VIEW top_students AS
SELECT student_id, student_name, marks, grade
FROM student
WHERE marks > 80;

-- Query the view to display top students
SELECT * 
FROM top_students;
