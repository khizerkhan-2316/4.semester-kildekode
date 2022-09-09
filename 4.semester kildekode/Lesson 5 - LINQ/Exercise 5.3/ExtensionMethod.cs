using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5._3
{
    internal static class ExtensionMethod
    {
        public static void SetAcceptedP(this List<Person> list, Predicate<Person> predicate)
        {
            list.FindAll((Person person) => predicate(person)).ForEach((Person person) => person.Accepted = true);
        }

        public static void Reset(this List<Person> list)
        {
            list.ForEach((Person person) => person.Accepted = false);
        }

    }
}
