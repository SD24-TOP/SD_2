using DataStructures.Common;

namespace DataStructures.List
{
    public class MyLinkedList<T>
    {
        public Node<T>? Head { get; set; }
        
        public MyLinkedList() 
        {
        }

        public MyLinkedList(Node<T> head) { 
            Head = head;
        }

        public void Add(T value) {
            if (Head == null)
            {
                Head = new Node<T>(value);
            }
            else
            {
                Node<T> curr = Head;
                while (curr.Next != null)
                {
                    curr = curr.Next;
                }
                Node<T> next = new Node<T>(value);
                curr.Next = next;
            }
        }

        public void Remove(T value) {
            if (Head == null) return;

            Node<T> curr = Head;
            if (curr.Value!.Equals(value))
            {
                curr.Next = curr.Next?.Next;
            }
            else
            {
                while (!curr.Next!.Value!.Equals(value))
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

        public bool Contains(T value) {
            if (Head == null) return false;

            Node<T> curr = Head;
            while (!curr.Value!.Equals(value))
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
            Node<T> curr = Head;
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
