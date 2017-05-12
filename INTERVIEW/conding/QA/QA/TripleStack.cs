using System;

namespace QA
{
	public class TripleStack
	{
		private Object[] values;
		private int c1, c2, c3;

		public TripleStack(){
			values = new Object[100];
			c1 = 0;
			c2 = 1;
			c3 = 2;
		}

		private void push(Object value, ref int index)
		{
			values [index] = value;
			index = index + 3;
			if (index >= values.Length)
				resise ();
		}

		private void resise()
		{
			Object[] tmp = new Object[2 * values.Length];
			for(int i = 0; i < values.Length; i++) 
				tmp [i] = values [i];
			values = tmp;
		}

		public void push(Object value, int stackID)
		{
			switch (stackID) {
				case 1:
				push (value, ref c1);
				break;
				case 2:
				push (value, ref c2);
				break;
				case 3:
				push (value, ref c3);
				break;
				default:
				break;
			}
		}

		public Object peek(int stackID)
		{
			switch (stackID) {
				case 1:
				if (c1 > 0)
					return values [c1 - 3];
				else
					return null;
				case 2:
				if (c2 > 1)
					return values [c2 - 3];
				else
					return null;
				case 3:
				if (c3 > 2)
					return values [c3 - 3];
				else
					return null;
				default:
					return null;
			}
		}

		public Object pop(int stackID)
		{
			switch (stackID) {
				case 1:
				if (c1 > 0) {
					c1 = c1 - 3;
					return values [c1];
				}
				else
					return null;
				case 2:
				if (c2 > 1) {
					c2 = c2 - 3;
					return values [c2];
				}
				else
					return null;
				case 3:
				if (c3 > 2) {
					c3 = c3 - 3;
					return values [c3];
				}
				else
					return null;
			default:
				return null;
			}
		}

	}
}

