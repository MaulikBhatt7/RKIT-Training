class BankAccount:
    def __init__(self, owner, balance):
        self.owner = owner            # Public
        self._account_type = "Saving" # Protected
        self.__balance = balance      # Private

    # Public method
    def show_details(self):
        print(f"Owner: {self.owner}")
        print(f"Account Type: {self._account_type}")
        print(f"Balance: {self.__balance}")

    # Public method to access private balance
    def get_balance(self):
        return self.__balance

    # Public method to safely update balance
    def deposit(self, amount):
        if amount > 0:
            self.__balance += amount
            print(f"Deposited: {amount}")
        else:
            print("Invalid deposit amount")

    # Public method to withdraw
    def withdraw(self, amount):
        if 0 < amount <= self.__balance:
            self.__balance -= amount
            print(f"Withdrawn: {amount}")
        else:
            print("Insufficient balance or invalid amount")

# Create object
account = BankAccount("MB", 1000)

# Accessing public variable
print(account.owner)

# Accessing protected variable (allowed but discouraged)
print(account._account_type)

# Accessing private variable directly (Error!)
# print(account.__balance)  # ❌ AttributeError

# Access using public method
print("Balance:", account.get_balance())

# Deposit and Withdraw
account.deposit(500)
account.withdraw(200)

# Updated balance
print("Balance after transaction:", account.get_balance())

# Attempting to access private variable using name mangling (Not recommended)
print("Accessing private via name mangling:", account._BankAccount__balance)
