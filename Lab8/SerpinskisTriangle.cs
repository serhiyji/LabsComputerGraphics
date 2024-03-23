using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public static class SerpinskisTriangle
    {
        public static List<MyPoint> GetSerpinskisTriangleRandom(List<MyPoint> pointsCorner, int count, MyPoint startPoint)
        {
            List<MyPoint> points = new List<MyPoint>();
            Random random = new Random();
            MyPoint currentPoint = startPoint;
            for (int i = 0; i < count; i++)
            {
                MyPoint point = pointsCorner[random.Next(0,pointsCorner.Count)];
                currentPoint = Calculator.Central(point, currentPoint);
                points.Add(currentPoint);
            }

            return points;
        }
    }
}
