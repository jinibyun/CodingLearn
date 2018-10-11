﻿using System;
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
        // && and, || or , ! not, ?? null check
        double _Sum = 0;
        DateTime _Time;
        bool? _Selected;

        public void Test(int? i, double? d, DateTime? time, bool? selected)
        {
            if (i.HasValue && d.HasValue)
                this._Sum = (double)i.Value + (double)d.Value;

            // check whehter time is null or not
            if (!time.HasValue)
                throw new ArgumentException();
            else
                this._Time = time.Value;

            // often used with ?? operator
            this._Selected = selected ?? false;

            //same as above
            if (selected.HasValue)
                this._Selected = selected;
            else
                this._Selected = false;
            //same as above
            this._Selected = selected.HasValue ? selected.HasValue : false;
        }        
    }
}
