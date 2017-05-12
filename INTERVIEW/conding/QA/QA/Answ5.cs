using System;

namespace QA
{
	public class Answ5
	{
		public Answ5 ()
		{
		}

		private void write_binary(int n)
		{
			if (n == 0 || n == 1)
				Console.Write (n);
			else {
				int c = n / 2;
				int r = n % 2;
				write_binary (c);
				Console.Write (r);
			}
		}
		public void print_binary(int n)
		{
			write_binary (n);
			Console.WriteLine ();
		}

		public int swapOddEvenBits(int n)
		{
			Int32 m1 = 0x55555555; // 101010...1
			int odd_ones = n & m1;
			int even_ones = n & (m1 << 1);
			return (even_ones >> 1) | (odd_ones << 1);
		}
	}
}

