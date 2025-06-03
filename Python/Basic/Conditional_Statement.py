# Python 3.10+ required for match-case
age = 19
marks = 92
num = -10
day = "Saturday"

print("=== if Statement ===")
if age > 18:
    print("You can drive.")

print("\n=== if-else Statement ===")
if marks >= 50:
    print("Passed")
else:
    print("Failed")

print("\n=== if-elif-else Statement ===")
if marks >= 90:
    print("Grade: A")
elif marks >= 80:
    print("Grade: B")
else:
    print("Grade: C or lower")

print("\n=== Nested if ===")
if num != 0:
    if num > 0:
        print("Positive number")
    else:
        print("Negative number")

print("\n=== Conditional (Ternary) Expression ===")
status = "Adult" if age >= 18 else "Minor"
print("Status:", status)

print("\n=== match-case Statement ===")
match day:
    case "Monday":
        print("Start of week")
    case "Saturday" | "Sunday":
        print("Weekend!")  # This matches
    case _:
        print("Midweek")
