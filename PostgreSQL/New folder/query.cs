CREATE OR REPLACE FUNCTION get_students_dynamic(column_name TEXT)
RETURNS TABLE(student_id INT, student_name varchar(50)) AS $$
BEGIN
    RETURN QUERY EXECUTE 'SELECT ' || column_name || ' FROM students';
END;
$$ LANGUAGE plpgsql;

drop function get_students_dynamic


SELECT * FROM get_students_dynamic('student_id,student_name');



CREATE OR REPLACE FUNCTION insert_student_dynamic(student_id INT, student_name varchar(50))
RETURNS VOID AS $$
BEGIN
    EXECUTE 'INSERT INTO students (student_id, student_name) VALUES ($1, $2)'
    USING student_id, student_name;
END;
$$ LANGUAGE plpgsql;

SELECT insert_student_dynamic(18, 'abcd');


