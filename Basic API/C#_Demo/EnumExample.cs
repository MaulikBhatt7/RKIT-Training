using System;

namespace EnumDemo
{
    /// <summary>
    /// Demonstrates the use of enumerations in C#.
    /// </summary>
    public class EnumExample
    {

        /// <summary>
        /// Enum representing days of the week.
        /// </summary>
        public enum EnmDays
        {
            Sunday,
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday
        }


        /// <summary>
        /// Runs a demo to show how enumerations are used in C#.
        /// </summary>
        public static void RunEnumDemo()
        {
            EnmDays today = EnmDays.Monday;

            // Assumption: Enum can be used for type safety and readability
            Console.WriteLine($"Today is: {today}");
        }

        
    }
}
