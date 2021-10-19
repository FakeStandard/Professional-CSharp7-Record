using System;

namespace ReadonlyStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            var point = new Dimensions(3, 6);
            Foo(point);

            Console.ReadLine();
        }

        public static void Foo(Dimensions dimensions)
        {

        }
    }
}
