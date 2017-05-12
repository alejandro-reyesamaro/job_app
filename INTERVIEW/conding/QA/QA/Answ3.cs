using System;
using System.Collections.Generic;

namespace QA
{
	public class Answ3
	{
		public Answ3 (){}

		// N discs from T1, using T2, to T3
		public void hanoi_towers(int N, HanoiTower T1, HanoiTower T2, HanoiTower T3)
		{
			if (N == 1) {
				Disc d = T1.removeDisc ();
				T3.insertDisc (d);
			} else {
				hanoi_towers (N - 1, T1, T3, T2);
				Disc d = T1.removeDisc ();
				T3.insertDisc (d);
				hanoi_towers (N - 1, T2, T1, T3);
			}
		}

		public void sortStack(Stack<int> stack)
		{
			Stack<int> aux = new Stack<int>();
			int N = stack.Count;
			int analyzed = 0;
			int min = stack.Pop ();
			int value;
			while (analyzed < N) {
				while (stack.Count > analyzed) {
					value = stack.Pop ();
					if (value < min) {
						aux.Push (min);
						min = value;
					} else
						aux.Push (value);
				}
				analyzed ++;
				stack.Push (min);
				while (aux.Count > 0)
					stack.Push (aux.Pop ());
			}

		}
	}
}