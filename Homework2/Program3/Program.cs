using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[100];
            for(int i=0;i<99;i++)
            {
                arr[i] = i + 2;
            }
            for(int m=2;m<=50;m++)
            {
                for(int n=2;n<99;n++)
                {
                    if (arr[n] % m == 0 && arr[n] / m != 1)
                    {
                        arr[n] = 0;
                    }
                }
            }
            for(int i=0;i<99;i++)
            {
                if (arr[i] != 0)
                {
                    Console.WriteLine(arr[i]);
                }
            }

        }
    }
}
