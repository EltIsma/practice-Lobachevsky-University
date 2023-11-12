using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string text = Console.ReadLine();
        bool isBalanced = CheckBrackets(text, out int extraLeftCount, out int extraRightPosition);

        if (isBalanced)
        {
            Console.WriteLine("да");
        }
        else
        {
            if (extraLeftCount > 0)
            {
                Console.WriteLine($"нет,  количество лишних левых {extraLeftCount}");
            }
            else
            {
                Console.WriteLine($"нет, лишняя правая скобка на позиции {extraRightPosition}");
            }
        }
    }

    static bool CheckBrackets(string text, out int extraLeftCount, out int extraRightPosition)
    {
        //Stack<int> leftBrackets = new Stack<int>();
        Stack leftBrackets = new Stack(100);
        extraLeftCount = 0;
        extraRightPosition = -1;

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            if (ch == '(')
            {
                leftBrackets.Push(i);
            }
            else if (ch == ')')
            {
                if (leftBrackets.Size() == 0)
                {
                    extraRightPosition = i;
                    return false;
                }

                leftBrackets.Pop();
            }
        }

        extraLeftCount = leftBrackets.Size();
        return leftBrackets.Size() == 0;
    }
}


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
      //  Console.WriteLine("ok");
    }

    public void Pop()
    {
        if (head != null)
        {
            Node tmp = head;
            //Console.WriteLine(tmp.Val);
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

    public int Size()
    {
        /*int stackSize = 0;
        Node current = head;
        while (current != null)
        {
            stackSize++;
            current = current.Prev;
        }
        return stackSize;*/
      return top+1;
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