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
            Shape shape;
            Console.WriteLine("输入图形Angle,Circle,Square,Rectangle:");
            string input = Console.ReadLine();
            shape = Factory.CreatShape(input);
            double result = shape.Area();
            Console.WriteLine("面积是：" + result);
        }
    }

    public abstract class Shape//父类
    {
        public abstract double Area();        
    }
    public class Angle:Shape//三角形
    {
        private int myEdge;
        private int myHeight;
        public Angle(int edge,int height)
        {
            myEdge = edge;
            myHeight = height;
        }
        public override double Area()
        {
            Console.WriteLine("Draw Angle");
            return myHeight * myEdge / 2; 
        }
    }
    public class Circle : Shape//圆类
    {
        private int myRadius;
        public Circle(int radius)
        {
            myRadius = radius;
        }
        public override double Area()
        {
            Console.WriteLine("Draw Circle");
            return myRadius * myRadius * System.Math.PI; 
        }
    }
    public class Square : Shape//正方形类
    {
        private int mySide;
        public Square(int side)
        {
            mySide = side;
        }
        public override double Area()
        {
            Console.WriteLine("Draw Square");
            return mySide * mySide; 
        }
    }
    public class Rectangle:Shape//长方形类
    {
        private int myWidth;
        private int myHeight;
        public Rectangle(int width,int height)
        {
            myHeight = height;
            myWidth = width;
        }
        public override double Area()
        {
            Console.WriteLine("Draw Rectangle");
            return myHeight * myWidth; 
        }
    }
    public class Factory
    {
        public static Shape CreatShape(string  shape)
        {
            Shape sh = null;
            switch(shape)
            {
                case "Angle":
                    Console.WriteLine("输入底和高：");
                    string edge = Console.ReadLine();
                    string height = Console.ReadLine();
                    sh = new Angle(int.Parse(edge),int.Parse(height));
                    break;
                case "Circle":
                    Console.WriteLine("输入半径：");
                    string radius = Console.ReadLine();
                    sh = new Circle(int.Parse(radius));
                    break;
                case "Square":
                    Console.WriteLine("输入边长：");
                    string side = Console.ReadLine();
                    sh = new Square(int.Parse(side));
                    break;
                case "Rectangle":
                    Console.WriteLine("输入宽和高：");
                    string width = Console.ReadLine();
                    string high = Console.ReadLine();
                    sh = new Rectangle(int.Parse(width),int.Parse(high));
                    break;
                default:
                    Console.WriteLine("input wrong");
                    break;
            }
            return sh;
        }
    }

}
