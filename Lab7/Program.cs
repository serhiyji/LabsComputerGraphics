using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Lab7
{
    public class WindowLab7 : BaseWindow
    {
        public WindowLab7() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            Line_3(0.5, 0.5, -0.5, -0.5, 5, 0.01);
            SwapBuffers();
            base.OnRenderFrame(args);
        }
        public static void Line_3(double x1, double y1, double x2, double y2, double size, double step)
        {
            if (step < Calculator.Distance((x1, y1), (x2, y2)))
            {
                MyPoint central = Calculator.Central((x1, y1), (x2, y2));
                Painter.Point(central, size);
                Line_3(x1, y1, central.x, central.y, size, step);
                Line_3(central.x, central.y, x2, y2, size, step);
            }
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab7 windowLab1 = new WindowLab7())
            {
                windowLab1.Run();
            }
        }
    }
}