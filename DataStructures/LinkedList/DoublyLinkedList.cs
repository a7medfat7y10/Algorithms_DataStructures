using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoublyLinkedList
{

    public class LinkedListNode
    {
        public int data;
        public LinkedListNode next;
        public LinkedListNode back;

        public LinkedListNode(int _data)
        {
            this.data = _data;
            this.next = null;
            this.back = null;
        }
    }

    public class LinkedListIterator
    {
        private LinkedListNode currentNode;

        public LinkedListIterator()
        {
            this.currentNode = null;
        }

        public LinkedListIterator(LinkedListNode node)
        {
            this.currentNode = node;
        }

        public int Data()
        {
            return this.currentNode.data;
        }

        public LinkedListIterator Next()
        {
            this.currentNode = this.currentNode.next;
            return this;
        }

        public LinkedListNode Current()
        {
            return this.currentNode;
        }
    }

    public class LinkedList
    {
        public LinkedListNode head = null;
        public LinkedListNode tail = null;

        public LinkedListIterator Begin()
        {
            LinkedListIterator itr = new LinkedListIterator(this.head);
            return itr;
        }

        public void PrintList()
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.Next())
            {
                Console.Write(itr.Data() + " -> ");
            }
            Console.Write("\n");
        }

        public LinkedListNode Find(int _data)
        {
            for (LinkedListIterator itr = this.Begin(); itr.Current() != null; itr.Next())
            {
                if (_data == itr.Data())
                {
                    return itr.Current();
                }
            }
            return null;
        }

        public void InsertAfter(LinkedListNode node, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node.next;
            newNode.back = node;
            node.next = newNode;

            if (newNode.next == null)
            {
                this.tail = newNode;
            }
            else
            {
                newNode.next.back = newNode;
            }
        }

        public void InsertLast(int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);

            if (this.tail == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                newNode.back = this.tail;
                this.tail.next = newNode;
                this.tail = newNode;
            }
        }

        public void InsertBefore(LinkedListNode node, int _data)
        {
            LinkedListNode newNode = new LinkedListNode(_data);
            newNode.next = node;

            if (node == this.head)
            {
                this.head = newNode;
            }
            else
            {
                node.back.next = newNode;
            }

            node.back = newNode;
        }

        public void DeleteNode(LinkedListNode node)
        {
            if (this.head == this.tail)
            {
                this.head = null;
                this.tail = null;
            }
            else if (node.back == null)
            {
                this.head = node.next;
                node.next.back = null;
            }
            else if (node.next == null)
            {
                this.tail = node.back;
                node.back.next = null;
            }
            else
            {
                node.back.next = node.next;
                node.next.back = node.back;
            }
            node = null;
        }
    }
}
