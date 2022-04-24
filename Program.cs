using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Parallelogram
    {
        protected double alfa;
        protected int h;
        protected int width;
        public double Alfa
        {
            get
            {
                return alfa;
            }
            set
            {
                if (value>0&value<180) alfa = value;
            }
        }
        public int H
        {
            get
            {
                return h;
            }
            set
            {
               if (value>0) h = value;
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value > 0) width = value;
            }
        }
        public bool isQuare
        {
            get
            {
                return (alfa == 90);
            }
        }
        private double Rad
        {
            get
            { 
                return alfa/180*Math.PI;
            }
        }
        public double Storona
        {
            get
            {
                return h / Math.Sin(Rad);
            }
        }
        public double Area()
        {
            return h * width;
        }
        public void Show()
        {
            Console.WriteLine("Высота параллелограмма: {0}\nЗаданная сторона параллелограмма: {1}\nУгол в параллелограмме: {2:f2}", h, width, alfa);
        }
        public double Perimetr()
        {
            return (Storona + (double)width) * 2;
        }
        public double Diagonal()
        {
            return Math.Sqrt(Storona + width - Math.Abs(2 * Storona * width * Math.Cos(Rad)));
        }
    }
   
}
