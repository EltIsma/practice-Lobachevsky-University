
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] elements = { 6, 7, 8 };
            int position = 2;

           // InsertElements(ref array, elements, position);
          int[] res = InsertElements( array, elements, position);

            foreach (int num in res)
            {
                Console.Write(num + " ");
            }

        }

       /* public static void InsertElements(ref int[] array, int[] elements, int position)
        {
            Array.Resize(ref array, array.Length + elements.Length);
            Array.Copy(array, position, array, position + elements.Length, array.Length - position - elements.Length);
            Array.Copy(elements, 0, array, position, elements.Length);
        }*/
    static int[] InsertElements(int[] array, int[] newElements, int k)
    {
        int length = array.Length;
        int newLength = length + newElements.Length;

        int[] result = new int[newLength];

        
        for (int i = 0; i < k; i++)
        {
            result[i] = array[i];
        }

        
        int newIndex = k;
        for (int i = 0; i < newElements.Length; i++)
        {
            result[newIndex] = newElements[i];
            newIndex++;
        }

    
        for (int i = k; i < length; i++)
        {
            result[newIndex] = array[i];
            newIndex++;
        }

        return result;
    }

    }
}