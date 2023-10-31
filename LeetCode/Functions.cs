using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LeetCode
{
    
    public static class Functions
    {
        static Dictionary<int, int> cachpairs = new Dictionary<int, int>();

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

        #region 8 https://leetcode.com/problems/merge-k-sorted-lists/description/
        public static ListNode MergeKLists(ListNode[] lists)
        {
            ///90ms Beats 83.02%
            ///43.60MB Beats 23.40%


            if (lists is null || lists.Length == 0) return null;

            List<int> l = new List<int>();

            foreach (var item in lists)
            {
                if (item != null)
                {
                    ListNode node = item;
                    while (node is not null)
                    {
                        l.Add(node.val);
                        node = node.next;
                    }
                }
            }

            l.Sort();

            ListNode result = null;

            for (int ii = l.Count - 1; ii >= 0; ii--)
            {

                if (result == null)
                {
                    result = new ListNode(l[ii]);
                }
                else
                {
                    result = new ListNode(l[ii], result);
                }

            }

            return result;
        }


        public static bool MergeKListsDic()
        {
            //ListNode[] lists
            //Runtime  103 ms     Beats 43.66 %
            //Memory   52.8 MB   Beats 19.33 %

            ListNode[] lists = new ListNode[] {
            new ListNode(1, new ListNode(3)),
            new ListNode(1, new ListNode(2,new ListNode(5)))
            };

            ListNode[] lists1 = new ListNode[] {
            };

            //if (lists is null || lists.Length == 0) return null;

            Dictionary<int, int> dic = new Dictionary<int, int>();            

            foreach (var item in lists)
            {
                if (item != null)
                {
                    NodeTodick(dic, item);
                }
            }

            dic = dic.OrderBy(obj => obj.Key).ToDictionary(obj => obj.Key, obj => obj.Value);

            string txt = "";

            ListNode result=null;

            for (int ii = dic.Count-1; ii >= 0; ii--)
            {
                var item = dic.ElementAt(ii);
                for (int i = 0; i < item.Value; i++)
                {
                    if (result == null)
                    {
                        result = new ListNode(item.Key);
                    }
                    else {
                        result = new ListNode(item.Key, result);
                    }
                    txt += item.Key + ",";
                }
            }
            MessageBox.Show(txt);
            /*
            foreach (var item in dic.Keys) 
            {
                for (int i = 0; i < dic[item]; i++)
                {
                    txt +=item+",";
                }
            }

            MessageBox.Show(txt);
            */
            return true;
        }

        public static void NodeTodick(Dictionary<int, int> dic, ListNode l) {
                if (!dic.ContainsKey(l.val))
                {
                    dic.Add(l.val, 1);
                }
                else
                {
                    dic[l.val]++;
                }

                if (l.next != null)
                {
                    NodeTodick(dic, l.next);
                }           
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }

            public void toList(Dictionary<int, int> dic) {
                //List<int> list = new List<int>();
                //list.Add(val);
                if (!dic.ContainsKey(val))
                {
                    dic.Add(val, 1);
                }
                else {
                    dic[val]++;
                }

                if (next != null) 
                {
                    next.toList(dic);
                }
                /*
                ListNode nextToCheck = next;
                while (nextToCheck != null)
                {
                    if (nextToCheck != null)
                    {
                        break;
                    }
                    else
                    {
                        //list.Add(nextToCheck.val);  
                        if (!dic.ContainsKey(val))
                        {
                            dic.Add(val, 1);
                        }
                        else
                        {
                            dic[val]++;
                        }
                        nextToCheck = nextToCheck.next;
                    }
                }
                */
                //return list;
            }
        }
        #endregion

        #region 9 CodeWars Multiples of 3 or 5
        public static int Find_Sum_Of35_Mults(int nums1)
        {
            if (nums1 < 0)
            {
                return 0;
            }

            int ress = 0;
            int newNums = nums1 - 1;
            for (int i = 1; i <= newNums / 3; i++)
            {
                int curr = 3 * i;
                if (curr % 5 != 0)
                {
                    ress += curr;
                }
            }

            for (int i = 1; i <= newNums / 5; i++)
            {
                int curr = 5 * i;
                ress += curr;
            }

            return ress;
        }

        public static int Find_Sum_Of35_MultsS(int value)
        {
            int sum = 0;
            for (int i = 3; i < value; i += 3)
            {
                sum += i;
            }
            for (int i = 5; i < value; i += 5)
            {
                if (i % 3 != 0)
                    sum += i;
            }
            return sum;
        }

        #endregion

        #region 10 CodeWars Phone Number
        public static string PhoneNumber(int[] numbers)
        { 
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                {
                    sb.Append(") ");
                }
                if (i == 6)
                {
                    sb.Append("-");
                }

                sb.Append(numbers[i]);
            }

            return sb.ToString();
        }

        public static string CreatePhoneNumber(int[] numbers)
        {
            return long.Parse(string.Concat(numbers)).ToString("(000) 000-0000");
        }
        #endregion

        #region 11 CodeeWars Vovels
        public static string RemoveVovels(string ste)
        {
            Regex regex = new Regex(@"[aeiou]", RegexOptions.IgnoreCase);
            string result = regex.Replace(ste, "");
            return result;
        }
        #endregion

        #region 12 CodeWars ( and )
        public static string ReplaseCharrWithBread(string str)
        {
            Dictionary<string,int> keyValuePairs = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            foreach (var item in str)
            {
                string rchar = item.ToString().ToLower();

                if (!keyValuePairs.ContainsKey(rchar))
                {
                    keyValuePairs.Add(rchar, 1);
                }
                else
                {
                    keyValuePairs[rchar]++;
                }
                    
            }
            foreach (var item in str)
            {
                string rchar = item.ToString().ToLower();

                if (keyValuePairs[rchar] > 1)
                {
                    sb.Append(")");
                }
                else
                {
                    sb.Append("(");
                }
            }

            return sb.ToString();
        }

        public static string DuplicateEncode(string word)
        {
            return new string(word.ToLower().Select(ch => word.ToLower().Count(innerCh => ch == innerCh) == 1 ? '(' : ')').ToArray());
        }
        #endregion

        #region 13 https://leetcode.com/problems/power-of-four/?envType=daily-question&envId=2023-10-23
        public static bool IsPowerOfFour(int n)
        {
            ///25ms    Beats 88.06 %
            ///27.98MB Beats 98.51 %

            if (n == 1)
            {
                return true;
            }

            if (n <= 0 || n % 4 != 0 )
            {
                return false;
            }

            while (n != 1)
            {
                n /= 4;
                if (n == 1)
                {
                    return true;
                }

                if (n % 4 != 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 14 https://leetcode.com/problems/regular-expression-matching/
        public static bool IsMatch(string s, string p)
        {
            ///25ms    Beats 88.06 %
            ///27.98MB Beats 98.51 %

            /*
                '.' Matches any single character.​​​​
                '*' Matches zero or more of the preceding element.
            */
            return IsMatchHelper(s,p,s.Length-1,p.Length-1);
            //return IsMatchRec(s,p,s.Length-1,p.Length-1);
            //return Var2(s, p);
            //return Var1(s, p);
        }

        private static bool IsMatchRec(string s, string p, int si, int pi)
        {
            if (si < 0)
            {
                if ( pi % 2 == 0)
                {
                    for (int i = 1; i < pi; i += 2)
                    {
                        if (p[i] != '*')
                        {
                            return false;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else 
            {
                if (pi < 0)
                {
                    return false;
                }
            }

            //прямое сравнение
            if (s[si] == p[pi] || p[pi] == '.')
            {
                return IsMatchRec(s, p, si - 1, pi - 1); //то длина -1
            }
            //если не совпадение и это не *
            if (p[pi] != '*')
            {
                return false;
            }
            //Убираем дублированные всех последних *
            while (pi >= 0 && p[pi] == '*')
            {
                pi--;
            }
            //Если после убирания всех * меньше 0 а строка больше 0
            if (pi < 0)
                return false;
            //Пока совпадает символ и ласт символ * 
            while (si >= 0 && (s[si] == p[pi] || p[pi] == '.'))
            {
                if (IsMatchRec(s, p, si, pi - 1)) //Ветвим с тем же самым патерном без ласт символ *
                {
                    return true;
                }

                si--;
            }
            //Если не совпадает то убираем ласт символ * 
            return IsMatchRec(s, p, si, pi - 1);

        }

        private static bool IsMatchHelper(string s, string p, int si, int pi)
        {
            //Если строка < 0 
            if (si < 0)
            {
                //проверяем что всеь оставшийся паттерн *
                while (pi >= 0 && p[pi] == '*')
                {
                    pi -= 2;
                }

                return pi < 0;
            }
            //Если строка не 0 а паттерн больше 0 то ошибка
            if (pi < 0)
            {
                return false;
            }
            //прямое сравнение
            if (s[si] == p[pi] || p[pi] == '.')
            {
                return IsMatchHelper(s, p, si - 1, pi - 1); //то длина -1
            }
            //если не совпадение и это не *
            if (p[pi] != '*')
            {
                return false;
            }
            //Убираем дублированные всех последних *
            while (pi >= 0 && p[pi] == '*')
            {
                pi--;
            }
            //Если после убирания всех * меньше 0 а строка больше 0
            if (pi < 0)
                return false;
            //Пока совпадает символ и ласт символ * 
            while (si >= 0 && (s[si] == p[pi] || p[pi] == '.'))
            {
                if (IsMatchHelper(s, p, si, pi - 1)) //Ветвим с тем же самым патерном без ласт символ *
                {
                    return true;
                }

                si--;
            }
            //Если не совпадает то убираем ласт символ * 
            return IsMatchHelper(s, p, si, pi - 1);
        }

        public static bool Var2(string s, string p)
        {
            char[] sc = s.ToCharArray();
            char[] pc = p.ToCharArray();

            if (sc.Length == 0)
            {
                if (pc.Length % 2 == 0)
                {
                    for (int i = 1; i < pc.Length; i += 2)
                    {
                        if (pc[i] != '*')
                        {
                            return false;
                        }
                    }

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (pc.Length == 0)
                {
                    return false;
                }
            }

            int l = 0;
            int r = 0;
            for (int i = 0; i < pc.Length; i++)
            {
                if (sc.Length > i)
                {
                    if (pc.Length > i + 1 && pc[i + 1] == '*')
                    {
                        break;
                    }
                    else
                    {
                        if (sc[i] == pc[i] || pc[i] == '.')
                        {
                            l = i + 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else 
                {
                    break;
                }
            }

            for (int i = 0; i < pc.Length - l; i++)
            {

                if (pc[pc.Length - 1 - i] == '*')
                {
                    break;
                }
                else
                {
                    int id = sc.Length - 1 - i;
                    if (id >= 0)
                    {
                        if (sc[sc.Length - 1 - i] == pc[pc.Length - 1 - i] || pc[pc.Length - 1 - i] == '.')
                        {
                            r = i + 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else 
                    {
                        break;
                    }
                }
            }

            if (l == s.Length && l == p.Length)
            {
                return true;
            }

            int ls = s.Length - l - r;
            int lp = p.Length - l - r;

            if (ls < 0)
            {
                lp += Math.Abs(ls);
                ls = 0;
            }

            sc = s.Substring(l, ls).ToCharArray();
            pc = p.Substring(l, lp).ToCharArray();

            string pcg = new string(pc);
            string scg = new string(sc);

            int newl = 0;
            int newr = 0;
            char toFind = ' ';
            char toFindBack = ' ';
            if (pc.Length > 0)
            {
                if (sc.Length > 0)
                {
                    toFind = sc[0];
                }
                //Убираем крайниее *
                if ((pc[0] != toFind && pc[0]!='.') && pc.Length > 1 && pc[1] == '*')
                {
                    newl = 2;
                }

                if (sc.Length > 0)
                {
                    toFindBack = sc[sc.Length - 1];
                }
                if (pc.Length > 1 && (pc[pc.Length - 2] != toFindBack && pc[pc.Length - 2] != '.') && pc[pc.Length - 1] == '*')
                {
                    newr = 2;
                }
            }
            if (sc.Length == 0 && newl == pcg.Length)
            {
                return true;
            }

            int pcgL = pcg.Length - newl - newr;
            if (pcgL < 0)
            {
                pcgL = 0;
            }

            if (pcgL >= 0)
            {
                pc = pcg.Substring(newl, pcgL).ToCharArray();
            }
            string pcg0 = new string(pc);

            int pcSameChCount = 0;
            int sameChCount = 0;
            //Проход по нужному *
            if (pc.Length > 1 && toFind !=' ')
            {
                if ((pc[0] == toFind || pc[0] == '.') && pc[1] == '*')
                {
                    sameChCount = 1;
                    for (int i = 1; i < sc.Length; i++)
                    {
                        if (sc[i] == toFind || pc[0] == '.')
                        {
                            sameChCount++;
                        }
                        else
                        {
                            break;
                        }
                    }

                    pcSameChCount = 2;
                    //тут сжимать а*а до а* если есть а?
                    for (int i = 2; i < sameChCount + 2; i++)
                    {
                        if (pc.Length > i && (pc[i] == pc[0])) //|| pc[i]=='*'
                        {
                            pcSameChCount++;
                        }
                        else if (pc.Length > i && pc[i] == '*')
                        {
                            pcSameChCount--;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            string scg1 = new string(sc);
            string pcg1 = new string(pc);

            int scg1L = scg1.Length - sameChCount;
            scg1L = scg1L < 0 ? 0 : scg1L;

            int pcg1L = pcg1.Length - pcSameChCount;
            pcg1L = pcg1L < 0 ? 0 : pcg1L;

            if (scg1.Length >= sameChCount)
            {
                sc = scg1.Substring(sameChCount, scg1L).ToCharArray();
            }
            if (pcg1.Length >= pcSameChCount)
            {
                pc = pcg1.Substring(pcSameChCount, pcg1L).ToCharArray();
            }

            string scg2 = new string(sc);
            string pcg2 = new string(pc);

            if (sc.Length > 0 && pc.Length == 0)
            {
                return false;
            }
            else if (sc.Length == 0 && pc.Length == 0)
            {
                return true;
            }
            else 
            {
                return Var2(new string(sc), new string(pc));
            }

        }

        public static bool Var1(string s, string p) 
        {
            char[] sc = s.ToCharArray();
            char[] pc = p.ToCharArray();
            int count = 0;
            char curr = ' ';
            for (int i = 0; i < pc.Length; i++)
            {
                if (count > sc.Length - 1)
                {
                    return false;
                }

                char cd = sc[count];
                char pd = pc[i];

                if (sc[count] == pc[i] || pc[i] == '.')
                {
                    if (pc.Length > i + 1 && pc[i + 1] == '*')
                    {
                        curr = pc[i];
                        while (true)
                        {
                            if (count <= sc.Length - 1 && (sc[count] == curr || curr == '.'))
                            {
                                count++;
                            }
                            else
                            {
                                break;
                            }
                        }

                        i++;

                        if (pc.Length > i + 1 && pc[i + 1] == curr)
                        {
                            for (int ii = i + 1; ii < pc.Length; ii++)
                            {
                                if (pc[ii] == curr)
                                {
                                    i++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        count++;
                    }
                }
                else if (pc.Length > i + 1 && pc[i + 1] == '*')
                {
                    //SKIPP
                    i++;
                }
                else
                {
                    return false;
                }
            }

            if (count <= sc.Length - 1)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 15 https://leetcode.com/problems/climbing-stairs/?envType=study-plan-v2&envId=dynamic-programming

        public static int ClimbStairs4ms(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            var climbArr = new int[n + 1];
            climbArr[1] = 1;
            climbArr[2] = 2;

            for (int i = 3; i <= n; i++)
            {
                climbArr[i] = climbArr[i - 1] + climbArr[i - 2];
            }

            return climbArr[n];
        }

        public static int ClimbStairsRec7mc(int n)
        {            
            if (cachpairs.ContainsKey(n))
            {
                return cachpairs[n];
            }
            
            int result = 0;
            
            if (n == 1)
            {
                result = 1;
            }
            else if (n == 2)
            {
                result = 2;
            }
            else 
            {            
                result = ClimbStairsRec7mc(n - 1) + ClimbStairsRec7mc(n - 2);
            }

            cachpairs[n] = result;
            return result;
        }

        public static int ClimbStairsOld28s(int n)
        {
            int result = 0;
            
            result += MakeStep(1, n,0);
            result += MakeStep(2, n,0);
            
            //result +=  MakeStepAs(1, n, 0).Result;
            //result +=  MakeStepAs(2, n, 0).Result;
            return result;
        }

        public static int MakeStep(int step, int max, int start)
        {
            //44 = 28.3 s  28 29.2
            if (cachpairs.ContainsKey(start))
            { 
                return cachpairs[start];
            }
            int mewStep = start + step;
            int result = 0;
            if (mewStep < max)
            {
                result += MakeStep(1, max, mewStep);
                result += MakeStep(2, max, mewStep);
            }
            else if (mewStep == max)
            {
                result++;
            }
            cachpairs[start] = result;
            return result;
        }
        async public static Task<int> MakeStepAs(int step, int max, int start)
        {
            //44 = хуй забей
            int mewStep = start + step;
            int result = 0;
            if (mewStep < max)
            {
                result += await MakeStepAs(1, max, mewStep);
                result += await MakeStepAs(2, max, mewStep);
            }
            else if (mewStep == max)
            {
                result++;
            }
            return result;
        }
        #endregion

        #region 16 https://leetcode.com/problems/fibonacci-number/description/?envType=study-plan-v2&envId=dynamic-programming
        public static int Fib(int n)
        {
            int result = 0;
            
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }
            /* 41ms
            else
            {
                result = Fib(n - 1) + Fib(n - 2);
            }
            */
            // 20ms
            var f0 = 0;
            var f1 = 1;
            for (var i = 2; i <= n; i++)
            {
                result = f0 + f1;
                f0 = f1;
                f1 = result;
            }

            return result;
        }
        #endregion

        #region 17 https://leetcode.com/problems/n-th-tribonacci-number/?envType=study-plan-v2&envId=dynamic-programming
        public static int Tribonacci(int n)
        {
            int result = 0;

            if (n == 0)
            {
                return 0;
            }
            else if (n == 1 || n == 2)
            {
                return 1;
            }

            var f0 = 0;
            var f1 = 1;
            var f2 = 1;
            for (var i = 3; i <= n; i++)
            {
                result = f0 + f1 + f2;
                f0 = f1;
                f1 = f2;
                f2 = result;
            }

            return result;
        }
        #endregion

        #region 18 https://leetcode.com/problems/min-cost-climbing-stairs/?envType=study-plan-v2&envId=dynamic-programming
        public static int MinCostClimbingStairs(int[] cost, int step = -1)
        {
            if (cachpairs.ContainsKey(step))
            {
                return cachpairs[step];
            }

            int result = 0;

            if (step >= cost.Length)
            {
                result = 0;
            }            
            else
            {
                if (step < 0)
                {
                    result = 0;
                }
                else
                {
                    result = cost[step];
                }
                result += Math.Min(MinCostClimbingStairs(cost,step + 1), MinCostClimbingStairs(cost,step + 2));
            }

            cachpairs[step] = result;

            return result;
            /*
            if (cachpairs.ContainsKey(n))
            {
                return cachpairs[n];
            }

            int result = 0;

            if (n == 1)
            {
                result = 1;
            }
            else if (n == 2)
            {
                result = 2;
            }
            else
            {
                result = ClimbStairsRec7mc(n - 1) + ClimbStairsRec7mc(n - 2);
            }

            cachpairs[n] = result;
            return result;
            */
        }

        public static int MinCostClimbingStairsFast(int[] cost)
        {
            int n = cost.Length;
            int first = cost[0];
            int second = cost[1];
            if (n <= 2) return Math.Min(first, second);
            for (int i = 2; i < n; i++)
            {
                int curr = cost[i] + Math.Min(first, second);
                first = second;
                second = curr;
            }
            return Math.Min(first, second);
        }

        #endregion

        #region 19 https://leetcode.com/problems/house-robber/?envType=study-plan-v2&envId=dynamic-programming
        public static int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len < 3)
            {
                //[ 1, 2, 3] любой 1 дом
                int max = -1;
                foreach (int n in nums)
                {
                    if (n > max)
                        max = n;
                }
                return max;
            }

            int[] dp = new int[len];
            dp[len - 1] = nums[len - 1];
            dp[len - 2] = nums[len - 2];
            for (int i = len - 3; i >= 0; i--) //Идем по каждому с конца
            {
                int max = dp[i + 1];
                for (int j = i + 2; j < len; j++) //Пробегаем с текеущего до конца 
                {
                    max = Math.Max(max, nums[i] + dp[j]);
                }
                dp[i] = max;
            }
            return dp[0];
        }

        public static int RobMy(int[] nums, int step =-1)
        {
            if (cachpairs.ContainsKey(step))
            {
                return cachpairs[step];
            }

            int result = 0;

            if (step >= nums.Length)
            {
                result = 0;
            }
            else
            {
                if (step < 0)
                {
                    result = 0;
                    result += Math.Max(Math.Max(RobMy(nums, step + 1), RobMy(nums, step + 2)), RobMy(nums, step + 3));
                }
                else
                {
                    result = nums[step];
                    result += Math.Max(RobMy(nums, step + 2), RobMy(nums, step + 3));
                }                
            }

            cachpairs[step] = result;

            return result;
        }

        public static int RobOld(int[] nums)
        {
            int d = 0;
            int p = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    d += nums[i];
                }
                else
                {
                    p += nums[i];
                }
            }

            return Math.Max(d, p);
        }
        #endregion

        #region 20 https://leetcode.com/problems/delete-and-earn/?envType=study-plan-v2&envId=dynamic-programming
        public static int DeleteAndEarn(int[] nums)
        {
            int result = 0;
            Dictionary<int, int> pointCount = new Dictionary<int, int>();
            foreach (var i in nums)
            {
                if (pointCount.ContainsKey(i))
                {
                    pointCount[i] += i;
                }
                else
                {
                    pointCount.Add(i,i);
                }
            }

            Dictionary<int, int> sortedPointCount = pointCount.OrderBy(x => x.Key).ToDictionary(x => x.Key,x=> x.Value);

            foreach (var point in sortedPointCount.Keys)
            {
                //Нахуй -> sortedPointCount[point-1], sortedPointCount[point + 1]
                //Начинаем с 0. 1. 2 ключа 
            }

            return result;
        }
        #endregion

        #region 21

        #endregion

        #region 22

        #endregion

        #region 23

        #endregion
    }
}
