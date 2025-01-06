using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// Demonstrates various LINQ methods such as filtering, projection, sorting, quantifiers, joins, grouping, aggregation, 
    /// and conversions using sample data.
    /// </summary>
    public class LINQDemo
    {
        // Sample data: List of people
        List<Person> lstPeople = new List<Person>
        {
            new Person { PersonID = 1, Name = "Arjun", Age = 25 },
            new Person { PersonID = 2, Name = "Ram", Age = 30 },
            new Person { PersonID = 3, Name = "Prabhas", Age = 25 },
            new Person { PersonID = 4, Name = "Nithin", Age = 40 }
        };

        // Sample data: List of orders
        List<Order> lstOrders = new List<Order>
        {
            new Order { OrderId = 1, PersonId = 1, TotalAmount = 100 },
            new Order { OrderId = 2, PersonId = 2, TotalAmount = 150 },
            new Order { OrderId = 3, PersonId = 3, TotalAmount = 200 }
        };

        /// <summary>
        /// Executes various LINQ methods and displays results.
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine("-----------Filter Methods----------");
            FilterMethods();

            Console.WriteLine("-----------Projection Methods----------");
            ProjectionMethods();

            Console.WriteLine("-----------Sorting Methods----------");
            SortingMethods();

            Console.WriteLine("-----------Quantifier Methods----------");
            QuantifierMethods();

            Console.WriteLine("-----------Set Methods----------");
            SetMethods();

            Console.WriteLine("-----------Join Methods----------");
            JoinMethods();

            Console.WriteLine("-----------Aggregate Methods----------");
            AggregateMethods();

            Console.WriteLine("-----------Group Methods----------");
            GroupMethods();

            Console.WriteLine("-----------Conversion Methods----------");
            ConversionMethods();

            Console.WriteLine("-----------Partition Methods----------");
            PartitionMethods();
        }

        /// <summary>
        /// Demonstrates filtering operations like Where, First, Last, Single, etc.
        /// </summary>
        public void FilterMethods()
        {
            // Where() - Filters adults aged 30 or above
            List<Person> adults = lstPeople.Where(p => p.Age >= 30).ToList();
            Console.WriteLine("Adults: " + string.Join(", ", adults.Select(p => p.Name)));

            // First() - Gets the first person aged 30 or above
            Person firstAdult = lstPeople.First(p => p.Age >= 30);
            Console.WriteLine("First adult: " + firstAdult.Name);

            // FirstOrDefault() - Gets the first person aged above 40, or null if none exist
            Person? firstOrDefault = lstPeople.FirstOrDefault(p => p.Age > 40);
            Console.WriteLine("First or Default (no match): " + (firstOrDefault?.Name ?? "None"));

            // Single() - Gets the only person with PersonID = 1
            try
            {
                Person singlePerson = lstPeople.Single(p => p.PersonID == 1);
                Console.WriteLine("Single person: " + singlePerson.Name);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Single person exception: Multiple matches");
            }

            // SingleOrDefault() - Returns null if no person with PersonID = 5
            Person? singleOrDefaultPerson = lstPeople.SingleOrDefault(p => p.PersonID == 5);
            Console.WriteLine("Single or Default (no match): " + (singleOrDefaultPerson?.Name ?? "None"));

            // Last() - Gets the last person aged 30 or above
            Person lastPerson = lstPeople.Last(p => p.Age >= 30);
            Console.WriteLine("Last adult: " + lastPerson.Name);

            // LastOrDefault() - Returns null if no person aged above 40
            Person? lastOrDefaultPerson = lstPeople.LastOrDefault(p => p.Age > 40);
            Console.WriteLine("Last or Default (no match): " + (lastOrDefaultPerson?.Name ?? "None"));
        }

        /// <summary>
        /// Demonstrates projection methods like Select and SelectMany.
        /// </summary>
        public void ProjectionMethods()
        {
            // Select - Projects only the names of people
            IEnumerable<string> names = lstPeople.Select(p => p.Name);
            Console.WriteLine("Names: " + string.Join(", ", names));

            // SelectMany - Flattens nested collections
            List<List<int>> numberGroups = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 3, 4 }
            };

            // Flattening the nested lists into a single collection
            IEnumerable<int> flattenedNumbers = numberGroups.SelectMany(group => group);
            Console.WriteLine("Flattened Numbers: " + string.Join(", ", flattenedNumbers));
        }

        /// <summary>
        /// Demonstrates partitioning methods like Take, Skip, and their variants.
        /// </summary>
        public void PartitionMethods()
        {
            // TakeWhile() - Takes elements while the condition is true
            IEnumerable<Person> lstPeopleStartingWithA = lstPeople.TakeWhile(p => p.Name.StartsWith("A"));
            Console.WriteLine("TakeWhile: " + string.Join(", ", lstPeopleStartingWithA.Select(p => p.Name)));

            // SkipWhile() - Skips elements while the condition is true
            IEnumerable<Person> lstPeopleNotStartingWithA = lstPeople.SkipWhile(p => p.Name.StartsWith("A"));
            Console.WriteLine("SkipWhile: " + string.Join(", ", lstPeopleNotStartingWithA.Select(p => p.Name)));

            // Take() - Takes the first 3 elements
            IEnumerable<Person> first3People = lstPeople.Take(3);
            Console.WriteLine("First 3 people: " + string.Join(", ", first3People.Select(p => p.Name)));

            // Skip() - Skips the first 3 elements
            IEnumerable<Person> skipFirst3People = lstPeople.Skip(3);
            Console.WriteLine("Skip first 3 people: " + string.Join(", ", skipFirst3People.Select(p => p.Name)));

            // TakeLast() - Takes the last 2 elements
            IEnumerable<Person> last2People = lstPeople.TakeLast(2);
            Console.WriteLine("Last 2 people: " + string.Join(", ", last2People.Select(p => p.Name)));

            // SkipLast() - Skips the last 2 elements
            IEnumerable<Person> skipLast2People = lstPeople.SkipLast(2);
            Console.WriteLine("Skip last 2 people: " + string.Join(", ", skipLast2People.Select(p => p.Name)));
        }

        /// <summary>
        /// Demonstrates sorting methods like OrderBy, ThenBy, and their descending variants.
        /// </summary>
        public void SortingMethods()
        {
            // OrderBy() - Sorts by age in ascending order
            List<Person> sortedByAgeAsc = lstPeople.OrderBy(p => p.Age).ToList();
            Console.WriteLine("Sorted by Age Ascending: " + string.Join(", ", sortedByAgeAsc.Select(p => p.Name)));

            // OrderByDescending() - Sorts by age in descending order
            List<Person> sortedByAgeDesc = lstPeople.OrderByDescending(p => p.Age).ToList();
            Console.WriteLine("Sorted by Age Descending: " + string.Join(", ", sortedByAgeDesc.Select(p => p.Name)));

            // ThenBy() - Secondary sort by name in ascending order
            List<Person> sortedThenByName = lstPeople.OrderBy(p => p.Age).ThenBy(p => p.Name).ToList();
            Console.WriteLine("Sorted by Age then Name: " + string.Join(", ", sortedThenByName.Select(p => p.Name)));

            // ThenByDescending() - Secondary sort by name in descending order
            List<Person> sortedThenByDescName = lstPeople.OrderBy(p => p.Age).ThenByDescending(p => p.Name).ToList();
            Console.WriteLine("Sorted by Age then Name Descending: " + string.Join(", ", sortedThenByDescName.Select(p => p.Name)));
        }

        /// <summary>
        /// Demonstrates quantifier methods like Any, All, Contains, and Count.
        /// </summary>
        public void QuantifierMethods()
        {
            // Any() - Checks if any person is aged 30 or above
            bool anyAdults = lstPeople.Any(p => p.Age >= 30);
            Console.WriteLine("Any adults: " + anyAdults);

            // All() - Checks if all people are aged 30 or above
            bool allAdults = lstPeople.All(p => p.Age >= 30);
            Console.WriteLine("All adults: " + allAdults);

            // Contains() - Checks if a specific PersonID is in the list
            bool containsPersonID1 = lstPeople.Select(p => p.PersonID).Contains(1);
            Console.WriteLine("Contains PersonID 1: " + containsPersonID1);

            // Count() - Counts the total number of people
            int totalPeople = lstPeople.Count();
            Console.WriteLine("Total people: " + totalPeople);
        }

        /// <summary>
        /// Demonstrates set operations like Distinct, Union, Intersect, and Except.
        /// </summary>
        public void SetMethods()
        {
            List<int> set1 = new List<int> { 1, 2, 3 };
            List<int> set2 = new List<int> { 3, 4, 5 };

            // Distinct() - Removes duplicates from a sequence
            List<int> distinctSet1 = set1.Distinct().ToList();
            Console.WriteLine("Distinct Set1: " + string.Join(", ", distinctSet1));

            // Union() - Combines two sequences, removing duplicates
            List<int> union = set1.Union(set2).ToList();
            Console.WriteLine("Union: " + string.Join(", ", union));

            // Intersect() - Finds common elements between two sequences
            List<int> intersect = set1.Intersect(set2).ToList();
            Console.WriteLine("Intersect: " + string.Join(", ", intersect));

            // Except() - Finds elements in set1 that are not in set2
            List<int> except = set1.Except(set2).ToList();
            Console.WriteLine("Except: " + string.Join(", ", except));

            // Concat() - Concatenates two sequences (allows duplicates)
            List<int> concat = set1.Concat(set2).ToList();
            Console.WriteLine("Concat: " + string.Join(", ", concat));
        }

        /// <summary>
        /// Demonstrates join operations like Join and GroupJoin.
        /// </summary>
        public void JoinMethods()
        {
            // Join() - Performs an inner join between two sequences
            var personOrders = lstPeople.Join(lstOrders,
                person => person.PersonID,
                order => order.PersonId,
                (person, order) => new
                {
                    PersonName = person.Name,
                    OrderAmount = order.TotalAmount
                });

            foreach (var item in personOrders)
            {
                Console.WriteLine($"Person: {item.PersonName}, Order Amount: {item.OrderAmount}");
            }

            // GroupJoin() - Groups orders by person
            var groupedOrders = lstPeople.GroupJoin(lstOrders,
                person => person.PersonID,
                order => order.PersonId,
                (person, orders) => new
                {
                    PersonName = person.Name,
                    Orders = orders.Select(o => o.TotalAmount)
                });

            foreach (var item in groupedOrders)
            {
                Console.WriteLine($"Person: {item.PersonName}, Orders: {string.Join(", ", item.Orders)}");
            }
        }

        /// <summary>
        /// Demonstrates aggregate methods like Sum, Average, Min, Max, and Aggregate.
        /// </summary>
        public void AggregateMethods()
        {
            // Sum() - Calculates the total of all order amounts
            int totalAmount = lstOrders.Sum(o => o.TotalAmount);
            Console.WriteLine("Total Order Amount: " + totalAmount);

            // Average() - Calculates the average order amount
            double averageAmount = lstOrders.Average(o => o.TotalAmount);
            Console.WriteLine("Average Order Amount: " + averageAmount);

            // Min() - Finds the minimum order amount
            int minAmount = lstOrders.Min(o => o.TotalAmount);
            Console.WriteLine("Minimum Order Amount: " + minAmount);

            // Max() - Finds the maximum order amount
            int maxAmount = lstOrders.Max(o => o.TotalAmount);
            Console.WriteLine("Maximum Order Amount: " + maxAmount);

            // Aggregate() - Combines all elements into a single result (sum in this case)
            int totalSum = lstOrders.Select(o => o.TotalAmount).Aggregate((sum, next) => sum + next);
            Console.WriteLine("Aggregate Total Amount: " + totalSum);
        }

        /// <summary>
        /// Demonstrates grouping methods like GroupBy.
        /// </summary>
        public void GroupMethods()
        {
            // GroupBy() - Groups people by age
            var groupedByAge = lstPeople.GroupBy(p => p.Age);

            foreach (var group in groupedByAge)
            {
                Console.WriteLine($"Age: {group.Key}, People: {string.Join(", ", group.Select(p => p.Name))}");
            }
        }

        /// <summary>
        /// Demonstrates conversion methods like ToList, ToArray, ToDictionary, and OfType.
        /// </summary>
        public void ConversionMethods()
        {
            // ToList() - Converts a sequence to a List
            List<string> namesList = lstPeople.Select(p => p.Name).ToList();
            Console.WriteLine("Names List: " + string.Join(", ", namesList));

            // ToArray() - Converts a sequence to an Array
            string[] namesArray = lstPeople.Select(p => p.Name).ToArray();
            Console.WriteLine("Names Array: " + string.Join(", ", namesArray));

            // ToDictionary() - Converts a sequence to a Dictionary
            Dictionary<int, string> personDictionary = lstPeople.ToDictionary(p => p.PersonID, p => p.Name);
            foreach (var kvp in personDictionary)
            {
                Console.WriteLine($"PersonID: {kvp.Key}, Name: {kvp.Value}");
            }

            // OfType<T>() - Filters elements of a specific type
            List<object> mixedList = new List<object> { 1, "hello", 2.5, "world" };
            IEnumerable<string> strings = mixedList.OfType<string>();
            Console.WriteLine("Strings: " + string.Join(", ", strings));
        }
    }
}
