create database college;

use college;

create table student(
	rollNo int primary key,
    name varchar(50)
);

show databases;
show tables;

insert into student values (101,'Ram'),(102,'Shyam');

select * from student;


truncate table student;

drop table student;

create table temp(
	id int,
    name varchar(50)
);

alter table temp
add column temp_column varchar(50) not null;

alter table temp
change column name full_name varchar(50) not null;

alter table temp
modify column full_name varchar(30) not null;

alter table temp
drop column temp_column;

alter table temp
rename to renamed_temp;

select * from renamed_temp;

drop table if exists renamed_temp;

create database if not exists temp_db;

drop database if exists temp_db;

















