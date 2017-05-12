using System;
using System.Collections.Generic;

namespace QA
{
	public class MyQueue
	{
		private Stack<int> stack1; 
		private Stack<int> stack2;
		private bool stand_by;

		public MyQueue ()
		{
			stack1 = new Stack<int> ();
			stack2 = new Stack<int> ();
			stand_by = false;
		}
		public void enqueue(int v)
		{
			if (stand_by) {
				reverseTo (stack2, stack1);
				stand_by = false;
			}
			stack1.Push (v);
		}
		public int dequeue()
		{
			if (!stand_by) {
				reverseTo (stack1, stack2);
				stand_by = true;
			}
			return stack2.Pop ();
		}
		public int front()
		{
			if (!stand_by) {
				reverseTo (stack1, stack2);
				stand_by = true;
			}
			return stack2.Peek ();
		}

		private void reverseTo(Stack<int> s1, Stack<int> s2)
		{
			while (s1.Count > 0)
				s2.Push (s1.Pop ());
		}
	}
}

