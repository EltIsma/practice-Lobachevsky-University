using System;

class Program
{
    static void Main(string[] args)
    {
        
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

       
        int[,] seats = new int[n, m];

       
        for (int i = 0; i < n; i++)
        {
            string[] row = Console.ReadLine().Split();
            for (int j = 0; j < m; j++)
            {
                seats[i, j] = int.Parse(row[j]);
            }
        }

        
        int k = int.Parse(Console.ReadLine());

      
        for (int i = 0; i < n; i++)
        {
            int consecutiveSeats = 0;

            for (int j = 0; j < m; j++)
            {
                if (seats[i, j] == 0) 
                {
                    consecutiveSeats++; 
                }
                else
                {
                    consecutiveSeats = 0; 
                }

                if (consecutiveSeats == k) 
                {
                    Console.WriteLine(i + 1); 
                    return;
                }
            }
        }

        Console.WriteLine(0); 
    }
}
