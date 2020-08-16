using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Beginner
{
    public class LoopTest
    {
        public void Test()
        {
            // 1. for loop
            // basic 
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("C# For Loop: Iteration {0}", i);
            }

            // without initialization and iterator statment
            int i2 = 1;
            for (; i2 <= 5;)
            {
                Console.WriteLine("C# For Loop: Iteration {0}", i2);
                i2++;
            }

            // Fibanocci Array:
            // 0, 1, 1, 2, 3, 5, 8, 13, 21.....

            // sum of n
            int n = 100, sum = 0;

            for (int i = 1; i <= n; i++)
            {
                // sum = sum + i;
                sum += i;
            }

            Console.WriteLine("Sum of first {0} natural numbers = {1}", n, sum);

            // 2. while loop
            int i3 = 1;
            while (i3 <= 5)
            {
                Console.WriteLine("C# For Loop: Iteration {0}", i3);
                i3++;
            }

            // sum of n
            int i4 = 1, sum4 = 0;

            while (i4 <= 5)
            {
                sum4 += i4;
                i4++;
            }
            Console.WriteLine("Sum = {0}", sum4);


            // 3. do while loop
            int i5 = 1, n5 = 5, product;

            do
            {
                product = n5 * i5;
                Console.WriteLine("{0} * {1} = {2}", n5, i5, product);
                i5++;
            } while (i5 <= 10);

     
            // for loop: read , write possible
            // forach loop: only read

            // 4. forach loop
            char[] myArray = { 'H', 'e', 'l', 'l', 'o' };

            foreach (char xxxxxxx in myArray)
            {
                Console.WriteLine(xxxxxxx);
            }

            // 
            char[] gender = { 'm', 'f', 'm', 'm', 'm', 'f', 'f', 'm', 'm', 'f' };
            int male = 0, female = 0;
            foreach (char g in gender)
            {
                if (g == 'm')
                    male++;
                else if (g == 'f')
                    female++;
            }
            Console.WriteLine("Number of male = {0}", male);
            Console.WriteLine("Number of female = {0}", female);
        }
    }
}
