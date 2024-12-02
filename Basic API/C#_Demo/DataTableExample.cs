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


            // Add a column without specifying the data type
            DataColumn column = new DataColumn("DefaultColumn");
            table.Columns.Add(column);

            // Check the data type of the column
            Console.WriteLine("Column Name: " + column.ColumnName);
            Console.WriteLine("Column Data Type: " + column.DataType);

            // Setting the ID column as the Primary Key
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

            // Adding rows using NewRow method
            DataRow newRow = table.NewRow();
            newRow["ID"] = 1;
            newRow["Name"] = "MB";
            table.Rows.Add(newRow);

            table.Rows.Add(2, "YK");
            table.Rows.Add(3, "AB");
            table.Rows.Add(4, "JG");

            Console.WriteLine("Displaying all rows:");
            DisplayTable(table);

            // Using ImportRow to copy a row into another DataTable
            DataTable clonedTable = table.Clone(); // Cloning structure without data
            DataRow importedRow = table.Rows[0];
            clonedTable.ImportRow(importedRow);
            Console.WriteLine("\nDisplaying cloned table with imported row:");
            DisplayTable(clonedTable);

            // Demonstrating AcceptChanges and RejectChanges
            DataRow modRow = table.Rows.Find(2);
            modRow["Name"] = "Changed Name";
            Console.WriteLine("\nBefore AcceptChanges:");
            Console.WriteLine($"Modified Row - ID: {modRow["ID"]}, Name: {modRow["Name"]}");
            table.AcceptChanges();
            Console.WriteLine("After AcceptChanges:");
            Console.WriteLine($"Committed Row - ID: {modRow["ID"]}, Name: {modRow["Name"]}");

            // RejectChanges Example
            DataRow rejectRow = table.NewRow();
            rejectRow["ID"] = 5;
            rejectRow["Name"] = "Temporary";
            table.Rows.Add(rejectRow);
            Console.WriteLine("\nBefore RejectChanges:");
            DisplayTable(table);
            table.RejectChanges(); // Rejects the addition of new rows since last AcceptChanges call
            Console.WriteLine("After RejectChanges:");
            DisplayTable(table);

            // Copy DataTable Example
            DataTable copiedTable = table.Copy();
            Console.WriteLine("\nDisplaying copied table:");
            DisplayTable(copiedTable);




            // Demo for Merge 3 tables

            // Create first DataTable
            DataTable table1 = new DataTable("Table1");
            table1.Columns.Add("ID", typeof(int));
            table1.Columns.Add("Name", typeof(string));
            table1.Rows.Add(1, "MB");

            // Create second DataTable
            DataTable table2 = new DataTable("Table2");
            table2.Columns.Add("ID", typeof(int));
            table2.Columns.Add("Name", typeof(string));
            table2.Rows.Add(2, "YK");

            // Create third DataTable
            DataTable table3 = new DataTable("Table3");
            table3.Columns.Add("ID", typeof(int));
            table3.Columns.Add("Name", typeof(string));
            table3.Rows.Add(3, "JG");

            // Create a merged DataTable by copying the first table's schema
            DataTable mergedTable = table1.Copy();

            // Merge other tables into the mergedTable
            mergedTable.Merge(table2);
            mergedTable.Merge(table3);


        }

        /// <summary>
        /// Displays the contents of the DataTable.
        /// </summary>
        /// <param name="table">The DataTable to display.</param>
        private static void DisplayTable(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}, Name: {row["Name"]}");
            }
        }
    }
}
