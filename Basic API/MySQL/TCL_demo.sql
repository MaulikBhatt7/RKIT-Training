-- TCL Demo

-- Start a transaction
START TRANSACTION;

-- Insert a new student record
INSERT INTO student (student_id, student_name, age, city_id, marks, grade) 
VALUES (107, 'Anil', 22, 1, 88, 'A');

-- Update a student's marks
UPDATE student SET marks = 95 WHERE student_id = 103;

-- Check if all operations are correct
-- If everything is fine, commit the transaction
COMMIT;

-- In case of an error, rollback all changes
-- ROLLBACK;

-- Another example with SAVEPOINT
START TRANSACTION;

-- Insert a new student record
INSERT INTO student (student_id, student_name, age, city_id, marks, grade) 
VALUES (108, 'Neha', 21, 2, 76, 'B');

-- Set a savepoint before another update
SAVEPOINT before_update;

-- Update a student's grade
UPDATE student SET grade = 'A' WHERE student_id = 104;

-- If an issue occurs, rollback to the savepoint
ROLLBACK TO SAVEPOINT before_update;

-- Finally, commit the transaction if all is good
COMMIT;


