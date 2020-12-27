using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Intermediate
{
    public class Asset : object
    {
        public string Name;
        public override string ToString()
        {
            // return base.ToString();
            return string.Format("Our Asset name {0}", this.Name);
        }
    }

    public class Stock : Asset  // inherits from Asset
    {
        public long SharesOwned;

        public override string ToString()
        {
            return base.ToString() + string.Format(" and SharesOwned {0}", SharesOwned);
        }
    }

    public class House : Asset  // inherits from Asset
    {        
        public decimal Mortgage;
    }
}
