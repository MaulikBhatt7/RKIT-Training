-- SUBQUERY DEMO

-- 1. Subquery in SELECT Clause
-- Get the student details along with their city names using a subquery
SELECT 
    student_id, 
    student_name, 
    marks, 
    (SELECT city_name FROM city WHERE city.city_id = student.city_id) AS city_name
FROM student;

-- 2. Subquery in WHERE Clause
-- Find all students who belong to the city 'Mumbai'
SELECT student_id, student_name
FROM student
WHERE city_id = (SELECT city_id FROM city WHERE city_name = 'Mumbai');

-- 3. Subquery in FROM Clause
-- List the average marks of students for each city
SELECT c.city_name, avg_data.avg_marks
FROM city c
JOIN (
    SELECT city_id, AVG(marks) AS avg_marks
    FROM student
    GROUP BY city_id
) AS avg_data ON c.city_id = avg_data.city_id;

-- 4. Correlated Subquery
-- Find all students who scored above the average marks of their respective city
SELECT student_id, student_name, marks
FROM student s1
WHERE marks > (
    SELECT AVG(marks)
    FROM student s2
    WHERE s1.city_id = s2.city_id
);

-- 5. Subquery with EXISTS
-- List all cities that have at least one student
SELECT city_name
FROM city c
WHERE EXISTS (
    SELECT 1
    FROM student s
    WHERE s.city_id = c.city_id
);

-- 6. Subquery with IN
-- Find all students from cities 'Mumbai' or 'Jaipur'
SELECT student_id, student_name
FROM student
WHERE city_id IN (
    SELECT city_id
    FROM city
    WHERE city_name IN ('Mumbai', 'Jaipur')
);

-- 7. Scalar Subquery
-- Find the total number of students
SELECT 
    COUNT(*) AS total_students,
    (SELECT COUNT(*) FROM city) AS total_cities
FROM student;

Explain 
SELECT 
	student_name
FROM STUDENT
WHERE city_id = (
    SELECT 
		city_id
    FROM CITY
    WHERE city_name = 'Kolkata'
);