using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class Order
    {
        public string orderNumber { get; set; }
        public string Name { get; set; }
        public string goodsName { get; set; }
        public Order() { }
        public Order(string orderNum, string name, string goodsN)
        {
            orderNumber = orderNum;
            Name = name;
            goodsName = goodsN;
        }
    }
}
