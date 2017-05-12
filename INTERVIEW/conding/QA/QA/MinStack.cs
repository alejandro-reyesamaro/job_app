using System;
using System.Collections.Generic;

namespace QA
{
	public class NodeMin
	{
		public NodeMin next;
		public NodeMin next_min;
		public int data;

		public NodeMin(int d)
		{
			data = d;
			next = null;
			next_min = null;
		}
	}

	public class MinStack
	{
		private NodeMin stack;
		private NodeMin min;

		public MinStack ()
		{
		}

		public void push(int value)
		{
			if (stack == null) {
				stack = new NodeMin (value);
				min = stack;
			} else {
				NodeMin top = new NodeMin (value);
				top.next = stack;
				if (value < stack.data) { // asking if the new value in smaller than current min
					top.next_min = min;
					min = top;
				}
				stack = top;
			}
		}

		public int peek()
		{
			return stack.data;
		}

		public int pop()
		{
			int res;
			res = stack.data;
			if (stack == min) 
				min = min.next_min;
			stack = stack.next;
			return res;
		}

		public int getMin()
		{
			return min.data;
		}
	}
}

