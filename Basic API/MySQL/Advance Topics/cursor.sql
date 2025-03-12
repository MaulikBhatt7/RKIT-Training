-- Cursor Example (Iterate Over Students and Print Names)
DELIMITER $$
CREATE PROCEDURE ShowStudentNames()
BEGIN
    DECLARE done INT DEFAULT FALSE;
    DECLARE studentName VARCHAR(50);
    DECLARE cur CURSOR FOR SELECT Name FROM students;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
    OPEN cur;
    read_loop: LOOP
        FETCH cur INTO studentName;
        IF done THEN
            LEAVE read_loop;
        END IF;
        SELECT studentName;
    END LOOP;
    CLOSE cur;
END $$
DELIMITER ;

CALL ShowStudentNames();