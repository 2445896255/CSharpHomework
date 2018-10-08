using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program2
{
    public class MyException : ApplicationException
    {
        public MyException(string message) : base(message) { }
    }
    public class Order
    {
        public string orderNumber;
        public string Name;
        public string goodsName;
        public Order(string orderNum, string name,string goodsN)
        {
            orderNumber = orderNum;
            Name = name;
            goodsName = goodsN;
        }
    }
    public class OrderDetails:Order
    {
        public double Price;
        public int goodsNumber;
        public OrderDetails(string orderNum, string name, string goodsN,double price,int goodsNum):base(orderNum,name,goodsN)
        {
            Price = price;
            goodsNumber = goodsNum;
        }
        public void showContents()
        {
            Console.WriteLine(orderNumber+" "+Name+" "+goodsName+" "+Price+" "+goodsNumber);
        }
    }
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
            switch(getChange)
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
        public void searchOrder(string searchBy,string keyWords)
        {
            switch(searchBy)
            {
                case "订单号":
                    foreach (OrderDetails wantedOrder in myList)
                    {
                        if(wantedOrder.orderNumber==keyWords)
                        {
                            wantedOrder.showContents();
                        }
                    }
                    break;
                case "客户名":
                    foreach (OrderDetails wantedOrder in myList)
                    {
                        if (wantedOrder.Name == keyWords)
                        {
                            wantedOrder.showContents();
                        }
                    }
                    break;
                case "商品名":
                    foreach (OrderDetails wantedOrder in myList)
                    {
                        if (wantedOrder.goodsName == keyWords)
                        {
                            wantedOrder.showContents();
                        }
                    }
                    break;
                default:
                    Console.WriteLine("错误，只能根据订单号、客户名和商品名进行查找");
                    break;
            }
        }
        public void showAll()
        {
            foreach(OrderDetails everyOrder in myList)
            {
                everyOrder.showContents();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderDetails order1 = new OrderDetails("20181005001", "John", "Apple", 2.5, 3);
            OrderDetails order2 = new OrderDetails("20181005002", "Anna", "Apple", 2.5, 4);
            OrderDetails order3 = new OrderDetails("20181005003", "John", "Pear", 3.5, 3);
            OrderDetails order4 = new OrderDetails("20181005004", "Peter", "Orange", 3, 3);
            OrderService MyService = new OrderService();
            try
            {
                MyService.addOrder(order1);
                MyService.addOrder(order2);
                MyService.addOrder(order3);
                MyService.addOrder(order4);

                //MyService.showAll();

                MyService.changeOrder(order4);

                //MyService.showAll();

                MyService.searchOrder("客户名", "John");

                MyService.deleteOrder(order4);

                //MyService.showAll();
            }
            catch(MyException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
