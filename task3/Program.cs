using System;
class Program {
  static void Main() {
    Console.WriteLine("Введите размер массива:");
    int size = int.Parse(Console.ReadLine());
    int[] arr1 = GetInitializeArray(size);
    int[] arr2 = GetInitializeArray(size);

    Console.WriteLine("Массив 1:");
    PrintArray(arr1);

    Console.WriteLine("Массив 2:");
    PrintArray(arr2);

    if (arr1.Length == arr2.Length)
    {
        int[] sumArray = SummArray(arr1, arr2);
        Console.WriteLine("Сумма массивов:");
        PrintArray(sumArray);
    }

    Console.WriteLine("Введите число для умножения массива:");
    int number = int.Parse(Console.ReadLine());

    int[] multipliedArray = MultiplicationArrayByNumber(arr1, number);
    Console.WriteLine("Умноженный массив:");
    PrintArray(multipliedArray);

    int[] commonValues = FindCommonValues(arr1, arr2);
    Console.WriteLine("Общие значения массивов:");
    PrintArray(commonValues);

    Console.WriteLine("Отсортированный массив:");
    QuickSortOptimized(0, arr1.Length-1, arr1);
    PrintArray(arr1);

    int min = FindMinValue(arr1);
    int max = FindMaxValue(arr2);
    double average = FindAverageValue(arr1);

    Console.WriteLine("Минимальное значение: " + min);
    Console.WriteLine("Максимальное значение: " + max);
    Console.WriteLine("Среднее значение: " + average);
    



  }

  public static int[]  GetInitializeArray(int size ) 
  {
    Random random= new Random();
    int[] newArray = new int[size];
    for(int i =0; i<size; i++){
        newArray[i] = random.Next(25);
    }

    return newArray;

  }
  
 public static int[] SummArray(int[] arr1, int[] arr2)
 {
    int[] resultOfSumArrray = new int[arr1.Length];
    for(int i = 0; i< arr1.Length; i++){
        resultOfSumArrray[i] = arr1[i] + arr2[i];
    } 

    return resultOfSumArrray;
 }

 public  static int[] MultiplicationArrayByNumber(int[] arr, int number)
 {
    int[] resultArray = new int[arr.Length]; 
    for(int i = 0; i< arr.Length; i++){
        resultArray[i] = arr[i]*number;
    }

    return resultArray;
 }

  public  static int[] FindCommonValues(int[] array1, int[] array2)
  {
    int[] commonValues = new int[Math.Min(array1.Length, array2.Length)];
    int index = 0;
    foreach (int value1 in array1)
    {
        foreach (int value2 in array2)
        {
            if (value1 == value2)
            {
                commonValues[index] = value1;
                index++;
                break;
            }
        }
    }
    Array.Resize(ref commonValues, index);
    return commonValues;
  }

  static void QuickSortOptimized(int left, int right, int[] array)
  {
    if (left >= right)
    {
        return;
    }
    int pivotValue = array[right];
    int i = left, j = right - 1;
    int p = left - 1;
    int q = right;
    while (i <= j)
    {
        while (array[i] > pivotValue)
        {
            i++;
        }
        while (j >= 0 && array[j] < pivotValue)
        {
            j--;
        }
        if (i >= j)
        {
            break;
        }
        int temp = array[j];
        array[j] = array[i];
        array[i] = temp;
        if (array[i] == pivotValue)
        {
            p++;
            int tempP = array[i];
            array[i] = array[p];
            array[p] = tempP;
        }
        if (array[j] == pivotValue)
        {
            q--;
            int tempQ = array[j];
            array[j] = array[q];
            array[q] = tempQ;
        }
        j--;
        i++;
    }
    int tempRight = array[right];
    array[right] = array[i];
    array[i] = tempRight;
    j = i - 1;
    i++;
    for (int k = left; k <= p; k++, j--)
    {
        int tempK = array[k];
        array[k] = array[j];
        array[j] = tempK;
    }
    for (int k = right - 1; k >= q; k--, i++)
    {
        int tempK = array[k];
        array[k] = array[i];
        array[i] = tempK;
    }
    QuickSortOptimized(left, j, array);
    QuickSortOptimized(i, right, array);
  }

    static int FindMinValue(int[] array)
    {
        int min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    static int FindMaxValue(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static double FindAverageValue(int[] array)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return (double)sum / array.Length;
    }


  static void PrintArray(int[] array)
  {
    foreach (int value in array)
    {
            Console.Write(value + " ");
    }
        Console.WriteLine();
  }
  
}