using System;

class Program
{
    class Node<T>
    {
        public Node<T> Previous { get; set; }
        public Node<T> Next { get; set; }
        public T Data { get; set; }
    }

    class Deque<T>
    {
        private Node<T> pbeg;
        private Node<T> pend;
        private int size;

        public void PushBack(T key)
        {
            Node<T> tmp = new Node<T> { Data = key };
            tmp.Next = null;

            if (pend != null && size != 0)
            {
                pend.Next = tmp;
                tmp.Previous = pend;
                pend = tmp;
            }
            else
            {
                tmp.Previous = null;
                pbeg = pend = tmp;
            }

            size++;
        }

        public void PushFront(T key)
        {
            Node<T> tmp = new Node<T> { Data = key };
            tmp.Previous = null;

            if (pbeg != null && size != 0)
            {
                pbeg.Previous = tmp;
                tmp.Next = pbeg;
                pbeg = tmp;
            }
            else
            {
                tmp.Next = null;
                pbeg = pend = tmp;
            }

            size++;
        }

        public void PopFront()
        {
            if (pbeg != null)
            {
                pbeg = pbeg.Next;

                if (pbeg != null)
                    pbeg.Previous = null;

                size--;
            }
        }

        public void PopBack()
        {
            if (pend != null)
            {
                pend = pend.Previous;

                if (pend != null)
                    pend.Next = null;

                size--;
            }
        }

        public T Front()
        {
            return pbeg.Data;
        }

        public T Back()
        {
            return pend.Data;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            while (size != 0)
            {
                PopFront();
            }
        }

        public void Remove(T key)
        {
            Node<T> current = pbeg;

            while (current != null)
            {
                if (current.Data.Equals(key))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                    }
                    else
                    {
                        pbeg = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Previous = current.Previous;
                    }
                    else
                    {
                        pend = current.Previous;
                    }

                    size--;
                    break;
                }

                current = current.Next;
            }
        }
         public int Find(T key)
        {
            Node<T> current = pbeg;
            int index = 0;

            while (current != null)
            {
                if (current.Data.Equals(key))
                {
                    return index;
                }

                current = current.Next;
                index++;
            }

            return -1;
        }

         public void Print()
        {
            Node<T> current = pbeg;

            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Next;
            }

            Console.WriteLine();
        }
    }

   
    static void Main()
    {
        var deque = new Deque<int>();

        string command;
        while ((command = Console.ReadLine()) != "exit")
        {
            string[] parts = command.Split(' ');
            string operation = parts[0];

            switch (operation)
            {
                case "push_back":
                    int value = int.Parse(parts[1]);
                   deque.PushBack(value);
                    Console.WriteLine("ok");
                    break;
                 case "push_front":
                    int n = int.Parse(parts[1]);
                   deque.PushFront(n);
                    Console.WriteLine("ok");
                    break;
                case "pop_back":
                    if (deque.Size() != 0)
                    {
                      Console.WriteLine(deque.Back());
                      deque.PopBack();
                    }
                    else
                    {
                      Console.WriteLine("error");
                    }
                    break;
                case "pop_front":
                    if (deque.Size() != 0)
                    {
                      Console.WriteLine(deque.Front());
                      deque.PopFront();
                    }
                    else
                    {
                      Console.WriteLine("error");
                    }
                    break;
                case "front":
                    if (deque.Size() != 0)
                    {
                        Console.WriteLine(deque.Front());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "back":
                    if (deque.Size() != 0)
                    {
                        Console.WriteLine(deque.Back());
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                case "size":
                    Console.WriteLine(deque.Size());
                    break;
                case "clear":
                    deque.Clear();
                    Console.WriteLine("ok");
                    break;
                case "find":
                    int f = int.Parse(parts[1]);
                    int fi = deque.Find(f);
                    Console.WriteLine(fi);
                    break;
                case "print":
                    deque.Print();
                    break;
                case "remove":
                    int r = int.Parse(parts[1]);
                    deque.Remove(r);
                    Console.WriteLine("ok");
                    break;
                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }

        Console.WriteLine("bye");
    }
}
