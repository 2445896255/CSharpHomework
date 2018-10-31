using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class OrderDetails : Order
    {
        public double Price { get; set; }
        public int goodsNumber { get; set; }
        public OrderDetails() { }
        public OrderDetails(string orderNum, string name, string goodsN, double price, int goodsNum) : base(orderNum, name, goodsN)
        {
            Price = price;
            goodsNumber = goodsNum;
        }
        public void showContents()
        {
            Console.WriteLine(orderNumber + " " + Name + " " + goodsName + " " + Price + " " + goodsNumber);
        }
    }
}
