using System;

namespace QA
{
	public class Node
	{
		public Node next;
		public int data;

		public Node(int d)
		{
			data = d;
			next = null;
		}

		public void append(int d)
		{
			Node tmp = next;
			while(tmp != null)
				tmp = tmp.next;
			tmp.next = new Node(d);
		}

		public static Node delete(Node head, int d)
		{
			if (head.data == d) 
				return head.next;
			Node del = head;
			while (del.next != null) {
				if (del.next.data == d) {
					del.next = del.next.next;
					return head;
				}
				del = del.next;
			}
			return head;
		}
	}

	public class Answ2
	{
		public Answ2 (){}

		public Node removeDuplicates(Node root)
		{
			Node head = root;
			while (head.next != null) {
				head.next = Node.delete (head.next, head.data);
				head = head.next;
			}
			return root;
		}

		public int kthToLast(Node root, int k)
		{
			Node fast = root;
			Node slow = root;
			while (fast.next != null && k-- > 0) {
				fast = fast.next;
			}
			if (fast.next == null && k > 0)
				return -1; // less values than k
			while (fast != null) {
				fast = fast.next;
				slow = slow.next;
			}
			return slow.data;
		}

		public Node partitionAround(Node root, int value)
		{ // assuning <value> exists
			Node smr = new Node (-1); 
			Node bgr = new Node (-1); 
			Node aux_smr = smr;
			Node aux_bgr = bgr;
			Node head = root;
			while (head != null) {
				if (head.data < value) {
					aux_smr.next = head;
					if (smr.next == null)
						smr.next = aux_smr;
					aux_smr = aux_smr.next;
				}
				else if (head.data > value)	{
					aux_bgr.next = head;
					if (bgr.next == null)
						bgr.next = aux_smr;
					aux_bgr = aux_bgr.next;
				}
				head = head.next;
			}
			Node middle = new Node (value);
			middle.next = bgr.next;
			aux_smr.next = middle;
			return smr.next;
		}

		public Node sumBack(Node a, Node b)
		{
			Node result = null;
			Node aux = null;
			Node r;
			int carry = 0;
			int s;
			while (a != null || b != null) {
				s = ((a == null) ? 0 : a.data) + ((b == null) ? 0 : b.data) + carry;
				carry = s / 10;
				s = s % 10;
				r = new Node (s);
				if (result == null) {
					result = r;
					aux = result;
				} else {
					aux.next = r;
					aux = aux.next;
				}
				a = ((a == null) ? a : a.next);
				b = ((b == null) ? b : b.next);
			}
			if (carry != 0)
				aux.next = new Node (carry);
			return result;
		}

		public Node sumForward(Node a, Node b)
		{ //assuming both same size
			Node r;
			Node result = null;
			Node aux = null;
			int carry = 0;
			int s;
			while (a != null && b != null) {
				s = a.data + b.data + carry;
				r = new Node (s);
				if (result == null) 
					result = r;
				else {
					r.next = aux;
					result = r;
				}
				aux = result;
				a = a.next;
				b = b.next;
			}
			carry = 0;
			result = null;
			while (aux != null) {
				s = (aux.data + carry) % 10;
				carry = (aux.data + carry) / 10;
				r = new Node (s);
				if (result == null) {
					result = r;
				} else {
					r.next = result;
					result = r;
				}
				aux = aux.next;
			}
			return result;
		}

		public bool deleteCenter_1(Node n)
		{
			if (n == null || n.next == null)
				return false; // failure
			Node next = n.next;
			n.data = next.data;
			n.next = next.next;
			return true;
		}

		public bool palindrome(Node node)
		{
			System.Collections.Generic.Stack<int> stack = new System.Collections.Generic.Stack<int> ();
			Node slow = node;
			Node fast = node;
			while (fast != null) {
				stack.Push (slow.data);
				slow = slow.next;
				if (fast.next == null) {
					stack.Pop ();
					fast = fast.next;
				} else
					fast = fast.next.next;
			}
			int value;
			while (stack.Count > 0) {
				value = stack.Pop ();
				if (value != slow.data)
					return false;
				slow = slow.next;
			}
			return true;
		}
	}
}

