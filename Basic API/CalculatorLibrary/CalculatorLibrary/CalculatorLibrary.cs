// CalculatorLibrary.cs
using System;

namespace CalculatorLibrary
{
    public class Calculator
    {
        // Method for addition
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Method for subtraction
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Method for multiplication
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Method for division
        public double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
}
