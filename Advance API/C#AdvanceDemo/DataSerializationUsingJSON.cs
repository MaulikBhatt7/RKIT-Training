using Newtonsoft.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CSharpAdvanceDemo
{
    /// <summary>
    /// This class demonstrates data serialization using JSON and XML.
    /// It contains a method to print the serialized and deserialized data.
    /// </summary>
    public class DataSerializationUsingJSON
    {
        /// <summary>
        /// Prints information related to data serialization using JSON and XML.
        /// </summary>
        public void PrintInfo()
        {
            // JSON Serialization and Deserialization demo
            // JSONSerializationDemo objJSONSerializationDemo = new JSONSerializationDemo();
            // objJSONSerializationDemo.PrintInfo();

            // XML Serialization and Deserialization demo
            XMLSerializationDemo objXMLSerializationDemo = new XMLSerializationDemo();
            objXMLSerializationDemo.PrintInfo();
        }
    }

    /// <summary>
    /// This class handles serialization and deserialization of ProductModel objects to and from JSON.
    /// </summary>
    public class JSONSerializationDemo
    {
        // A list of product objects for demonstration purposes
        public static List<ProductModel> products = new List<ProductModel>
        {
            new ProductModel { Id = 1, Name = "Laptop", Price = 1500 },
            new ProductModel { Id = 2, Name = "Smartphone", Price = 800 },
            new ProductModel { Id = 3, Name = "Tablet", Price = 400 }
        };

        /// <summary>
        /// Converts a ProductModel object to a JSON string.
        /// </summary>
        /// <param name="objMember">The ProductModel object to be serialized.</param>
        /// <returns>A JSON string representation of the ProductModel object.</returns>
        public static string ConvertObjectToJson(ProductModel objMember)
        {
            return JsonConvert.SerializeObject(objMember);
        }

        /// <summary>
        /// Converts a JSON string to a ProductModel object.
        /// </summary>
        /// <param name="strJson">The JSON string to be deserialized.</param>
        /// <returns>A ProductModel object created from the JSON string.</returns>
        public static ProductModel ConvertJsonToObject(string strJson)
        {
            return JsonConvert.DeserializeObject<ProductModel>(strJson);
        }

        /// <summary>
        /// Prints the serialized JSON and deserialized objects for each product.
        /// </summary>
        public void PrintInfo()
        {
            foreach (ProductModel product in products)
            {
                string serializedString = ConvertObjectToJson(product);
                Console.WriteLine("JSON Serialization - " + serializedString);
                Console.WriteLine("JSON Deserialization - " + ConvertJsonToObject(serializedString));
            }
        }
    }

    /// <summary>
    /// This class demonstrates how to convert XML data to JSON and vice versa.
    /// It also shows the serialization and deserialization of XML elements.
    /// </summary>
    public class XMLSerializationDemo
    {
        /// <summary>
        /// Converts an XML element to a JSON string.
        /// </summary>
        /// <param name="root">The XML element to be serialized to JSON.</param>
        /// <returns>A JSON string representation of the XML element.</returns>
        public static string ConvertXmlToString(XElement root)
        {
            return JsonConvert.SerializeXNode(root);
        }

        /// <summary>
        /// Converts a JSON string to an XML element.
        /// </summary>
        /// <param name="strJson">The JSON string to be deserialized into XML.</param>
        /// <returns>An XElement representing the XML content from the JSON string.</returns>
        public static XElement ConvertStringToXml(string strJson)
        {
            XElement jsonOutput = JsonConvert.DeserializeXNode($"{{\"Root\":{strJson}}}").Root;
            return jsonOutput;
        }

        /// <summary>
        /// Demonstrates the process of XML serialization and deserialization
        /// and also demonstrates converting between XML and JSON formats.
        /// </summary>
        public void PrintInfo()
        {
            // Creating an object of Person for serialization to XML
            object person = new Person { Name = "MB" };

            // Serialize to XML
            var xmlSerializer = new XmlSerializer(typeof(Person));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, person);
                string xml = stringWriter.ToString();
                Console.WriteLine($"Serialized XML: {xml}");
            }

            // Optionally serialize an XML element to JSON
            // XElement rootElement = new XElement("root", new XElement("Name", "MB"));
            // Console.WriteLine("Serialized XML using JsonConvert: " + ConvertXmlToString(rootElement));

            // Deserialize XML string to object
            string xmlData = "<Person><Name>MB</Name></Person>";
            using (var stringReader = new StringReader(xmlData))
            {
                var deserializedPerson = (Person)xmlSerializer.Deserialize(stringReader);
                Console.WriteLine($"Deserialized Name: {deserializedPerson.Name}");
            }

            // Convert the XML string to JSON using JsonConvert
            Console.WriteLine("Deserialized Name using JsonConvert: " + ConvertStringToXml(xmlData));
        }
    }
}
