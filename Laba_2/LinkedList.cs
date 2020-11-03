using System.Collections;
using System.Collections.Generic;

namespace Laba_2
{
    public class LinkedList<T> : IEnumerable<T>
	{
		public bool IsEmpty => Count == 0;
		public Node<T> Head { get; set; }
		public Node<T> Tail { get; set; }
		public int Count { get; set; }

		public void Add(T data)
		{
			var node = new Node<T>(data);

			if (Head == null)
				Head = node;
			else
				Tail.Next = node;
			Tail = node;

			Count++;
		}

		public bool Remove(T data)
		{
			var current = Head;
			Node<T> previous = null;

			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					if (previous != null)
					{
						previous.Next = current.Next;

						if (current.Next == null)
							Tail = previous;
					}
					else
					{
						Head = Head.Next;

						if (Head == null)
							Tail = null;
					}
					Count--;
					return true;
				}

				previous = current;
				current = current.Next;
			}
			return false;
		}

		public void Clear()
		{
			Head = null;
			Tail = null;
			Count = 0;
		}

		public bool Contains(T data)
		{
			var current = Head;

			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;

				current = current.Next;
			}
			return false;
		}

		public T GetByIndex(int index)
		{
			var current = Head;
			var ind = 0;

			while (current != null)
			{
				if (index == ind)
					return current.Data;

				current = current.Next;
				ind++;
			}
			return default;
		}

		public void AppendFirst(T data)
		{
			var node = new Node<T>(data)
			{
				Next = Head
			};

			Head = node;
			if (Count == 0)
				Tail = Head;

			Count++;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			Node<T> current = Head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}

		public IEnumerator GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}
    }
}
