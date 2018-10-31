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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
       
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        private void button1_Click(object sender, EventArgs e)
        {
            string orderNumber = textBox1.Text;
            string cilentName = textBox2.Text;
            string goodName = textBox3.Text;
            double price = double.Parse(textBox4.Text);
            int goodNumber = int.Parse(textBox5.Text);
            OrderDetails newOrder = new OrderDetails(orderNumber, cilentName, goodName, price, goodNumber);
            Form1.myOrderService.addOrder(newOrder);
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs();
            PassDataBetweenForm(this, args);
            this.Close();
        }
    }
}
