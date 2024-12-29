using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_Demo.Models
{
    public class StudentModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CityID { get; set; }

        public decimal Marks { get; set; }

        public string Grade { get; set; }

    }
}