using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public delegate void ClockHandler(object sender, EventArgs args);
    public class MyClock
    {
        public event ClockHandler OnClock;
        public void Clock(DateTime setTime)
        {
            
            string curtime= DateTime.Now.ToShortTimeString().ToString();
            DateTime curTime = Convert.ToDateTime(curtime);
            DateTime t;
            for (t = curTime; t < setTime;)
            {
                t = Convert.ToDateTime(DateTime.Now.ToShortTimeString().ToString());
            }
            if (setTime == t)
            {
                EventArgs args = new EventArgs();
                OnClock(this, args);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClock myClock = new MyClock();
            myClock.OnClock += ShowRing;
            Console.WriteLine("输入闹钟的时间，格式为年/月/日 时:分:秒（24小时制及英文字符）");            
            string settime= Console.ReadLine();
            DateTime setTime = Convert.ToDateTime(settime);
            myClock.Clock(setTime);
        }
        static void ShowRing(object sender,EventArgs e)
        {
            Console.WriteLine("闹钟时间到了");
        }
    }
}
