using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class ExceptionTest
    {
        int result;

        public ExceptionTest()
        {
            result = 0;
        }

        public void Test(int num1, int num2)
        {
            // 코스트를 좀 잡아먹어서 performance를 추구하는 곳에서는 자제해달라고 함
            try
            {
                // 실행구문
                result = num1 / num2;
            }
            catch (DivideByZeroException e) // 예외 발생?
            {
                // 에러출력
                Console.WriteLine("Exception caught: {0}", e);
            }
            // 성공하든 말든 무조건 실행
            // 예를들어 파일을 읽다가 close를 한다던지 db 연결 끊는다던지 써서 다른 잠재적 문제 예방
            // 모든 상황에 필수는 아님
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }

            // try 다음 catch가 여러개 붙어 있다면
            // specific한 에러가 해당되는 catch 하나 실행함.
            // 해당되는 specific한 에러가 없다면 마지막에 general exception catch 실행함.
            // 뭐든간에 catch는 단 한번만 실행됨.
            // 아래의 경우 DivideByZeroException이 나오면 해당되는 catch가 실행되고
            // 아닐 경우 모두 Exception을 통해 catch가 실행됨
            try
            {
            }
            catch (DivideByZeroException e)
            {
            }
            // general하게
            catch (Exception e)
            {
            }
            

            // 2 try-catch
            try
            {

            }
            catch
            {

            }

            // 3 try-finally
            try
            {

            }
            finally
            {

            }
        }
    }
}
