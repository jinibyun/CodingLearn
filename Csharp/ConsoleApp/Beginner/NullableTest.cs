using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    public class NullableTest
    {
        // All referenc type does not need to be nullable because it is originally allowed type of null.
        // Therefore, all value type needs to have nullable
        double _Sum = 0;
        DateTime _Time;
        bool? _Selected;

        public void Test(int? i, double? d, DateTime? time, bool? selected) //i는 null값을 가질 수 있다고 accept해둔것
        {
            if (i.HasValue && d.HasValue)   
                this._Sum = (double)i.Value + (double)d.Value;

            // check whehter time is null or not
            if (!time.HasValue)
                throw new ArgumentException();  //throw: 시스템에 익셉션을 던져주는것 (익셉션발생)
            else
                this._Time = time.Value;

            // often used with ?? operator : Null체크 만약 null이면 뒤에 값을 왼쪽에 변수에 넣어주는것
            this._Selected = selected ?? false;

            //same as above
            if (selected.HasValue)
                this._Selected = selected;
            else
                this._Selected = false;

            //same as above 조건 ? a : b      :조건이 true면 a가 실행되고 false면 b가 실행된다. (단항조건문)
            // bool t =  canada == "country" ? true : false;
            this._Selected = selected.HasValue ? selected.HasValue : false;
        }        
    }
}
