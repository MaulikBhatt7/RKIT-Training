# --- Custom Exception Class ---
class TooSmallError(Exception):
    def __init__(self, message):
        self.message = message
        super().__init__(self.message)

print("=== Full Exception Handling Demo ===")

def process_number(n):
    try:
        # Raise manually if too small
        if n < 10:
            raise TooSmallError("Number is too small (< 10)")

        # Trigger division by zero
        result = 100 / (n - 10)

        # Conversion error
        number = int("not_a_number")

        print("Result:", result)
        print("Converted number:", number)

    except TooSmallError as e:
        print("Custom Exception:", e)

    except ZeroDivisionError as e:
        print("ZeroDivisionError:", e)

    except ValueError as e:
        print("ValueError:", e)

    except Exception as e:
        print("General Exception:", e)

    finally:
        print("Finished processing number:", n)
        print("---")

# Run demo with different values
process_number(5)     # Custom exception
process_number(10)    # ZeroDivisionError
process_number(20)    # ValueError
