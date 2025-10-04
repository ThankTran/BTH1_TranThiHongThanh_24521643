using System;

namespace Bai05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter day: ");
            if (!int.TryParse(Console.ReadLine(), out int day)) 
            { 
                Console.WriteLine("Invalid input."); 
                return; 
            }

            Console.Write("Enter month: ");
            if (!int.TryParse(Console.ReadLine(), out int month)) 
            { 
                Console.WriteLine("Invalid input."); 
                return; 
            }

            Console.Write("Enter year: ");
            if (!int.TryParse(Console.ReadLine(), out int year)) 
            { 
                Console.WriteLine("Invalid input."); 
                return; 
            }

            try
            {
                DateTime dt = new DateTime(year, month, day);
                Console.WriteLine($"{dt:dd/MM/yyyy} is a " 
                    + $"{dt.DayOfWeek}.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Invalid date.");
            }
        }

    }
}