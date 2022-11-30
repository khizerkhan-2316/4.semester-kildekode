using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Model
{
    public class Library
    {
        public Guid LibraryID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual List<Book> Books{ get; set; }



        public Library(string name, string address)
        {
                Name = name;
                Address = address;
                Books = new List<Book>();
                LibraryID = Guid.NewGuid();
        }


        public Library()
        {

        }

            public override string ToString()
        {
            return $"Library: {Name}, {Address}";
        }

    }
}
