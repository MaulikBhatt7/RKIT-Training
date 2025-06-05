import json

# Python data
data = {
    "name": "MB",
    "age": 21,
    "skills": ["Python", ".Net", "JS"],
    "address": {
        "city": "Rajkot",
        "zip": "110001"
    }
}

# Dump to JSON string
json_str = json.dumps(data, indent=2)
print("JSON String:\n", json_str)

# Write to file
with open("mb.json", "w") as f:
    json.dump(data, f)

# Read from file
with open("mb.json", "r") as f:
    loaded_data = json.load(f)

print("\nLoaded from file:", loaded_data["address"]["city"])
