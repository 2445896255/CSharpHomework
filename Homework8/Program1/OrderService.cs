using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Xml;

namespace Program1
{
    [Serializable]
    public class OrderService//订单处理
    {
        public List<OrderDetails> myList = new List<OrderDetails>();
        //public List<OrderDetails> searchList = new List<OrderDetails>();
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
        public void changeOrder(string getChange,OrderDetails targetOrder,string target)//修改订单
        {
            //Console.WriteLine("输入想修改的内容：订单号、客户名、商品名、单价、购买数量");
            //string getChange = Console.ReadLine();
            switch (getChange)
            {
                case "订单号":
                    
                    targetOrder.orderNumber =  target;
                    break;
                case "客户名":
                    //Console.WriteLine("输入新客户名：");
                    targetOrder.Name = target;//Console.ReadLine();
                    //Console.WriteLine("修改成功");
                    break;
                case "商品名":
                    //Console.WriteLine("输入新商品名：");
                    targetOrder.goodsName = target;//Console.ReadLine();
                    break;
                case "单价":
                    //Console.WriteLine("输入新单价：");
                    targetOrder.Price = double.Parse(target);//(Console.ReadLine());
                    break;
                case "购买数量":
                    //Console.WriteLine("输入新购买数量：");
                    targetOrder.goodsNumber = int.Parse(target);//(Console.ReadLine());
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
                    //for (int i=0;i<myList.Count;i++)
                    //{
                    //    if(myList[i].orderNumber!=keyWords)
                    //    {
                    //        myList.Remove(myList[i]);
                    //        searchList.Add(myList[i]);
                    //    }
                    //}
 
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
        public void showAll()//显示所有订单
        {
            foreach (OrderDetails everyOrder in myList)
            {
                everyOrder.showContents();
            }
        }
        public static object XmlSerialize(XmlSerializer ser, string fileName, List<OrderDetails> obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
            return obj;
            //using (FileStream fs = new FileStream(fileName, FileMode.Create))
            //{
            //    var setting = new XmlWriterSettings()
            //    {
            //        Encoding = new UTF8Encoding(false),
            //        Indent = true
            //    };
            //    using (XmlWriter writer = XmlWriter.Create(fs, setting))
            //    {

            //        ser.Serialize(fs, obj);
            //    }
            //    fs.Close();
            //}
        }
        static XmlSerializer xmlser = new XmlSerializer(typeof(List<OrderDetails>));
        public string Export()//xml序列化
        {
            String xmlFileName = @"..\..\my.xml";
            XmlSerialize(xmlser, xmlFileName, myList);
            Console.WriteLine("xml文本如下：");
            string xml = File.ReadAllText(xmlFileName);
            Console.WriteLine(xml);
            return xmlFileName;
        }
        public void Import(string xmlFileName)//xml反序列化
        {
            Console.WriteLine("xml文件反序列化：");
            List<OrderDetails> xmlOrder = xmlser.Deserialize(File.OpenRead(xmlFileName)) as List<OrderDetails>;
            foreach (OrderDetails order in xmlOrder)
            {
                order.showContents();
            }
        }

        public void getHTML()
        {
            try
            {
                Export();
                XmlDocument doc = new XmlDocument();
                doc.Load(@"..\..\my.xml");
                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();

                XslTransform xt = new XslTransform();
                xt.Load(@"..\..\xslt.xslt");

                FileStream outFileStream = File.OpenWrite(@"..\..\index.html");
                XmlTextWriter writer = new XmlTextWriter(outFileStream, System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);

               
            }
            catch (XmlException e)
            {
                Console.WriteLine("Xml Exception: " + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("XSLT Exception: " + e, ToString());
            }
        }
    }
}
