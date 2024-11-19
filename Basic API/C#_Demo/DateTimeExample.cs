using System;

namespace DateTimeDemo
{
    /// <summary>
    /// Demonstrates working with the DateTime class in C#.
    /// </summary>
    public class DateTimeExample
    {
        /// <summary>
        /// Runs a demo to show how DateTime operations work in C#.
        /// </summary>
        public static void RunDateTimeDemo()
        {
            DateTime currentDateTime = DateTime.Now;
            Console.WriteLine($"Current DateTime: {currentDateTime}");

            // Getting the Date part
            DateTime currentDate = currentDateTime.Date;
            Console.WriteLine($"Current Date: {currentDate}");

            // Getting the Time part
            TimeSpan currentTime = currentDateTime.TimeOfDay;
            Console.WriteLine($"Current Time: {currentTime}");

            // Add Days, Months, and Years
            DateTime newDate = currentDateTime.AddDays(5);
            Console.WriteLine($"5 Days Later: {newDate}");

            // DateTime Formatting
            Console.WriteLine($"Formatted DateTime: {currentDateTime:yyyy-MM-dd HH:mm:ss}");

            // Parsing a DateTime string
            string dateString = "2024-11-20";
            DateTime parsedDate = DateTime.Parse(dateString);
            Console.WriteLine($"Parsed Date: {parsedDate}");

            // Compare Dates
            DateTime anotherDate = new DateTime(2024, 11, 20);
            int comparisonResult = DateTime.Compare(currentDateTime, anotherDate);
            string comparisonMessage = comparisonResult == 0 ? "Dates are equal." :
                comparisonResult < 0 ? "Current date is earlier." : "Current date is later.";
            Console.WriteLine(comparisonMessage);
        }
    }
}
