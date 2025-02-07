create database college2;

drop table std01;
CREATE TABLE STD01 (
    D01F01 INT NOT NULL PRIMARY KEY, -- Student ID, primary key
    D01F02 VARCHAR(50) NOT NULL,  -- Student name, required
    D01F03 INT NOT NULL,            -- Student age, required
    D01F04 INT NULL,                -- City ID, nullable
    D01F05 INT NOT NULL,            -- Marks, required
    D01F06 CHAR(1) NOT NULL         -- Grade, required
);

select * from std01;