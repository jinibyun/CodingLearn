using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
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
            }   //int i는 }만나는 순간 죽는다

            // without initialization and iterator statment 자바는 이방법만 가능
            int i2 = 1;
            for (; i2 <= 5;)    
            {
                Console.WriteLine("C# For Loop: Iteration {0}", i2);
                i2++;
            }
            Console.WriteLine(i2); //for를 몇바퀴 돌렸는지 알수있다.

           

            // sum of n
            int n = 5, sum = 0;

            //for (int i = 1; i < 11; i++)
            //{
            //    Console.WriteLine("1~10까지 합:");
            //    sum = sum + i; //sum += i;

            //}

            sum = 0;

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
                i3++;   //언젠가는 i3가 6이 되서 while문을 빠져나갈 수 있게 해줘야됨. 안달면 무한loop돌게됨
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

            do //한번은 하고나서 while문 돌린다.
            {

            } while (true);
            {
                product = n5 * i5;
                Console.WriteLine("{0} * {1} = {2}", n5, i5, product);
                i5++;
            } while (i5 <= 10);


            // 4. foreach loop
            char[] myArray = { 'H', 'e', 'l', 'l', 'o' };
            // = char [] myArray = new char { 'H', 'e', 'l', 'l', 'o' };

            foreach (char hh in myArray)    // myArray 의 변수의 수만큼 돌려준다.
            {
                Console.WriteLine(hh);
            }

            //convert foreach to for
            for (int i = 0; i < myArray.Length; i++) {
                Console.WriteLine(myArray[i]);
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
