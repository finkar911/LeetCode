using System.Collections;
using System.Collections.Generic;

namespace LeetCode
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //https://leetcode.com/problems/two-sum/

            int[] arr = new int[] { 2, 7, 11, 15 };
            int[] arr1 = new int[] { 3, 2, 4 };
            int target = 6;

            int[] result = Functions.dictionary_two_sum(arr1, target);
            MessageBox.Show(result[0] + " " + result[1]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int n = 44;
            int res = Functions.ClimbStairsRec7mc(n);
            MessageBox.Show(n + " Result:" + res);
        }
    }
}