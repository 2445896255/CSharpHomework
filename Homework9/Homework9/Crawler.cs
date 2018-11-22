using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;

namespace Program1
{
    public class Crawler
    {
        public Hashtable urls = new Hashtable();
        private int count = 0;
        public void Crawl()
        {
            Console.WriteLine("开始爬行了....");
            Parallel.For(0, 10, count =>
            {
                  string current = null;
                  foreach (string url in urls.Keys)//找到一个还没有下载过的链接
                  {
                    if ((bool)urls[url]) continue;//已经下载过的，不再下载
                    current = url;
                  }
                  Console.WriteLine("爬行" + current + "页面！");
                  string html = DownLoad(current);//下载

                  urls[current] = true;
                  count++;

                  Parse(html);//解析，并加入新的链接

                Console.WriteLine("线程id=" + Thread.CurrentThread.ManagedThreadId);
            });
            Console.WriteLine("爬行结束");
            Console.ReadLine();
        }


        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach(Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"','/','#',' ','>');
                    if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    }
}
