using System;
using System.Collections.Generic;

namespace Function
{
    public enum SortOrder { Ascending, Descending }
    public static class Function
    {
        public static bool IsSorted(int[] array, SortOrder order)
        {
            bool result = true;
            for (int index = 0; index < array.Length; index++)
            {
                if (index != array.Length - 1)
                {
                    if (array[index] > array[index + 1] && order == SortOrder.Descending)
                    {
                        result = true;
                    }
                    else if (array[index] < array[index + 1] && order == SortOrder.Descending)
                    {
                        result = false;
                        break;
                    }
                    if (array[index] > array[index + 1] && order == SortOrder.Ascending)
                    {
                        result = false;
                        break;
                    }
                    else if (array[index] < array[index + 1] && order == SortOrder.Ascending)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public static void Transform(int[] array, SortOrder order)
        {
            for (int index = 0; index < array.Length; index++)
            {
                if (IsSorted(array, SortOrder.Descending) && order == SortOrder.Descending)
                {
                    array[index] += index;
                }
                else if (IsSorted(array, SortOrder.Ascending) && order == SortOrder.Ascending)
                {
                    array[index] += index;
                }
                else if (array[index] == 0)
                {
                    array[index] += index;
                }
            }
        }

        public static double MultArithmeticElements(double a, double t, int n)
        {
            double result = 1;
            List<double> lst = new List<double>(n);
            for (int num = 0; num < n; a += t, num++)
            {
                lst.Add(a);
            }
            foreach (double num in lst)
            {
                result *= num;
            }
            return result;
        }

        public static double SumGeometricElements(double a, double t, double alim)
        {
            double result = 1;
            List<double> lst = new List<double>();

            while (true)
            {
                if (a > alim)
                {
                    lst.Add(a);
                    a *= t;
                }
                else
                {
                    break;
                }
            }
            foreach (double num in lst)
            {
                result += num;
            }
            return result-1;
        }
    }
}
