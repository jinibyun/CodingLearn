using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public enum City
    {
        // 연산 상에서 단순히 정수형으로 충분한데 가독성이 안좋아서 Enum이 쓰이게 됨
        // 예를들어 그냥 0, 1, 5, 10으로만 나타내면 나중에 다른 사람이 코드 읽을 때 이게 뭔지 모르니까.
        // 그래서 명시적으로 쓰기 위해 Enum을 씀
        // Value Type에 속함
        // 
        // 100, 200, 300 으로 처음부터 적용하면 4번째는 301로 시작 (아마도..)
        Seoul,   // 0
        Daejun,  // 1
        Busan = 5,  // 5
        Jeju = 10   // 10
    }
    // Enum도 데이터타입이기 때문에 보통 클래스 밖에서 정의됨!!

    public class EnumTest
    {
        City myCity;

        public void Test()
        {            
            // Access to enum
            myCity = City.Seoul;

            // enum to int casting
            int cityValue = (int)myCity;

            if (myCity == City.Seoul) // enum comparison
            {
                Console.WriteLine("Welcome to Seoul");
            }
        }
    }
}
