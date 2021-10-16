using System;
// 賦予別名
using Introduction = CSharpTest.Basics;

namespace NamespaceSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // :: 命名空間修飾符
            Introduction::NamespaceExample NE = new Introduction::NamespaceExample();
            Console.WriteLine(NE.GetNamespace());
        }
    }
}

namespace CSharpTest.Basics
{
    class NamespaceExample
    {
        public string GetNamespace() => GetType().Namespace;
    }
}
