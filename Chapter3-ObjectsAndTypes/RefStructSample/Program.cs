using System;

namespace RefStructSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeOnly vt = new ValueTypeOnly(10);
            vt.AMethod();
        }
    }
}
