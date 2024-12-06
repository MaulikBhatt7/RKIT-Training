-- Create Indexes on the student and city tables

-- 1. Simple Index: Create an index on the student_name column to speed up queries
CREATE INDEX idx_student_name ON student(student_name);

-- 2. Composite Index: Create an index on city_id and marks for queries involving both columns
CREATE INDEX idx_city_marks ON student(city_id, marks);

-- 3. Unique Index: Enforces uniqueness on city_name in addition to improving performance
CREATE UNIQUE INDEX idx_unique_city_name ON city(city_name);

-- Demonstrating Queries That Use Indexes

-- Query using idx_student_name
SELECT student_id, student_name
FROM student
WHERE student_name = 'Ram';

-- Query using idx_city_marks
SELECT student_id, marks
FROM student
WHERE city_id = 1 AND marks > 80;

-- Query using idx_unique_city_name
SELECT city_id
FROM city
WHERE city_name = 'Mumbai';

-- Dropping Indexes

-- Drop the simple index on student_name
DROP INDEX idx_student_name ON student;

-- Drop the composite index on city_id and marks
DROP INDEX idx_city_marks ON student;

-- Drop the unique index on city_name
DROP INDEX idx_unique_city_name ON city;
