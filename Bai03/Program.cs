using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bai03
{
    class Program
    {
        static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) 
                || (year % 400 == 0);
        }
        static bool DateCheck(int date, int month, int year)
        {
            if (year < 0 || month < 1 || month > 12 || date < 1 
                || date > 31)
                return false;
            if (month == 2)
            {
                if (IsLeapYear(year))
                    return date <= 29;
                else
                    return date <= 28;
            }
            if (month == 4 || month == 6 || month == 9 || month == 11)
                return date <= 30;
            return true;
        }
        
        static void Main(string[] args)
        {
            int date, month, year;
            date= int.Parse(Console.ReadLine());
            month= int.Parse(Console.ReadLine());
            year= int.Parse(Console.ReadLine());
            if (DateCheck(date, month, year))
                Console.WriteLine("Valid date");
            else
                Console.WriteLine("Invalid date");
        }
    }
}