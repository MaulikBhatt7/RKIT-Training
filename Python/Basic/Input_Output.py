# Taking input from the user
name = input("Enter your name: ")  # Prompt user and read input as string

age = input("Enter your age: ")  # Reads input as string
age = int(age)  # Convert age from string to integer

# Display output using print
print("Hello", name)  # Print greeting with name
print("You are", age, "years old.")  # Print age using comma-separated values
print("Next year you will be " + str(age + 1) + " years old.")  # Using concatenation

# Using f-string for formatted output (Python 3.6+)
print(f"{name}, in 5 years you will be {age + 5} years old.")
