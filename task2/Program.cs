using System;
class Program {
  static void Main() {
    int[] array = { 1, 2, 3, 4, 5, 6};
    SwapHalves(array);

    foreach (int num in array) {
        Console.Write(num + " ");
    }
  }


  public static void SwapHalves(int[] arr)
  {

    int n = arr.Length;
    int mid = n / 2;
    int k = mid;
    if (n % 2 != 0){
        k++;
    }
    for (int i = 0; i < mid; i++)
    {
        int temp = arr[i];
        arr[i] = arr[k + i];
        arr[k + i] = temp;
    }
  }
}