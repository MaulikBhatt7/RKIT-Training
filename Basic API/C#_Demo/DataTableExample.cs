using System;
using System.Data;

namespace DataTableDemo
{
    /// <summary>
    /// Demonstrates working with DataTables in C#.
    /// </summary>
    public class DataTableExample
    {
        /// <summary>
        /// Runs a demo to show how DataTables are used in C#.
        /// </summary>
        public static void RunDataTableDemo()
        {
            // Creating a new DataTable with two columns: ID and Name
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int)); // ID column of type integer
            table.Columns.Add("Name", typeof(string)); // Name column of type string

            // Setting the ID column as the Primary Key
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

            // Adding rows to the DataTable
            table.Rows.Add(1, "John");
            table.Rows.Add(2, "Jane");
            table.Rows.Add(3, "Alice");
            table.Rows.Add(4, "Bob");

            // Assumption: Display all rows
            Console.WriteLine("Displaying all rows:");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
            }

            // Sorting rows by the 'Name' column
            Console.WriteLine("\nDisplaying rows sorted by Name:");
            DataView sortedView = new DataView(table);
            sortedView.Sort = "Name ASC"; // Sort by Name in ascending order
            foreach (DataRowView rowView in sortedView)
            {
                Console.WriteLine($"ID: {rowView["ID"]}, Name: {rowView["Name"]}");
            }

            // Filtering rows: Get rows where Name starts with 'J'
            Console.WriteLine("\nDisplaying rows where Name starts with 'J':");
            DataRow[] filteredRows = table.Select("Name LIKE 'J%'");
            foreach (DataRow row in filteredRows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
            }

            // Modifying a DataRow value
            Console.WriteLine("\nModifying the Name of the row with ID 2:");
            DataRow rowToModify = table.Rows.Find(2); // Find row by primary key (assuming ID is unique)
            if (rowToModify != null)
            {
                rowToModify["Name"] = "Janet";
            }

            // Display modified row
            Console.WriteLine($"ID: {rowToModify["ID"]}, Name: {rowToModify["Name"]}");

            // Deleting a DataRow
            Console.WriteLine("\nDeleting the row with ID 4:");
            DataRow rowToDelete = table.Rows.Find(4); // Find the row by ID
            if (rowToDelete != null)
            {
                table.Rows.Remove(rowToDelete);
            }

            // Displaying remaining rows after deletion
            Console.WriteLine("\nRemaining rows after deletion:");
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
            }
        }
    }
}
