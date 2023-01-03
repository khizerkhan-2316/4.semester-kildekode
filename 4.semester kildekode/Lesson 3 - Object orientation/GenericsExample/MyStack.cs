using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
	internal class MyStack<T>
	{
		private int _capacity;

		private T[] _stack;

		private int _top;

		public MyStack(int capacity)

		{
			_capacity = capacity;
			_stack = new T[capacity];
			_top = -1;

		}


		public int push(T Element)

		{

			//Check Overflow

			if (_top == _capacity - 1)

			{

				// return -1 if over flow is there

				return -1;

			}

			else

			{

				// insert elementt into stack

				_top = _top + 1;

				_stack[_top] = Element;

			}

			return 0;

		}


		public T pop()

		{

			T RemovedElement;

			T temp = default(T);

			//check Underflow

			if (!(_top <= 0))

			{

				RemovedElement = _stack[_top];

				_top = _top - 1;

				return RemovedElement;

			}

			return temp;

		}


		public T peep(int position)

		{

			T temp = default(T);

			//check if Position is Valid or not

			if (position < _capacity && position >= 0)

			{

				return _stack[position];

			}

			return temp;

		}



		public T[] GetAllStackElements()

		{

			T[] Elements = new T[_top + 1];

			Array.Copy(_stack, 0, Elements, 0, _top + 1);

			return Elements;

		}

		public override string ToString()
		{
			return $"[{string.Join(", ", _stack)}]";
		}

	}







}

