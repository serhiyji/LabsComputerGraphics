using OpenTK.Mathematics;
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
        public double z { get; set; }
        public MyPoint(double _x, double _y, double _z = 0)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public static implicit operator MyPoint((double x, double y) values) => new MyPoint(values.x, values.y, 0);
        public static implicit operator MyPoint((double x, double y, double z) values) => new MyPoint(values.x, values.y, values.z);

        public static implicit operator MyPoint(Vector3 vector) => new MyPoint(vector.X, vector.Y, vector.Z);

        public static implicit operator Vector3(MyPoint point) => new Vector3((float)point.x, (float)point.y, (float)point.z);
        public override string ToString() => $"X:{x} Y:{y} Z:{z}";
    }
}
