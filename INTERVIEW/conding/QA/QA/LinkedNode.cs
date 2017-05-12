using System;

namespace QA
{
	public class LinkedNode
	{
		public LinkedNode next;
		public IComparable data;

		public LinkedNode(IComparable d)
		{
			data = d;
			next = null;
		}

		public void append(IComparable d)
		{
			LinkedNode tmp = this;
			while(tmp.next != null)
				tmp = tmp.next;
			tmp.next = new LinkedNode(d);
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
}

