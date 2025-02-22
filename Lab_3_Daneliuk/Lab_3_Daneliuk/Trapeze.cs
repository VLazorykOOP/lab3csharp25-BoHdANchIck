using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_Daneliuk
{
    class Trapeze
    {
        private int a, b, h; 
        private int c;       

        public Trapeze(int a, int b, int h, int color)
        {
            this.a = a;
            this.b = b;
            this.h = h;
            this.c = color;
        }

        public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public int H
        {
            get { return h; }
            set { h = value; }
        }

        public int Color
        {
            get { return c; }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Trapeze: a = {a}, b = {b}, h = {h}, color = {c}");
        }

        public double Perimeter()
        {
            double side = Math.Sqrt(Math.Pow((a - b) / 2.0, 2) + Math.Pow(h, 2));
            return a + b + 2 * side;
        }

        public double Area()
        {
            return ((a + b) / 2.0) * h;
        }

        public bool IsSquare
        {
            get { return a == b && a == h; }
        }
    }
}

