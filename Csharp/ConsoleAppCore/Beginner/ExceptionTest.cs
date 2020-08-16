using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Beginner
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
                result = num1 / num2;
                
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Specific Exception caught: {0}", e);
            }
            //catch
            //{
            //    throw new Exception();
            //}
            catch (Exception e)
            {
                Console.WriteLine("Very general Exception caught: {0}", e);
            }
            finally
            {
                Console.WriteLine("Result: {0}", result);
            }
        }
    }
}
