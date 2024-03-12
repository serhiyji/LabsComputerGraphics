using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Calculator
    {
        public static MyPoint Central(MyPoint point1, MyPoint point2)
        {
            return new MyPoint((point1.x + point2.x) / 2, (point1.y + point2.y) / 2);
        }
        public static double Distance(MyPoint point1, MyPoint point2)
        {
            return Math.Sqrt(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2));
        }
    }
}
