using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3._2
{
    internal class EmployeeList<TKey>
    {

        private readonly Dictionary<TKey, IHasAddress> _collection = new Dictionary<TKey, IHasAddress>();


        public void AddElement(TKey key, IHasAddress element)
        {
            if (this._collection.ContainsKey(key))
            {
                throw new ArgumentException($"Key is in use: {key}");
            }

            this._collection.Add(key, element);
        }


        public IHasAddress GetElement (TKey key)
        {
            IHasAddress element = this._collection[key];

            return element != null? element : null;
        }

        public int Size()
        {
            return this._collection.Count;
        }
    }
}
