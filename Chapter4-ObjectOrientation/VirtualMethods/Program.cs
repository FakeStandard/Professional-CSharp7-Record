using System;

namespace VirtualMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = new Rectangle();
            r.Position.X = 10;
            r.Position.Y = 20;
            r.Size.Width = 100;
            r.Size.Height = 200;
            r.Draw();
            DrawShape(r);

            r.Move(new Position { X = 30, Y = 40 });
            r.Draw();

            Shape s = new Ellipse();
            DrawShape(s);
        }

        public static void DrawShape(Shape shape) => shape.Draw();
    }
}
