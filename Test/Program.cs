using Extensions;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace Test
{
    public static class Program
    {
        static void Main()
        {
            TimeCounter timeCounter = new TimeCounter(1);
            while (true)
            {
                if (timeCounter.IsNext)
                {
                    Console.WriteLine("/");
                }
            }
        }
    }
}