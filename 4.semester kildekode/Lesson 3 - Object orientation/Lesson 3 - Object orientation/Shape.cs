using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3___Object_orientation
{
    internal abstract class Shape
    {

        private double x;
        private double y;

   
        public Shape(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Shape() : this(1, 1)
        {
           
        }

        public double X { get { return this.x; } set { this.x = value; } }
        public double Y { get { return this.y; } set { this.y = value; } }

        public abstract override string ToString();

        public abstract double Area();

    }
}
