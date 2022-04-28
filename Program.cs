using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_2
{
    class Program
    {
        static public uint Try_Parse(byte option)
        {
            uint x;
            bool a = UInt32.TryParse(Console.ReadLine(), out x);
            if (!a)
            {
                Console.Write("Введено нечисловое значение. Повторите ввод: ");
                return Try_Parse(option);
            }
            if ((option == 0 & x > 5) | (option == 1 & x > 7) | x == 0|(option == 2&x>2)) //я конченый
            {
                Console.Write("Введено не то число. Повторите ввод: ");
                return Try_Parse(option);
            }
            return x;
        }
        static public int Try_Parse()
        {
            int x;
            bool a = Int32.TryParse(Console.ReadLine(), out x);
            if (!a)
            {
                Console.Write("Введено нечисловое значение. Повторите ввод: ");
                return Try_Parse();
            }
            return x;
        }
        static public double Try_Parse_Double(byte option)
        {
            double x;
            try
            {
                x = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Write("Введено нечисловое значение. Повторите ввод: ");
                return Try_Parse_Double(option);
            }
            if (option == 0 & (x <= 0 | x >= 180)) //угол (мб просто еще что-нибудь придется вводить...)
            {
                Console.Write("Введенное число должно быть параметром угла в градусах (от 0 до 180 невключительно). Повторите ввод: ");
                return Try_Parse_Double(0);
            }
            return x;
        }
        static Rectangle Create_Rectangle()
        {
            Console.Write("Введите ширину параллелограмма: ");
            int width = (int)Try_Parse(3);
            Console.Write("Введите высоту параллелограмма: ");
            int h = (int)Try_Parse(3);
            return new Rectangle(h, width);
        }
        static Romb Create_romb()
        {
            Console.Write("Введите сторону ромба: ");
            int width = (int)Try_Parse(3);
            Console.Write("Введите угол ромба: ");
            double alfa = Try_Parse_Double(0);
            return new Romb(alfa, width);
        }
        static Parallelogram Create_Parallelogram()
        {
            Console.WriteLine("Введите 1, если хотите создать прямоугольник. Введите 2, если хотите создать ромб");
            byte option = (byte)Try_Parse(2);
            if (option == 1)
            {
                Console.WriteLine("Введите 1, если хотите создать с дефолтными значениями. Введите 2, если хотите ввести значения");
                if ((byte)Try_Parse(2) == 1) return new Rectangle();
                else return Create_Rectangle();
            }
            else
            {
                Console.WriteLine("Введите 1, если хотите создать с дефолтными значениями. Введите 2, если хотите ввести значения");
                if ((byte)Try_Parse(2) == 1) return new Romb();
                else return Create_romb();
            }
        }
        static void Interface_Rectangle(Rectangle obj1, Romb obj2)
        {
            Console.WriteLine("Работа с ")
            Console.WriteLine("Программа может:\n1)Вывести параметры прямоугольника\n2)Вывести значение его диагонали\n3)Проверить, является ли" +
                " прямоугольник квадратом\n4)Посчитать его периметр\n5)Перейти к ромбу");
            Console.Write("Введите команду (число от 1 до 5): ");
            byte option = (byte)Try_Parse(0);
            switch (option)
            {
                case 1:
                    obj1.Show();
                    Interface_Rectangle(obj1, obj2);
                    break;
                case 2:
                    Console.WriteLine("Диагональ: {0}", obj1.Diagonal());
                    break;
                case 3:
                    if (obj1.isQuare) Console.WriteLine("Прямоугольник является квадратом");
                    else Console.WriteLine("Прямоугольник не является квадратом");
                    break;
                case 4:
                    Console.WriteLine("Периметр прямоугольника: {0}", obj1.Perimetr());
                    break;
                case 5:
                    Interface_Romb(obj2, obj1);
                    break;

            }
        }
        static void Interface_Romb(Romb obj1, Rectangle obj2)
        {
            Console.WriteLine("Программа может:\nВывести параметры ромба\n2)Вывести значение диагонали\n3)Проверить" +
                ", является ли ромб квадратом\n4)Посчитать его периметр\n5)Перейти к прямоугольнику");
            Console.Write("Введите команду (число от 1 до 5): ");
            byte option = (byte)Try_Parse(0);
            switch(option)
            {
                case 1:

            }
        }
        static void Main(string[] args)
        {
            //хочу продать класс и спокойно получить 2 за фоновую...
            Parallelogram[] mas = new Parallelogram [2];
            mas[0] = Create_Parallelogram();
            mas[1] = Create_Parallelogram();
            if (mas[0].isQuare) Interface_Rectangle((Rectangle)mas[0],(Romb)mas[1]); //это имеет смысл, правда
            else Interface_Romb((Romb)mas[0], (Rectangle)mas[1]);
        }
    }
    class Parallelogram
    {
        protected double alfa;
        protected int h;
        protected int width;
        public Parallelogram()
        {
            alfa = 45;
            h = 4;
            width = 8;
        }
        public Parallelogram(double alfa, int h, int width)
        {
            this.alfa = alfa;
            this.h = h;
            this.width = width;
        }
        public double Alfa
        {
            get
            {
                return alfa;
            }
            set
            {
                if (value > 0 & value < 180) alfa = value;
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
                if (value > 0) h = value;
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
        public virtual bool isQuare
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
                return alfa / 180 * Math.PI;
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
        public virtual void Show()
        {
            Console.WriteLine("Высота параллелограмма: {0}\nЗаданная сторона параллелограмма: {1}\nУгол в параллелограмме: {2:f2}", h, width, alfa);
        }
        public virtual double Perimetr()
        {
            return (Storona + (double)width) * 2;
        }
        public virtual double Diagonal()
        {
            return Math.Sqrt(Storona + width - Math.Abs(2 * Storona * width * Math.Cos(Rad)));
        }
    }
    class Rectangle : Parallelogram
    {
        public Rectangle()
            : base(90, 4, 8)
        {

        }
        public Rectangle(int h, int width)
            : base(90, h, width)
        {
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Мы имеем дело с прямоугольником, держу в курсе");
        }
        public override double Diagonal()
        {
            return Math.Sqrt(width * width + h * h);
        }
        public override double Perimetr()
        {
            return (width + h) * 2;
        }
        public override bool isQuare
        {
            get
            {
                return (width == h);
            }
        }
    }
    class Romb :Parallelogram
    {
        public Romb()
            : base(45, Height(45, 8), 8)
        {

        }
        public Romb(double alfa, int width)
            :base(alfa, Height(alfa, width), width)
        {

        }
        private static int Height(double alfa, int width)
        {
            return width * (int)Math.Sin(Radian(alfa));
        }
        private static double Radian(double alfa)
        {
            return alfa / 180 * Math.PI;
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Мы имеем дело с ромбом, держу в курсе");
        }
        public override double Diagonal()
        {
            return 2*width * h / base.Diagonal();
        }
        public override double Perimetr()
        {
            return width * 4;
        }
        public override bool isQuare
        {
            get
            {
                return (alfa == 90);
            }
        }
    }
}
