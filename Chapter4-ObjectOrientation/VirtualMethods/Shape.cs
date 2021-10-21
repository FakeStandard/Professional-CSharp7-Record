using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualMethods
{
    public abstract class Shape
    {
        public Position Position { get; } = new Position();
        public Size Size { get; } = new Size();

        public virtual void Draw() => Console.WriteLine($"Shape with {Position} and {Size}");

        public virtual void Move(Position position)
        {
            Position.X = position.X;
            Position.Y = position.Y;

            Console.WriteLine($"move to {Position}");
        }

        public abstract void Resize(int width, int height);
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return $"X: {X}, Y: {Y}";
        }
    }

    public class Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override string ToString()
        {
            //return base.ToString();
            return $"Width: {Width}, Height: {Height}";
        }
    }

    class DerivedClass : MyClass
    {
        // 無法覆寫繼承的成員
        //public override void FinalMethod()
        //{

        //}
    }

    class MyClass : MyBaseClass
    {
        public sealed override void FinalMethod()
        {
            // implementation
        }
    }

    class MyBaseClass
    {
        public virtual void FinalMethod()
        {
            
        }
    }
}
