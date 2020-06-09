using System;
using System.Collections.Generic;
using System.Text;

namespace FiveNumberSummary
{
    class Calculations
    {
        public string UserInput;

        //Returns the selected percentile (25 for Q1, 50 for Q2, 75 for Q3)
        public double Percentile(double[] nums, int perct)
        {

            if (perct >= 100) return nums[nums.Length - 1];

            double position = (nums.Length + 1) * perct / 100;
            double leftNumber = 0.0d, rightNumber = 0.0d;

            double n = perct / 100.0d * (nums.Length - 1) + 1.0d;

            if (position >= 1)
            {
                leftNumber = nums[(int)Math.Floor(n) - 1];
                rightNumber = nums[(int)Math.Floor(n)];
            }
            else
            {
                leftNumber = nums[0]; // first data
                rightNumber = nums[1]; // first data
            }

            //if (leftNumber == rightNumber)
            if (Equals(leftNumber, rightNumber))
                return leftNumber;
            double part = n - Math.Floor(n);
            return leftNumber + part * (rightNumber - leftNumber);
        }

        //Returns the minimum value of the given array
        public double Min(double[] nums)
        {
            double min = nums[0];
            return min;
        }

        //Returns the maximum value of the given array
        public double Max(double[] nums)
        {
            double max = nums[nums.Length - 1];
            return max;
        }
    }
}
