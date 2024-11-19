using System;

namespace OperatorsDemo
{
    /// <summary>
    /// Demonstrates all operators and expressions in C#.
    /// </summary>
    public class OperatorsExample
    {
        public static void RunOperatorsDemo()
        {
            
            int a = 5, b = 10;

            // Arithmetic operators
            int sum = a + b;
            int difference = a - b;
            int product = a * b;
            int quotient = b / a;
            int remainder = b % a;

            // Relational operators
            bool isEqual = (a == b);
            bool isNotEqual = (a != b);
            bool isGreaterThan = (b > a);
            bool isLessThan = (a < b);
            bool isGreaterOrEqual = (b >= a);
            bool isLessOrEqual = (a <= b);

            // Logical operators
            bool logicalAnd = (a > 0) && (b > 0);
            bool logicalOr = (a > 0) || (b < 0);
            bool logicalNot = !(a == 5);

            // Bitwise operators
            int bitwiseAnd = a & b;
            int bitwiseOr = a | b;
            int bitwiseXor = a ^ b;
            int bitwiseNot = ~a;
            int leftShift = a << 1;
            int rightShift = b >> 1;

            // Assignment operators
            int x = 5;
            x += 3; // x = x + 3
            x -= 2; // x = x - 2
            x *= 4; // x = x * 4
            x /= 2; // x = x / 2
            x %= 3; // x = x % 3

            // Unary operators
            int increment = ++a;  // Pre-increment
            int decrement = --b;  // Pre-decrement
            int positive = +a;    // Unary plus
            int negative = -b;    // Unary minus
            bool notEqual = !(a == b); // Logical negation

            // Ternary operator
            string result = (a > b) ? "a is greater than b" : "a is not greater than b";

            // Type-checking operators
            object obj = a;
            bool isInt = obj is int; // Checks if obj is of type int
            int? nullableInt = null;
            int nonNullableInt = nullableInt ?? -1;  // Null-coalescing operator

            // Output results
            Console.WriteLine($"Arithmetic Operators: Sum: {sum}, Difference: {difference}, Product: {product}, Quotient: {quotient}, Remainder: {remainder}");
            Console.WriteLine($"Relational Operators: a == b: {isEqual}, a != b: {isNotEqual}, b > a: {isGreaterThan}, a < b: {isLessThan}, b >= a: {isGreaterOrEqual}, a <= b: {isLessOrEqual}");
            Console.WriteLine($"Logical Operators: Logical AND: {logicalAnd}, Logical OR: {logicalOr}, Logical NOT: {logicalNot}");
            Console.WriteLine($"Bitwise Operators: AND: {bitwiseAnd}, OR: {bitwiseOr}, XOR: {bitwiseXor}, NOT: {bitwiseNot}, Left Shift: {leftShift}, Right Shift: {rightShift}");
            Console.WriteLine($"Assignment Operators: x = 5, after operations x = {x}");
            Console.WriteLine($"Unary Operators: Pre-increment: {increment}, Pre-decrement: {decrement}, Unary Plus: {positive}, Unary Minus: {negative}, NOT: {notEqual}");
            Console.WriteLine($"Ternary Operator: {result}");
            Console.WriteLine($"Type-Checking Operators: obj is int: {isInt}, Nullable Int: {nullableInt}, Non-nullable Int: {nonNullableInt}");
        }
    }
}
