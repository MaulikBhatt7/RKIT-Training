-- CTE Demo
Explain with HighScorers as (
    select 
        s.student_id, 
        s.student_name, 
        s.marks, 
        c.city_name
    from 
        student s
    join 
        city c on s.city_id = c.city_id
    where 
        s.marks > 75
)
select * from HighScorers;


-- Find_In_Set() demo

-- Example usage of FIND_IN_SET
select student_name, 
       find_in_set(student_name, 'Karan,Ram') as position
from student;