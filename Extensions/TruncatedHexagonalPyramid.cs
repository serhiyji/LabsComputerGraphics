using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class TruncatedHexagonalPyramid
    {
        public static void Draw(MyPoint point, double scale, Color visible, Color notVisible) => Draw(point.x, point.y, scale, visible, notVisible);
        public static void Draw(double x, double y, double scale, Color visible, Color notVisible)
        {
            double _0_1 = 0.1 * scale, _0_25 = 0.25 * scale, _0_4 = 0.4 * scale, _0_45 = 0.45 * scale, _0_5 = 0.5 * scale, _0_7 = 0.7 * scale, _0_8 = 0.8 * scale, _0_9 = 0.9 * scale;

            Painter.Color3 = notVisible;
            Painter.LineStrip((x - _0_8, y - _0_45), (x - _0_4, y - _0_1), (x + _0_4, y - _0_1), (x + _0_8, y - _0_45));

            Painter.Line((x - _0_4, y - _0_1), (x - _0_25, y + _0_9), (x + _0_4, y - _0_1), (x + _0_25, y + _0_9));

            Painter.Color3 = visible;
            Painter.LineStrip((x - _0_8, y - _0_45), (x - _0_4, y - _0_8), (x + _0_4, y - _0_8), (x + _0_8, y - _0_45));

            Painter.Line((x - _0_8, y - _0_45), (x - _0_5, y + _0_7), (x - _0_4, y - _0_8), (x - _0_25, y + _0_5), (x + _0_4, y - _0_8), (x + _0_25, y + _0_5), (x + _0_8, y - _0_45), (x + _0_5, y + _0_7));

            Painter.LineLoop((x - _0_5, y + _0_7), (x - _0_25, y + _0_9), (x + _0_25, y + _0_9), (x + _0_5, y + _0_7), (x + _0_25, y + _0_5), (x - _0_25, y + _0_5));
        }
    }
}
