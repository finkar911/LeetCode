using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static class Functions
    {
        #region 1 https://leetcode.com/problems/two-sum/
        static public int[] dictionary_two_sum(int[] nums, int target)
        {
            Dictionary<int, int> ht = new Dictionary<int, int>();
            //add first
            ht.Add(nums[0], 0);
            //and start from 1
            for (int i = 1; i < nums.Length; i++)
            {
                int weNeed = target - nums[i];
                if (ht.ContainsKey(weNeed))
                {
                    return new int[] { ht[weNeed], i };
                }

                if (!ht.ContainsKey(nums[i]))
                {
                    ht.Add(nums[i], i);
                }
            }

            return new int[] { 0, 0 };
        }

        static public int[] hash_table_two_sum(int[] nums, int target)
        {
            Hashtable ht = new Hashtable();

            for (int i = 0; i < nums.Length; i++)
            {
                int weNeed = target - nums[i];
                if (ht.ContainsKey(weNeed))
                {
                    return new int[] { (int)ht[weNeed], i };
                }

                if (!ht.ContainsKey(nums[i]))
                {
                    ht.Add(nums[i], i);
                }
            }

            return new int[] { 0, 0 };
        }

        static public int[] two_points_two_sum(int[] arr, int target)
        {
            int l = 0;
            int r = arr.Length - 1;

            while (l < r)
            {
                int sum = arr[l] + arr[r];
                if (sum == target)
                {
                    return new int[] { l, r };
                }

                if (sum > target)
                {
                    r--;
                }
                else
                {
                    l++;
                }
            }

            return new int[] { 0, 0 };
        }
        #endregion

        #region 2 https://leetcode.com/problems/palindrome-number/description/
        public static bool IsPalindrome_NoString(int x)
        {
            ///38ms
            //Beats 56.46 %
            ///
            if (x < 0)
            {
                return false;
            }
            else if (x < 10)
            {
                return true;
            }

            int summ = 0;
            int nuber = x;

            summ += nuber % 10;

            if (summ == 0)
                return false;

            nuber /= 10;

            while (nuber>0)
            {
                summ= (nuber % 10) + summ * 10;
                nuber /= 10;
            }

            return summ == x;
        }
        public static bool IsPalindrome(int x)
        {
            ///29ms
            //Beats 93.07 %
            string stx = x.ToString();
            for (int i = 0; i < (stx.Length / 2); i++)
            {
                if (stx[i] != stx[stx.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPalindrome1(int x)
        {
            ///51ms
            //Beats 8.59 %
                        string stx = x.ToString();
            for (int i = 0; i < stx.Length; i++)
            {
                if (stx[i] != stx[stx.Length - 1 - i])
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 3 https://leetcode.com/problems/palindrome-number/description/
        public static int Roman_to_Int(string s) 
        {
            ///55ms
            ///Beats 95.58 %
            int count = 0;
            Dictionary<char, int> rom = new Dictionary<char, int>();
            rom.Add('I',1);
            rom.Add('V', 5);
            rom.Add('X', 10);
            rom.Add('L', 50);
            rom.Add('C', 100);
            rom.Add('D', 500);
            rom.Add('M', 1000);
            int currMax = 0;

            for (int i = s.Length-1; i >= 0; i--)
            {          
                if (rom.ContainsKey(s[i]))
                {
                    int toAdd = rom[s[i]];
                    if (toAdd >= currMax)
                    {
                        count += toAdd;
                        currMax = toAdd;
                    }
                    else
                    {
                        count -= toAdd;
                    }
                }
            }
            return count;
        }
        #endregion

        #region 4 https://leetcode.com/problems/richest-customer-wealth/
        public static int Ritch_W_Count(int[][] accounts)
        {
            int maxSum = 0;
            foreach (var i in accounts)
            {
                maxSum = Math.Max(i.Sum(), maxSum);
            }
            return maxSum;
        }
        #endregion

        #region 5 https://leetcode.com/problems/running-sum-of-1d-array/description/
        public static int[] RunningSum(int[] nums)
        {          
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int[] data = new int[nums.Length];
            for (int count = 0; count < 100; count++)
            {
                ///137ms
                ///Beats 20.47%
                ///5ms
                /*
                for (int i = 1; i < nums.Length; i++)
                {
                    nums[i] += nums[i - 1];
                }
                */


                ///124ms
                ///Beats 82.93%
                ///5ms     
                
                int sum = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    sum += nums[i];
                    data[i] = sum;
                }
                

            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            MessageBox.Show("RunTime " + ts);
            return data;
            return nums;

        }
        #endregion

        #region 6 

        #endregion
    }
}
