using System;
using System.Collections.Generic;

namespace QA
{
	public class SetStacks
	{
		private List<Stack<int>> stack_set;
		int stack_capacity;
		int last_stack_index;

		public SetStacks (int capacity)
		{
			stack_set = new List<Stack<int>> ();
			this.stack_capacity = capacity;
			int last_stack_index = 0;
			stack_set.Add (new Stack<int> (capacity));
		}

		public void push(int value)
		{
			if (stack_set [last_stack_index].Count == stack_capacity) {
				last_stack_index ++;
				stack_set.Add (new Stack<int> (stack_capacity));
				stack_set [last_stack_index].Push (value);
			} else 
				stack_set [last_stack_index].Push (value);
		}

		public int peek()
		{
			return stack_set [last_stack_index].Peek ();
		}

		public int pop()
		{
			int to_pop = stack_set [last_stack_index].Pop();
			if (stack_set [last_stack_index].Count == 0) 
				stack_set.RemoveAt (last_stack_index--);
			return to_pop;
		}

		public int popAt(int index)
		{
			int to_pop = stack_set [last_stack_index].Pop();
			if (stack_set [last_stack_index].Count == 0) {
				stack_set.RemoveAt (index);
				last_stack_index--;
			}
			return to_pop;
		}
	}
}

