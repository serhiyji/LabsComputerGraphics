using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Lab5
{
    public class WindowLab5 : BaseWindow
    {
        List<List<MyPoint>> Tora = Tor.GetSectionTor((0, 0), 0.65, 0.2, 20, 20, 180.0);
        public WindowLab5() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Painter.PointV3((0, 0, 0), 3);

            GL.Rotate(0.3, 1, 1, 1);
            Tor.Draw(Tora);

            SwapBuffers();
            base.OnRenderFrame(args);
        }
    }
    
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab5 windowLab1 = new WindowLab5())
            {
                windowLab1.Run();
            }
        }
    }
}