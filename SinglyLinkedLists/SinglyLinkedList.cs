using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SinglyLinkedLists
{
    public class SinglyLinkedList
    {

        public SinglyLinkedList(params object[] values)
        {
            count = 0;

            for (int i = 0; i < values.Length; i++)
            {
                AddLast(values[i].ToString());
            }
        }

        public string this[int i]
        {
            get { return ElementAt(i); }
            set { NodeAt(i).Value = value; }
        }

        public void AddAfter(string existingValue, string value)
        {
            if (ElementAt(-1) == existingValue)
            {
                AddLast(value);
            }
            else
            {
                SinglyLinkedListNode prevNode = firstNode;
                bool found = false;
                while (!prevNode.IsLast())
                {
                    if (prevNode.Value == existingValue)
                    {
                        SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
                        SinglyLinkedListNode oldNext = prevNode.Next;
                        newNode.Next = oldNext;
                        prevNode.Next = newNode;

                        found = true;
                        count++;
                        break;
                    }
                    prevNode = prevNode.Next;
                }

                if (!found)
                {
                    throw new ArgumentException();
                }
            }
        }

        public void AddFirst(string value)
        {
            SinglyLinkedListNode newNode = new SinglyLinkedListNode(value);
            if (this.First() == null)
            {
                AddLast(value);
            }
            else
            {
                newNode.Next = firstNode;
                firstNode = newNode;
                count++;
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
            else
            {
                while (lastNode.IsLast())
                {
                    lastNode.Next = newNode;
                }
                lastNode = newNode;
            }
            count++;
        }

        // NOTE: There is more than one way to accomplish this.  One is O(n).  The other is O(1).
        private int count;
        public int Count()
        {
            return count;
        }

        private SinglyLinkedListNode NodeAt(int index)
        {
            if (firstNode != null && index >= 0)
            {
                SinglyLinkedListNode node = firstNode;
                for (int i = 0; i <= index; i++)
                {
                    if (index == i)
                    {
                        break;
                    }
                    if (node.IsLast())
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    node = node.Next;
                }

                return node;
            }
            else if (index < 0)
            {
                return this.NodeAt(Count() + index); //Positive index/offset
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public string ElementAt(int index)
        {
            return NodeAt(index).Value;
        }

        private SinglyLinkedListNode firstNode;
        public string First()
        {
            if (firstNode == null)
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
            while (currentNode != null)
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
            SinglyLinkedListNode current_node = firstNode;
            int position = 0;
            bool found = false;
            if (firstNode == null)
            {
                position = -1;
            }
            else
            {
                //position++;
                while (current_node != null)
                {
                    if (value == current_node.Value)
                    {
                        found = true;
                        break;
                    }
                    current_node = current_node.Next;
                    position++;
                }
                if (!found)
                {
                    position = -1;
                }
            }
            return position;
        }

        public bool IsSorted()
        {
            if(firstNode == null || firstNode.Next == null)
            {
                return true;
            }

            SinglyLinkedListNode left = firstNode;
            SinglyLinkedListNode right = firstNode.Next;
            while (right != null)
            {
                if (left > right)
                {
                    return false;
                }
                left = right;
                right = left.Next;
            }
            return true;
        }

        private SinglyLinkedListNode lastNode;
        public string Last()
        {
            SinglyLinkedListNode current = lastNode;
            if (this.First() == null)
            {
                return null;
            }
            else
            {
                return this.ElementAt(-1);
            }
        }

        public void Remove(string value)
        {
            int position = IndexOf(value);

            if (position >= 0)
            {
                if (position == 0)
                {
                    firstNode = firstNode.Next;
                }
                else if (position >= 1 && !NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = NodeAt(position + 1);
                }
                else if (NodeAt(position).IsLast())
                {
                    NodeAt(position - 1).Next = null;
                }
                count--;
            }
        }

        public void Sort()
        {
            while (!IsSorted())
            {
                SinglyLinkedListNode left = firstNode;
                SinglyLinkedListNode right = firstNode.Next;
                while (right != null)
                {
                    if (left > right)
                    {
                        string value = left.Value;
                        left.Value = right.Value;
                        right.Value = value;
                        //swap them
                    }
                    left = right;
                    right = left.Next;
                }
            }
        }

        public string[] ToArray()
        {
            LinkedList<string> sentence = new LinkedList<string>();
            SinglyLinkedListNode currentNode = firstNode;

            if (this.First() == null)
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
                while (currentNode != null)
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