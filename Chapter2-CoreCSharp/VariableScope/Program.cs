using System;

namespace VariableScope
{
    class Program
    {
        static int k = 10;
        static void Main(string[] args)
        {
            // Scope 1
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);
            for (int i = 9; i >= 0; i--)
                Console.WriteLine(i);

            // Scope 2
            int j = 10;
            for(int i = 0; i < 10; i++)
            {
                // j is still in scope, so can't do this.
                // int j = 20;
                Console.WriteLine(i);
            }

            // Scope 3
            int k = 20;
            Console.WriteLine(k);
            Console.WriteLine(Program.k);
        }
    }
}
