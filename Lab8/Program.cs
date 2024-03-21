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
        List<MyPoint> points;
        List<List<MyPoint>> data = new List<List<MyPoint>>();
        int min = 0, max = 10, current = 0, rendermax = 0;
        //Counter counter = new Counter(1, 6, 1, 1, 0, true);
        public WindowLab8() : base(BaseWindow.DefaultSetupWindow()) 
        {
            data.Add(FractalSnowflakeKohi.GetRightTriangle((0, 0), 1.5));
            //for (int i = 0; i < 6; i++)
            //{
            //    data.Add(FractalSnowflakeKohi.NextIteration(data.LastOrDefault()));
            //}
            points = data[0];
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //points = data[(int)counter.Next];
            Painter.LineLoopV3(points);
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
                        points = data[current];
                    }
                    else if (current == rendermax && current != max)
                    {
                        DateTime start = DateTime.UtcNow;
                        data.Add(FractalSnowflakeKohi.NextIteration(data[current]));
                        DateTime end = DateTime.UtcNow;
                        Console.WriteLine($"{current} -> {current + 1} {end - start}");
                        current++;
                        rendermax++;
                        points = data[current];
                    }
                    break;
                case OpenTK.Windowing.GraphicsLibraryFramework.Keys.Down:
                    if (current != min)
                    {
                        current -= 1;
                        points = data[current];
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