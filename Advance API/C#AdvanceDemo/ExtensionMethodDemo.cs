namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Demonstrates the usage of extension methods for various data types.
    /// </summary>
    public class ExtensionMethodDemo
    {
        /// <summary>
        /// Tests and prints the output of various extension methods.
        /// </summary>
        public void PrintInfo()
        {
            string str = "ram";
            Console.WriteLine("String Extension - " + str.ToTitleCase());

            double average = 10.2555555;
            Console.WriteLine("Double Extension - " + average.RoundTo(2));

            DateTime dateTime = DateTime.Now;
            Console.WriteLine("DateTime Extension - " + dateTime.IsWeekend());

            List<int> lstNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("List Extension - " + lstNumbers.Average());
        }
    }

    /// <summary>
    /// Provides extension methods for string manipulation.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Converts a string to title case (first letter of each word capitalized).
        /// </summary>
        /// <param name="str">The input string.</param>
        /// <returns>The title-cased string.</returns>
        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }

    /// <summary>
    /// Provides extension methods for double values.
    /// </summary>
    public static class DoubleExtension
    {
        /// <summary>
        /// Rounds a double value to the specified number of decimal places.
        /// </summary>
        /// <param name="value">The double value to round.</param>
        /// <param name="decimals">The number of decimal places to round to.</param>
        /// <returns>The rounded double value.</returns>
        public static double RoundTo(this double value, int decimals)
        {
            return Math.Round(value, decimals);
        }
    }

    /// <summary>
    /// Provides extension methods for DateTime.
    /// </summary>
    public static class DateTimeExtension
    {
        /// <summary>
        /// Checks if a given DateTime falls on a weekend (Saturday or Sunday).
        /// </summary>
        /// <param name="date">The DateTime to check.</param>
        /// <returns>True if the date is a weekend; otherwise, false.</returns>
        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
    }

    /// <summary>
    /// Provides extension methods for lists of integers.
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// Calculates the average of a list of integers.
        /// </summary>
        /// <param name="lstNumbers">The list of integers.</param>
        /// <returns>The average value as a double.</returns>
        public static double Average(this List<int> lstNumbers)
        {
            double sum = 0;
            foreach (int number in lstNumbers)
            {
                sum += number;
            }
            double average = sum / lstNumbers.Count;
            return average;
        }
    }
}
