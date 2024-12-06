-- 1. INNER JOIN: Retrieve students with their corresponding city names
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
INNER JOIN city c ON s.city_id = c.city_id;

-- 2. LEFT JOIN: Retrieve all students, including those without a city
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
LEFT JOIN city c ON s.city_id = c.city_id;

-- 3. RIGHT JOIN: Retrieve all cities, including those without students
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
RIGHT JOIN city c ON s.city_id = c.city_id;

-- 4. FULL OUTER JOIN (emulated in MySQL using UNION)
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
LEFT JOIN city c ON s.city_id = c.city_id
UNION
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
RIGHT JOIN city c ON s.city_id = c.city_id;

-- 5. CROSS JOIN: Retrieve all possible combinations of students and cities
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
CROSS JOIN city c;

-- 6. SELF JOIN: Compare students' marks to find pairs with the same grade
SELECT a.student_id AS Student1_ID, a.student_name AS Student1_Name, 
       b.student_id AS Student2_ID, b.student_name AS Student2_Name
FROM student a
INNER JOIN student b ON a.grade = b.grade AND a.student_id != b.student_id;

-- 7. NATURAL JOIN: Retrieve common data between tables based on the column with the same name
-- (Assuming column names match, here 'city_id')
SELECT * 
FROM student 
NATURAL JOIN city;

-- 8. INNER JOIN with a condition: Retrieve students with marks above 75 and their cities
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
INNER JOIN city c ON s.city_id = c.city_id
WHERE s.marks > 75;

-- 9. LEFT JOIN with a filter: Retrieve students and their cities, including students without cities
SELECT s.student_id, s.student_name, c.city_name 
FROM student s
LEFT JOIN city c ON s.city_id = c.city_id
WHERE s.city_id IS NULL;

-- 10. RIGHT JOIN with a filter: Retrieve cities without students
SELECT c.city_id, c.city_name 
FROM student s
RIGHT JOIN city c ON s.city_id = c.city_id
WHERE s.student_id IS NULL;

-- 11. Join with an aggregate: Count the number of students in each city
SELECT c.city_name, COUNT(s.student_id) AS TotalStudents 
FROM city c
LEFT JOIN student s ON c.city_id = s.city_id
GROUP BY c.city_name;

-- 12. Join with a calculated field: Combine student details with city names and total marks
SELECT s.student_id, s.student_name, c.city_name, (s.marks + 10) AS UpdatedMarks
FROM student s
INNER JOIN city c ON s.city_id = c.city_id;
