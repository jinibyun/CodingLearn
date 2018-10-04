using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class VariableAndConstant
    {
        // global in class
        int globalVar;
        // globalVar will die after the last '}' of this class
        // it means its scope is only inside of this class

        // difference between constant and readonly
        // 이것들은 variable 이름이 대문자로 시작함.
        // const -> 상수. 절대 안바뀜
        const int MAXVALUE = 1024;
        // readonly -> 이것은 딱 한번 값을 바꿀 수 있음. 이것이 const와 차이점.
        // constructor 내에서만 값이 지정될 수 있음. 다른 메소드에서는 값 지정 안됨
        // it can be assigned once in the constructor only
        readonly int Max;

        // constructor (생성자)
        // 클래스 이름과 같음
        public VariableAndConstant()
        {
            Max = 1;
        }
        public void Test()
        {
            Console.WriteLine(globalVar); // default value 0 has been assgined to the int variable

            // local
            // localVar will die when reach this method's last '}'
            // it means its scope is only inside of this method
            int localVar;        
            localVar = 100;

            Console.WriteLine(globalVar);
            Console.WriteLine(localVar);
        }        
    }
}
