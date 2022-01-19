using System;
using System.Collections.Generic;
using System.Linq;

namespace ArrayObject
{
    public static class ArrayTasks
    {
        public static void ChangeElementsInArray(int[] nums)
        {
            for (int index = 0, lastindex = 1; index < nums.Length / 2; index++, lastindex++)
            {
                //Check if index even number then it will swap numbers if condition is true
                if ((Math.Abs(nums[index]) % 2 == 0) && (Math.Abs(nums[^lastindex]) % 2 == 0))
                {
                    int temp = nums[index];
                    nums[index] = nums[^lastindex];
                    nums[^lastindex] = temp;
                }
            }
        }

        public static int DistanceBetweenFirstAndLastOccurrenceOfMaxValue(int[] nums)
        {
            //Сheck if the matrix is empty
            if (nums.Length == 0)
            {
                return 0;
            }
            int[] range = new int[0];
            int distance = 0;
            List<int> lst = new List<int>(nums);
            //Find a max value by linq's descendng sorting
            int maxValue = lst.OrderByDescending(x => x).First();
            //Find index of the first entry of the maximum value
            int first = Array.IndexOf(nums, maxValue);

            for (int index = 0; index < nums.Length; index++)
            {
                if ((nums[index] == maxValue && index != first) || (nums[index] == maxValue && index == first))
                {
                    range = nums[first..index];
                }
            }
            foreach (int i in range)
            {
                distance++;
            }
            return distance;
        }

        public static void ChangeMatrixDiagonally(object matrix)
        {
            var castedMatrix = matrix as int[,];
            //Сheck if the matrix is empty
            if ((castedMatrix.GetLength(0) != 0) && (castedMatrix.GetLength(1) != 0))
            {
                for (int i = 0; i < castedMatrix.GetLength(0); i++)
                {
                    for (int j = i + 1; j < castedMatrix.GetLength(0); j++)
                    {
                        // assing right side of diagonal array 1
                        castedMatrix[i, j] = 1;
                        // assing left side of diagonal array 0
                        castedMatrix[j, i] = 0;
                    }
                }
            }
        }
    }
}