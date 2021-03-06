﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Beginner
{
    public class NullableTest
    {
        // All referenc type does not need to be nullable because it is originally allowed type of null.
        // Therefore, all value type needs to have nullable
        double _Sum = 0;
        DateTime _Time;
        bool? _Selected;
        public void Test(int? i, double? d, DateTime? time, bool? selected)
        {
            if (i.HasValue && d.HasValue)
                _Sum = (double)i.Value + (double)d.Value;

            // check whehter time is null or not
            if (!time.HasValue) 
            { 
                throw new Exception();
            }
            else
                _Time = time.Value;

            // often used with ?? operator
            _Selected = selected ?? false;
        }        
    }
}
