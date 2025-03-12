-- Trigger Example (Before Insert - Prevent Duplicate ID)
DELIMITER $$
CREATE TRIGGER BeforeInsertStudent
BEFORE INSERT ON students
FOR EACH ROW
BEGIN
    IF EXISTS (SELECT 1 FROM students WHERE ID = NEW.ID) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Duplicate ID not allowed';
    END IF;
END $$
DELIMITER ;

-- Trigger Example (After Insert - Log New Student Entry)
CREATE TABLE student_log (
    LogID INT AUTO_INCREMENT PRIMARY KEY,
    StudentID INT,
    ActionType VARCHAR(50),
    ActionTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

DELIMITER $$
CREATE TRIGGER AfterInsertStudent
AFTER INSERT ON students
FOR EACH ROW
BEGIN
    INSERT INTO student_log (StudentID, ActionType) VALUES (NEW.ID, 'INSERT');
END $$
DELIMITER ;


DROP TRIGGER IF EXISTS BeforeInsertStudent;
DROP TRIGGER IF EXISTS AfterInsertStudent;
DROP TABLE IF EXISTS student_log;
