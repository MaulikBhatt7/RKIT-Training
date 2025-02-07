CREATE USER 'insert_user'@'localhost' IDENTIFIED BY 'password123';
GRANT INSERT ON college.student TO 'insert_user'@'localhost';

CREATE USER 'procedure_user'@'localhost' IDENTIFIED BY 'password123';
GRANT CREATE ROUTINE ON college.* TO 'procedure_user'@'localhost';
GRANT SELECT ON college.student TO 'procedure_user'@'localhost';
REVOKE ALL PRIVILEGES ON college.student FROM 'procedure_user'@'localhost';

CREATE USER 'function_user'@'localhost' IDENTIFIED BY 'password123';
GRANT CREATE ROUTINE ON college.* TO 'function_user'@'localhost';

CREATE USER 'select_user'@'localhost' IDENTIFIED BY 'password123';
GRANT SELECT ON college.student TO 'select_user'@'localhost';



CREATE USER 'creator_user'@'localhost' IDENTIFIED BY 'password123';

GRANT ALL PRIVILEGES ON college.* TO 'creator_user'@'localhost';
REVOKE ALL PRIVILEGES ON college.* from 'creator_user'@'localhost';

GRANT CREATE ROUTINE ON `college`.* TO 'creator_user'@'localhost';

GRANT ALL PRIVILEGES ON college.employee TO 'creator_user'@'localhost';


GRANT ALL PRIVILEGES ON college.employee TO 'creator_user'@'localhost';

 
CREATE USER 'tester_user'@'localhost' IDENTIFIED BY 'password123';
GRANT ALL PRIVILEGES ON college.student TO 'tester_user'@'localhost';
REVOKE ALL PRIVILEGES ON college.student FROM 'tester_user'@'localhost';
FLUSH PRIVILEGES;

GRANT EXECUTE ON PROCEDURE `college`.`SelectAllStudents` TO 'tester_user'@'localhost';


REVOKE EXECUTE ON PROCEDURE `college`.`SelectAllStudents` FROM 'tester_user'@'localhost';


SELECT ROUTINE_NAME, ROUTINE_SCHEMA, ROUTINE_TYPE
FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_SCHEMA = 'college'
  AND ROUTINE_NAME = 'SelectAllStudents';

