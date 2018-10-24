using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Program1
{
    [Serializable]
    public class OrderService//订单处理
    {
        static public List<OrderDetails> myList = new List<OrderDetails>();
        public bool addOrder(OrderDetails newOrder)//添加订单
        {
            if (myList.Contains(newOrder))
            {
                Console.WriteLine("重复添加");
                return false;
            }
            else
            {
                myList.Add(newOrder);
                newOrder.showContents();
                Console.WriteLine("此订单添加成功");
                return true;
            }
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
        public OrderDetails changeOrder(OrderDetails targetOrder,string getChange,string target)//修改订单
        {
            //Console.WriteLine("输入想修改的内容：订单号、客户名、商品名、单价、购买数量");
            //string getChange = Console.ReadLine();
            switch (getChange)
            {
                case "订单号":
                    //Console.WriteLine("输入新订单号：");
                    targetOrder.orderNumber = target;
                    break;
                case "客户名":
                    //Console.WriteLine("输入新客户名：");
                    targetOrder.Name = target;
                    break;
                case "商品名":
                    //Console.WriteLine("输入新商品名：");
                    targetOrder.goodsName = target;
                    break;
                case "单价":
                    //Console.WriteLine("输入新单价：");
                    targetOrder.Price = double.Parse(target);
                    break;
                case "购买数量":
                    //Console.WriteLine("输入新购买数量：");
                    targetOrder.goodsNumber = int.Parse(target);
                    break;
                default:
                    throw new MyException("错误，无法进行修改");
                    //break;
            }
            return targetOrder;
        }
        public List<OrderDetails> searchOrder(string searchBy, string keyWords)//查询订单
        {
            List<OrderDetails> keyList = new List<OrderDetails>();
            switch (searchBy)
            {
                case "订单号":
                    var targeton = from findings in myList where findings.orderNumber == keyWords select findings;
                    foreach (var findings in targeton)
                    {
                        findings.showContents();
                        keyList.Add(findings);
                    }
                    break;
                case "客户名":
                    var targetcn = from findings in myList where findings.Name == keyWords select findings;
                    foreach (var findings in targetcn)
                    {
                        findings.showContents();
                        keyList.Add(findings);
                    }
                    break;
                case "商品名":
                    var targetgn = from findings in myList where findings.goodsName == keyWords select findings;
                    foreach (var findings in targetgn)
                    {
                        findings.showContents();
                        keyList.Add(findings);
                    }
                    break;
                case "订单总额":
                    var targetwp = from findings in myList where (findings.Price) * (findings.goodsNumber) >= double.Parse(keyWords) select findings;
                    foreach (var findings in targetwp)
                    {
                        findings.showContents();
                        keyList.Add(findings);
                    }
                    break;
                default:
                    Console.WriteLine("错误，只能根据订单号、客户名、商品名和订单总额进行查找");
                    break;
            }
            return keyList;
        }
        /*
        public void showAll()//显示所有订单
        {
            foreach (OrderDetails everyOrder in myList)
            {
                everyOrder.showContents();
            }
        }
        */
        public static void XmlSerialize(XmlSerializer ser, string fileName, List<OrderDetails> obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
        static XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderDetails>));
        public static string Export()//xml序列化
        {
            if (myList.Count != 0)
            {
                String xmlFileName = "my.xml";
                XmlSerialize(xmlser, xmlFileName, myList);
                Console.WriteLine("xml文本如下：");
                string xml = File.ReadAllText(xmlFileName);
                Console.WriteLine(xml);
                return xmlFileName;
            }
            else
                return "无法序列化，订单列表为空";
        }
        public static bool Import(string xmlFileName)//xml反序列化
        {
            if (xmlFileName == "无法序列化，订单列表为空")
            {
                return false;
            }
            else
            {
                Console.WriteLine("xml文件反序列化：");
                List<OrderDetails> xmlOrder = xmlser.Deserialize(File.OpenRead(xmlFileName)) as List<OrderDetails>;
                foreach (OrderDetails order in xmlOrder)
                {
                    order.showContents();
                }
                return true;
            }
        }
    }
}
