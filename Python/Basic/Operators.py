# Demo of all Python operators

a = 10
b = 3
c = [1, 2, 3]
d = [1, 2, 3]
x = a

print("=== Arithmetic Operators ===")
print("a + b =", a + b)        # Addition
print("a - b =", a - b)        # Subtraction
print("a * b =", a * b)        # Multiplication
print("a / b =", a / b)        # Division
print("a // b =", a // b)      # Floor Division
print("a % b =", a % b)        # Modulus
print("a ** b =", a ** b)      # Exponentiation

print("\n=== Comparison Operators ===")
print("a == b:", a == b)       # Equal
print("a != b:", a != b)       # Not equal
print("a > b:", a > b)         # Greater than
print("a < b:", a < b)         # Less than
print("a >= b:", a >= b)       # Greater than or equal
print("a <= b:", a <= b)       # Less than or equal

print("\n=== Assignment Operators ===")
x = 5                          # Assignment
x += 2; print("x += 2:", x)    # Add and assign
x *= 3; print("x *= 3:", x)    # Multiply and assign

print("\n=== Logical Operators ===")
print("a > 5 and b < 5:", a > 5 and b < 5)  # Logical AND
print("a < 5 or b < 5:", a < 5 or b < 5)    # Logical OR
print("not(a < b):", not (a < b))          # Logical NOT

print("\n=== Bitwise Operators ===")
print("a & b:", a & b)         # Bitwise AND
print("a | b:", a | b)         # Bitwise OR
print("a ^ b:", a ^ b)         # Bitwise XOR
print("~a:", ~a)               # Bitwise NOT
print("a << 1:", a << 1)       # Bitwise left shift
print("a >> 1:", a >> 1)       # Bitwise right shift

print("\n=== Membership Operators ===")
print("2 in c:", 2 in c)             # Value in list
print("4 not in c:", 4 not in c)     # Value not in list

print("\n=== Identity Operators ===")
print("c is d:", c is d)       # Identity (same object)
print("c == d:", c == d)       # Equality (same content)
print("a is x:", a is x)       # Identity (a and x are same object)
