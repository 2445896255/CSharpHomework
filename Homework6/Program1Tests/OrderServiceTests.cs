using Microsoft.VisualStudio.TestTools.UnitTesting;
using Program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        public bool SameOrder(object obj1,object obj2)
        {
            OrderDetails order1 = obj1 as OrderDetails;
            OrderDetails order2 = obj2 as OrderDetails;
            return order1.goodsName == order2.goodsName && order1.goodsNumber == order2.goodsNumber && order1.Name == order2.Name && order1.orderNumber == order2.orderNumber && order1.Price == order2.Price;
        }

        static OrderDetails newOrder = new OrderDetails("20181005003", "Lily", "Orange", 3.1, 6);
        static OrderDetails testOrder = new OrderDetails("20181005003", "Bob", "Orange", 3.1, 6);
        static OrderService testOrderService = new OrderService();
        
        [TestMethod()]
        public void addOrderTest()
        {
            Assert.IsTrue(testOrderService.addOrder(testOrder));
            Assert.IsTrue(SameOrder(testOrder, OrderService.myList[0]));
        }

        [TestMethod()]
        public void addOrderTest1()//非正确调试，重复添加
        {
            Assert.IsTrue(testOrderService.addOrder(testOrder));

        }

        [TestMethod()]
        public void deleteOrderTest()
        {
            testOrderService.deleteOrder(testOrder);
            Assert.IsTrue(OrderService.myList.Count == 0);
        }

        [TestMethod()]
        public void deleteOrderTest1()//非正确调试，二次删除
        {
            testOrderService.deleteOrder(testOrder);
            //Assert.IsTrue(OrderService.myList.Count == 0);
        }

        [TestMethod()]
        public void changeOrderTest()
        {
            testOrderService.addOrder(testOrder);               
            Assert.IsTrue(SameOrder(newOrder, testOrderService.changeOrder(testOrder, "客户名", "Lily")));
        }

        [TestMethod()]
        public void changeOrderTest1()//非正确调试,未正确更改订单
        {
            testOrderService.addOrder(testOrder);
            Assert.IsTrue(SameOrder(newOrder, testOrderService.changeOrder(testOrder, "客户名", "Angle")));
        }

        [TestMethod()]
        public void searchOrderTest()
        {
            List<OrderDetails> myList = testOrderService.searchOrder("订单号", "20181005003");
            Assert.IsTrue(SameOrder(testOrder, myList[0]));           
        }

        [TestMethod()]
        public void searchOrderTest1()//非正确调试,未找到目标订单
        {
            List<OrderDetails> myList = testOrderService.searchOrder("订单号", "20181005004");
            Assert.IsTrue(SameOrder(testOrder, myList[0]));
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService.Export();
            Assert.AreEqual("my.xml", OrderService.Export());
        }

        [TestMethod()]
        public void ExportTest1()//非正确调试，序列化列表为空
        {
            testOrderService.deleteOrder(testOrder);
            OrderService.Export();
            Assert.AreNotEqual("无法序列化，订单列表为空", OrderService.Export());
        }

        [TestMethod()]
        public void ImportTest()
        {
            testOrderService.addOrder(testOrder);
            OrderService.Export();
            Assert.IsTrue(OrderService.Import(OrderService.Export()));
        }

        [TestMethod()]
        public void ImportTest1()//非正确调试，反序列化列表为空
        {
            testOrderService.deleteOrder(testOrder);
            OrderService.Export();
            Assert.IsTrue(OrderService.Import(OrderService.Export()));
        }

    }
}