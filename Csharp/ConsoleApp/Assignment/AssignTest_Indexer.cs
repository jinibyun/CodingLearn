using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Assignment
{
    class AssignTest_Indexer
    {
        string[] words = "My pet's name is monky".Split();

        
        public string this[int wordNum]      // indexer
        {
            get { return words[wordNum]; }
            set { words[wordNum] = value; }
        }
    }
}
