using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class CPrNumber 
    {

        public string Birthday { get; set; }

        public string SequenceNumber { get; set; }


        public CPrNumber(string birthday, string sequenceNumber)
        {
            this.Birthday = birthday;
            this.SequenceNumber = sequenceNumber;
        }

        public string GetCPr()
        {
            return $"{this.Birthday}-{this.SequenceNumber}";
        }


        public override bool Equals(object obj)
        {
            CPrNumber cPrNumber = obj as CPrNumber;

            if(cPrNumber == null)
            {
                return false;
            }

            return this.GetHashCode() == obj.GetHashCode();
        }


        public override int GetHashCode()
        {
            return this.Birthday.GetHashCode() + this.SequenceNumber.GetHashCode();
        }


        public override string ToString()
        {
            return $"CPR: {this.Birthday}-{this.SequenceNumber}";
        }
    }
}
