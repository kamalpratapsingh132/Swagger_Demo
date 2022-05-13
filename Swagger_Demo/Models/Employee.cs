using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Swagger_Demo.Models
{
    public class Employee
    {
        [Key]     
        [JsonIgnore]       
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public string Salary { get; set; }
        public string Address { get; set; }

    }
}
