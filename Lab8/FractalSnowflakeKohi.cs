using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class FractalSnowflakeKohi
    {
        public static List<MyPoint> GetRightTriangle(MyPoint center, double length) => new() {
                (center.x - length / 2, center.y + Math.Sqrt(3) * length / 6),
                (center.x + length / 2, center.y + Math.Sqrt(3) * length / 6),
                (center.x, center.y - Math.Sqrt(3) * length / 3)
            };
        
        public static List<MyPoint> GenerateKochSnowflake(MyPoint center, int iterations, double length)
        {
            List<MyPoint> points = GetRightTriangle(center, length);
            for (int i = 0; i < iterations; i++)
            {
                points = NextIteration(points);
            }
            return points;
        }
        public static List<MyPoint> NextIteration(List<MyPoint> points)
        {
            List<MyPoint> newPoints = new List<MyPoint>();
            for (int j = 0; j < points.Count; j++)
            {
                MyPoint p1 = points[j], p2 = points[(j + 1) % points.Count];
                newPoints.Add(p1);
                newPoints.Add(new MyPoint((2 * p1.x + p2.x) / 3, (2 * p1.y + p2.y) / 3));
                newPoints.Add(new MyPoint((p1.x + p2.x) / 2 - Math.Sqrt(3) / 6 * (p2.y - p1.y), (p1.y + p2.y) / 2 + Math.Sqrt(3) / 6 * (p2.x - p1.x)));
                newPoints.Add(new MyPoint((p1.x + 2 * p2.x) / 3, (p1.y + 2 * p2.y) / 3));
            }
            return newPoints;
        }
    }
}
