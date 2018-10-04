using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class StringTest
    {
        public void Test()
        {
            // immutable    한번 값이 정해지면 GarbageCollection이 돌지 않는 한 없어지지 않는다는 뜻.. 
            // Heap Memory에 저장되는 Reference Type들은 ValueType과 달리
            // 마지막 }에 도달해도 없어지지 않음.
            // 이것들을 GarbageCollection을 통해 삭제함
            string s1 = "C#";
            string s2 = "Programming";

            // char 
            char c1 = 'A';
            char c2 = 'B';

            // concatenation
            string s3 = s1 + " " + s2;
            Console.WriteLine("String Concatenation: {0}", s3);

            // substring
            string s3substring = s3.Substring(1, 5);    // output: # Pro
            Console.WriteLine("Substring: {0}", s3substring);

            string s = "C# Studies";

            // String is array of char
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, s[i]);
            }

            // string to charArray
            string str = "Hello";
            char[] charArray = str.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                Console.WriteLine(charArray[i]);
            }

            // char array to string
            char[] charArray2 = { 'A', 'B', 'C', 'D' };
            s = new string(charArray2);

            Console.WriteLine(s);

            // one char has one ASCII code which is actual number value. Therefore it can be operated with plus, minus, multiply and divide
            // NOTE: char operation is different from string operation
            // ref: 
            char c11 = 'A';
            char c22 = (char)(c11 + 3);
            Console.WriteLine(c22);

            // string and stringBuilder
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 26; i++)
            {
                sb.Append(i.ToString());
                sb.Append(System.Environment.NewLine);
            }
            string sbstring = sb.ToString();

            // The worst example!!!!!!!!!!
            // 이러면 매번 새로운 sBig이 계속 생기는데 이게 immutable이라 가비지콜렉터 돌 때까지 안없어짐.
            // 메모리 엄청나게 잡아먹힘!!!!
            // 아래 예제에서는 string object가 10000개 생김!
            // 그래서 StringBuilder가 쓰임!!   인터뷰 문제!!
            // StringBuilder는 하나의 StringBuilder 하나만 만들어서 그것에 계속 append만 하기 때문에
            // 더 많은 오브젝트가 생길 일이 없음.
            //string sBig = "";
            //for (int i = 1; i <= 10000; i++)
            //{
            //    sBig = sBig + i.ToString();
            //}

            Console.WriteLine(sbstring);
        }
    }
}
