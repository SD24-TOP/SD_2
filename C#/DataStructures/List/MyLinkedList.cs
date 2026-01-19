using DataStructures.Common;

namespace DataStructures.List
{
    public class MyLinkedList
    {
        public Node? Head { get; set; }
        
        public MyLinkedList() 
        {
        }

        public MyLinkedList(Node head) { 
            Head = head;
        }

        public void Add(int value) {
            if (Head == null)
            {
                Head = new Node(value);
            }
            else
            {
                Node curr = Head;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                Node next = new Node(value);
                curr.Next = next;
            }
        }

        public void Remove(int value) {
            if (Head == null) return;

            Node curr = Head;
            if (curr.Value == value)
            {
                curr.Next = curr.Next.Next;
            }
            else
            {
                while (curr.Next.Value != value)
                {
                    curr = curr.Next;
                    if(curr.Next == null)
                    {
                        return;
                    }
                }
                curr.Next = curr.Next.Next;
            }
        }

        public void Clear() {
            Head = null;
        }

        public bool Contains(int value) {
            if (Head == null) return false;

            Node curr = Head;
            while (curr.Value != value)
            {
                if (curr.Next == null)
                {
                    return false;
                }
                curr = curr.Next;
            }
            return true;
        }

        public int Count() {
            if (Head == null) return 0;
            Node curr = Head;
            int count = 1;
            while (curr.Next != null)
            {
                curr = curr.Next;
                count++;
            }
            return count;
        }
    }
}
