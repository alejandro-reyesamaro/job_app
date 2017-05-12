using System;
using System.Collections.Generic;

namespace QA
{
	public class BalanceFactor
	{
		public int diff;
		public int length;
		public BalanceFactor(int d, int l)
		{
			diff = d;
			length = l;
		}
	}

	public class BinaryTree
	{
		public int data;
		public BinaryTree left;
		public BinaryTree right;

		public BinaryTree (int data)
		{
			this.data = data;
			this.left = null;
			this.right = null;
		}

		public bool isBinarySearch()
		{
			return isBinarySearch (this, int.MinValue, int.MaxValue);
		}

		private bool isBinarySearch(BinaryTree bt, int min, int max)
		{
			bool itis;
			itis = bt.left == null || (bt.left.data < bt.data && bt.left.data > min);
			itis = itis && (bt.right == null || (bt.right.data > bt.data && bt.right.data < max));
			return (bt.right == null || isBinarySearch (bt.right, bt.data, max)) && (bt.left == null || isBinarySearch (bt.left, min, bt.data));
		}

		public static List<LinkedNode> nodesByDepth(BinaryTree bt)
		{
			List<LinkedNode> list = new List<LinkedNode> ();
			bt.nodesByDepth (list, 0);
			return list;
		}

		private void nodesByDepth(List<LinkedNode> list, int depth)
		{
			if (list.Count <= depth) {
				LinkedNode this_node = new LinkedNode (this.data);
				list.Add (this_node);
			}
			else
				list [depth].append (this.data);
			// recursion
			if (this.left != null)
				left.nodesByDepth (list, depth + 1);
			if (this.right != null)
				right.nodesByDepth (list, depth + 1);
		}

		public static BinaryTree sortedArrayToBinaryTree(int[] arr)
		{
			BinaryTree bt; 
			switch (arr.Length) {
			case 0:
				return null;
			case 1:
				bt = new BinaryTree (arr [0]);
				return bt;
			case 2:
				bt = new BinaryTree (arr [0]);
				bt.right = new BinaryTree (arr [1]);
				return bt;
			case 3:
				bt = new BinaryTree (arr [1]);
				bt.left = new BinaryTree (arr [0]);
				bt.right = new BinaryTree (arr [2]);
				return bt;
			default:
				int mid = (arr.Length - 1) / 2;
				bt = new BinaryTree (arr [mid]);
				bt.insert_sorted_array (arr, 0, mid - 1, mid + 1, arr.Length - 1);
				return bt;
			}

		}

		private void insert_sorted_array(int[] arr, int begin_left, int end_left, int begin_right, int end_right)
		{
			int mid;
			// left
			if (end_left - begin_left == 1) {
				left = new BinaryTree (arr [end_left]);
				left.left = new BinaryTree (arr [begin_left]);
			} else if (end_left - begin_left == 0)
				left = new BinaryTree (arr [end_left]);
			else {
				mid = (begin_left + end_left) / 2;
				left = new BinaryTree (arr [mid]);
				left.insert_sorted_array (arr, begin_left, mid - 1, mid + 1, end_left);
			}

			// right
			if (end_right - begin_right == 1) {
				right = new BinaryTree (arr [begin_right]);
				right.right = new BinaryTree (arr [end_right]);
			} else if (end_left - begin_left == 0)
				right = new BinaryTree (arr [end_right]);
			else {
				mid = (begin_right + end_right) / 2;
				right = new BinaryTree (arr [mid]);
				right.insert_sorted_array (arr, begin_right, mid - 1, mid + 1, end_right);
			}
		}

		public bool IsLeaf
		{
			get{ return left == null && right == null; }
		}

		public int LengthLeft
		{
			get
			{
				if (left == null)
					return 0;
				else
					return 1 + left.Length;
			}
		}

		public int LengthRight
		{
			get
			{
				if (right == null)
					return 0;
				else
					return 1 + right.Length;
			}
		}

		public int Length
		{
			get	{ return Math.Max (LengthLeft, LengthRight); }
		}

		private BalanceFactor GetBalanceFactor
		{
			get{
				if (this.IsLeaf) return new BalanceFactor (0, 0);
				BalanceFactor bf_left;
				BalanceFactor bf_right;
				if (left == null) {
					bf_right = right.GetBalanceFactor;
					return new BalanceFactor (bf_right.diff + 1, bf_right.length + 1);
				}
				if (right == null) {
					bf_left = left.GetBalanceFactor;
					return new BalanceFactor (bf_left.diff + 1, bf_left.length + 1);
				}
				// has both children 
				bf_right = right.GetBalanceFactor;
				bf_left = left.GetBalanceFactor;
				int bf_diff 	= Math.Abs (bf_left.length - bf_right.length);
				int bf_length 	= Math.Max (bf_left.length, bf_right.length) + 1;
				return new BalanceFactor(bf_diff, bf_length);
			}
		}

		public bool IsBalanced
		{
			get
			{
				BalanceFactor bf = this.GetBalanceFactor;
				return bf.diff < 2;
			}
		}
	}
}

