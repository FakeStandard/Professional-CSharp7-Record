using System;

namespace PassingByValueAndReference
{
    class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A { X = 1 };
            ChangeA(a1);
            Console.WriteLine(a1.X);
            ChangeA(ref a1);
            Console.WriteLine(a1.X);

            B b1 = new B { X = 1 };
            ChangeB(b1);
            Console.WriteLine(b1.X);
            ChangeB(ref b1);
            Console.WriteLine(b1.X);
        }

        static void ChangeA(A a)
        {
            a.X = 2;
        }
        static void ChangeA(ref A a)
        {
            a.X = 2;
        }

        static void ChangeB(B b)
        {
            b.X = 2;
        }

        static void ChangeB(ref B b)
        {
            b.X = 2;
            b = new B { X = 3 };
        }
    }

    struct A
    {
        public int X { get; set; }
    }

    class B
    {
        public int X { get; set; }
    }
}
