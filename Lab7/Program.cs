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
            Painter.Line_3(0.5, 0.5, -0.5, -0.5, 5, 0.01);
            SwapBuffers();
            base.OnRenderFrame(args);
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