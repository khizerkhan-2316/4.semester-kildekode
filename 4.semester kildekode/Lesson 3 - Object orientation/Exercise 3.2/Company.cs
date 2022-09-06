using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class Company : IHasAddress
    {

        public string Name { get; set; }
        public Address Address { get; set; }
        

        public Company(string name, Address address)
        {
            this.Name = name;
            this.Address = address;
        }

        public override string ToString()
        {
            return $"Company: Name: {this.Name}, {this.Address}";
        }
    }
}
