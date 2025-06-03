print("=== for Loop ===")
for i in range(3):  # for loop from 0 to 2
    print("for loop:", i)

print("\n=== while Loop ===")
j = 0
while j < 3:  # while loop until j becomes 3
    print("while loop:", j)
    j += 1  # increment j in each iteration

print("\n=== nested Loop ===")
for i in range(2):  # outer loop from 0 to 1
    for j in range(2):  # inner loop from 0 to 1
        print(f"nested loop: i={i}, j={j}")  # prints combination of i and j

print("\n=== for Loop with else ===")
for i in range(3):  # loop from 0 to 2
    print("loop with else:", i)
else:  # runs only if loop completes normally
    print("Loop finished successfully")  # this runs after the loop ends

print("\n=== break Statement ===")
for i in range(5):  # loop from 0 to 4
    if i == 2:
        break  # exits the loop when i is 2
    print("break example:", i)

print("\n=== continue Statement ===")
for i in range(5):  # loop from 0 to 4
    if i == 2:
        continue  # skips the rest of the loop when i is 2
    print("continue example:", i)

print("\n=== pass Statement ===")
for i in range(5):  # loop from 0 to 4
    if i == 2:
        pass  # does nothing, placeholder
    print("pass example:", i)
