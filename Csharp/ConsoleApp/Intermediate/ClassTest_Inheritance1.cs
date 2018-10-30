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
        private string Price;
        protected int YearOfBirth;
    }

    public class Stock : Asset  // inherits from Asset
    {
        public long SharesOwned;
    }

    public class House  : Asset  // inherits from Asset
    {        
        public decimal Mortgage;
    }
}
