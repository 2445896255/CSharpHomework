using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Program1;

namespace WinForm
{

    public partial class Form1 : Form
    {
        public string KeyWord { get; set; }
        public static OrderService myOrderService = new OrderService();
        //public List<OrderDetails> formList = new List<OrderDetails>();
        public Form1()
        {
            InitializeComponent();
            this.Text = "订单管理";
            myOrderService.myList.Add(new OrderDetails("20181005001", "John", "Apple", 2.5, 3,"13012376988"));
            myOrderService.myList.Add(new OrderDetails("20181005002", "Lily", "Orange", 2.7, 6,"15913545442"));
            orderDetailsBindingSource.DataSource = myOrderService.myList;
            queryInput.DataBindings.Add("Text", this, "KeyWord");
        }

        public void reFresh()//刷新DataGridView
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = myOrderService.myList;
            orderDetailsBindingSource.DataSource = bs;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Text = "新建订单";
            form2.PassDataBetweenForm += new Form2.PassDataBetweenFormHandler(FrmChild_PassDataBetweenForm);
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)//删除订单
        {
            foreach(OrderDetails order in myOrderService.myList)
            {
                if(order.orderNumber==this.label4.Text)
                {
                    myOrderService.deleteOrder(order);
                    break;
                }
            }
            reFresh();
        }

        private void button1_Click(object sender, EventArgs e)//查询订单
        {
            switch(searchBy.Text)
            {
                case "订单号":
                    orderDetailsBindingSource.DataSource = myOrderService.myList.Where(order => order.orderNumber == KeyWord);
                    break;
                case "客户名":
                    orderDetailsBindingSource.DataSource = myOrderService.myList.Where(order => order.Name == KeyWord);
                    break;
                case "商品名":
                    orderDetailsBindingSource.DataSource = myOrderService.myList.Where(order => order.goodsName == KeyWord);
                    break;
                default:
                    break;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            reFresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (OrderDetails order in myOrderService.myList)
            {
                if (order.orderNumber == this.label4.Text)
                {
                    Form3 form3 = new Form3(order);
                    form3.Text = "修改订单";
                    form3.PassDataBetweenForm += new Form3.PassDataBetweenFormHandler(FrmChild_PassDataBetweenForm);
                    form3.ShowDialog();
                }
            }
        }

        private void FrmChild_PassDataBetweenForm(object sender, PassDataWinFormEventArgs e)
        {
            reFresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myOrderService.getHTML();
            Form5 form5 = new Form5();
            form5.Text = "HTML";
            form5.ShowDialog();
            //System.Diagnostics.Process.Start("explorer.exe", @"...\..\index.html");
        }
    }
}
