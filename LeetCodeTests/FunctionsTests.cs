using LeetCode;

namespace LeetCodeTests
{
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
    }
}