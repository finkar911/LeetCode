using LeetCode;
using static LeetCode.Functions;

namespace LeetCodeTests
{
    public static class LeetCodeTestData 
    {
        public static int[][] FirstTestarr = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 } };
    }

    public class FunctionsTests
    {       

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1})]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2})]
        public void dictionary_two_sum_Valid_Data_Test(int[] nums, int target, int[] expected)
        {
            var actual = Functions.dictionary_two_sum(nums, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(123321, true)]
        [InlineData(95688659, true)]
        [InlineData(-121, false)]
        [InlineData(10, false)]
        [InlineData(123, false)]
        public void IsPalindrome_Test(int nums, bool expected)
        {
            var actual = Functions.IsPalindrome(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void Rome_To_Int_Test(string nums, int expected)
        {
            var actual = Functions.Roman_to_Int(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 1, 2, 10, 1 }, new int[] { 3, 4, 6, 16, 17 })]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20}, new int[] { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210 })]
        public void RunningSum_Valid_Data_Test(int[] nums, int[] expected)
        {
            var actual = Functions.RunningSum(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
        [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1,-1 })]
        [InlineData(new int[] { 2, 2, 2, 2, 2, 2 }, 2, new int[] { 0, 5 })]
        public void Firas_Last_pose_sorted_ArrTest(int[] nums, int target, int[] expected)
        {
            var actual = Functions.Firas_Last_pose_sorted_Arr(nums,target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2 )]
        [InlineData(new int[] { 1, 2 }, new int[] { 3, 4 }, 2.5)]
        public void Find_Median_Sorted_ArraysTest(int[] nums, int[] target, double expected)
        {
            var actual = Functions.Find_Median_Sorted_Arrays(nums, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true)]
        public void MergeKListsTest(bool expected)
        {
            //var actual = Functions.MergeKLists();
            //Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(10, 23)]
        [InlineData(20, 78)]
        [InlineData(200, 9168)]
        [InlineData(0, 0)]
        public void Find_Sum_Of35_MultsTest(int max,int expected)
        {
            var actual = Find_Sum_Of35_Mults(max);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, "(123) 456-7890")]
        [InlineData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, "(111) 111-1111")]
        public void PhoneNumberTest(int[] nums, string expected)
        {
            var actual = PhoneNumber(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("This website is for losers LOL!", "Ths wbst s fr lsrs LL!")]
        [InlineData("No offense but,\nYour writing is among the worst I've ever read", "N ffns bt,\nYr wrtng s mng th wrst 'v vr rd")]
        public void RemoveVovelsTest(string nums, string expected)
        {
            var actual = RemoveVovels(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("din", "(((")]
        [InlineData("recede", "()()()")]
        public void ReplaseCharrWithBreadTest(string nums, string expected)
        {
            var actual = ReplaseCharrWithBread(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(16, true)]
        [InlineData(12, false)]
        [InlineData(0, false)]
        [InlineData(-64, false)]
        public void IsPowerOfFourTest(int nums, bool expected)
        {
            var actual = IsPowerOfFour(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("mississippi", "mis*is*ip*.", true)]
        [InlineData("ab", ".*", true)]
        [InlineData("aaa", "aaaa", false)]
        [InlineData("aaa", "a*a", true)]
        [InlineData("aaa", "a*aaa", true)]
        [InlineData("aaa", "a*aaaa", false)]
        [InlineData("aaa", "ab*a*c*a", true)]
        [InlineData("aa","a*", true)]
        [InlineData("aa","aa*", true)]
        [InlineData("aa","a.", true)]
        [InlineData("aa","a", false)]
        [InlineData("aab", "c*a*b", true)]
        [InlineData("aaa", "ab*a", false)]
        [InlineData("ab", ".*..", true)]
        [InlineData("ab", ".*..c*", true)]
        [InlineData("a", ".*..a*", false)]
        [InlineData("a", ".*..", false)]
        [InlineData("aaaaaaaaaaaaab", "a*a*a*a*a*a*a*a*a*b", true)]
        [InlineData("aabcbcbcaccbcaabc", ".*a*aa*.*b*.c*.*a*", true)]
        [InlineData("aabcbcbcaccbcaabc", ".*a.*", true)]
        public void IsMatchTest(string s, string p, bool expected)
        {
            var actual = IsMatch(s, p);
            Assert.Equal(expected, actual);
        }


        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(44, 1134903170)]
        public void ClimbStairsTest(int nums, int expected)
        {
            int actual = ClimbStairsRec7mc(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        public void FibTest(int nums, int expected)
        {
            int actual = Fib(nums);
            Assert.Equal(expected, actual);
        }

    }
}