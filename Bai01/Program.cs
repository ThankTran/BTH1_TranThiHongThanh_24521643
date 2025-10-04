using System;

namespace Bai01
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number < 1) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
        static bool check(int n)
        {
            if (n < 0) return false;
            int sr = (int)Math.Sqrt(n);
            return (sr * sr == n);
        }
        static void Main(string[] args)
        {
            Random rand = new Random();
            int n;
            n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int sumodd = 0;
            int count = 0;
            int countcp = int.MaxValue;
            
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rand.Next(1, 101);
                Console.Write(numbers[i] + " ");
                if (numbers[i] % 2 != 0)
                    sumodd += numbers[i];
                if (IsPrime(numbers[i])) 
                    count++;
                if (check(numbers[i]) && numbers[i] < countcp) 
                    countcp = numbers[i];
            }
            Console.WriteLine("\nSum of odd numbers: " + sumodd);
            Console.WriteLine("Count of prime numbers: " + count);
            if (countcp == int.MaxValue)
                Console.WriteLine("No perfect square found");
            else
            {
                Console.WriteLine("Smallest perfect square: ");
                Console.WriteLine(countcp);
            }    
                
        }
    }
}