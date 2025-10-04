using System;

namespace Bai06
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
        static void Outputbcd(int n, int m, int[] numbers)
        {
            int maxsumrow = int.MinValue;
            int sumnotprime = 0;
            for (int i = 0; i < n; i++)
            {
                int sumrow = 0;
                for (int j = 0; j < m; j++)
                {
                    int idx = i * m + j;
                    sumrow += numbers[idx];
                    if (!IsPrime(numbers[idx])) 
                        sumnotprime += numbers[idx];
                }
                if (sumrow > maxsumrow) 
                    maxsumrow = sumrow;
            }
            int length = numbers.Length;
            int maxnum = int.MinValue;
            int minnum = int.MaxValue;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] > maxnum) 
                    maxnum = numbers[i];
                if (numbers[i] < minnum) 
                    minnum = numbers[i];
            }
            Console.WriteLine
                ("Max number in matrix is: " + maxnum);
            Console.WriteLine
                ("Min number in matrix is: " + minnum);
            Console.WriteLine
                ("Sum of row that has max value: " + maxsumrow);
            Console.WriteLine
                ("Sum of NonPrime: " + sumnotprime);
        }

        static int[] Eraserow(int n, int m, int[] numbers, int k)
        {
            if (k < 0 || k >= n)
            {
                Console.WriteLine("Invalid row index.");
                return numbers;
            }

            int[] array = new int[(n - 1) * m];
            int z = 0;

            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                {
                    array[z * m + j] = numbers[i * m + j];
                    Console.Write(array[z * m + j] + " ");
                }
                z++;
                Console.WriteLine();
            }

            return array;
        }

        static int[] Erasecol(int n, int m, int[] numbers, int k)
        {
            if (k < 0 || k >= m)
            {
                Console.WriteLine("Invalid column index.");
                return numbers;
            }
            int[] array = new int[n * (m - 1)];
            int z = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == k) continue;
                    int newColIndex;
                    if (j < k)
                        newColIndex = j;
                    else
                        newColIndex = j - 1;

                    int oldIndex = i * m + j;
                    int newIndex = z * (m - 1) + newColIndex;

                    array[newIndex] = numbers[oldIndex];
                    Console.Write(array[newIndex] + " ");

                }
                z++;
                Console.WriteLine();
            }
            return array;
        }

        static int maxnum(int n, int m, int[] numbers)
        {
            int maxnum = int.MinValue;
            int maxnumid = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int idx = i * m + j;
                    if (numbers[idx] > maxnum)
                    {
                        maxnum = numbers[idx];
                        maxnumid = idx;
                    }
                }
            }
            return maxnumid;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            Random rand = new Random();
            int[] numbers = new int[m * n];
            Console.WriteLine("Output Matrix: ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int idx = i * m + j;
                    numbers[idx] = rand.Next(1, 101);
                    Console.Write(numbers[idx] + " ");
                }
                Console.WriteLine();
            }

            Outputbcd(n, m, numbers);

            Console.Write("\nEnter row index to erase: ");
            int k = int.Parse(Console.ReadLine());
            Console.WriteLine($"Matrix after erasing row {k}:");
            int[] newMatrix = Eraserow(n, m, numbers, k);

            int idr = maxnum(n, m, numbers) / m;
            int idc = maxnum(n, m, numbers) % m;
            Console.WriteLine
                ($"\nMatrix after erasing row having max num:");
            Eraserow(n, m, numbers, idr);

            Console.WriteLine
                ($"\nMatrix after erasing column having max num:");
            Erasecol(n, m, numbers, idc);
        }
    }
}