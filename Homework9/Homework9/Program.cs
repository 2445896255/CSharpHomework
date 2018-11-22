using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Crawler myCrawler = new Crawler();
            string startUrl = "http://www.cnblogs.com/dstang2000";
            if (args.Length >= 1) startUrl = args[0];

            myCrawler.urls.Add(startUrl, false);//加入初始页面
            new Thread(myCrawler.Crawl).Start();//开始爬行

        }
    }
}
