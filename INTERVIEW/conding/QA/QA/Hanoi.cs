using System;
using System.Collections.Generic;

namespace QA
{
	public class Disc
	{
		private int size;

		public int Size{
			get{ return size; }
		}

		public Disc(int size)
		{
			this.size = size;
		}
	}

	public class HanoiTower
	{
		private Stack<Disc> stack;
		private int capacity;

		public HanoiTower (int capacity)
		{
			stack = new Stack<Disc> (capacity);
			this.capacity = capacity;
		}

		public Disc removeDisc()
		{
			if(stack.Count == 0)
				throw new Exception ("IMPOSIBLE to remove");
			return stack.Pop ();
		}

		public void insertDisc(Disc d)
		{
			if (stack.Count > 0 && (stack.Peek ().Size < d.Size || stack.Count == capacity))
				throw new Exception ("IMPOSIBLE to insert");
			else 
				stack.Push (d);
		}

		public override string ToString()
		{
			Disc[] arr = stack.ToArray ();
			string str = "";
			foreach (var d in arr) {
				str += d.Size.ToString () + " ";
			}
			return str;
		}
	}
}

