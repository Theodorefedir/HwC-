using System.Text;

namespace hw1
{
    internal class Program
    {
        static void PrintArr(int[] arr) {
            for (int i = 0; i < arr.Length; i++) { 
                Console.Write(arr[i]);
            }
        }

        static int Sum2D(int[,] arr2d)
        {
            int sum = 0;
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for (int j = 0; j < arr2d.GetLength(1); j++)
                {
                    sum += arr2d[i, j];
                }
            }
            return sum;
        }

        static int findMin2D(int[,] arr2d) { 
            int min = arr2d[0, 0];
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for (int j = 1; j < arr2d.GetLength(1); j++)
                {
                    if (arr2d[i, j] < min) { 
                        min = arr2d[i, j];
                    }
                }
            }
            return min;
        }

        static int findMax2D(int[,] arr2d)
        {
            int max = arr2d[0, 0];
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for (int j = 1; j < arr2d.GetLength(1); j++)
                {
                    if (arr2d[i, j] > max)
                    {
                        max = arr2d[i, j];
                    }
                }
            }
            return max;
        }

        static int Sum(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }

        static int findMin(int[] arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }
            return min;
        }

        static int findMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        static int SumEvenElements(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    sum += arr[i];
                }
            }
            return sum;
        }

        static int SumOddColumns(int[,] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (j % 2 != 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }
            return sum;
        }

        static void FindMinIndex(int[,] arr, out int minRow, out int minCol)
        {
            minRow = 0;
            minCol = 0;
            int minValue = arr[0, 0];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] < minValue)
                    {
                        minValue = arr[i, j];
                        minRow = i;
                        minCol = j;
                    }
                }
            }
        }

        static void FindMaxIndex(int[,] arr, out int maxRow, out int maxCol)
        {
            maxRow = 0;
            maxCol = 0;
            int maxValue = arr[0, 0];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (arr[i, j] > maxValue)
                    {
                        maxValue = arr[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }
        }

        static int SumAmong(int[,] arr, int minRow, int minCol, int maxRow, int maxCol)
        {
            int sum = 0;
            int minPos = minRow * 5 + minCol;
            int maxPos = maxRow * 5 + maxCol;

            int start = Math.Min(minPos, maxPos);
            int end = Math.Max(minPos, maxPos);
            for (int pos = start + 1; pos < end; pos++)
            {
                int row = pos / 5;
                int col = pos % 5;
                sum += arr[row, col];
            }
            return sum;
        }

        static string CaesarCipher(string text, int n)
        {
            text = text.ToLower();
            StringBuilder result = new StringBuilder();
            foreach (char c in text) 
            {
                if (char.IsLetter(c)) {
                    int asciiCode = (int)c;
                    int newAsciiCode = (asciiCode - 97 + n) % 26 + 97;
                    char newChar = (char)newAsciiCode;
                    result.Append(newChar);
                }
                else {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        static int CountDifference(int[] arr) {
            int min = arr.Min();
            int count = 0;
            foreach (int el in arr)
            {
                if (el == min + 5)
                    count++;
            }

            return count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] A = new int[5];
            int[,] B = new int[3, 4];

            for (int i = 0; i < A.Length; i++) { 
                Console.Write($"enter number {i+1}: ");
                A[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Arr2D: ");
            for (int i = 0; i < B.GetLength(0); i++) {
                for (int j = 0; j < B.GetLength(1); j++) {
                    B[i, j] = Random.Shared.Next(-100, 100);
                    Console.Write($"{B[i, j]} ");
                }
                Console.WriteLine();
                
            }
            Console.WriteLine("");
            Console.WriteLine("Simple arr:");
            PrintArr(A);
            Console.WriteLine("");
            Console.WriteLine($"Simple Sum: {Sum(A)}");            
            Console.WriteLine($"Simple Min: {findMin(A)}");            
            Console.WriteLine($"Simple Max: {findMax(A)}");
            Console.WriteLine($"Sum2D: {Sum2D(B)}");            
            Console.WriteLine($"Min2D: {findMin2D(B)}");            
            Console.WriteLine($"Max2D: {findMax2D(B)}");
            Console.WriteLine(SumEvenElements(A));
            Console.WriteLine(SumOddColumns(B));

            //task 2

            int[,] arr2d = new int[5, 5];
            for (int i = 0; i < arr2d.GetLength(0); i++)
            {
                for (int j = 0; j < arr2d.GetLength(1); j++)
                {
                    arr2d[i, j] = Random.Shared.Next(-100, 100);
                }
            }
            FindMinIndex(arr2d, out int minRow, out int minCol);
            FindMaxIndex(arr2d, out int maxRow, out int maxCol);
            Console.WriteLine("Sum Among");
            Console.WriteLine(SumAmong(arr2d, minRow, minCol, maxRow, maxCol));
            Console.WriteLine($"Caesar Cipher: {CaesarCipher("text", 4)}");

            //task 3
            Console.WriteLine(CountDifference(A));


        }
    }
}
