CALL SelectAllStudents;

SHOW GRANTS FOR 'tester_user'@'localhost';

Select * from student;
Insert into student (student_id,student_name) values (107,'asdf')