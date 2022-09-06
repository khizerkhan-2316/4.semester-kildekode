using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Address
    {
        public string RoadName { get; set; }
        public string PostalCode { get; set; }  

        public string City { get; set; }


        public Address(string roadName, string postalCode, string city)
        {
            RoadName = roadName;
            PostalCode = postalCode;
            City = city;
        }

        public override string ToString()
        {
            return $"Address: {this.RoadName}, {this.PostalCode}, {this.City}";
        }
    }
}
