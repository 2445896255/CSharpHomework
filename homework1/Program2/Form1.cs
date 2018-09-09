using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nums1 = number1.Text;
            double numd1 = double.Parse(nums1);
            string nums2 = number2.Text;
            double numd2 = double.Parse(nums2);
            result.Text = numd1 + "*" + numd2 + "=" + (numd1 * numd2);
        }

    }
}
