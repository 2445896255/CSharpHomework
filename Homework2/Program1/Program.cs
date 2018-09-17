using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//输出素数因子
namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入数字：");
            string s = Console.ReadLine();
            int number = int.Parse(s); 
            if(number<=1)
            {
                Console.WriteLine("输入错误");
            }
            else
            {
                for(int i=2;i<=number;i++)
                {
                    if(number%i==0)//求因子,i是number的因子
                    {
                        int j = 2;
                        for(;j<i;j++)
                        {
                            if (i % j == 0)
                                break;
                        }
                        if (j == i)
                            Console.WriteLine(i);
                    }
                }
            }
        }
    }
}
