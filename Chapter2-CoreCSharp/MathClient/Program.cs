using System;
using MathLib;

namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            double d1 = 3;
            double d2 = 4;
            double result = Calculator.Add(d1, d2);
            Console.WriteLine(result);
        }
    }
}
