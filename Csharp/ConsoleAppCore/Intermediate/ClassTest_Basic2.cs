using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCore.Intermediate
{
    public class ClassTest_Basic2
    {
        decimal currentPrice;           // The private "backing" field
        decimal sharesOwned;           // The private "backing" field
        decimal interestRate = 0.012456M;


        public ClassTest_Basic2()
        {
            BenchmarkShare = 99;
        }
        
        public decimal CurrentPrice     // The public property
        {
            get { return currentPrice; }
            set { currentPrice = value; }
        }

        public decimal SharesOwned     // The public property
        {
            get { return sharesOwned; }
            set { sharesOwned = value; }
        }

        // automatic property
        public decimal BenchmarkPrice { get; set; } // automatically it generates variable on compile

        public decimal BenchemarkPrice
        {
            get;
            set;
        }

        // automatic property : readonly (public and private)
        public int BenchmarkShare { get; }

        // readonly property
        public decimal Worth
        {
            get { return currentPrice * sharesOwned; }
        }
    }
}
