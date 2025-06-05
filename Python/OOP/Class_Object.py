# --- Define a class ---
class Person:
    # Class variable (shared among all instances)
    species = "Homo sapiens"

    # Constructor (__init__)
    def __init__(self, name, age):
        # Instance variables (unique to each object)
        self.name = name
        self.age = age

    # Instance method
    def greet(self):
        print(f"Hello, my name is {self.name} and I'm {self.age} years old.")

    # Another method
    def have_birthday(self):
        self.age += 1
        print(f"Happy birthday {self.name}, now you are {self.age}!")

# --- Creating Objects ---
person1 = Person("MB", 25)
person2 = Person("YK", 30)

# --- Calling Methods ---
person1.greet()
person2.greet()

# --- Accessing and Modifying Attributes ---
print(person1.age)       # 25
person1.age = 26         # Modify
print(person1.age)       # 26

# --- Using Class Variable ---
print(person1.species)   # Homo sapiens
print(person2.species)   # Homo sapiens

# --- Adding new attribute dynamically ---
person1.city = "New York"
print(person1.city)

# --- Check attribute existence ---
print(hasattr(person1, "name"))  # True
print(hasattr(person1, "salary"))  # False

# --- Use getattr and setattr ---
print(getattr(person1, "name"))     # Alice
setattr(person1, "age", 27)         # Modify age
print(person1.age)

# --- Delete attribute using delattr ---
delattr(person1, "city")
# print(person1.city)  # This will raise AttributeError

# --- Built-in attributes ---
print(person1.__class__)  # <class '__main__.Person'>
print(person1.__dict__)   # Dictionary of instance attributes

# --- Delete object or attribute ---
del person2.age
# print(person2.age)  # Will raise AttributeError

# --- Check class type and instance type ---
print(type(person1))            # <class '__main__.Person'>
print(isinstance(person1, Person))  # True

# --- Empty class using pass ---
class Empty:
    pass

e = Empty()
e.name = "Temporary"
print(e.name)
