using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class Counter
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Step { get; private set; }
        public double Current {  get; private set; }
        public bool IsMoveUp { get; private set; }

        private TimeCounter _timeCounter;
        public double Next { get
            {
                if (_timeCounter.IsNext)
                {
                    Current += IsMoveUp ? Step : -Step;
                    IsMoveUp = (!IsMoveUp || Current < Max) && ((!IsMoveUp && Current <= Min) || IsMoveUp);
                }
                return Current;
            } }
        public Counter(double min, double max, double step, double countPerSecond, double current = 0, bool isMoveUp = true)
        {
            this.Min = min;
            this.Max = max;
            this.Step = step;
            this.Current = current;
            this.IsMoveUp = isMoveUp;
            this._timeCounter = new TimeCounter(countPerSecond);
        }
    }
}
