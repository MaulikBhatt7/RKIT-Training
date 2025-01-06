using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LINQDemo.Controllers
{
    /// <summary>
    /// Controller that demonstrates various LINQ operations on in-memory collections (arrays and lists).
    /// </summary>
    public class LINQToObjectController : ApiController
    {
        /// <summary>
        /// Performs various LINQ operations on arrays and lists, such as filtering, projecting, sorting, etc.
        /// </summary>
        /// <returns>
        /// An HTTP response indicating the success of the operation (currently returns Ok).
        /// </returns>
        [HttpGet]
        [Route("linq-to-object")]
        public IHttpActionResult Get()
        {
            // Array of names
            string[] names = {
                "Allu Arjun",
                "Ram Charan",
                "Ram Pothineni "
            };

            // An int array with 7 elements.
            IEnumerable<int> lstNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            // A char array with 6 elements.
            IEnumerable<char> lstLetters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F' };

            // Filter: Select names containing the letter 'a'
            IEnumerable<string> query1 = from name in names
                                         where name.Contains('a')
                                         select name;

            // Filter: Select names with less than 5 characters
            IEnumerable<string> query2 = from name in names
                                         where name.Length < 5
                                         select name;

            // Projection: Select the first character of each name
            IEnumerable<string> query3 = from name in names
                                         select name.Substring(0, 1);

            // Flattening: Split each name into individual words
            IEnumerable<string> query4 = from name in names
                                         from word in name.Split(' ')
                                         select word;

            // Zipping: Combine two sequences (numbers and letters) into pairs
            foreach (var pair in lstNumbers.Zip(lstLetters, (number, letter) => new { number, letter }))
            {
                Console.WriteLine($"Number: {pair.number} zipped with letter: '{pair.letter}'");
            }

            // Set: Removing duplicate names
            IEnumerable<string> query5 = from name in names.Distinct()
                                         select name;

            // Sorting: Order names alphabetically
            IEnumerable<string> query7 = from name in names
                                         orderby name
                                         select name;

            // Sorting: Order names in descending order
            IEnumerable<string> query8 = from name in names
                                         orderby name descending
                                         select name;

            // Partition: Take first 3 numbers from a range
            IEnumerable<int> query9 = from number in Enumerable.Range(0, 8).Take(3)
                                      select number;

            // Partition: Skip first 3 numbers from a range
            IEnumerable<int> query10 = from number in Enumerable.Range(0, 8).Skip(3)
                                       select number;

            // Partition: Take numbers while less than 3
            IEnumerable<int> query11 = from number in Enumerable.Range(0, 8).TakeWhile(n => n < 3)
                                       select number;

            // Partition: Skip numbers while less than 3
            IEnumerable<int> query12 = from number in Enumerable.Range(0, 8).SkipWhile(n => n < 3)
                                       select number;

            // Returning OK response (currently no data returned in response)
            return Ok();
        }
    }
}
