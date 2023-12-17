using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Linked_List_Homework
{
    public class LinkedList
    {
        public Node First { get; set; }

        public void Print()
        {
            Node move = First;
            while (move != null)
            {
                Console.Write(move.Data+"\t");
                move = move.Next;
            }
            Console.WriteLine();
        }

        // methods
        public void Add(int val)
        {
            // TODO: add item to the end of the list
            // consider when the list is empty
            // create a new node with the given data
            Node temp = new Node(val);
            if (First == null) 
            {
                First=temp;
                return;
            }           
            Node move = First;
            while (move.Next!= null)
            {
                move = move.Next;
            }
            move.Next = temp;
        }
        public void RemoveKey(int key)
        {
            // TODO: search for the key and remove it from the list
            // consider when the key does not exist and when the list is empty
            Node temp = First, prev = null;

            if (temp != null && temp.Data == key)
            {
                First = temp.Next;
                return;
            }

            while (temp != null && temp.Data != key)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null) return;

            prev.Next = temp.Next;
        }
        public void Merge(LinkedList other_list)
        {
            // TODO: merge this list with the other list
            Node head1 = this.First;
            Node head2 = other_list.First;

            Node prev = null;

            while (head1 != null && head2 != null)
            {
                if (head1.Data <= head2.Data)
                {
                    prev = head1;
                    head1 = head1.Next;
                }
                else
                {
                    Node next = head2.Next;

                    if (prev != null)
                    {
                        prev.Next = head2;
                    }
                    else
                    {
                        this.First = head2;
                    }

                    head2.Next = head1;
                    prev = head2;

                    head2 = next;
                }
            }

            if (head1 == null && prev != null)
            {
                prev.Next = head2;
            }
        }
        public void Reverse()
        {
            // TODO: revers the nodes of this list
            // initialize three pointers: prev, curr, and next
            Node prev = null;
            Node current = First;
            Node next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            First = prev;
        }
    }
}
