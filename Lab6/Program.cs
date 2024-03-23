using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;

namespace Lab6
{
    public class WindowLab6 : BaseWindow
    {
        public WindowLab6() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            SwapBuffers();
            base.OnRenderFrame(args);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab6 windowLab1 = new WindowLab6())
            {
                windowLab1.Run();
            }
        }
    }
}