using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Painter
    {
        public static Color Color3 { get; set; } = Color.White;
        public static float LineWidth { get; set; } = 1;
        public static void Line(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.Lines);
            foreach (MyPoint point in points)
            {
                GL.Vertex2(point.x, point.y);
            }
            GL.End();
        }
        public static void LineStrip(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.LineStrip);
            foreach (MyPoint point in points)
            {
                GL.Vertex2(point.x, point.y);
            }
            GL.End();
        }
        public static void LineLoop(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (MyPoint point in points)
            {
                GL.Vertex2(point.x, point.y);
            }
            GL.End();
        }
        public static void Line_3(double x1, double y1, double x2, double y2, double size, double step)
        {
            if(step < Distance((x1, y1), (x2, y2)))
            {
                MyPoint central = Central((x1, y1), (x2, y2));
                DrawPoint(central, size);
                Line_3(x1, y1, central.x, central.y, size, step);
                Line_3(central.x, central.y, x2, y2, size, step);
            }
        }
        private static void DrawPoint(MyPoint point, double size)
        {
            GL.PointSize((float)size);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(point.x, point.y);
            GL.End();
        }
        private static MyPoint Central(MyPoint point1, MyPoint point2)
        {
            return new MyPoint((point1.x + point2.x) / 2, (point1.y + point2.y) / 2);
        }
        private static double Distance(MyPoint point1, MyPoint point2)
        {
            return Math.Sqrt(Math.Pow(point1.x - point2.x, 2) + Math.Pow(point1.y - point2.y, 2));
        }
    }
}
