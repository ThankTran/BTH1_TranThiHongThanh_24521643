using System;

namespace Bai02
{
    class Program
    {
        static bool IsPrime(int number)
        {
            if (number <= 1) 
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) 
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
                if (IsPrime(i)) sum += i;
            Console.WriteLine(sum);
        }
    }
}