using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public class TimeCounter
    {
        private DateTime _lastTime = DateTime.Now;
        private TimeSpan _updateInterval;
        public TimeCounter(double countPerSecond)
        {
            _lastTime = DateTime.Now;
            _updateInterval = TimeSpan.FromMilliseconds(Math.Floor(1000.0 / countPerSecond));
        }
        public bool IsNext
        {
            get
            {
                if (DateTime.Now - _lastTime >= _updateInterval)
                {
                    _lastTime = DateTime.Now;
                    return true;
                }
                return false;
            }
        }
    }
}
