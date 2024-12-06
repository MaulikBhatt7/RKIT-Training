-- DCL Demo

-- Grant SELECT and INSERT privileges on the student table to user 'MB'
GRANT SELECT, INSERT ON student TO 'MB'@'localhost';

-- Grant ALL privileges on the entire college database to user 'YK'
GRANT ALL PRIVILEGES ON college TO 'YK'@'localhost';

-- Revoke SELECT privilege from user 'MB' on the student table
REVOKE SELECT ON student FROM 'MB'@'localhost';

-- Revoke all privileges on the entire college database from user 'YK'
REVOKE ALL PRIVILEGES ON college FROM 'YK'@'localhost';

-- Check privileges (optional, can be executed separately)
SHOW GRANTS FOR 'MB'@'localhost';
SHOW GRANTS FOR 'YK'@'localhost';
