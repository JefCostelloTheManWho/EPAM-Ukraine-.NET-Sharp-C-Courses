using System;
using System.Text;

namespace Condition
{
    public static class Condition
    {
        public static int Task1(int n)
        {
            if (n > 0)
            {
                return n * n;
            } 
            else if (n < 0)
            {
                return Math.Abs(n);
            }
            else
            {
                return 0;
            }
        }

        public static int Task2(int n)
        {
            //Convert number to string
            string number = n.ToString();
            StringBuilder sb = new StringBuilder(number);
            //Bubble sorting by descending
            char temp;
            for (int i = 0; i < sb.Length - 1; i++)
            {
                for (int j = i + 1; j < sb.Length; j++)
                {
                    if (sb[i] < sb[j])
                    {
                        temp = sb[i];
                        sb[i] = sb[j];
                        sb[j] = temp;
                    }
                }
            }
            //Convert StringBuilder to string then to integer
            string res = sb.ToString();
            return Convert.ToInt32(res);
        }
    }
}
