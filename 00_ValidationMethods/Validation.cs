using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_ValidationMethods
{
    public static class Validation
    {
        public static string IntFromStringValidation()
        {
            var intAsString = Console.ReadLine();
            int num1;
            while (!int.TryParse(intAsString, out num1))
            {
                Console.WriteLine("Please enter a valid number");
                intAsString = Console.ReadLine();               
            }
            return intAsString;
        }
        public static string DoubleFromStringValidation()
        {
            var doubleAsString = Console.ReadLine();
            double num1;
            while (!double.TryParse(doubleAsString, out num1))
            {
                Console.WriteLine("Please enter a valid number");
                doubleAsString = Console.ReadLine();
            }
            return doubleAsString;
        }

        public static string DateFromStringValidation()
        {
            var dateAsString = Console.ReadLine();
            DateTime date1;
            while (!DateTime.TryParse(dateAsString, out date1))
            {
                Console.WriteLine("Please enter a valid date");
                dateAsString = Console.ReadLine();
            }
            return dateAsString;
        }
    }
}
