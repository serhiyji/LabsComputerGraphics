using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class EllipseHandler
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double A { get; private set; }
        public double B { get; private set; }
        public double Angle { get; private set; }
        public double Step { get; private set; }
        public double Prev_t { get; private set; }
        private MyPoint prev;
        private TimeCounter _timeCounter;
        public EllipseHandler(double x, double y, double a, double b, double step, double angle = 0, double countPerSecond = 60)
        {
            this.X = x; this.Y = y;
            this.A = a; this.B = b;
            this.Step = step;
            this.Angle = angle * Math.PI / 180.0;
            _timeCounter = new TimeCounter(countPerSecond);
        }
        public MyPoint Next { 
            get {
                if (_timeCounter.IsNext)
                {
                    Prev_t += Step;
                    prev = new MyPoint(
                            X + A * Math.Cos(Prev_t) * Math.Cos(Angle) - B * Math.Sin(Prev_t) * Math.Sin(Angle),
                            Y + A * Math.Cos(Prev_t) * Math.Sin(Angle) + B * Math.Sin(Prev_t) * Math.Cos(Angle)
                        );

                    return prev;
                }
                return prev;
            } 
        }
    }
}
