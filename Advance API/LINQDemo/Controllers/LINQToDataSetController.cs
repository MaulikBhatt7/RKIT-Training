using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace LINQDemo.Controllers
{
    /// <summary>
    /// Controller demonstrating LINQ operations on a DataSet.
    /// </summary>
    public class LINQToDataSetController : ApiController
    {
        /// <summary>
        /// Retrieves rows from a DataTable where the "Name" column contains the letter 'A'.
        /// </summary>
        /// <returns>
        /// A list of anonymous objects containing the ID and Name of rows that match the condition.
        /// </returns>
        [HttpGet]
        [Route("linq-to-dataset")]
        public IHttpActionResult Get()
        {
            // Creating a new DataTable with two columns: ID and Name
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int)); // ID column of type integer
            table.Columns.Add("Name", typeof(string)); // Name column of type string

            // Setting the ID column as the Primary Key
            table.PrimaryKey = new DataColumn[] { table.Columns["ID"] };

            // Adding rows to the DataTable using NewRow method
            DataRow newRow = table.NewRow(); // Creating a new DataRow
            newRow["ID"] = 1;               // Setting values for the row
            newRow["Name"] = "MB";          // Assigning name to the row
            table.Rows.Add(newRow);         // Adding the row to the DataTable
            table.Rows.Add(2, "YK");        // Adding rows directly using parameterized Add
            table.Rows.Add(3, "AB");
            table.Rows.Add(4, "JG");

            // Using LINQ to filter rows where the Name column contains the letter 'A'
            var students = table.AsEnumerable()
                           .Where(row => row.Field<string>("Name").Contains("A")) // Filter rows
                           .Select(row => new
                           {
                               ID = row.Field<int>("ID"),       // Select ID column
                               Name = row.Field<string>("Name") // Select Name column
                           });

            // Returning the filtered rows as the response
            return Ok(students);
        }
    }
}
