# --- Create sets ---
fruits = {"apple", "banana", "cherry"}
more_fruits = set(["mango", "orange"])
print("Fruits:", fruits)
print("More fruits:", more_fruits)

# --- Add elements ---
fruits.add("kiwi")
fruits.update(["melon", "grape"])
print("After adding:", fruits)

# --- Remove elements ---
fruits.remove("banana")  # Raises error if not present
fruits.discard("pear")   # Safe if not present
print("After removal:", fruits)

# --- Pop & clear ---
popped = fruits.pop()
print("Popped:", popped)
print("Set after pop:", fruits)
fruits.clear()
print("After clear:", fruits)

# --- Set operations ---
a = {"apple", "banana", "cherry"}
b = {"banana", "kiwi", "mango"}

print("Union:", a.union(b))
print("Intersection:", a.intersection(b))
print("Difference (a - b):", a.difference(b))
print("Symmetric difference:", a.symmetric_difference(b))

# --- Update operations ---
a.intersection_update(b)
print("Intersection Update a:", a)

a = {"apple", "banana", "cherry"}
a.difference_update(b)
print("Difference Update a:", a)

a = {"apple", "banana", "cherry"}
a.symmetric_difference_update(b)
print("Symmetric Difference Update a:", a)

# --- Comparison ---
set1 = {"a", "b"}
set2 = {"a", "b", "c"}
print("Is set1 subset of set2?", set1.issubset(set2))
print("Is set2 superset of set1?", set2.issuperset(set1))
print("Are sets disjoint?", set1.isdisjoint({"x", "y"}))

# --- frozenset ---
frozen = frozenset(["x", "y"])
print("Frozen set:", frozen)