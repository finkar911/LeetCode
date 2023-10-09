using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
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

        #region 6 https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description
        public static int[] Firas_Last_pose_sorted_Arr(int[] nums, int target) 
        {
            /*
            129 ms
            Beats 84.59 %
            Memory
            44.8 MB
            Beats
            91.22 %
            */
            int start = 0;
            int end = nums.Length - 1;
            int[] result = new int[] { -1 , -1};
            while (start <= end)
            {
                int mid = (end + start) / 2;
                int numi = nums[mid];
                if (numi == target) 
                {
                    result[0] = mid;
                    result[1] = mid;
                    for (int i = 1; i <= (mid - start); i++)
                    {
                        int currId = mid - i;
                        if (nums[currId] == target)
                        {
                            result[0] = currId;
                        }
                        else 
                        {
                            break;
                        }
                    }

                    for (int i = 1; i <= (end - mid); i++)
                    {
                        int currId = mid + i;
                        if (currId < nums.Length && nums[currId] == target)
                        {
                            result[1] = currId;
                        }
                        else
                        {
                            break;
                        }
                    }

                    return result;
                }
                else if (numi > target)
                {
                    end = mid-1;
                }
                else if (numi < target)
                {
                    start = mid+1;
                }
            }
            return result;
        }
        #endregion

        #region 7 https://leetcode.com/problems/median-of-two-sorted-arrays/
        public static double Find_Median_Sorted_Arrays(int[] nums1, int[] nums2)
        {
            //Runtime  87 ms     Beats 89.66 %
            //Memory   52.8 MB   Beats 22.33 %
            List<int> ints1 = new List<int>(nums1);
            List<int> ints2 = new List<int>(nums2);


            double ress = 0;
            int fullLength = nums1.Length + nums2.Length;
            int[] newArr = new int[fullLength];
            //int fid = 0;
            //int sid = 0;
            for (int i = 0; i < fullLength; i++)
            {
                if (ints1.Count > 0 && ints2.Count > 0)
                {
                    int f = ints1[0];
                    int s = ints2[0];
                    if (f < s)
                    {
                        newArr[i] = f;
                        ints1.RemoveAt(0);
                    }
                    else if (f > s)
                    {
                        newArr[i] = s;
                        ints2.RemoveAt(0);
                    }
                    else if (f == s)
                    {
                        newArr[i] = f;
                        newArr[i + 1] = s;
                        ints1.RemoveAt(0);
                        ints2.RemoveAt(0);
                        i++;
                    }
                }
                else 
                {
                    if (ints1.Count > 0) {
                        newArr[i] = ints1[0];
                        ints1.RemoveAt(0);
                    }
                    if (ints2.Count > 0)
                    {
                        newArr[i] = ints2[0];
                        ints2.RemoveAt(0);
                    }
                }
                /*
                int f = nums1[fid];
                int s = nums2[sid];
                if (f < s)
                {
                    fid++;
                    newArr[i] = f;
                }
                else if (f > s)
                {
                    sid++;
                    newArr[i] = s;
                }
                else if (f == s)
                {
                    newArr[i] = f;
                    newArr[i+1] = s;
                    fid++;
                    sid++;
                    i++;
                }
                */
            }

            if (fullLength % 2 == 0)
            {
                ress = ((double)(newArr[fullLength / 2 - 1] + newArr[fullLength / 2]) / 2.0 );
            }
            else {
                ress = newArr[fullLength / 2];
            }

            return ress;
        }
        #endregion

        #region 8
        public static double Find_Median_Sorted_Arrays1(int[] nums1, int[] nums2)
        {
            double ress = 0;
            int[] newArr = new int[nums1.Length + nums2.Length];


            return ress;
        }
        #endregion

        #region 9
        public static double Find_Median_Sorted_Arrays2(int[] nums1, int[] nums2)
        {
            double ress = 0;
            int[] newArr = new int[nums1.Length + nums2.Length];


            return ress;
        }
        #endregion

        #region 10

        #endregion

        #region 11

        #endregion

        #region 12

        #endregion
    }
}
