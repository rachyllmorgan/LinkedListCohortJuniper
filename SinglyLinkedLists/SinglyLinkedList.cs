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
                        newNode = oldNext;
                        prevNode.Next = newNode;

                        found = true;
                        //count++;
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
                    if (node.Next == null)
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
            //SinglyLinkedList nodes = new SinglyLinkedList();
            //if(this.First() == null)
            //{
            //    //empty list
            //}
            //else
            //{
            //    while (!firstNode.IsLast())
            //    {
            //        if (firstNode.IsLast())
            //        {
            //            break;
            //        }
            //        firstNode.CompareTo(firstNode.Next);
            //        nodes.AddFirst(firstNode.Value);
            //    }
            //    firstNode = firstNode.Next;
            //}
            //List<string> sortList = new List<string>(nodes.ToArray());
        }

        public string[] ToArray()
        {
            SinglyLinkedListNode node = firstNode;
            if (node != null)
            {
                string[] answer = new string[Count()];

                for (int i = 0; i < Count(); i++)
                {
                    answer[i] = ElementAt(i);
                }
                return answer;
            }
            else
            {
                return new string[] { };
            }
        }
    }
}