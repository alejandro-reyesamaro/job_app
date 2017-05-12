using System;

namespace QA
{
	public class AVL
	{		
		public IComparable data;
		public AVL left;
		public AVL right;
		private AVL father;
		private int h_left;
		private int h_right;	

		public AVL(IComparable data, AVL father)
		{
			this.father = father;
			this.data = data;
			this.left = null;
			this.right = null;
			h_left = 0;
			h_right = 0;
		}

		public bool find(IComparable value)
		{
			if (this.data.CompareTo (value) == 0)
				return true;
			bool is_in_left = left != null && value.CompareTo(data) < 0 && left.find (value);
			bool is_in_right = right != null && value.CompareTo(data) > 0 && right.find (value);
			return is_in_left || is_in_right;
		}

		public void insert(IComparable value) { insert_and_update (value);	}
		private void insert_and_update(IComparable value)
		{
			if (this.data.CompareTo (value) == 0)
				return;

			if (this.data.CompareTo (value) > 0) {// data is after the value, so inserting to the left
				 // case 1: son_left --- null
				if (left != null && right == null) {
					left.insert_and_update (value);
					h_left = Math.Max (left.h_left, left.h_right) + 1;
					// CHECK 4 UNBALANCE
					check_4_unbalance ();
				}// case 2: null --- son_right
				else if (left == null && right != null) {
					this.left = new AVL (value, this);
					h_left = 1;
				}// case 3: null --- null
				else if (left == null && right == null){
					this.left = new AVL (value, this);
					h_left = 1;
				}// case 4: son_left --- son_right
				else {//(left != null && right != null){
					left.insert_and_update (value);
					h_left = Math.Max (left.h_left, left.h_right) + 1;
					// CHECK 4 UNBALANCE										 
					check_4_unbalance ();
				}
			}
			else {// data is before the value, so inserting to the right
				// case 1: son_left --- null
				if (left != null && right == null) {
					this.right = new AVL (value, this);
					h_right = 1;
				}// case 2: null --- son_right
				else if (left == null && right != null) {
					right.insert_and_update (value);
					h_right = Math.Max (right.h_left, right.h_right) + 1;
					// CHECK 4 UNBALANCE
					check_4_unbalance ();
				}// case 3: null --- null
				else if (left == null && right == null){
					this.right = new AVL (value, this);
					h_right = 1;
				}// case 4: son_left --- son_right
				else { //if (left != null && right != null){
					right.insert_and_update (value);
					h_right = Math.Max (right.h_left, right.h_right) + 1;
					// CHECK 4 UNBALANCE
					check_4_unbalance ();					 
				}
			}
		}

		private void check_4_unbalance ()
		{
			// Case 1: ONE rotation, unbalanced by the right
			if (h_right - h_left == 2 && right.h_right - right.h_left == 1) {
				IComparable dataA = this.data;
				IComparable dataB = this.right.data;
				AVL B = this.right;
				this.right = B.right;
				this.right.father = this;
				B.right = B.left; // not updating the father
				if (this.left != null) {
					B.left = this.left;
					B.left.father = B;
				}
				this.left = B;
				B.father = this;
				this.data = dataB;
				this.left.data = dataA;
				h_left += 1;
				h_right -= 1;
			} 
			// Case 2: TWO rotations, unbalanced by the right
			else if (h_right - h_left == 2 && right.h_left - right.h_right == 1) {

			}
		}

		public bool IsLeaf
		{
			get{ return left == null && right == null; }
		}
		public int Height
		{
			get	{ return Math.Max (h_left, h_right) + 1; }
		}
		public bool IsBalanced
		{
			get	{ return Math.Abs(h_left - h_right) < 2; }
		}
	}
}

