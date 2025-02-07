-- Create a procedure to insert a new student
CREATE OR REPLACE PROCEDURE insert_PROC(Student_ID INT , Student_Name Varchar(50))
LANGUAGE plpgsql
SECURITY DEFINER
AS $$
BEGIN
    -- Insert the new student into the table
    INSERT INTO students
    VALUES (Student_ID, Student_Name);
END;
$$;

GRANT EXECUTE ON PROCEDURE insert_PROC TO user_all;

REVOKE EXECUTE ON PROCEDURE insert_PROC FROM PUBLIC;

DROP TABLE Students

Insert into students values (106,'asdf')


SELECT proname, proowner::regrole, proacl
FROM pg_proc
WHERE proname = 'inserta_proc';


SELECT defaclrole::regrole AS role_name,
       defaclnamespace::regnamespace AS schema_name,
       defaclobjtype AS object_type,
       defaclacl AS default_privileges
FROM pg_default_acl;


SELECT proname AS procedure_name,
       nspname AS schema_name,
       proowner::regrole AS owner,
       proacl AS privileges
FROM pg_proc
JOIN pg_namespace ON pg_proc.pronamespace = pg_namespace.oid
WHERE proname = 'insert_porc';


CALL insert_PROC(12,'ASDF')