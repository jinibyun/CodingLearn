﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Intermediate
{
    public class Asset
    {
        public string Name;
    }

    public class Stock : Asset   // inherits from Asset
    {
        //public string Name; it is inherited from the parent class
        public long SharesOwned;
    }

    public class House : Asset   // inherits from Asset
    {
        public decimal Mortgage;

        
    }
}
