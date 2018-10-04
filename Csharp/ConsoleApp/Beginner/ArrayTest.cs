using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class ArrayTest
    { 
        public void Test()
        {
            // array
            // group of same data type
            // every array type is reference type (stored in heap memory)
            // string is char array
            // most of coding questions use arrays

            // one dimensional
            string[] players = new string[10];
            string[] Regions = { "Toronto", "Vancouver", "Montreal" };
            // same as 
            // string[] Regions = new string[3] { "Toronto", "Vancouver", "Montreal" };

            // 2 dimensional
            // 방 개수가 같은 어레이들은 이렇게 선언하는게 편함
            string[,] Province = { { "Toronto", "ON" }, { "Vancouver", "BC" } };
            // it's ok
            // string[,] Provinces = { { "Toronto", "ON", "ff" }, { "Vancouver", "BC", "f" } };

            // jagged array: 
            // 1. each dimension's size can be different. Dynamic 2 dimensional array
            // 2. array of array
            // rule: first array must be initialzied with size
            int[][] A = new int[3][];

            // different size
            A[0] = new int[2];
            A[1] = new int[3] { 1, 2, 3 };
            A[2] = new int[4] { 1, 2, 3, 4 };

            A[0][0] = 1;
            A[0][1] = 2;

            // array and loop
            int sum = 0;
            int[] scores = { 80, 78, 60, 90, 100 };
            for (int i = 0; i < scores.Length; i++)
            {
                sum += scores[i];
            }
            Console.WriteLine(sum);

            // array & parameter
            int[] scores2 = { 80, 78, 60, 90, 100 };
            int sum2 = CalculateSum(scores);
            Console.WriteLine(sum2);

        }

        private int CalculateSum(int[] scoresArray)
        {
            int sum = 0;
            for (int i = 0; i < scoresArray.Length; i++)
            {
                sum += scoresArray[i];
            }
            return sum;
        }
    }
}
