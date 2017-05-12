using System;
using System.Text;
using System.Collections.Generic;

namespace QA
{
	class MainClass
	{
		private static void print_intMatrix(int[,] M)
		{
			string str_n;
			int n = M.GetLength (0);
			int m = M.GetLength (1);
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < m; j++) {
					str_n = M [i, j].ToString ();
					if (str_n.Length == 1)
						str_n = " " + str_n;
					Console.Write (str_n + " ");
				}
				Console.WriteLine ();
			}
		}

		private static void print_node(Node node)
		{
			Node aux = node;
			while (aux != null) {
				System.Console.Write (aux.data.ToString () + " -> ");
				aux = aux.next;
			}
			Console.WriteLine ();
		}

		public static void Main (string[] args)
		{
			Answers answ = new Answers();
			Answ2 answ2 = new Answ2 ();
			Answ3 answ3 = new Answ3 ();
			Answ5 answ5 = new Answ5 ();
			string str, str2;
			StringBuilder sbtr;

			// 1.1 
			str = "qwerty";
			//System.Console.WriteLine(answ.allDifferentCharacters(str)?"YES":"NO");

			// 1.3
			str2 = "treyqw";
			//Console.WriteLine(answ.isPermutationOf(str, str2) ? "YES" : "NO");

			// 1.4
			sbtr = new StringBuilder("Mr John Smith    ");
			//answ.spaceFill(ref sbtr, 13);
			//Console.WriteLine(sbtr.ToString());

			// 1.5
			str = "aaabccccaa";
			//Console.WriteLine(str + " = " + answ.compress(str));

			// 1.6
			//int[,] M = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}, {13, 14, 15, 16}};
			//int[,] M = {{1, 2, 3, 4, 0}, {5, 6, 7, 8, 0}, {9, 10, 11, 12, 0}, {13, 14, 15, 16, 0}, {0,0,0,0,0}};
			//print_intMatrix(M);
			//Console.WriteLine ();
			//answ.rotate(ref M);
			//print_intMatrix(M);

			// 1.7
			//int[,] M = {{1, 0, 3, 4}, {1, 2, 3, 4}, {1, 2, 0, 4}};
			//answ.crossZero_1(ref M);
			//print_intMatrix(M);

			// 1.8
			//str = "alejo";
			//str2 = "ejoal";
			//Console.WriteLine(answ.isRotationOf_1(str, str2) ? "YES" : "NO");

			// 2.1
			Node a1, a2, a3, a4, a5, a6, a7;
			//a1 = new Node (1); a2 = new Node (2); a3 = new Node (3); a4 = new Node (2); a5 = new Node (3); a6 = new Node (1); a7 = new Node (7);
			//a6.next = a7; a5.next = a6; a4.next = a5; a3.next = a4; a2.next = a3; a1.next = a2;
			//Node res;
			//res = answ2.removeDuplicates (a1);
			//print_node(res);

			// 2.2 
			//a1 = new Node (1); a2 = new Node (2); a3 = new Node (3); a4 = new Node (4); a5 = new Node (5); a6 = new Node (6); a7 = new Node (7);
			//a6.next = a7; a5.next = a6; a4.next = a5; a3.next = a4; a2.next = a3; a1.next = a2;
			//Console.WriteLine(answ2.kthToLast(a1, 3));

			// 2.3
			//a1 = new Node (1); a2 = new Node (2); a3 = new Node (3); a4 = new Node (4); a5 = new Node (5); a6 = new Node (6); a7 = new Node (7);
			//a6.next = a7; a5.next = a6; a4.next = a5; a3.next = a4; a2.next = a3; a1.next = a2;
			//print_node (a1);
			//answ2.deleteCenter_1 (a4);
			//print_node (a1);

			// 2.4
			//a1 = new Node (6); a2 = new Node (1); a3 = new Node (7); a4 = new Node (5); a5 = new Node (2); a6 = new Node (3); a7 = new Node (9);
			//a6.next = a7; a5.next = a6; a4.next = a5; a3.next = a4; a2.next = a3; a1.next = a2;
			//print_node(answ2.partitionAround(a1, 5));

			// 2.5 a 
			//a1 = new Node (7); a2 = new Node (1); a3 = new Node (6); a4 = new Node (5); a5 = new Node (9); a6 = new Node (2); a7 = new Node (2);
			//a2.next = a3; a1.next = a2; a5.next = a6; a4.next = a5; //a2.next = a3; a1.next = a2;
			//print_node(a1);
			//Console.WriteLine ("+");
			//print_node(a4);
			//Console.WriteLine ("=");
			//print_node(answ2.sumBack(a1, a4));

			// 2.5 b
			//a6 = new Node (6); a1 = new Node (1); a7 = new Node (7); a2 = new Node (2); Node a9 = new Node (9); a5 = new Node (5);
			//a1.next = a7; a6.next = a1; 
			//a9.next = a5; a2.next = a9; 
			//print_node(a6);
			//Console.WriteLine ("+");
			//print_node(a2);
			//Console.WriteLine ("=");
			//print_node(answ2.sumForward(a6, a2));

			// 2.7
			//a1 = new Node (5); a2 = new Node (1); a3 = new Node (7); a4 = new Node (1); a5 = new Node (6);
			//a1 = new Node (5); a2 = new Node (1); a3 = new Node (1); a4 = new Node (6); 
			//a4.next = a5; a3.next = a4; a2.next = a3; a1.next = a2;
			//a3.next = a4; a2.next = a3; a1.next = a2;
			//print_node(a1);
			//Console.WriteLine(answ2.palindrome(a1) ? "YES" : "NO");

			// 3.4
			/*
			Disc d3 = new Disc (3); Disc d2 = new Disc (2); Disc d1 = new Disc (1);
			HanoiTower T1 = new HanoiTower (3); HanoiTower T2 = new HanoiTower (3); HanoiTower T3 = new HanoiTower (3);
			T1.insertDisc (d3); T1.insertDisc (d2); T1.insertDisc (d1);
			Console.WriteLine (T1.ToString ());
			Console.WriteLine (T2.ToString ());
			Console.WriteLine (T3.ToString ());
			answ3.hanoi_towers (3, T1, T2, T3);
			Console.WriteLine ("---------");
			Console.WriteLine (T1.ToString ());
			Console.WriteLine (T2.ToString ());
			Console.WriteLine (T3.ToString ());
			*/

			// 3.5 
			//MyQueue mq = new MyQueue ();
			//mq.enqueue(1); mq.enqueue (2); mq.enqueue (3);
			//Console.WriteLine (mq.dequeue ().ToString () + " " + mq.dequeue ().ToString () + " " + mq.dequeue ().ToString ());

			// 4.1
			//AVL T5 = new AVL (5, null);
			//T5.insert (3);T5.insert (2);T5.insert (4);
			//T5.insert (7);T5.insert (6);T5.insert (8);T5.insert (9);T5.insert (10);
			//Console.WriteLine(T5.IsBalanced ? "YES" : "NO");
			//Console.WriteLine(T5.find(1) ? "YES" : "NO");

			// 4.3
			//int[] arr = {1, 2,3, 4, 5, 6, 7, 8, 9,10};
			//BinaryTree bt = BinaryTree.sortedArrayToBinaryTree(arr);
			//Console.WriteLine(bt.IsBalanced ? "YES" : "NO");
			// 4.4
			//List<LinkedNode> by_depth = BinaryTree.nodesByDepth(bt);
			//Console.WriteLine(bt.isBinarySearch() ? "YES" : "NO");

			// 5.5
			answ5.print_binary (answ5.swapOddEvenBits (106));

		}
	}
}
