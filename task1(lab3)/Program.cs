using System;

/*class Stack
{
    private int[] stackArray;
    private int top;
    private int size;

    public Stack(int stackSize)
    {
        size = stackSize;
        stackArray = new int[size];
        top = -1;
    }

    public void Push(int item)
    {
        if (top == size - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }

        stackArray[++top] = item;
        Console.WriteLine("ok");
    }

    public void Pop()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack Underflow");
            return;
        }

        Console.WriteLine(stackArray[top--]);
    }

    public void Peek()
    {
        if (top == -1)
        {
            Console.WriteLine("Stack is empty");
            return;
        }

        Console.WriteLine(stackArray[top]);
    }

    public void Size()
    {
        Console.WriteLine(top + 1);
    }

    public void Clear()
    {
        top = -1;
        Console.WriteLine("ok");
    }
}*/

using System;

public class Node
{
    public int Val { get; set; }
    public Node Prev { get; set; }
}

public class Stack
{
    private Node head;
    private int size;
    private int top;
    public Stack(int stackSize)
    {
        size = stackSize;
        top = -1;
    }

    public void Push(int data)
    {
         if (top == size - 1)
        {
            Console.WriteLine("Stack Overflow");
            return;
        }
        Node node = new Node { Val = data, Prev = head };
        head = node;
        top ++;
        Console.WriteLine("ok");
    }

    public void Pop()
    {
        if (head != null)
        {
            Node tmp = head;
            Console.WriteLine(tmp.Val);
            head = head.Prev;
            tmp = null;
            top--;
        } else 
        {
            Console.WriteLine("Stack Underflow");
            return;
        }
    }

    public void Peek()
    {
        if (head != null)
        {
             Console.WriteLine(head.Val);
        } else 
        {
            Console.WriteLine("Stack Underflow");
            return;
        }
       
    }

    public void Size()
    {
        /*int stackSize = 0;
        Node current = head;
        while (current != null)
        {
            stackSize++;
            current = current.Prev;
        }
        return stackSize;*/
       Console.WriteLine(top + 1);
    }

    public void Clear()
    {
        while (head != null)
        {
            Pop();
        }
         Console.WriteLine("ok");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Stack stack = new Stack(100);

        while (true)
        {
            string[] command = Console.ReadLine().Split();
            if (command[0] == "push")
            {
                int item = int.Parse(command[1]);
                stack.Push(item);
            }
            else if (command[0] == "pop")
            {
                stack.Pop();
            }
            else if (command[0] == "back")
            {
                stack.Peek();
            }
            else if (command[0] == "size")
            {
                stack.Size();
            }
            else if (command[0] == "clear")
            {
                stack.Clear();
            }
            else if (command[0] == "exit")
            {
                Console.WriteLine("Bye");
                break;
            }
        }
    }
}
