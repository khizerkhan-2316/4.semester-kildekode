using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_3___Object_orientation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Circle(10, 20, 30));
            shapes.Add(new Rectangle(40, 50, 20, 40));

            shapes.ForEach((Shape shape) =>
            {
                Console.WriteLine(shape);
                Console.WriteLine($"Area:{shape.Area()} ");
            });
            Console.ReadLine();
        }
    }
}
