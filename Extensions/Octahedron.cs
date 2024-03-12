using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class Octahedron
    {
        public static void Draw(MyPoint point, double scale, Color color)
        {
            double _0_5 = 0.5 * scale;
            double x = point.x, y = point.y, z = point.z;
            Painter.LineWidth = 2;
            Painter.Color3 = color;
            Painter.LineStripV3(
                (x, y - _0_5, z), (x, y, z + _0_5), (x + _0_5, y, z), (x, y + _0_5, z),
                (x, y, z + _0_5), (x - _0_5, y, z), (x, y - _0_5, z),
                (x, y, z - _0_5), (x - _0_5, y, z), (x, y + _0_5, z),
                (x, y, z - _0_5), (x + _0_5, y, z), (x, y - _0_5, z)
            );
        }

        public static void DrawOctahedronTriangles(MyPoint point, double scale)
        {
            double _0_5 = 0.5 * scale;
            double x = point.x, y = point.y, z = point.z;

            Painter.TrianglesV3(Color.Pink, (x, y - _0_5, z), (x, y, z - _0_5), (x + _0_5, y, z));
            Painter.TrianglesV3(Color.White, (x, y - _0_5, z), (x, y, z - _0_5), (x - _0_5, y, z));

            Painter.TrianglesV3(Color.Yellow, (x, y, z - _0_5), (x + _0_5, y, z), (x, y + _0_5, z));
            Painter.TrianglesV3(Color.Gray, (x, y, z - _0_5), (x - _0_5, y, z), (x, y + _0_5, z));

            Painter.TrianglesV3(Color.Red, (x, y - _0_5, z), (x, y, z + _0_5), (x + _0_5, y, z));
            Painter.TrianglesV3(Color.Green, (x, y - _0_5, z), (x, y, z + _0_5), (x - _0_5, y, z));

            Painter.TrianglesV3(Color.Brown, (x, y, z + _0_5), (x + _0_5, y, z), (x, y + _0_5, z));
            Painter.TrianglesV3(Color.Indigo, (x, y, z + _0_5), (x - _0_5, y, z), (x, y + _0_5, z));
        }
    }
}
