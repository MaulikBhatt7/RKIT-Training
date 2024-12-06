using System;
using System.Data;

namespace DataSetDemo
{
    /// <summary>
    /// Demonstrates working with DataSet in C#.
    /// </summary>
    public class DataSetExample
    {
        /// <summary>
        /// Runs a demo to show how DataSet is used in C#.
        /// </summary>
        public static void RunDataSetDemo()
        {
            // Create a new DataSet
            DataSet dataSet = new DataSet("MyDataSet");

            // Create and add the first DataTable (Customers)
            DataTable customers = new DataTable("Customers");
            customers.Columns.Add("CustomerID", typeof(int));
            customers.Columns.Add("CustomerName", typeof(string));

            // Add rows to Customers table
            customers.Rows.Add(1, "MB");
            customers.Rows.Add(2, "YK");

            // Add the Customers table to the DataSet
            dataSet.Tables.Add(customers);

            // Create and add the second DataTable (Orders)
            DataTable orders = new DataTable("Orders");
            orders.Columns.Add("OrderID", typeof(int));
            orders.Columns.Add("CustomerID", typeof(int));
            orders.Columns.Add("OrderDate", typeof(DateTime));

            // Add rows to Orders table
            orders.Rows.Add(101, 1, DateTime.Now.AddDays(-1));
            orders.Rows.Add(102, 2, DateTime.Now);

            // Add the Orders table to the DataSet
            dataSet.Tables.Add(orders);

            //  Display tables in DataSet
            Console.WriteLine("Displaying tables in DataSet:");
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine($"\nTable: {table.TableName}");
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        Console.Write($"{column.ColumnName}: {row[column]} \t");
                    }
                    Console.WriteLine();
                }
            }

            // Add a DataRelation between Customers and Orders
            DataRelation relation = new DataRelation(
                "CustomerOrders",
                customers.Columns["CustomerID"],
                orders.Columns["CustomerID"]);
            dataSet.Relations.Add(relation);

            // Display related data using the relation
            Console.WriteLine("\nDisplaying related data using DataRelation:");
            foreach (DataRow customerRow in customers.Rows)
            {
                Console.WriteLine($"\nCustomer: {customerRow["CustomerName"]}");
                DataRow[] customerOrders = customerRow.GetChildRows(relation);
                foreach (DataRow orderRow in customerOrders)
                {
                    Console.WriteLine($"Order ID: {orderRow["OrderID"]}, Order Date: {orderRow["OrderDate"]}");
                }
            }

            // Merging another DataSet
            DataSet newDataSet = new DataSet();
            DataTable newCustomers = customers.Copy();
            newCustomers.Rows.Add(3, "JG");
            newDataSet.Tables.Add(newCustomers);

            Console.WriteLine("\nMerging new DataSet:");
            dataSet.Merge(newDataSet);

            // Display data after merge
            foreach (DataRow row in dataSet.Tables["Customers"].Rows)
            {
                Console.WriteLine($"Customer ID: {row["CustomerID"]}, Name: {row["CustomerName"]}");
            }

            //  Accepting and Rejecting Changes
            Console.WriteLine("\nModifying data and demonstrating AcceptChanges and RejectChanges:");
            DataRow mbRow = customers.Rows.Find(1);
            mbRow["CustomerName"] = "MB Updated";

            // Reject changes demonstration
            Console.WriteLine("Before RejectChanges:");
            Console.WriteLine($"Modified Name: {mbRow["CustomerName"]}");
            customers.RejectChanges(); // Undo changes
            Console.WriteLine("After RejectChanges:");
            Console.WriteLine($"Reverted Name: {mbRow["CustomerName"]}");

            // Accept changes demonstration
            mbRow["CustomerName"] = "MB Updated";
            customers.AcceptChanges(); // Save changes
            Console.WriteLine("After AcceptChanges:");
            Console.WriteLine($"Final Name: {mbRow["CustomerName"]}");
        }

    }
}
