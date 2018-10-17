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
            OrderDetails order1 = new OrderDetails("20181005001", "John", "Apple", 2.5, 3);
            OrderDetails order2 = new OrderDetails("20181005002", "Anna", "Apple", 2.5, 4);
            OrderDetails order3 = new OrderDetails("20181005003", "John", "Pear", 3.5, 3);
            OrderDetails order4 = new OrderDetails("20181005004", "Peter", "Orange", 3, 3);
            OrderDetails order5 = new OrderDetails("20181005004", "Peter", "Watermelen", 10, 1000);
            OrderService MyService = new OrderService();
            try
            {
                MyService.addOrder(order1);
                MyService.addOrder(order2);
                MyService.addOrder(order3);
                MyService.addOrder(order4);
                MyService.addOrder(order5);

                //MyService.showAll();

                MyService.changeOrder(order4);

                //MyService.showAll();

                MyService.searchOrder("订单号", "20181005004");
                MyService.searchOrder("订单总额", "10000");

                MyService.deleteOrder(order4);

                //MyService.showAll();
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }

              
        }
    }
}
