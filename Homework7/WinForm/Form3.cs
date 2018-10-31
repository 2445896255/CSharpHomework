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
    public partial class Form3 : Form
    {
        private OrderDetails aimOrder;
        public Form3(OrderDetails order)
        {
            InitializeComponent();
            aimOrder = order;
        }
        //声明委托
        public delegate void PassDataBetweenFormHandler(object sender, PassDataWinFormEventArgs e);
        //声明事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        private void button1_Click(object sender, EventArgs e)
        {
            Form1.myOrderService.changeOrder(this.comboBox1.Text, aimOrder, this.textBox1.Text);
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs();
            PassDataBetweenForm(this, args);
            this.Close();
        }
    }
}
