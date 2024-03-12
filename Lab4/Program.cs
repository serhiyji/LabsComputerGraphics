using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Lab4
{
    public class WindowLab4 : BaseWindow
    {
        public WindowLab4() : base(BaseWindow.DefaultSetupWindow())
        {
            GL.Rotate(10, 1, 0, 0);
            GL.Rotate(10, 0, 1, 0);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //this.Task1();
            //this.Task2();
            this.Task3();
            SwapBuffers();
            base.OnRenderFrame(args);
        }
        public void Task1()
        {
            GL.Rotate(0.1, 0, 0, 1);
            Painter.LineV3((0.5, 0.5), (-0.5, -0.5));
            Painter.LineV3((-0.5, 0.5), (0.5, -0.5));
            Painter.LineLoopV3((0.5, 0.5), (-0.5, 0.5), (-0.5, -0.5), (0.5, -0.5));
        }
        public void Task2()
        {
            GL.Rotate(0.2, 1, 0, 0);
            Octahedron.Draw((0, 0, 0), 1, Color.White);
        }
        public void Task3()
        {
            GL.Rotate(0.2, 1, 0, 0);
            Octahedron.DrawOctahedronTriangles((0, 0, 0), 1);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab4 windowLab2 = new WindowLab4())
            {
                windowLab2.Run();
            }
        }
    }
}