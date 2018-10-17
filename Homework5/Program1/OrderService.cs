using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class OrderService//订单处理
    {
        List<OrderDetails> myList = new List<OrderDetails>();
        public void addOrder(OrderDetails newOrder)//添加订单
        {
            myList.Add(newOrder);
            newOrder.showContents();
            Console.WriteLine("此订单添加成功");
        }
        public void deleteOrder(OrderDetails outerOrder)//删除订单
        {
            if (myList.Contains(outerOrder))
            {
                myList.Remove(outerOrder);
                Console.WriteLine("删除成功");
            }
            else
            {
                throw new MyException("不存在这个订单，无法删除");
            }
        }
        public void changeOrder(OrderDetails targetOrder)//修改订单
        {
            Console.WriteLine("输入想修改的内容：订单号、客户名、商品名、单价、购买数量");
            string getChange = Console.ReadLine();
            switch (getChange)
            {
                case "订单号":
                    Console.WriteLine("输入新订单号：");
                    targetOrder.orderNumber = Console.ReadLine();
                    break;
                case "客户名":
                    Console.WriteLine("输入新客户名：");
                    targetOrder.Name = Console.ReadLine();
                    break;
                case "商品名":
                    Console.WriteLine("输入新商品名：");
                    targetOrder.goodsName = Console.ReadLine();
                    break;
                case "单价":
                    Console.WriteLine("输入新单价：");
                    targetOrder.Price = double.Parse(Console.ReadLine());
                    break;
                case "购买数量":
                    Console.WriteLine("输入新购买数量：");
                    targetOrder.goodsNumber = int.Parse(Console.ReadLine());
                    break;
                default:
                    throw new MyException("错误，无法进行修改");
                    //break;
            }
        }
        public void searchOrder(string searchBy, string keyWords)//查询订单
        {
            switch (searchBy)
            {
                case "订单号":
                    var targeton = from findings in myList where findings.orderNumber == keyWords select findings;
                    foreach (var findings in targeton)
                    {
                        findings.showContents();
                    }
                    break;
                case "客户名":
                    var targetcn = from findings in myList where findings.Name == keyWords select findings;
                    foreach (var findings in targetcn)
                    {
                        findings.showContents();
                    }
                    break;
                case "商品名":
                    var targetgn = from findings in myList where findings.goodsName == keyWords select findings;
                    foreach (var findings in targetgn)
                    {
                        findings.showContents();
                    }
                    break;
                case "订单总额":
                    var targetwp = from findings in myList where (findings.Price) * (findings.goodsNumber) >= double.Parse(keyWords) select findings;
                    foreach (var findings in targetwp)
                    {
                        findings.showContents();
                    }
                    break;
                default:
                    Console.WriteLine("错误，只能根据订单号、客户名、商品名和订单总额进行查找");
                    break;
            }
        }
        public void showAll()
        {
            foreach (OrderDetails everyOrder in myList)
            {
                everyOrder.showContents();
            }
        }
    
    }
}
