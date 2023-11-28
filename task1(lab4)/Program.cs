using System;

public class My2DArray
{
    public static void InputRows(ref int[][] array, string[] rows)
    {
        for (int i = 0; i < array.Length && i < rows.Length; i++) {
            string[] values = rows[i].Split(' ');
            array[i] = new int[values.Length];

            for (int j = 0; j < values.Length; j++)
            {
                if (int.TryParse(values[j], out int number))
                {
                    array[i][j] = number;
                }
                else
                {
                    array[i][j] = 0;
                }
            }
        }
    }

    public static void FindMin(in int[][] array, out int[] minValue)
    {
        minValue = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            minValue[i] = int.MaxValue;
            foreach (int value in array[i])
            {
                if (value < minValue[i])
                {
                    minValue[i] = value;
                }
            }
        }
    }

    public static void FindMax(in int[][] array, out int[] maxValue)
    {
        maxValue = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            maxValue[i] = int.MinValue;
            foreach (int value in array[i])
            {
                if (value > maxValue[i])
                {
                    maxValue[i] = value;
                }
            }
        }
    }

    public static void SumsRows(in int[][] array, out int[] sums)
    {
        sums = new int[array.Length];

        for (int i = 0; i < array.Length; i++)
        {
            int sum = 0;

            foreach (int value in array[i])
            {
                sum += value;
            }

            sums[i] = sum;
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите количество строк:");
        int n = int.Parse(Console.ReadLine());

        int[][] array = new int[n][];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите значения для строки {i}:");
            string[] values = Console.ReadLine().Split(' ');

            array[i] = new int[values.Length];

            for (int j = 0; j < values.Length; j++)
            {
                if (int.TryParse(values[j], out int number))
                {
                    array[i][j] = number;
                }
                else
                {
                    array[i][j] = 0;
                }
            }
        }

        FindMin(array, out int[] minValue);
        FindMax(array, out int[] maxValue);
        SumsRows(array, out int[] sums);

        for (int i = 0; i < minValue.Length; i++)
        {
            Console.WriteLine($"Минимальное значение строки {i}: {minValue[i]}");
        }
        
        for (int i = 0; i < maxValue.Length; i++)
        {
            Console.WriteLine($"Максимальное значение строки {i}: {maxValue[i]}");
        }

        for (int i = 0; i < sums.Length; i++)
        {
            Console.WriteLine($"Сумма элементов строки {i}: {sums[i]}");
        }
    }
}