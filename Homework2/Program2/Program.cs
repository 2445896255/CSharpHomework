using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    class Program
    {
        //求整数数组的最大值、最小值、平均值和和
        static void Main(string[] args)
        {
            int[] array = new int[5];
            Console.WriteLine("输入5个数组元素：");
            for(int i=0;i<5;i++)
            {
                string s = Console.ReadLine();
                array[i] = int.Parse(s);
            }
            for (int m = 0; m < 4; m++)
            {
                for (int n = m + 1; n < 5; n++)
                {
                    if (array[n] < array[m])
                    {
                        int temp = array[n];
                        array[n] = array[m];
                        array[m] = temp;
                    }
                }
            }
            Console.WriteLine("最小值为" + array[0]);
            Console.WriteLine("最大值为" + array[4]);
            int sum = 0;
            for(int j=0;j<5;j++)
            {
                sum += array[j];
            }
            Console.WriteLine("和为" + sum);
            Console.WriteLine("平均值为" + ((double)sum / 5));
        }
    }
}
