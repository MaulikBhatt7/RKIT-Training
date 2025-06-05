# -------------------------------------
# 1. Single Inheritance
# -------------------------------------

class Animal:
    def speak(self):
        print("Animal speaks")

class Dog(Animal):  # Inherits from Animal
    def bark(self):
        print("Dog barks")

print("---- Single Inheritance ----")
dog = Dog()
dog.speak()  # Inherited
dog.bark()   # Own method

# -------------------------------------
# 2. Multiple Inheritance
# -------------------------------------

class Father:
    def skills(self):
        print("Father: Gardening, Driving")

class Mother:
    def skills(self):
        print("Mother: Cooking, Painting")

class Child(Father, Mother):  # Inherits from both
    def skills(self):
        print("Child: ", end="")
        super().skills()  # Will call Father's method due to MRO

print("\n---- Multiple Inheritance ----")
child = Child()
child.skills()
print("MRO:", [cls.__name__ for cls in Child.__mro__])  # Show resolution order

# -------------------------------------
# 3. Multilevel Inheritance
# -------------------------------------

class Grandparent:
    def house(self):
        print("Grandparent's House")

class Parent(Grandparent):  # Inherits from Grandparent
    def car(self):
        print("Parent's Car")

class Grandchild(Parent):  # Inherits from Parent
    def bike(self):
        print("Grandchild's Bike")

print("\n---- Multilevel Inheritance ----")
gc = Grandchild()
gc.house()
gc.car()
gc.bike()

# -------------------------------------
# 4. Hierarchical Inheritance
# -------------------------------------

class Bird:
    def fly(self):
        print("Bird can fly")

class Sparrow(Bird):  # Inherits from Bird
    def size(self):
        print("Sparrow is small")

class Eagle(Bird):  # Also inherits from Bird
    def power(self):
        print("Eagle is powerful")

print("\n---- Hierarchical Inheritance ----")
sp = Sparrow()
eg = Eagle()
sp.fly()
sp.size()
eg.fly()
eg.power()

# -------------------------------------
# 5. Hybrid Inheritance (Multiple + Multilevel)
# -------------------------------------

class A:
    def show(self):
        print("Class A")

class B(A):
    def show(self):
        print("Class B")

class C(A):
    def show(self):
        print("Class C")

class D(B, C):  # Hybrid inheritance
    def show(self):
        print("Class D")

print("\n---- Hybrid Inheritance ----")
d = D()
d.show()
print("MRO:", [cls.__name__ for cls in D.__mro__])
