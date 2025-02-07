GRANT EXECUTE ON PROCEDURE add_student2 TO mb;

REVOKE EXECUTE ON PROCEDURE add_student2 FROM mb;

Grant all privileges on students to mb

Grant all privileges on students to yk

revoke all privileges on students from yk

select * from students

revoke srvuser from mb;

CREATE OR REPLACE PROCEDURE add_student(
	IN student_id integer,
	IN student_name character varying)
LANGUAGE plpgsql
SECURITY DEFINER
AS $$
BEGIN
    INSERT INTO STUDENTS (STUDENT_ID,STUDENT_NAME) 
    VALUES (STUDENT_ID,STUDENT_NAME);
END;

CREATE OR REPLACE PROCEDURE add_student(Student_ID int, Student_name varchar(50) )
LANGUAGE plpgsql
SECURITY INVoker
AS $$
BEGIN
   INSERT INTO STUDENTS (STUDENT_ID,STUDENT_NAME) 
    VALUES (STUDENT_ID,STUDENT_NAME);
END;
$$;


CREATE OR REPLACE PROCEDURE add_student2(
	IN student_id integer,
	IN student_name character varying)
LANGUAGE plpgsql
SECURITY DEFINER
AS $$
BEGIN
    INSERT INTO STUDENTS (STUDENT_ID,STUDENT_NAME) 
    VALUES (STUDENT_ID,STUDENT_NAME);
END;
$$


GRANT USAGE, CREATE ON SCHEMA public TO mb;

create user mb with password 'mb@123'

create user yk with password 'yk@123'

SELECT rolname,
       rolsuper,
       rolinherit,
       rolcreaterole,
	   rolupdaterole,
       rolcreatedb,
       rolcanlogin,
       rolreplication
FROM pg_roles;

DROP ROLE IF EXISTS mbnew;
