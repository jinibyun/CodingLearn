using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Beginner
{
    // value type and reference type
    // diff between stuct and class
    // 복합적인 데이터 저장소 (복합데이터저장소)
    // 여자가방처럼 핸드폰, 필기도구, 화장도구를 넣을 수 있음.
    // class랑 비슷한데 다른 점은 struct는 valuetype임. (reference 아님)
    public struct StructTest
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
