using System;
using System.Collections;
using System.Collections.Generic;
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
            //1 просто добавляем
            ht.Add(nums[0], 0);
            //И начинаем с 2го эл-та
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

        #region 2

        #endregion
    }
}
