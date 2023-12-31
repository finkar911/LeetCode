using LeetCode;
using static LeetCode.Functions;

namespace LeetCodeTests
{
    public static class LeetCodeTestData
    {
        public static int[][] FirstTestarr = new int[][] { new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 } };
        public static int[][] NextTestarr = new int[][] { new int[] { 1, 2, 3}, new int[] { 4, 5, 6}};
    }

    public class FunctionsTests
    {

        [Theory]
        [InlineData(new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 })]
        [InlineData(new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 })]
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
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, new int[] { 1, 3, 6, 10, 15, 21, 28, 36, 45, 55, 66, 78, 91, 105, 120, 136, 153, 171, 190, 210 })]
        public void RunningSum_Valid_Data_Test(int[] nums, int[] expected)
        {
            var actual = Functions.RunningSum(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 8, new int[] { 3, 4 })]
        [InlineData(new int[] { 5, 7, 7, 8, 8, 10 }, 6, new int[] { -1, -1 })]
        [InlineData(new int[] { 2, 2, 2, 2, 2, 2 }, 2, new int[] { 0, 5 })]
        public void Firas_Last_pose_sorted_ArrTest(int[] nums, int target, int[] expected)
        {
            var actual = Functions.Firas_Last_pose_sorted_Arr(nums, target);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 3 }, new int[] { 2 }, 2)]
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
        public void Find_Sum_Of35_MultsTest(int max, int expected)
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
        [InlineData("aa", "a*", true)]
        [InlineData("aa", "aa*", true)]
        [InlineData("aa", "a.", true)]
        [InlineData("aa", "a", false)]
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

        [Theory]
        [InlineData(new int[] { 10, 15, 20 }, 15)]
        [InlineData(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6)]
        [InlineData(new int[] { 841, 462, 566, 398, 243, 248, 238, 650, 989, 576, 361, 126, 334, 729, 446, 897, 953, 38, 195, 679, 65, 707, 196, 705, 569, 275, 259, 872, 630, 965, 978, 109, 56, 523, 851, 887, 91, 544, 598, 963, 305, 481, 959, 560, 454, 883, 50, 216, 732, 572, 511, 156, 177, 831, 122, 667, 548, 978, 771, 880, 922, 777, 990, 498, 525, 317, 469, 151, 874, 202, 519, 139, 670, 341, 514, 469, 858, 913, 94, 849, 839, 813, 664, 163, 3, 802, 21, 634, 944, 901, 446, 186, 843, 742, 330, 610, 932, 614, 625, 169, 833, 4, 81, 55, 124, 294, 71, 24, 929, 534, 621, 543, 417, 534, 427, 327, 179, 90, 341, 949, 368, 692, 646, 290, 488, 145, 273, 617, 596, 82, 538, 751, 80, 616, 763, 826, 932, 184, 630, 478, 163, 925, 259, 237, 839, 602, 60, 786, 603, 413, 816, 278, 4, 35, 243, 64, 631, 405, 23, 638, 618, 829, 481, 877, 756, 482, 999, 973, 718, 157, 262, 752, 931, 882, 741, 40, 77, 535, 542, 879, 607, 879, 321, 46, 210, 116, 244, 830, 591, 285, 382, 925, 48, 497, 913, 203, 239, 696, 162, 623, 291, 525, 950, 27, 546, 293, 108, 577, 672, 354, 256, 3, 671, 998, 22, 989, 557, 424, 251, 923, 542, 243, 46, 488, 80, 374, 372, 334, 190, 817, 150, 742, 362, 196, 75, 193, 162, 645, 859, 758, 433, 903, 199, 289, 175, 303, 475, 818, 213, 576, 181, 668, 243, 297, 572, 549, 840, 161, 292, 719, 226, 338, 981, 345, 203, 655, 210, 65, 111, 746, 76, 935, 406, 646, 976, 567, 32, 726, 638, 674, 727, 861, 426, 297, 349, 464, 973, 341, 452, 826, 223, 805, 940, 458, 468, 967, 107, 345, 987, 553, 407, 916, 103, 324, 367, 864, 74, 946, 712, 596, 105, 194, 79, 634, 855, 703, 70, 170, 543, 208, 739, 632, 663, 880, 857, 824, 258, 743, 488, 659, 647, 470, 958, 492, 211, 927, 356, 488, 744, 570, 143, 674, 502, 589, 270, 80, 6, 463, 506, 556, 495, 713, 407, 229, 689, 280, 162, 454, 757, 565, 267, 575, 417, 948, 607, 269, 852, 938, 560, 24, 222, 580, 604, 800, 628, 487, 485, 615, 796, 384, 555, 226, 412, 445, 503, 810, 949, 966, 28, 768, 83, 213, 883, 963, 831, 390, 951, 378, 497, 440, 780, 209, 734, 290, 96, 398, 146, 56, 445, 880, 910, 858, 671, 164, 552, 686, 748, 738, 837, 556, 710, 787, 343, 137, 298, 685, 909, 828, 499, 816, 538, 604, 652, 7, 272, 729, 529, 343, 443, 593, 992, 434, 588, 936, 261, 873, 64, 177, 827, 172, 712, 628, 609, 328, 672, 376, 628, 441, 9, 92, 525, 222, 654, 699, 134, 506, 934, 178, 270, 770, 994, 158, 653, 199, 833, 802, 553, 399, 366, 818, 523, 447, 420, 957, 669, 267, 118, 535, 971, 180, 469, 768, 184, 321, 712, 167, 867, 12, 660, 283, 813, 498, 192, 740, 696, 421, 504, 795, 894, 724, 562, 234, 110, 88, 100, 408, 104, 864, 473, 59, 474, 922, 759, 720, 69, 490, 540, 962, 461, 324, 453, 91, 173, 870, 470, 292, 394, 771, 161, 777, 287, 560, 532, 339, 301, 90, 411, 387, 59, 67, 828, 775, 882, 677, 9, 393, 128, 910, 630, 396, 77, 321, 642, 568, 817, 222, 902, 680, 596, 359, 639, 189, 436, 648, 825, 46, 699, 967, 202, 954, 680, 251, 455, 420, 599, 20, 894, 224, 47, 266, 644, 943, 808, 653, 563, 351, 709, 116, 849, 38, 870, 852, 333, 829, 306, 881, 203, 660, 266, 540, 510, 748, 840, 821, 199, 250, 253, 279, 672, 472, 707, 921, 582, 713, 900, 137, 70, 912, 51, 250, 188, 967, 14, 608, 30, 541, 424, 813, 343, 297, 346, 27, 774, 549, 931, 141, 81, 120, 342, 288, 332, 967, 768, 178, 230, 378, 800, 408, 272, 596, 560, 942, 612, 910, 743, 461, 425, 878, 254, 929, 780, 641, 657, 279, 160, 184, 585, 651, 204, 353, 454, 536, 185, 550, 428, 125, 889, 436, 906, 99, 942, 355, 666, 746, 964, 936, 661, 515, 978, 492, 836, 468, 867, 422, 879, 92, 438, 802, 276, 805, 832, 649, 572, 638, 43, 971, 974, 804, 66, 100, 792, 878, 469, 585, 254, 630, 309, 172, 361, 906, 628, 219, 534, 617, 95, 190, 541, 93, 477, 933, 328, 984, 117, 678, 746, 296, 232, 240, 532, 643, 901, 982, 342, 918, 884, 62, 68, 835, 173, 493, 252, 382, 862, 672, 803, 803, 873, 24, 431, 580, 257, 457, 519, 388, 218, 970, 691, 287, 486, 274, 942, 184, 817, 405, 575, 369, 591, 713, 158, 264, 826, 870, 561, 450, 419, 606, 925, 710, 758, 151, 533, 405, 946, 285, 86, 346, 685, 153, 834, 625, 745, 925, 281, 805, 99, 891, 122, 102, 874, 491, 64, 277, 277, 840, 657, 443, 492, 880, 925, 65, 880, 393, 504, 736, 340, 64, 330, 318, 703, 949, 950, 887, 956, 39, 595, 764, 176, 371, 215, 601, 435, 249, 86, 761, 793, 201, 54, 189, 451, 179, 849, 760, 689, 539, 453, 450, 404, 852, 709, 313, 529, 666, 545, 399, 808, 290, 848, 129, 352, 846, 2, 266, 777, 286, 22, 898, 81, 299, 786, 949, 435, 434, 695, 298, 402, 532, 177, 399, 458, 528, 672, 882, 90, 547, 690, 935, 424, 516, 390, 346, 702, 781, 644, 794, 420, 116, 24, 919, 467, 543, 58, 938, 217, 502, 169, 457, 723, 122, 158, 188, 109, 868, 311, 708, 8, 893, 853, 376, 359, 223, 654, 895, 877, 709, 940, 195, 323, 64, 51, 807, 510, 170, 508, 155, 724, 784, 603, 67, 316, 217, 148, 972, 19, 658, 5, 762, 618, 744, 534, 956, 703, 434, 302, 541, 997, 214, 429, 961, 648, 774, 244, 684, 218, 49, 729, 990, 521, 948, 317, 847, 76, 566, 415, 874, 399, 613, 816, 613, 467, 191 }, 209040)]
        public void MinCostClimbingStairsTest(int[] nums, int expected)
        {
            int actual = MinCostClimbingStairs(nums); //MinCostClimbingStairsFast
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 2, 1, 1, 2 }, 4)]
        [InlineData(new int[] { 1, 2, 3, 1 }, 4)]
        [InlineData(new int[] { 2, 7, 9, 3, 1 }, 12)]
        public void RobTest(int[] nums, int expected)
        {
            int actual = Rob(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 3, 4, 2 }, 6)]
        [InlineData(new int[] { 2, 2, 3, 3, 3, 4 }, 9)]
        [InlineData(new int[] { 1, 1, 1, 2, 4, 5, 5, 5, 6 }, 18)]
        [InlineData(new int[] { 12, 32, 93, 17, 100, 72, 40, 71, 37, 92, 58, 34, 29, 78, 11, 84, 77, 90, 92, 35, 12, 5, 27, 92, 91, 23, 65, 91, 85, 14, 42, 28, 80, 85, 38, 71, 62, 82, 66, 3, 33, 33, 55, 60, 48, 78, 63, 11, 20, 51, 78, 42, 37, 21, 100, 13, 60, 57, 91, 53, 49, 15, 45, 19, 51, 2, 96, 22, 32, 2, 46, 62, 58, 11, 29, 6, 74, 38, 70, 97, 4, 22, 76, 19, 1, 90, 63, 55, 64, 44, 90, 51, 36, 16, 65, 95, 64, 59, 53, 93 }, 3451)]
        public void DeleteAndEarnTest(int[] nums, int expected)
        {
            int actual = DeleteAndEarn(nums);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(3, 7, 28)]
        [InlineData(3, 2, 3)]
        public void UniquePathsTest(int m, int n, int expected)
        {
            int actual = UniquePaths(m, n);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(12)]
        public void MinPathSumTest(int expected)
        {
            int actual = MinPathSum(LeetCodeTestData.NextTestarr);
            Assert.Equal(expected, actual);
        }

    }
}