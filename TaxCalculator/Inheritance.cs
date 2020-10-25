using System;
using System.Drawing;
using System.Xml;

namespace TaxCalculator
{
    public abstract class Shape
    {
        public Shape(string name, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            Name = name;
            ForeColor = foreColor;
            BackColor = backColor;
        }
        public readonly string Name;
        public ConsoleColor ForeColor { get; set; }
        public ConsoleColor BackColor { get; set; }
        public void Draw()
        {
            Console.ForegroundColor = ForeColor;
            Console.BackgroundColor = BackColor;
            Console.WriteLine($"Name: {Name} Area: {GetArea()}");
        }
        public abstract int GetArea();
    }

    public class Rectangle : Shape
    {
        public Rectangle(int width, int height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }
        public readonly int Width;
        public readonly int Height;
        public override int GetArea()
        {
            return Width * Height;
        }
    }

    public class Circle : Shape
    {
        public readonly int Diameter;
        public Circle(int diameter) : base("Circle")
        {
            Diameter = diameter;
        }

        public override int GetArea()
        {
            var d = Diameter / 2;
            return Convert.ToInt32(Math.PI * (d * d));
        }
    }
}
