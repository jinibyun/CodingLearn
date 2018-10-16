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
            
            // 한 문장만 쓴다면 {}를 생략해도 되지만 가독성문제가 있음.
            // 코딩스타일에 따라 붙이거나 떼거나
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

            // switch
            char ch;
            Console.WriteLine("Enter an alphabet for switch test");
            ch = Convert.ToChar(Console.ReadLine());

            // if condition이 3~4개 이상이면 가독성을 위해 switch를 쓰는게 좋음
            switch (Char.ToLower(ch))
            {
                case 'a':
                    Console.WriteLine("Vowel");
                    int asd = 1;
                    break;
                case 'e':
                    asd = 2;
                    Console.WriteLine("Vowel" + asd);
                    break;
                case 'i':
                    asd = 3;
                    Console.WriteLine("Vowel");
                    break;
                case 'o':
                    Console.WriteLine("Vowel");
                    break;
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                    // statement가 있는데 break;가 없으면 케이스 컨트롤이 제대로 안된다고 에러 뜸.
                case 'b':   // 이렇게 break;랑 아무 statement없으면 쓰면 or 효과. 아래로 쭉 흐름.
                case 'c':   // if (value == 'b' || value == 'c' || value == 'd')
                case 'd':
                    Console.WriteLine("Consonant");
                    break;
                default:
                    Console.WriteLine("Not a vowel");
                    break;
            }
        }
    }
}
