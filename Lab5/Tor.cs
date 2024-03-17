using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public static class Tor
    {
        public static List<List<MyPoint>> GetSectionTor(MyPoint center, double radiusTor, double radiusSection, int countSection, int countPointsInSection = 20, double angleSectionTor = 360.0)
        {
            List<MyPoint> centrsSection = Calculator.GenerateCirclePoints3D(center, radiusTor, countSection, 0, 0, 0, angleSectionTor);
            List<List<MyPoint>> data = new List<List<MyPoint>>();
            double stepAngle = angleSectionTor / (double)countSection;
            int i = 0;
            foreach (var pointCentrSection in centrsSection)
            {
                data.Add(Calculator.GenerateCirclePoints3D(pointCentrSection, radiusSection, countPointsInSection, 90, 0, i * stepAngle));
                i++;
            }
            return data;
        }
        public static void Draw(List<List<MyPoint>> data)
        {
            Painter.LineLoopV3(data.LastOrDefault());
            for (int i = 0; i < data.Count - 1; i++)
            {
                Painter.LineLoopV3(data[i]);
                for (int j = 0; j < data[i].Count; j++)
                {
                    Painter.LineStripV3(data[i][j], data[i + 1][j]);
                }
            }
        }
    }
}
