using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Invalidate();
            if (graphics == null)graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }
        
        Random myRan = new Random();
        double random()
        {
            return myRan.NextDouble();
        }

        private Graphics graphics;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;

        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            double x2 = x0 + leng * random() * Math.Cos(th);
            double y2 = y0 + leng * random() * Math.Sin(th);

            drawLine(x0, y0, x1, y1,Color.FromName("Blue"),2);
            drawLine(x0, y0, x2, y2,Color.FromName("Green"),2);

            drawCayleyTree(n - 1, x1, y1, per1 * leng , th + th1 );
            drawCayleyTree(n - 1, x2, y2, per2 * leng , th - th2 );
        }

        
        void drawLine(double x0, double y0, double x1, double y1,Color color,float width)
        {
            Pen myPen = new Pen(color, width);
            graphics.DrawLine(myPen, (int)x0, (int)y0, (int)x1, (int)y1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
