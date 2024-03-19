using Extensions;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using System.Drawing;
using System.Linq;
using System.Numerics;
using Vector3 = OpenTK.Mathematics.Vector3;
using Vector4 = OpenTK.Mathematics.Vector4;

namespace Lab4_1
{
    public class WindowLab4_1 : BaseWindow
    {
        private List<MyPoint> basepoints = new List<MyPoint>() 
        {
            (0, 0 - 0.5, 0), (0, 0, 0 + 0.5), (0 + 0.5, 0, 0), (0, 0 + 0.5, 0),
            (0, 0, 0 + 0.5), (0 - 0.5, 0, 0), (0, 0 - 0.5, 0),
            (0, 0, 0 - 0.5), (0 - 0.5, 0, 0), (0, 0 + 0.5, 0),
            (0, 0, 0 - 0.5), (0 + 0.5, 0, 0), (0, 0 - 0.5, 0)
        };
        private MyPoint center = new MyPoint(0, 0, 0);
        public WindowLab4_1() : base(BaseWindow.DefaultSetupWindow())
        {
            GL.Rotate(10, 1, 1, 0);
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            //this.Task1(); // Зсув
            //this.Task2(); // відображення відносно однієї з осей (x)
            //this.Task3(); // відображення відносно заданої прямої
            //this.Task4(); // масштабування(збільшення та зменшення)
            this.Task5(); // поворот на заданий кут

            SwapBuffers();
            base.OnRenderFrame(args);
        }

        private List<MyPoint> Landslide(List<MyPoint> points, Vector3 vector) => points.Select(point => (MyPoint)(point + vector)).ToList();
        // відображення відносно заданої прямої (для окремої точки)
        public static Vector3 ReflectPoint(Vector3 point, Vector3 linePoint1, Vector3 linePoint2)
        {
            Vector3 lineDirection = Vector3.Normalize(linePoint2 - linePoint1);
            Vector3 lineToPoint = point - linePoint1;
            return point + (2 * ((lineDirection * Vector3.Dot(lineToPoint, lineDirection)) - lineToPoint));
        }
        public static Vector3 ScalePoint(Vector3 point, Vector3 center, float scaleX, float scaleY, float scaleZ)
        {
            return (Vector3.TransformPosition((point - center), Matrix4.CreateScale(scaleX, scaleY, scaleZ))) + center;
        }
        public static Vector3 RotatePoint(Vector3 point, Vector3 center, float angleDegrees)
        {
            float angleRadians = MathHelper.DegreesToRadians(angleDegrees);
            Vector3 translatedPoint = point - center;
            float newX = translatedPoint.X * (float)Math.Cos(angleRadians) - translatedPoint.Y * (float)Math.Sin(angleRadians);
            float newY = translatedPoint.X * (float)Math.Sin(angleRadians) + translatedPoint.Y * (float)Math.Cos(angleRadians);
            return new Vector3(newX, newY, point.Z) + center;
        }

        private void Task1()
        {
            List<MyPoint> old = basepoints;
            List<MyPoint> newpoints = this.Landslide(old, new Vector3(0.1f, 0.1f, 0.1f));
            Painter.LineStripV3(old, Color.White);
            Painter.LineStripV3(newpoints, Color.Red);
        }

        private void Task2()
        {
            List<MyPoint> first = Landslide(basepoints, new Vector3(0.5f, 0.5f, 0));
            List<MyPoint> second = first.Select(point => new MyPoint(point.x, -point.y, point.z)).ToList();
            Painter.LineStripV3(first, Color.White);
            Painter.LineStripV3(second, Color.Red);
        }

        private void Task3()
        {
            Vector3 linePoint1 = new Vector3(1, -1, 0), linePoint2 = new Vector3(-1, 1, 0);
            List<MyPoint> first = Landslide(basepoints, new Vector3(0.5f, 0.5f, 0));
            List<MyPoint> second = first.Select(point => (MyPoint)ReflectPoint(point, linePoint1, linePoint2)).ToList();
            Painter.LineStripV3(first, Color.White);
            Painter.LineStripV3(second, Color.Red);
        }

        private void Task4()
        {
            List<MyPoint> first = Landslide(basepoints, new Vector3(0.5f, 0.5f, 0));
            List<MyPoint> second = Landslide(first, new Vector3(-1.0f, -1.0f, 0)).Select(point => (MyPoint)ScalePoint(point, new Vector3(-0.5f, -0.5f, 0), 0.5f, 0.5f, 0.5f)).ToList();
            Painter.LineStripV3(first, Color.White);
            Painter.LineStripV3(second, Color.Red);
        }

        private void Task5() 
        {
            List<MyPoint> first = basepoints;
            List<MyPoint> second = first.Select(point => (MyPoint)RotatePoint(point, new MyPoint(0, -0.5, 0), 45.0f)).ToList();
            Painter.LineStripV3(first, Color.White);
            Painter.LineStripV3(second, Color.Red);
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
