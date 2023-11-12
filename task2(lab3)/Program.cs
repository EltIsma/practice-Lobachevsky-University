using System;

class QueueProgram
{
    static void Main()
    {
        CustomQueue queue = new CustomQueue();

        string command;
        while ((command = Console.ReadLine()) != "exit")
        {
            string[] parts = command.Split(' ');
            string operation = parts[0];

            switch (operation)
            {
                case "push":
                    int value = int.Parse(parts[1]);
                    queue.Push(value);
                    Console.WriteLine("ok");
                    break;
                case "pop":
                    queue.Pop();
                    break;
                case "front":
                    queue.Front();
                    break;
                case "size":
                    Console.WriteLine(queue.Size());
                    break;
                case "clear":
                    queue.Clear();
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

class CustomQueue
{
    private QueueNode head;
    private QueueNode tail;
    private int size;

    public CustomQueue()
    {
        head = null;
        tail = null;
        size = 0;
    }

    public void Push(int value)
    {
        QueueNode newNode = new QueueNode(value);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }

        size++;
    }

    public void Pop()
    {
        if (head == null){
            Console.WriteLine("Stack Underflow");
            return; 
        }

        int poppedValue = head.Value;
        head = head.Next;
        size--;

        if (head == null)
            tail = null;

         Console.WriteLine(poppedValue);
    }

    public void Front()
    {
        if (head == null){
             Console.WriteLine("Stack Underflow");
            return; 
        }

        Console.WriteLine(head.Value);
    }

    public int Size()
    {
        return size;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        size = 0;
    }

    private class QueueNode
    {
        public int Value { get; }
        public QueueNode Next { get; set; }

        public QueueNode(int value)
        {
            Value = value;
            Next = null;
        }
    }
}
