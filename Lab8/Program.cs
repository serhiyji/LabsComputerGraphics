using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Collections;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Lab8
{
    public class WindowLab8 : BaseWindow
    {
        List<List<MyPoint>> data = new List<List<MyPoint>>();
        int min = 0, max = 10, current = 0, rendermax = 0;
        //Counter counter = new Counter(1, 6, 1, 1, 0, true);

        List<MyPoint> pointsT2 = SerpinskisTriangle.GetSerpinskisTriangleRandom(FractalSnowflakeKohi.GetRightTriangle((0, 0), 1.5), 1_000_000, (0, 0));
        public WindowLab8() : base(BaseWindow.DefaultSetupWindow()) 
        {
            data.Add(FractalSnowflakeKohi.GetRightTriangle((0, 0), 1.5));
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Task1
            //points = data[(int)counter.Next];
            //Painter.LineLoopV3(data[current]);

            // Task2
            Painter.PointV3(pointsT2, 1);

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.Key)
            {
                case OpenTK.Windowing.GraphicsLibraryFramework.Keys.Up:
                    if(current + 1 <= rendermax)
                    {
                        current++;
                    }
                    else if (current == rendermax && current != max)
                    {
                        data.Add(FractalSnowflakeKohi.NextIteration(data[current]));
                        current++;
                        rendermax++;
                    }
                    break;
                case OpenTK.Windowing.GraphicsLibraryFramework.Keys.Down:
                    if (current != min)
                    {
                        current -= 1;
                    }
                    break;
            }
            double sizeInBytes = System.GC.GetTotalMemory(true);
            double sizeInMegabytes = sizeInBytes / (1024 * 1024);
            Title = $"{current} {sizeInMegabytes}";
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab8 windowLab1 = new WindowLab8())
            {
                windowLab1.Run();
            }
        }
    }
}