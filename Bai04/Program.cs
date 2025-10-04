using System;

namespace Bai04
{
    class Program
    {
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) 
                || (year % 400 == 0);
        }

        static int DaysInMonth(int month, int year)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException
                    ("Month must be between 1 and 12.");
            if (year < 1)
                throw new ArgumentOutOfRangeException
                    ("Year must be greater than 0.");

            if (month == 4 || month == 6 || month == 9 
                || month == 11)
                return 30;
            else if (month == 2)
                return IsLeapYear(year) ? 29 : 28;
            else
                return 31;
        }

        static void Main(string[] args)
        {
            int month, year;
            try
            {
                // Console.WriteLine("Enter the month: ");
                month = int.Parse(Console.ReadLine());
                // Console.WriteLine("Enter the year: ");
                year = int.Parse(Console.ReadLine());
                Console.WriteLine("Date of month: " 
                    + DaysInMonth(month, year));
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (FormatException)
            {
                Console.Write("Error: Invalid month and year.");
            }

        }
    }
}