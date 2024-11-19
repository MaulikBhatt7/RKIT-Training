using System;

namespace ExceptionHandlingDemo
{

    /// <summary>
    /// Custom exception class to handle specific errors.
    /// </summary>
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }


    /// <summary>
    /// Demonstrates exception handling in C# including custom exceptions and throw keyword.
    /// </summary>
    public class ExceptionHandlingExample
    {
        /// <summary>
        /// Runs a demo to show how exceptions are handled in C#.
        /// </summary>
        public static void RunExceptionHandlingDemo()
        {
            try
            {
                // Assumption: Trying to divide by zero which will throw an exception
                int result = DivideNumbers(10, 0);
            }
            catch (DivideByZeroException ex)
            {
                // Insight: Handling DivideByZeroException
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Assumption: Finally block runs regardless of an exception
                Console.WriteLine("Finally Block");
            }

            // Throwing custom exception directly
            try
            {
                ThrowCustomException("Something went wrong in the process!");
            }
            catch (CustomException ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }
        }

        /// <summary>
        /// Divides two numbers and throws an exception if division by zero is attempted.
        /// </summary>
        /// <param name="numerator">The numerator</param>
        /// <param name="denominator">The denominator</param>
        /// <returns>The result of the division</returns>
        /// <exception cref="DivideByZeroException">Thrown when denominator is zero</exception>
        public static int DivideNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                // Insight: Manually throwing DivideByZeroException
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return numerator / denominator;
        }

        /// <summary>
        /// Throws a custom exception with the provided error message.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <exception cref="CustomException">Throws a custom exception</exception>
        public static void ThrowCustomException(string message)
        {
            // Throwing a custom exception
            throw new CustomException(message);
        }
    }

    
}
