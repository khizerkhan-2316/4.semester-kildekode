using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4___Delegates
{
    internal static class ExtensionMethods
    {
        public static bool Lang(this string x, int length)
        {
      
            return length > x.Length;
        }
    }
}
