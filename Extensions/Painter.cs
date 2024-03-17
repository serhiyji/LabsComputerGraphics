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
        public static void LineV3(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.Lines);
            foreach (MyPoint point in points)
            {
                GL.Vertex3(point.x, point.y, point.z);
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
        public static void LineStripV3(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.LineStrip);
            foreach (MyPoint point in points)
            {
                GL.Vertex3(point.x, point.y, point.z);
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

        public static void LineLoopV3(params MyPoint[] points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (MyPoint point in points)
            {
                GL.Vertex3(point.x, point.y, point.z);
            }
            GL.End();
        }

        public static void LineLoopV3(List<MyPoint> points)
        {
            GL.LineWidth(LineWidth);
            GL.Color3(Color3);
            GL.Begin(PrimitiveType.LineLoop);
            foreach (MyPoint point in points)
            {
                GL.Vertex3(point.x, point.y, point.z);
            }
            GL.End();
        }

        public static void TrianglesV3(Color color, MyPoint point1, MyPoint point2, MyPoint point3)
        {
            GL.Color3(color);
            GL.Begin(PrimitiveType.Triangles);
            GL.Vertex3(point1.x, point1.y, point1.z);
            GL.Vertex3(point2.x, point2.y, point2.z);
            GL.Vertex3(point3.x, point3.y, point3.z);
            GL.End();
        }

        
        public static void Point(MyPoint point, double size = 3)
        {
            GL.PointSize((float)size);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex2(point.x, point.y);
            GL.End();
        }
        public static void PointV3(MyPoint point, double size = 3)
        {
            GL.PointSize((float)size);
            GL.Begin(PrimitiveType.Points);
            GL.Vertex3(point.x, point.y, point.z);
            GL.End();
        }
    }
}
