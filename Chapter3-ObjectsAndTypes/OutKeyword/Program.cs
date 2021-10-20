using System;

namespace OutKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            // version 1
            string input1 = Console.ReadLine();
            int result1 = int.Parse(input1);
            Console.WriteLine(result1);

            // version 2
            string input2 = Console.ReadLine();

            if (int.TryParse(input2, out int result))
                Console.WriteLine(input2);
            else
                Console.WriteLine("not a number");

            // vsersion 3
            string input3 = Console.ReadLine();
            Console.WriteLine(GetParseResult(input3));
        }

        static string GetParseResult(string input) =>
            int.TryParse(input, out int result) ? $"n: {result}" : "not a number";
    }
}
