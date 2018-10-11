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
            try
            {
                result = num1 / num2;   //실행구문 파일열고->닫기 닫을때 ,문제생긴다면 익셉션핸들링 실행 : 나누기 시도
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Exception caught: {0}", e);  //혹시발생할지 모르는 에러(익셉션)에 대한 핸들링 : 0으로 나누기 시도되는 경우(에러)
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught: {0}", e);
            }
            finally //써도되고 안써도됨 (옵션)
            {
                Console.WriteLine("Result: {0}", result);   //무조건 실행되는 경우 익셉션핸들링 후에 무조건 실행시키는것
            }
        }
    }
}
