using System;

namespace Variable
{
    class Program
    {
        static void Main(string[] args)
        {
            // 類別推斷
            var name = "Riley Lin";
            var age = 18;
            var isStudent = false;

            Type nameType = name.GetType();
            Type ageType = age.GetType();
            Type isStudentType = isStudent.GetType();

            Console.WriteLine($"name is of type {nameType}");
            Console.WriteLine($"age is of type {ageType}");
            Console.WriteLine($"isStudent is of type {isStudentType}");
        }
    }
}
