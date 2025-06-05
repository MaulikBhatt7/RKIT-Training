# Full Dictionary Demo

# — Creation
car = {"brand":"Ford", "model":"Mustang", "year":1964}
print("Initial:", car)

car2 = dict(name="John", age=36, country="Norway")
print("Named Constructor:", car2)

# — Access
print("brand:", car["brand"], "| model:", car.get("model"))

# — Add / Modify
car["color"] = "red"
car.update({"year":2020, "price":20000})
print("After add/update:", car)

# — Remove
print("Removed price:", car.pop("price"))
# print("Remove last:", car.popitem())
del car["color"]
print("After removal:", car)

# — Looping
print("Keys:", list(car.keys()))
print("Values:", list(car.values()))
print("Items:", list(car.items()))
for k, v in car.items():
    print("Loop –", k, "→", v)

# — Copy & Clear
car_copy = car.copy()
car.clear()
print("Copied:", car_copy, "| Cleared:", car)

# — Nested dictionaries
child1 = {"name":"Emil", "year":2004}
child2 = {"name":"Tobias", "year":2007}
family = {"child1":child1, "child2":child2}
print("Nested child2 name:", family["child2"]["name"])
for key, nested in family.items():
    print(key, nested)

# — Built-in funcs
nums = {"a": 5, "b": 10, "c": 15}
print("Len:", len(nums), "Sum:", sum(nums.values()), "Max:", max(nums.values()))

# — Comprehensions
sq = {x: x*x for x in range(1,6)}
even_sq = {k:v for k,v in sq.items() if v % 2 == 0}
nested_comp = {i:{j:i*j for j in range(1,4)} for i in range(1,4)}
print("Squares:", sq)
print("Even squares:", even_sq)
print("Nested comp:", nested_comp)

# — fromkeys
keys = ["a", "b", "c"]
dk = dict.fromkeys(keys, 0)
print("fromkeys:", dk)
