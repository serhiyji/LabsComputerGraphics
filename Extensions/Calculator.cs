using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public static List<MyPoint> GenerateCirclePoints3D(MyPoint center, double radius, int count, double xAngle, double yAngle, double zAngle, double circleAngle = 360.0)
        {
            List<MyPoint> points = new List<MyPoint>();
            double angleIncrement = circleAngle / count;
            // angles -> radians
            double xAngleRadians = xAngle * Math.PI / 180.0, yAngleRadians = yAngle * Math.PI / 180.0, zAngleRadians = zAngle * Math.PI / 180.0;
            for (int i = 0; i < count + 1; i++)
            {
                // angle -> radians
                double angleRadians = (i * angleIncrement) * Math.PI / 180.0;
                // without rotation
                double pointX = radius * Math.Cos(angleRadians);
                double pointY = radius * Math.Sin(angleRadians);
                double pointZ = 0;

                // x-axis
                double tempY = pointY * Math.Cos(xAngleRadians) - pointZ * Math.Sin(xAngleRadians);
                double tempZ = pointY * Math.Sin(xAngleRadians) + pointZ * Math.Cos(xAngleRadians);
                pointY = tempY;
                pointZ = tempZ;

                // y-axis
                double tempX = pointX * Math.Cos(yAngleRadians) + pointZ * Math.Sin(yAngleRadians);
                pointZ = -pointX * Math.Sin(yAngleRadians) + pointZ * Math.Cos(yAngleRadians);
                pointX = tempX;

                // z-axis
                tempX = pointX * Math.Cos(zAngleRadians) - pointY * Math.Sin(zAngleRadians);
                tempY = pointX * Math.Sin(zAngleRadians) + pointY * Math.Cos(zAngleRadians);
                pointX = tempX;
                pointY = tempY;

                points.Add(new MyPoint(pointX + center.x, pointY + center.y, pointZ + center.z));
            }
            return points;
        }
    }
}
