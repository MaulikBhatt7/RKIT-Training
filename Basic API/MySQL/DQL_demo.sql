use college;

-- create city table
create table city(
	city_id int primary key,
    city_name varchar(50)
);


-- create student table
create table student(

	-- primary key demo
	student_id int primary key,
    
    -- unique key and not null constraints demo
    student_name varchar(50) unique not null,
    
    -- default and check constraints demo
    age int default 0 check (age>=0 and age<=100),
    city_id int,
    marks int,
    grade char(1),
    
    -- foreign key demo with cascading demo
    foreign key (city_id) references city(city_id)
    on delete cascade
    on update cascade
);

-- insert in city table
insert into city values
(1,'Rajkot'),
(2,'Morbi');


-- insert in student table
insert into student values
(101,'Ram',20,1,80,'A'),
(102,'Ramesh',21,2,70,'B'),
(103,'Shyam',20,1,90,'O'),
(104,'Suresh',20,2,67,'C'),
(105,'Karan',20,1,85,'A');

insert into student values
(106,'Raju',21,null,54,'D');

-- select demo
select * from student;

-- where clause demo
select * from student 
where student_id = 101;

-- operators demo
select * from student
where student_id = 102 and student_name="Ramesh";

select * from student
where student_id = 102 or student_name="Suresh";

select * from student
where marks between 80 and 90;

select * from student
where marks>=60 and marks<=90;

select * from student
where marks in (80,90);

-- null value demo
select * from student 
where city_id is null;

-- aggregate functions demo
select max(marks) as 'max marks' from student;

select min(marks) as 'min marks' from student;

select avg(marks) as 'avg marks'  from student;

select sum(marks) as 'total marks' from student;

select count(student_id) as 'total students' from student;

select city_name,max(marks) from student s join city c
on s.city_id = c.city_id
where s.city_id is not null
group by city_name
having max(marks) > 70
order by city_name