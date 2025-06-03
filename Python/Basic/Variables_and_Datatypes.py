# Variables and Data Types

# Numeric Types
int_var = 42
float_var = 3.14159
complex_var = 2 + 3j

# Text Type
str_var = "Hello, Python!"

# Boolean Type
bool_true = True
bool_false = False

# Sequence Types
list_var = [10, 20, 30]
tuple_var = (1, 2, 3)
range_var = range(5)

# Mapping Type
dict_var = {"name": "Alice", "age": 25}

# Set Types
set_var = {1, 2, 3, 4}
frozenset_var = frozenset([5, 6, 7])

# Binary Types
bytes_var = b"Byte string"
bytearray_var = bytearray(5)
memoryview_var = memoryview(bytes(5))

# Print All with Types
print("=== Python Variables and Data Types Demo ===\n")

print(f"int_var: {int_var}, type: {type(int_var)}")
print(f"float_var: {float_var}, type: {type(float_var)}")
print(f"complex_var: {complex_var}, type: {type(complex_var)}\n")

print(f"str_var: {str_var}, type: {type(str_var)}\n")

print(f"bool_true: {bool_true}, type: {type(bool_true)}")
print(f"bool_false: {bool_false}, type: {type(bool_false)}\n")

print(f"list_var: {list_var}, type: {type(list_var)}")
print(f"tuple_var: {tuple_var}, type: {type(tuple_var)}")
print(f"range_var: {list(range_var)}, type: {type(range_var)}\n")

print(f"dict_var: {dict_var}, type: {type(dict_var)}\n")

print(f"set_var: {set_var}, type: {type(set_var)}")
print(f"frozenset_var: {frozenset_var}, type: {type(frozenset_var)}\n")

print(f"bytes_var: {bytes_var}, type: {type(bytes_var)}")
print(f"bytearray_var: {bytearray_var}, type: {type(bytearray_var)}")
print(f"memoryview_var: {memoryview_var}, type: {type(memoryview_var)}\n")

# Type Conversion Example
str_number = "100"
int_number = int(str_number)
float_number = float(int_number)

print(f"Original str_number: {str_number} (type: {type(str_number)})")
print(f"Converted to int: {int_number} (type: {type(int_number)})")
print(f"Converted to float: {float_number} (type: {type(float_number)})")
