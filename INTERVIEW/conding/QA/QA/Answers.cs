using System;
using System.Text;

namespace QA
{
	class Answers
	{
		// algorithm only for lowercase
		public bool allDifferentCharacters(string str)
		{            
			int bit_flag = 0;
			int current_bit;
			int zero_base_code;
			foreach (char c in str)
			{
				zero_base_code = ((int)c) - 97;
				if (zero_base_code < 0 || zero_base_code > 122)
					return false;
				else
				{
					current_bit = (int)Math.Pow(2, zero_base_code);
					if ((current_bit & bit_flag) > 0) return false;
					bit_flag += current_bit;
				}
			}
			return true;
		}

		private string sortString(string s)
		{
			char[] content = s.ToCharArray ();
			Array.Sort (content);
			return new string (content);
		}

		public bool isPermutationOf_1(string a, string b)
		{
			if (a.Length != b.Length) return false;
			return sortString (a).Equals (sortString (b));
		}

		public bool isPermutationOf_2(string a, string b)
		{
			if (a.Length != b.Length) return false;
			int[] letters = new int[256];
			foreach (var c in a)
				letters [c] ++;			
			
			foreach (var c in b) 
				if(--letters[c] < 0)
					return false;

			return true;			
		}

		public bool isPermutationOf(string a, string b)
		{
			int i_first;
			string left_b, right_b;
			if (a.Length != b.Length) return false;
			if (a.Length == 1)
				return a == b;
			else 
			{
				char first = a[0];
				i_first = b.IndexOf(first);
				if (i_first < 0) return false;
				left_b = (i_first == 0) ? "" : b.Substring(0, i_first);
				right_b = ((i_first == b.Length - 1) ? "" : b.Substring(i_first + 1, b.Length - i_first - 1));
				return isPermutationOf(a.Substring(1), left_b + right_b);
			}
		}

		public void spaceFill(ref StringBuilder str, int len)
		{
			int total_end = str.Length - 1;
			int end = len - 1;
			while(total_end > end)
			{
				if(str[end] == ' ')
				{
					str[total_end--] = '0';
					str[total_end--] = '2';
					str[total_end--] = '%';
					end--;
				} 
				else 
					str [total_end--] = str [end--];
			}
		}

		public string compress(string str)
		{
			int n = 0;
			char c = '\0';
			StringBuilder sb_res = new StringBuilder ();
			foreach (var ch in str) 
			{
				if (ch == c)
					n++;
				else 
				{
					if (n > 0) sb_res.Append (n);
					sb_res.Append (ch);
					c = ch;
					n = 1;
				}
			}
			sb_res.Append (n);
			return sb_res.ToString ();
		}

		private void eraseDimension(ref int[,] M, int index, int dimension)
		{
			bool ed0 = dimension == 0; // erase dimension 0 ? 
			int L = (ed0)? M.GetLength (1) : M.GetLength (0);
			for (int i = 0; i < L; i++)
				M [(ed0) ? index : i, (ed0) ? i : index] = 0;
		}

		public void crossZero_1(ref int[,] M)
		{
			bool[] row = new bool[M.GetLength (0)];
			bool[] column = new bool[M.GetLength (1)];

			// store the row and column index with value 0;
			for(int i = 0; i < M.GetLength(0); i++)
				for (int j = 0; j < M.GetLength(1); j++) 
					if (M [i, j] == 0) {
						row [i] = true;
						column [j] = true;
					}
			for (int i = 0; i < row.Length; i++)
				if (row [i])
					eraseDimension (ref M, i, 0);

			for (int i = 0; i < column.Length; i++)
				if (column [i])
					eraseDimension (ref M, i, 1);

		}

		public void rotate(ref int[,] M)
		{
			int N = M.GetLength (0); // supposing M of NxN
			//int[,] I = {{0, 1, 0, -1},{1, 0, -1, 0}}; // Increment paths
			int start = 0;
			int end = N - 1;
			int n = N;
			int tmp;
			for (int q = 0; q < N/2; q++) {
				for (int i = 0; i < n - 1; i++) {
					tmp = M [start, start + i];
					M [start, start + i] = M [start + i, end];
					M [start + i, end] = M [end, end - i];
					M [end, end - i] = M [end - i, start];
					M [end - i, start] = tmp;
				}
				start = start + 1;
				end = end - 1;
				n = n - 2;
			}
		}

		private bool isSubStringOf(string s1, string s2)
		{
			int start_s1 = 0;
			for (int i = 0; i < s2.Length; i ++) {
				if (s1 [start_s1] == s2 [i])
					start_s1 ++;
				else
					start_s1 = (s1 [0] == s2 [i])? 1 : 0;
				if (start_s1 == s1.Length)
					return true;
			}
			return false;
		}

		public bool isRotationOf(string s1, string s2)
		{
			if (s1.Length != s2.Length)
				return false;
			int start_s1 = 0;
			for (int i = 0; i < s2.Length; i ++) {
				if (s1 [start_s1] == s2 [i])
					start_s1 ++;
				else
					start_s1 = (s1 [0] == s2 [i])? 1 : 0;
			}
			string rest_s1 = s1.Substring (start_s1);
			return isSubStringOf (rest_s1, s2);
		}

		public bool isRotationOf_1(string s1, string s2)
		{
			if (s1.Length != s2.Length)
				return false;
			string s1s1 = s1 + s1;
			return isSubStringOf (s2, s1s1);
		}
	}
}

