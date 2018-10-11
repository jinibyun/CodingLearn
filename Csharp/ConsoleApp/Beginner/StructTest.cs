using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    // value type and reference type
    // diff between stuct and class
    public struct StructTest    //Struct : 복합 데이타 저장소 ex. 화장품보관함: 립스틱넣는곳, 틴트넣는곳, 파우더넣는곳 .. = Class 와 유사
        //struct 데이타타입도 value타입이다 (레퍼런스타입의 반대)
    {
        public int X;
        public int Y;

        public StructTest(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}
