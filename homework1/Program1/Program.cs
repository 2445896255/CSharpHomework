using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please write the first number:");
            string nums1 = "";
            double numd1 = 0;
            nums1 = Console.ReadLine();
            numd1 = double.Parse(nums1);

            Console.WriteLine("Please write the second number:");
            string nums2 = "";
            double numd2 = 0;
            nums2 = Console.ReadLine();
            numd2 = double.Parse(nums2);

            Console.WriteLine("the product is:" + (numd1 * numd2));
        }
    }
}
