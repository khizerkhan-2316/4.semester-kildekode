using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3___Object_orientation
{
    internal class Rectangle: Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }


        public Rectangle(double x, double y, double length, double width) : base(x, y)
        {
            this.Length = length;
            this.Width = width;

        }

        public override double Area()
        {
            return Math.Round(this.Length * this.Width, 2);
        }

        public override string ToString()
        {
            return $"Rectangle: x: {base.X}, y: {base.Y}, length: {this.Length}, width: {this.Width}, area: {this.Area()} ";
        }



    }
}
