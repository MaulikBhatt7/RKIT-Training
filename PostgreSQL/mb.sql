call add_student(96,'asdf')

SELECT grantee, privilege_type
FROM information_schema.role_routine_grants
WHERE routine_name = 'add_student2'
  AND grantee = 'mb';

  INSERT INTO STUDENTS (STUDENT_ID,STUDENT_NAME) 
    VALUES (123,'asdf');

 select * from students

  SELECT 
  r.rolname AS grantee,
  p.proname AS procedure_name,
  HAS_FUNCTION_PRIVILEGE(r.rolname, p.oid, 'EXECUTE') AS has_execute,
  pg_catalog.pg_get_userbyid(p.proowner) AS owner
FROM 
  pg_proc p
JOIN 
  pg_roles r ON r.rolname = p.proowner::regrole::text
WHERE 
  p.proname = 'add_student';


  SELECT r.rolname AS grantee,
       p.proname AS procedure_name,
       HAS_FUNCTION_PRIVILEGE(r.rolname, p.oid, 'EXECUTE') AS has_execute
FROM pg_proc p
JOIN pg_roles r ON r.rolname = p.proowner::regrole::text
WHERE p.proname = 'add_student';




CREATE OR REPLACE PROCEDURE add_student_by_mb(
	IN student_id integer,
	IN student_name character varying)
LANGUAGE plpgsql
SECURITY INVOKER
AS $$
BEGIN
    INSERT INTO STUDENTS (STUDENT_ID,STUDENT_NAME) 
    VALUES (STUDENT_ID,STUDENT_NAME);
END;
$$


GRANT EXECUTE ON PROCEDURE add_student_by_mb TO yk;


