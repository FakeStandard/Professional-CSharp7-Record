using System;

namespace ClassesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person("Lin", "Riley");
            Console.WriteLine($"{person.FirstName} {person.LastName}");
            Console.WriteLine(person.FullName);
        }
    }
}
