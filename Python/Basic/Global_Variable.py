# Global variable defined at the top level
count = 0

def read_global():
    print("Read Global (inside function):", count)  # Allowed

def modify_local():
    count = 100  # This creates a new local variable (does NOT modify global)
    print("Modified Local:", count)

def modify_global():
    global count
    count = 200  # This modifies the global variable
    print("Modified Global:", count)

def dynamic_global_change():
    globals()['count'] = 300  # Modify global variable using globals() dict
    print("Changed using globals():", count)

#  Function demonstrating another global variable
def define_new_global():
    global new_var
    new_var = "I'm new here!"  # Creates a new global variable
    print("Defined inside function:", new_var)

# Run all demos
print("Initially:", count)
read_global()

modify_local()       # Only affects local copy
print("After local modify:", count)  # Global remains unchanged

modify_global()      # Updates the global
print("After global modify:", count)

dynamic_global_change()
print("After globals() modify:", count)

define_new_global()
print("Access new global outside:", new_var)
