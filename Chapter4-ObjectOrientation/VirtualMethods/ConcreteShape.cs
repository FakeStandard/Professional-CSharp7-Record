using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMethods
{
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            //base.Draw();
            Console.WriteLine($"Rectanlge with {Position} and {Size}");
        }

        public override void Move(Position position)
        {
            Console.Write("Rectangle ");
            base.Move(position);
        }

        public override void Resize(int width, int height)
        {
            throw new NotImplementedException();
        }
    }

    public class Ellipse : Shape
    {
        public Ellipse() : base() { }
        public void MoveBy(int x, int y)
        {
            Position.X += x;
            Position.Y += y;
        }

        public override void Resize(int width, int height)
        {
            Size.Width = width;
            Size.Height = height;
        }
    }
}
