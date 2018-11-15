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
            if (this.comboBox1.Text == "订单号")
            {
                bool ob = judge();
                if (ob)
                    Form1.myOrderService.changeOrder(this.comboBox1.Text, aimOrder, this.textBox1.Text);
                else
                {
                    Form4 form4 = new Form4();
                    form4.Text = "错误";
                    form4.ShowDialog();
                }
            }
            else
            {
                Form1.myOrderService.changeOrder(this.comboBox1.Text, aimOrder, this.textBox1.Text);
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs();
            PassDataBetweenForm(this, args);
            this.Close();
        }

        private bool judge()
        {
            if (textBox1.Text == null) return false;
            foreach (OrderDetails order in Form1.myOrderService.myList)
            {
                if (order.orderNumber == textBox1.Text) return false;
            }
            System.Text.RegularExpressions.Regex rx = new System.Text.RegularExpressions.Regex("^(([0-9]{3}[1-9]|[0-9]{2}[1-9][0-9]{1}|[0-9]{1}[1-9][0-9]{2}|[1-9][0-9]{3})(((0[13578]|1[02])(0[1-9]|[12][0-9]|3[01]))|((0[469]|11)(0[1-9]|[12][0-9]|30))|(02(0[1-9]|[1][0-9]|2[0-8]))))|((([0-9]{2})(0[48]|[2468][048]|[13579][26])|((0[48]|[2468][048]|[3579][26])00))0229)([0-9]{3})$");//年月日匹配
            bool ok = rx.IsMatch(textBox1.Text);
            return ok ;

        }
    }
}
