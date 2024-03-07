using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using System.Drawing;

namespace Lab3
{
    public class WindowLab3 : BaseWindow
    {
        public WindowLab3() : base(BaseWindow.DefaultSetupWindow()) { }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //this.Task1();
            this.Task2();
            
            SwapBuffers();
            base.OnRenderFrame(args);
        }
        private Counter T1CounterPos = new Counter(-0.7, 0.7, 0.01, 60, 0);
        private Counter T1CounterSize = new Counter(0.2, 0.35, 0.001, 60, 0.2);
        private void Task1()
        {
            double val = T1CounterPos.Next;
            TruncatedHexagonalPyramid.Draw(val, -val, T1CounterSize.Next, Color.White, Color.Red);
        }
        //private EllipseHandler EllipseHandler = new EllipseHandler(0, 0, 0.5, 0.7, 0.005, 45, 60);
        //private Counter T2CounterSize = new Counter(0.2, 0.3, 0.00015, 60, 0.25);
        private EllipseHandler EllipseHandler = new EllipseHandler(0, 0, 0.5, 0.7, 0.005, 45, 60);
        private Counter T2CounterSize = new Counter(0.2, 0.3, 0.00015, 60, 0.25);
        // 1.898
        // 1.989/0.005=397.8
        // 0.1/    =397.8
        private void Task2()
        {
            double scale = T2CounterSize.Next;
            TruncatedHexagonalPyramid.Draw(EllipseHandler.Next, scale, Color.White, Color.Red);
            Title = scale.ToString();
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab3 windowLab1 = new WindowLab3())
            {
                windowLab1.Run();
            }
        }
    }
}