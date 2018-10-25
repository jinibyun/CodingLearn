using System;
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


    public class Stock : Asset   // inherits from Asset      : = inherit

    {
        public long SharesOwned;
    }


    //same as above
    //public class Stock
    //{
        //public string Name;
        //public long SharesOwned;
    //}

    public class House : Asset   // inherits from Asset
    {

        public decimal Mortgage;
    }
}
