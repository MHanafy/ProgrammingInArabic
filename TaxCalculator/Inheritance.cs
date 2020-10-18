using System;
using System.Drawing;

namespace TaxCalculator
{
    public class Shape
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
            Console.WriteLine(Name);
        }
        public virtual int GetArea() => 0;
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
}
