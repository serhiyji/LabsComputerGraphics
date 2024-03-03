using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class MyPoint
    {
        public double x { get; set; }
        public double y { get; set; }
        public MyPoint(double _x, double _y)
        {
            x = _x;
            y = _y;
        }
        public static implicit operator MyPoint((double x, double y) values) => new MyPoint(values.x, values.y);
        public override string ToString() => $"X:{x} Y:{y}";
    }
}
