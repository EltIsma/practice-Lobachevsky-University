using System;

public class MyArrayInteger
{
    private int[] array;

    public MyArrayInteger(in int size)
    {
        array = new int[size];
    }

    public void InputData(int[] values)
    {
        if (values.Length > array.Length)
        {
            throw new ArgumentOutOfRangeException();
        }
        for (int i = 0; i < values.Length; i++)
        {
            
            array[i] = values[i];
        }
    }

    public void InputDataRandom()
    {
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(100);
        }
    }

    public void Print(ref int start, ref int end)
    {
        if (end < start) (start, end) = (end, start);
        if (start < 0 || end > array.Length - 1) throw new ArgumentOutOfRangeException();
        for (int i = start; i <= end; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }

    public void FindValue(in int value, out List<int> indices)
    {
        indices = new List<int>();

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                indices.Add(i);
            }
        }
    }

    public void Resize(in int newSize)
    {
        if(newSize < 0) { throw new InvalidOperationException(); }
        int[] temp = new int[newSize];
        for (int i = 0; i < newSize; i++)
        {
            temp[i] = array[i];
        }
        array = temp;
    }

    public void DeleteValue(in int value)
    {
        FindValue(value, out List<int> indices);

        for (int i = indices.Count - 1; i > -1; i--)
        {
            int index = indices[i];
            for (int j = index; j < array.Length - 1; j++)
            {
                array[j] = array[j + 1];
            }
        }

        if (indices.Count > 0) { Resize(array.Length - indices.Count); }
    }

    public void FindMax(out int max)
    {
        max = int.MinValue;

        foreach (int value in array)
        {
            if (value > max)
            {
                max = value;
            }
        }
    }

    public void Add(in MyArrayInteger secondArray)
    {
        if (array.Length != secondArray.array.Length)
        {
            throw new ArgumentException("Размеры массивов должны быть одинаковыми");
        }

        for (int i = 0; i < array.Length; i++)
        {
            array[i] += secondArray.array[i];
        }
    }

    private void Swap(ref int value1, ref int value2)
    {
        int temp = value1;
        value1 = value2;
        value2 = temp;
    }

    private int FindPivot(int minIndex, int maxIndex)
    {
        int pivot = minIndex - 1;
        for (int i = minIndex; i < maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                Swap(ref array[pivot], ref array[i]);
            }
        }
        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);
        return pivot;
    }

    public void Sort(in int minIndex, in int maxIndex)
    {
        if (minIndex >= maxIndex) return;

        int pivot = FindPivot(minIndex, maxIndex);
        Sort(minIndex, pivot - 1);
        Sort(pivot + 1, maxIndex);

        return; 
    }

    public int GetValue(in int index) {
        if (index > array.Length - 1 || index < 0) { throw new IndexOutOfRangeException(); }
        return array[index]; 
    }

    public int this[int index]
    {
        get => array[index];
    }

    public int GetLenght() { return array.Length; }

    static void MenuInputArr(ref MyArrayInteger array)
    {
        bool ArrIsEmpty = true;
        while (ArrIsEmpty)
        {
            Console.WriteLine("Выберете способ задания элементов массива:\n" +
            "1) Пользовательские\n" +
            "2) Рандомные");
            string method = Console.ReadLine();
            switch (method)
            {
                case "1":
                    Console.WriteLine("Введите значения массива через пробел: ");
                    int[] input = Console.ReadLine().Split(' ').Select(it => Convert.ToInt32(it)).ToArray();
                    array.InputData(input);
                    ArrIsEmpty = false;
                    break;
                case "2":
                    array.InputDataRandom();
                    ArrIsEmpty = false;
                    break;
                default:
                    Console.WriteLine("Выберете корректный пункт меню");
                    break;
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите количество элементов массива:");
        int n = int.Parse(Console.ReadLine());
        MyArrayInteger myArray = new MyArrayInteger(n);

        MenuInputArr(ref myArray);

        bool end = false;
        while (!end)
        {
            Console.WriteLine("Выберете операцию над массивом\n" +
                "1) Print\n" +
                "2) FindValue\n" +
                "3) DeleteValue\n" +
                "4) FindMax\n" +
                "5) Add\n" +
                "6) Sort\n" +
                "0) Выход");

            string method = Console.ReadLine();
            switch (method)
            {
                case "1":
                    int startInd, endInd;
                    Console.WriteLine("Укажите диапазон массива");

                    Console.Write("Индекс первого элемента: ");
                    startInd = int.Parse(Console.ReadLine());

                    Console.Write("Индекс последнего элемента: ");
                    endInd = int.Parse(Console.ReadLine());

                    myArray.Print(ref startInd, ref endInd);
                    break;
                case "2":
                    Console.Write("Укажите элемент для поиска: ");
                    int valueToFind = int.Parse(Console.ReadLine());

                    myArray.FindValue(valueToFind, out List<int> indices);
                    if (indices.Count == 0)
                    {
                        Console.WriteLine("Данный элемент не содержится в массиве");
                        break;
                    }
                    Console.Write($"Элемент {valueToFind} содержится под индексами: ");
                    Console.WriteLine(string.Join(", ", indices));
                    break;
                case "3":
                    Console.WriteLine("Укажите элемент для удаления: ");
                    int valueToDelete = int.Parse(Console.ReadLine());

                    myArray.DeleteValue(valueToDelete);
                    break;
                case "4":
                    myArray.FindMax(out int max);
                    Console.WriteLine($"Максимальный элемент в массиве: {max}");
                    break;
                case "5":
                    Console.WriteLine("Создайте второй массив");
                    MyArrayInteger secondArray = new MyArrayInteger(myArray.GetLenght());
                    MenuInputArr(ref secondArray);

                    myArray.Add(secondArray);
                    Console.Write("Результат сложения двух массивов: ");
                    startInd = 0;
                    endInd = myArray.GetLenght() - 1;
                    myArray.Print(ref startInd, ref endInd);
                    break;
                case "6":
                    startInd = 0;
                    endInd = myArray.GetLenght() - 1;
                    myArray.Sort(startInd, endInd);

                    Console.Write("Результат сортировки массива: ");
                    myArray.Print(ref startInd, ref endInd);
                    break;
                case "0":
                    end = true;
                    break;
                default: 
                    Console.WriteLine("Введите корректный пункт меню");
                    break;
            }
        }
    }
}
