using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {
        public SinglyLinkedList()
        {
            // NOTE: This constructor isn't necessary, once you've implemented the constructor below.
        }

        // READ: http://msdn.microsoft.com/en-us/library/aa691335(v=vs.71).aspx
        public SinglyLinkedList(params object[] values)
        {
            int size = values.Length;
        }

        // READ: http://msdn.microsoft.com/en-us/library/6x16t2tx.aspx
        public string this[int i]
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void AddAfter(string existingValue, string value)
        {
            //SinglyLinkedListNode prevNode = firstNode;
            //SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            //if (this.First() == null)
            //{
            //    throw new ArithmeticException("Node doesn't exist");
            //}
            //else
            //{
            //    while(prevNode != null)
            //    {
            //        if(prevNode.IsLast())
            //        {
            //            AddLast(value);
            //        }
            //        prevNode = prevNode.Next;
            //    }
            //}
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if(this.First() == null)
            {
                newNode.Next = null;
                firstNode = newNode;
                lastNode = newNode;
            }
            else
            {
                newNode.Next = firstNode;
                firstNode = newNode;
            }
        }

        public void AddLast(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (this.First() == null)
            {
                firstNode = newNode;
                lastNode = newNode;
            }
            else if(lastNode.IsLast())
            {
                lastNode.Next = newNode;
            }
            lastNode = newNode;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        public int Count()
        {
            throw new NotImplementedException();
        }

        public string ElementAt(int index)
        {
            if (this.First() == null && index >= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            SinglyLinkedListNode currentNode = firstNode;
            if(index > 0)
            {
                for (int i = 0; i < index; i++)
                {
                    if (currentNode.IsLast())
                    {
                        throw new ArgumentOutOfRangeException("Exceeds list index!");
                    }
                    currentNode = currentNode.Next;
                }
                return currentNode.ToString();
            }
            else if(index < 0) //handling negative index
            {
                SinglyLinkedListNode negNode = firstNode;
                int length = 1;
                while (!negNode.IsLast())
                {
                    length++;
                    negNode = negNode.Next;
                }
                return this.ElementAt(length + index); //Positive index/offset
            }
            return currentNode.ToString();
        }

        private SinglyLinkedListNode firstNode;
        public string First()
        {
            if(firstNode == null)
            {
                return null;
            }
            else
            {
                return firstNode.Value;
            }
        }

        public override string ToString()
        {
            string leftBr = "{";
            string rightBr = "}";
            string comma = ",";
            string space = " ";
            string quote = "\"";
            StringBuilder newList = new StringBuilder(leftBr);
            SinglyLinkedListNode currentNode = firstNode;
            while(currentNode != null)
            {
                newList.Append(space);
                newList.Append(quote);
                newList.Append(currentNode.Value);
                newList.Append(quote);
                if (currentNode.IsLast())
                {
                    break;
                }
                else
                {
                    newList.Append(comma);
                }
                currentNode = currentNode.Next;
            }
            newList.Append(space).Append(rightBr);
            return newList.ToString();
        }

        public int IndexOf(string value)
        {
            if(this.First() == null)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public bool IsSorted()
        {
            throw new NotImplementedException();
        }

        // HINT 1: You can extract this functionality (finding the last item in the list) from a method you've already written!
        // HINT 2: I suggest writing a private helper method LastNode()
        // HINT 3: If you highlight code and right click, you can use the refactor menu to extract a method for you...
        private SinglyLinkedListNode lastNode;
        public string Last()
        {
            SinglyLinkedListNode current = lastNode;
            if (this.First() == null)
            {
                return null;
            }
            while (!current.IsLast())
            {
                current = current.Next;
            }
            return current.Value;
        }

        public void Remove(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string[] ToArray()
        {
            LinkedList<string> sentence = new LinkedList<string>();
            SinglyLinkedListNode currentNode = firstNode;
            if(this.First() == null)
            {
                return sentence.ToArray();
            }
            else if (firstNode.IsLast())
            {
                sentence.AddFirst(firstNode.ToString());
                return sentence.ToArray();
            }
            else
            {
                while(currentNode != null)
                {
                    sentence.AddLast(currentNode.ToString());
                    if (currentNode.IsLast())
                    {
                        break;
                    }
                    currentNode = currentNode.Next;
                }
                return sentence.ToArray();
            }
        }
    }
}
