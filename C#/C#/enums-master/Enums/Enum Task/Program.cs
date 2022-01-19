using System;

namespace Enum_Task
{
    public static class Program
    {
        /// <summary>
        /// Start point of the program
        /// </summary>
        static void Main()
        {
            bool temp = true;

            while(temp)
            {
                Console.WriteLine("Press 1 to work with months enum\n" +
                    "Press 2 to work with colors enum\n" +
                    "Press 3 to work with enum of Long values\n" +
                    "Press 4 to quit\n");
                int.TryParse(Console.ReadLine(), out int num);
                switch(num)
                {
                    case 1:
                        Console.WriteLine("Enter number of month");
                        int.TryParse(Console.ReadLine(), out num);
                        ShowMonth(num);
                        break;
                    case 2:
                        Console.WriteLine("Sorted enum of months");
                        ColorsSort();
                        break;
                    case 3:
                        GetLongRangeValues();
                        break;
                    case 4:
                        temp = false;
                        break;
                    default:
                        Console.WriteLine("You have entered wrong number. Try again");
                        Console.Clear();
                        break;
                }
            }
        }

        /// <summary>
        /// Show element from Months enum
        /// </summary>
        /// <param name="n">Number of element (starts from 1)</param>
        public static void ShowMonth(int n)
        {
            if (n > 0 && n <= 12)
                Console.WriteLine(Enum.GetName(typeof(Months), n - 1));
            else
                throw new ArgumentOutOfRangeException($"{nameof(n)} must be bigger then 0 and smaller then 13");
        }

        /// <summary>
        /// Print sorted enum Colors by value
        /// </summary>
        public static void ColorsSort()
        {
            foreach(var el in Enum.GetValues(typeof(Colors)))
            {
                Console.WriteLine(Convert.ToString(el) + " = " + Convert.ToInt32( el));
            }
        }

        /// <summary>
        /// Print name and value of element in LongRange enum
        /// </summary>
        public static void GetLongRangeValues()
        {
            foreach(var el in Enum.GetValues(typeof(LongRange)))
            {
                Console.WriteLine(Convert.ToString(el) + " value is: " + Convert.ToInt64(el));
            }
        }
    }
}