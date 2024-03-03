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
    }
}
