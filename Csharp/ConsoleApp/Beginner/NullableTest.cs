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

        // int?, double? may have null value
        public void Test(int? i, double? d, DateTime? time, bool? selected)
        {
            // HasValue property is for checking whether it is null or not
            if (i.HasValue && d.HasValue)
                //this is the current class scope
                this._Sum = (double)i.Value + (double)d.Value;

            // check whehter time is null or not
            if (!time.HasValue)
                // occur an error
                throw new ArgumentException();
            else
                this._Time = time.Value;

            // often used with ?? operator
            //★★★★★
            // 인터뷰 문제: 
            // ??는 안에 있는 값이 null인지 체크하는 것.
            // selected가 null이 아니라면 _Selected에 selected를, 아니면 false 입력함.
            this._Selected = selected ?? false;

            // same as ??
            // 아래와 같은 4줄의 코드를 위의 한줄코드로 바꿀 수 있음.
            if (selected.HasValue)
                this._Selected = selected;
            else
                this._Selected = false;

            // same as above
            // Bell 회사에서 나왔던 인터뷰 문제
            // 조건(명제, HasValue)가 true면 selected, 아니면 false를 _Selected에 넣는다. 
            this._Selected = selected.HasValue ? selected : false;
        }        
    }
}
