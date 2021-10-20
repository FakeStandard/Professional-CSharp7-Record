using System;

namespace InParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            AValueType vt = new AValueType { Data = 10 };
            CannotChange(vt);

            ARefType rt = new ARefType { Data = 10 };
            CannotChange(rt);

            int num = 10;
            CannotChange(num);
        }

        static void CannotChange(in AValueType a)
        {
            // does not compile because a is readonly variable.
            //a.Data = 20;

            Console.WriteLine(a.Data);
        }

        static void CannotChange(in ARefType b)
        {
            // 可變,因 ARefType 為 Reference Type
            b.Data = 20;
            Console.WriteLine(b.Data);
        }

        static void CannotChange(in int x)
        {
            // dose not compile because x is readonly variable.
            //x = 20;
        }
    }
}
