from sqlalchemy import create_engine, Column, Integer, String, ForeignKey
from sqlalchemy.orm import declarative_base, sessionmaker, relationship

# Step 1: Database Configuration
engine = create_engine("mysql+pymysql://Admin:Miracle1234@localhost:3306/test_db_1", echo=True)
Base = declarative_base()
Session = sessionmaker(bind=engine)
session = Session()

# Step 2: Define Tables
class Department(Base):
    __tablename__ = 'departments'
    id = Column(Integer, primary_key=True)
    name = Column(String(50))
    employees = relationship("Employee", back_populates="department")

class Employee(Base):
    __tablename__ = 'employees'
    id = Column(Integer, primary_key=True)
    name = Column(String(50))
    salary = Column(Integer)
    department_id = Column(Integer, ForeignKey('departments.id'))
    department = relationship("Department", back_populates="employees")

# Step 3: Create Tables
Base.metadata.create_all(engine)

# Step 4: Insert Records
def insert_data():
    dept1 = Department(name="HR")
    dept2 = Department(name="IT")
    session.add_all([dept1, dept2])
    session.commit()

    emp1 = Employee(name="MB", salary=50000, department=dept1)
    emp2 = Employee(name="YK", salary=50000, department=dept2)
    session.add_all([emp1, emp2])
    session.commit()

# Step 5: Select All Employees
def select_all_employees():
    employees = session.query(Employee).all()
    print("\nAll Employees:")
    for emp in employees:
        print(f"{emp.id}: {emp.name}, Salary: {emp.salary}, Department: {emp.department.name}")

# Step 6: Select Employee by ID
def select_employee_by_id(emp_id):
    emp = session.query(Employee).get(emp_id)
    if emp:
        print(f"\nEmployee Found: {emp.id}: {emp.name}, Salary: {emp.salary}, Dept: {emp.department.name}")
    else:
        print("\nEmployee not found")

# Step 7: Update Employee Salary
def update_employee_salary(emp_id, new_salary):
    emp = session.query(Employee).get(emp_id)
    if emp:
        emp.salary = new_salary
        session.commit()
        print(f"\nUpdated Salary of {emp.name} to {new_salary}")
    else:
        print("\nEmployee not found")

# Step 8: Delete Employee
def delete_employee(emp_id):
    emp = session.query(Employee).get(emp_id)
    if emp:
        session.delete(emp)
        session.commit()
        print(f"\nDeleted Employee ID {emp_id}")
    else:
        print("\nEmployee not found")

# Step 9: Join Query
def join_employee_department():
    print("\nJoin: Employee and Department")
    results = session.query(Employee.name, Department.name).join(Department).all()
    for emp_name, dept_name in results:
        print(f"Employee: {emp_name}, Department: {dept_name}")

# ---------------------------
# RUN OPERATIONS
# ---------------------------
insert_data()
select_all_employees()
select_employee_by_id(1)
update_employee_salary(1, 70000)
select_employee_by_id(1)
delete_employee(2)
select_all_employees()
join_employee_department()
