using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class Order
    {
        public string orderNumber;
        public string Name;
        public string goodsName;
        public Order(string orderNum, string name, string goodsN)
        {
            orderNumber = orderNum;
            Name = name;
            goodsName = goodsN;
        }
    }
}
