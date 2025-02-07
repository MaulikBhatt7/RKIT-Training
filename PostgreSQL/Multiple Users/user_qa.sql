CALL INSERT_PROC(116,'ASDF');

INSERT INTO STUDENTS VALUES (1112,'ASDF')


Select * from students
DROP TABLE students

SELECT
    grantee,
    privilege_type
FROM
    information_schema.role_routine_grants
WHERE
    routine_name = 'insert_proc';


SELECT 
    grantee, 
    routine_schema, 
    routine_name, 
    privilege_type 
FROM 
    information_schema.role_routine_grants 
WHERE 
     routine_name = 'insert_PROC';


 SELECT calculate_factorial(5);