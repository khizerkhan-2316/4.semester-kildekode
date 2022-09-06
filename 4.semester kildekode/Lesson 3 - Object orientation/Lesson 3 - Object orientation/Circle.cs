using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3___Object_orientation
{
    internal class Circle: Shape

    {
        public double Radius { get; set; }


        public Circle(double x, double y, double radius) : base(x, y)
        {
            this.Radius = radius;
        }


        public override double Area()
        {
            return Math.Round(Math.PI * Math.Pow(this.Radius, 2), 2);
        }

        public override string ToString()
        {
            return $"Circle: x: {base.X}, y: {base.Y}, radius: {this.Radius}, Areal: {this.Area()} ";
        }


    }
}
