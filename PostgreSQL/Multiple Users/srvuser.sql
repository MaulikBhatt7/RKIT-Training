-- Create users
CREATE USER user_insert WITH PASSWORD 'password_insert';
CREATE USER user_procedure WITH PASSWORD 'password_procedure';
CREATE USER user_function WITH PASSWORD 'password_function';
CREATE USER user_select WITH PASSWORD 'password_select';
CREATE USER user_all WITH PASSWORD 'password_all';
CREATE USER user_qa_2 WITH PASSWORD 'password_qa2';


-- Grant insert privilege to a specific table
GRANT INSERT ON students TO user_insert;

-- Grant the ability to create procedures

GRANT CREATE ON SCHEMA public TO user_procedure;
GRANT INSERT ON students TO user_procedure
REVOKE INSERT ON students FROM user_procedure

-- Grant the ability to create functions
GRANT CREATE ON SCHEMA public TO user_function;


-- Grant select privilege on a specific table
GRANT SELECT ON students TO user_select;


GRANT ALL PRIVILEGES ON students TO user_all;


-- Grant all privileges to this user
GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO user_all;
GRANT INSERT ON students TO user_all;
GRANT ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public TO user_all;
GRANT ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public TO user_all;
GRANT ALL PRIVILEGES ON ALL PROCEDURES IN SCHEMA public TO user_all;


-- Revoke all privileges from this user
REVOKE ALL PRIVILEGES ON ALL TABLES IN SCHEMA public FROM user_all;
REVOKE INSERT ON students FROM user_all;
REVOKE ALL PRIVILEGES ON ALL SEQUENCES IN SCHEMA public FROM user_all;
REVOKE ALL PRIVILEGES ON ALL FUNCTIONS IN SCHEMA public FROM user_all;
REVOKE ALL PRIVILEGES ON ALL PROCEDURES IN SCHEMA public FROM user_all;


GRANT EXECUTE ON PROCEDURE insert_PROC TO user_all;
REVOKE EXECUTE ON PROCEDURE insert_PROC FROM PUBLIC;

GRANT EXECUTE ON PROCEDURE insert_PROC TO PUBLIC;


SELECT grantee, privilege_type
FROM information_schema.role_table_grants
WHERE table_schema = 'schema_name' AND table_name = 'my_function';

SELECT grantee, routine_name, privilege_type
FROM information_schema.routine_privileges
WHERE specific_schema = 'public';


SELECT 
    grantee, 
    routine_schema, 
    routine_name, 
    privilege_type 
FROM 
    information_schema.role_routine_grants 
WHERE 
     routine_name = 'insert_PROC';