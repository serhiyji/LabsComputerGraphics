using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Lab1
{
    public class WindowLab1 : BaseWindow
    {
        public WindowLab1() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            TruncatedHexagonalPyramid.Draw(0, 0, 1, Color.White, Color.Red);
            SwapBuffers();
            base.OnRenderFrame(args);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using(WindowLab1 windowLab1 = new WindowLab1())
            {
                windowLab1.Run();
            }
        }
    }
}