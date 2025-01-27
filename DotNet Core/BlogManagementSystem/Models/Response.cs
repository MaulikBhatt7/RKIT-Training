using System.Data;

namespace BlogManagementSystem.Models
{
    /// <summary>
    /// Response Model.
    /// </summary>
    public class Response 
    {
       

        /// <summary>
        /// Check error occuring or not.
        /// </summary>
        public bool IsError { get; set; } = false;


        /// <summary>
        /// Message according to the success or error Response.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Store data of Response.
        /// </summary>
        public dynamic Data { get; set; }


    }
}
