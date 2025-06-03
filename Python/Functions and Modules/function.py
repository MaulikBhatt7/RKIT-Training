# 1. Function with no parameters and no return value
def say_hello():
    print("Hello! This is a basic function.")

say_hello()  # Call the function


# 2. Function with positional parameters
def greet_user(name, age):
    print(f"Positional: Hello {name}, you are {age} years old.")

greet_user("MB", 21)  # Arguments based on position


# 3. Function with return value
def add(x, y):
    return x + y  # Returns the sum

sum_result = add(10, 5)
print("Returned Sum:", sum_result)


# 4. Function with default parameter
def welcome(name="Guest"):
    print(f"Default Param: Welcome, {name}")

welcome()            # Uses default
welcome("MB")      # Overrides default


# 5. Function with keyword (named) arguments
def student_info(name, grade):
    print(f"Keyword Args: {name} is in grade {grade}")

student_info(grade=10, name="Ramesh")  # Order doesn't matter


# 6. Function with *args (arbitrary positional arguments)
def multiply_all(*numbers):
    result = 1
    for num in numbers:
        result *= num
    print("Args (*args): Product =", result)

multiply_all(2, 3, 4)  # Any number of arguments


# 7. Function with **kwargs (arbitrary keyword arguments)
def print_user_info(**kwargs):
    print("Kwargs (**kwargs):")
    for key, value in kwargs.items():
        print(f"{key} = {value}")

print_user_info(name="Sahil", age=30, city="London")


# 8. Function with both *args and **kwargs
def full_details(title, *args, **kwargs):
    print(f"Title: {title}")
    print("Other args:", args)
    print("Other kwargs:", kwargs)

full_details("Employee Record", "extra1", "extra2", name="David", salary=5000)


# 9. Function returning multiple values
def calculate(a, b):
    return a + b, a - b  # Returns a tuple (sum, difference)

s, d = calculate(15, 5)
print("Multiple Returns: Sum =", s, ", Difference =", d)


# 10. Lambda function (anonymous)
square = lambda x: x * x
print("Lambda Function: Square of 6 =", square(6))
