# --- List Creation & Type ---
fruits = ["apple", "banana", "cherry", "apple"]  # Allows dupes
print(fruits, type(fruits))

# --- Constructor ---
nums = list((1, 2, 3, 4))
print(nums)

# --- Length, Indexing, Slicing ---
print("Len:", len(fruits))
print("First:", fruits[0], "Last:", fruits[-1])
print("Slice 1–3:", fruits[1:3])

# --- Modifying ---
fruits[1] = "blueberry"
print("After change:", fruits)

# --- Methods ---
fruits.append("date")
fruits.insert(2, "avocado")
fruits.extend(["elderberry", "fig"])
print("After append/insert/extend:", fruits)

print("Count 'apple':", fruits.count("apple"))
print("Index of 'cherry':", fruits.index("cherry"))

removed = fruits.pop()     # removes last
fruits.remove("apple")     # removes first 'apple'
print("Removed:", removed)
print("After pop/remove:", fruits)

fruits.reverse()
print("Reversed:", fruits)

fruits.sort()
print("Sorted:", fruits)

# --- Copy and Clear ---
copy_fruits = fruits.copy()
copy_fruits.clear()
print("Copy cleared:", copy_fruits)

# --- List Comprehension ---
numbers = [1, 2, 3, 4, 5]
squares = [n * n for n in numbers if n % 2 == 0]
print("Squares of evens:", squares)

# --- all(), sum(), min(), max(), sorted(), reversed() ---
print("All >0:", all(n > 0 for n in numbers))
print("Sum:", sum(numbers), "Min:", min(numbers), "Max:", max(numbers))
print("Sorted dec:", sorted(numbers, reverse=True))
print("Reversed iterator:", list(reversed(numbers)))

# --- Looping Lists ---
for i, fruit in enumerate(fruits):
    print(f"Index {i} — {fruit}")

# --- Nested Lists ---
matrix = [[1,2,3], [4,5,6], [7,8,9]]
print("Matrix[1][2]:", matrix[1][2])

# --- List from other iterables ---
chars = list("hello")
tuple_elements = list((10, 20))
print(chars, tuple_elements)

# --- All True using all() ---
print("All fruits:", all(fruits))  # False if empty or contains false-y
