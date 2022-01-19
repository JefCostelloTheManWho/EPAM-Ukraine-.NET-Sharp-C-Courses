using System;

namespace LoopTasks
{
    public static class LoopTasks
    {
        public static int SumOfOddDigits(int n)
        {
            int sum = 0;
            string number = n.ToString();
            foreach (char c in number)
            {
                // Check if a digit is odd
                if (c % 2 != 0)
                {
                    sum += Convert.ToInt32(c.ToString());
                }
            }
            return sum;
        }

        public static int NumberOfUnitsInBinaryRecord(int n)
        {
            int unit = 0;
            string binaryCode = Convert.ToString(n, 2);
            foreach (char c in binaryCode)
            {
                if (c == '1')
                {
                    unit++;
                }
            }
            return unit;
        }

        public static int SumOfFirstNFibonacciNumbers(int n)
        {
            int sum = 0;
            int[] arr = new int[n + 1];
            //initialize first numbers of fibonacci
            arr[0] = 0;
            arr[1] = 1;
            if (n > 1)
            {
                for (int num = 2; num < n; num++)
                {
                    arr[num] = arr[num - 1] + arr[num - 2];
                    sum += arr[num];
                }
                return sum + 1;
            }
            else
            {
                return sum;
            }
        }
    }
}