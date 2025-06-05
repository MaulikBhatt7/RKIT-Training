# --- Tuple Creation ---
t = ("apple", "banana", "cherry", "apple", "cherry")
print("Tuple:", t)

# --- Type and Length ---
print("Type:", type(t))
print("Length:", len(t))

# --- Accessing Items ---
print("First Item:", t[0])
print("Last Item:", t[-1])
print("Slicing [1:4]:", t[1:4])

# --- Membership Test ---
print("Is 'banana' in tuple?", "banana" in t)

# --- Looping ---
print("For loop:")
for item in t:
    print(item)
print("While loop:")
i = 0
while i < len(t):
    print(t[i])
    i += 1

# --- Immutable Nature and Workaround ---
try:
    t[1] = "kiwi"
except TypeError as e:
    print("Tuple is immutable:", e)

t_list = list(t)
t_list[1] = "kiwi"
t = tuple(t_list)
print("Modified Tuple:", t)

# --- Methods ---
print("Count 'apple':", t.count("apple"))
print("Index of 'cherry':", t.index("cherry"))

# --- Nested Tuple ---
nested = ((1, 2), (3, 4))
print("Nested element:", nested[1][0])

# --- Tuple Packing and Unpacking ---
x = ("python", "java", "c++")
(lang1, lang2, lang3) = x
print("Unpacked:", lang1, lang2, lang3)

# --- Using * unpacking ---
y = ("x", "y", "z", "w")
(a, *b) = y
print("a:", a)
print("b:", b)

# --- Conversion ---
from_list = tuple(["a", "b"])
from_string = tuple("abc")
print("From List:", from_list)
print("From String:", from_string)
