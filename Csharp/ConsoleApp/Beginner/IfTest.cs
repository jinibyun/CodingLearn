using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class IfTest
    {
        public void Test()
        {
            // if statement
            int number = 12;

            if (number < 5)
            {
                Console.WriteLine("{0} is less than 5", number);
            }
            else if (number > 5)
            {
                Console.WriteLine("{0} is greater than 5", number);
            }
            else
            {
                Console.WriteLine("{0} is equal to 5");
            }

            // switch : multiple if / if가 3개이상이면 switch를 쓰는게 낫다.
            char ch;
            Console.WriteLine("Enter an alphabet for switch test");
            ch = Convert.ToChar(Console.ReadLine());    //console창에서 입력값을 기다린다.

            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Vowel");
                    break;
                case 'e':
                    Console.WriteLine("Vowel");
                    break;
                case 'i':
                    Console.WriteLine("Vowel");
                    break;
                case 'o':
                    Console.WriteLine("Vowel");
                    break;
                case 'u':
                    Console.WriteLine("Vowel");
                    break;

               
                 //string은 "" 꼭 써야함
                   

                // case 'b', 'c','d': 이렇게 쓰면 안됨 아래처럼 써야함
                case 'b':
                case 'c':   //if(value == 'b' || value == 'c' || value == 'd')
                case 'd':   // C#에는 === 없음
                    Console.WriteLine("Consonent!");    //string은 "" 꼭 써야함
                    break;

                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }

            Console.ReadKey();
        }
    }
}
