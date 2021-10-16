using System;

namespace ReferenceTypeString
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reference Type 參考類型 - String
            string s1 = "s1 string";

            // 初始化 s2 時,會直接指向 s1 物件,符合參考類型
            string s2 = s1;

            Console.WriteLine($"s1 is {s1}");
            Console.WriteLine($"s2 is {s2}");

            // 雖然 string 是參考類型,但為特例
            // 此時不會改變stack上的值,而是在stack上配置一個新的記憶體位址給s1
            s1 = "new string";

            Console.WriteLine($"s1 is {s1}");
            Console.WriteLine($"s2 is {s2}");
        }
    }
}
