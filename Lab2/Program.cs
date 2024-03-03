using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Drawing;

namespace Lab2
{
    public class WindowLab2 : BaseWindow
    {
        private List<(MyPoint point, double scale, Color visible, Color notVisible)> Values = new();
       
        public WindowLab2() : base(BaseWindow.DefaultSetupWindow())
        {
            Random random = new Random();
            List<Color> colors = new List<Color>() { Color.Brown, Color.AliceBlue, Color.Red, Color.Blue, Color.White, Color.Yellow, Color.Green};
            for (int i = 0; i < 10; i++)
            {
                Values.Add(new(
                    new MyPoint(random.Next(-7, 8) / 10d, random.Next(-7, 8) / 10d), 
                    random.Next(1, 4) / 10d,
                    colors[random.Next(colors.Count)], colors[random.Next(colors.Count)]));
            }
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
        private void Task1()
        {
            foreach (var values in Values)
            {
                TruncatedHexagonalPyramid.Draw(values.point, values.scale, values.visible, values.notVisible);
            }
        }
        private void Task2()
        {
            TruncatedHexagonalPyramid.Draw(0, 0, 1, Color.White, Color.Red);
            TruncatedHexagonalPyramid.Draw(0, -0.2, 0.5, Color.White, Color.Red);
            TruncatedHexagonalPyramid.Draw(0, -0.3, 0.25, Color.White, Color.Red);
            TruncatedHexagonalPyramid.Draw(0, -0.35, 0.125, Color.White, Color.Red);
        }
        private Counter CounterPos = new Counter(-0.7, 0.7, 0.01, 60, 0);
        private void Task3()
        {
            double val = CounterPos.Next;
            TruncatedHexagonalPyramid.Draw(val, 0, 0.3, Color.White, Color.Red);
        }
    }
    public static class Program
    {
        public static void Main()
        {
            using (WindowLab2 windowLab1 = new WindowLab2())
            {
                windowLab1.Run();
            }
        }
    }
}