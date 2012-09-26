
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public class Node<T>
    {
        public T element;
        public Node<T> next;
        public Node<T> previous;

        public Node(T element)
        {
            this.element = element;
        }

        public Node(T element, Node<T> previous, Node<T> next)
        {
            this.element = element;
            setprev(previous);
            setnext(next);
        }

        public Node<T> getprev()
        {
            return previous;
        }

        public Node<T> getnext()
        {
            return next;
        }

        public T getelement()
        {
            return element;
        }

        public void setprev(Node<T> previous)
        {
            this.previous = previous;
        }

        public void setnext(Node<T> next)
        {
            this.next = next;
        }
    }

    public class DoubleLinkedList<T>
    {
        public Node<T> head = new Node<T>(default(T));

        public Node<T> tail = new Node<T>(default(T));
        public int length = 0;

        public void initList()
        {
            head.setprev(null);
            head.setnext(tail);
            tail.setnext(null);
            tail.setprev(head);
        }


        public int Count
        {
            get { return length; }
        }

        public T First
        {
            get
            {
                if (length == 0)
                {
                    throw InvalidOperationException();
                }
                else
                {

                    Node<T> cursor = head;
                    cursor = cursor.getnext();
                    return cursor.getelement();
                }
            }
        }

        public Exception InvalidOperationException()
        {
            throw new NotImplementedException();
        }

        public T Last
        {
            get
            {
                if (length == 0)
                {
                    throw InvalidOperationException();
                }
                else
                {
                    Node<T> cursor = tail;
                    cursor = cursor.getprev();
                    return cursor.getelement();
                }
            }
        }

        public void AddFirst(T element)
        {
            Node<T> cursor = head;
            Node<T> newNode = new Node<T>(element);
            newNode.setprev(cursor);
            newNode.setnext(cursor.getnext());
            cursor.setnext(newNode);
            cursor.getnext().setprev(newNode);
            length++;
        }

        public void AddLast(T element)
        {
            Node<T> cursor = tail;
            Node<T> newNode = new Node<T>(element);
            newNode.setnext(cursor);
            newNode.setprev(cursor.getprev());
            cursor.setprev(newNode);
            cursor.getprev().setnext(newNode);
            length++;
        }

        public T RemoveFirst()
        {
            if (length == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Node<T> cursor = head;
                Node<T> result = cursor.getnext();
                result.getnext().setprev(result.getprev());
                result.getprev().setnext(result.getnext());
                length--;
                return result.getelement();
            }
        }

        public T RemoveLast()
        {
            if (length == 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                Node<T> cursor = tail;
                Node<T> result = cursor.getprev();
                result.getnext().setprev(result.getprev());
                result.getprev().setnext(result.getnext());
                length--;
                return result.getelement();
            }
        }

        public bool Remove(T element)
        {
            Node<T> cursor = tail;
            int index = length;
            bool retValue = false;
            for (int i = 0; i < index; i++)
            {

                cursor = cursor.getnext();
                if (EqualityComparer<T>.Default.Equals(cursor.getelement(), (element)))
                {
                    cursor.getnext().setprev(cursor.getprev());
                    cursor.getprev().setnext(cursor.getnext());
                    length--;
                    retValue = true;
                    break;
                }
            }
            return retValue;

        }

        public int RemoveAll(T element)
        {
            Node<T> cursor = tail;
            int index = length;
            int number = 0;
            for (int i = 0; i < index; i++)
            {
                cursor = cursor.getnext();
                if (EqualityComparer<T>.Default.Equals(cursor.getelement(), (element)))
                {
                    cursor.getnext().setprev(cursor.getprev());
                    cursor.getprev().setnext(cursor.getnext());
                    length--;
                    number++;
                }
            }
            return number;
        }

        public void Clear()
        {
            Node<T> cursor = tail;
            int index = length;
            for (int i = 0; i < index; i++)
            {
                cursor = cursor.getnext();
                cursor.getnext().setprev(cursor.getprev());
                cursor.getprev().setnext(cursor.getnext());
                length--;
            }

        }
    }
    class mainprogram
    {
        public static void Main(string[] args)
        {
            DoubleLinkedList<string> newList = new DoubleLinkedList<string>();
            newList.initList();
            newList.AddFirst("Prashanth");
            newList.AddLast("Eugene");
            newList.AddLast("David");
            newList.AddLast("Tom");
            newList.RemoveLast();
            Console.WriteLine(newList.First);
            Console.WriteLine(newList.Last);
            Console.WriteLine(newList.Count);
            Console.ReadLine();
        }
    }
}