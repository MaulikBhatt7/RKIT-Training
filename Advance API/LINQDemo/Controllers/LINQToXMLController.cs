using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace LINQDemo.Controllers
{
    /// <summary>
    /// Controller that demonstrates LINQ operations on an XML file.
    /// </summary>
    public class LINQToXMLController : ApiController
    {
        /// <summary>
        /// Retrieves all book names from the provided XML file.
        /// </summary>
        /// <returns>
        /// An HTTP response containing the list of book names retrieved from the XML document.
        /// </returns>
        [HttpGet]
        [Route("linq-to-xml")]
        public IHttpActionResult Get()
        {
            // Loading the XML document from the specified file path
            XElement doc = XElement.Load(@"F:\Maulik Bhatt (RKIT)\RKIT Training\Advance API\LINQDemo\XM File\books.xml");

            // LINQ query to retrieve all book names from the "book" elements in the XML
            var books = from bookname in doc.Descendants("book")
                        select bookname.Value;

            // Returning the list of book names as an HTTP response
            return Ok(books);
        }
    }
}
