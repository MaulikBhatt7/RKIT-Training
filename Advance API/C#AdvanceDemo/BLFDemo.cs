using UniqueListLibrary;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// A demonstration class to showcase basic features of the UniqueList.
    /// It demonstrates adding unique elements to the list and preventing duplicates.
    /// </summary>
    public class BLFDemo
    {
        /// <summary>
        /// Prints the information of the BLF (Basic Library Feature) demo.
        /// This includes demonstrating adding unique items and handling duplicate values in the list.
        /// </summary>
        public void PrintInfo()
        {
            // Create an instance of the UniqueList to hold unique integer values
            UniqueList<int> lstNumbers = new UniqueList<int>();

            // Adding elements to the list
            lstNumbers.Add(1);  // Adds 1
            lstNumbers.Add(2);  // Adds 2
            lstNumbers.Add(3);  // Adds 3
            lstNumbers.Add(1);  // Does not add 1 (duplicate)

            // Print the list after adding unique elements
            Console.WriteLine("List after adding unique elements: ");
            foreach (int number in lstNumbers)
            {
                // Display each element in the list
                Console.WriteLine(number);  // Output: 1, 2, 3
            }

            // Add a range of elements to the list, demonstrating uniqueness
            lstNumbers.AddRange(new List<int> { 4, 5, 6, 6 });  // 6 is duplicated and won't be added

            // Print the list after adding a range of elements
            Console.WriteLine("List after adding a range of unique elements: ");
            foreach (int number in lstNumbers)
            {
                // Display each element in the updated list
                Console.WriteLine(number);  // Output: 1, 2, 3, 4, 5, 6
            }
        }
    }
}
