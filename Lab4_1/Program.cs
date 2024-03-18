using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using System.Drawing;

namespace Lab4_1
{
    public class WindowLab4_1 : BaseWindow
    {
        public WindowLab4_1() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Rotate(1, 0, 0, 1);
            Octahedron.Draw((0, 0, 0), 1, Color.White);
            SwapBuffers();
            base.OnRenderFrame(args);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab4_1 windowLab1 = new WindowLab4_1())
            {
                windowLab1.Run();
            }
        }
    }
}
