using System;
using System.Collections.Generic;
using System.Text;

namespace ClassesSample
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string FullName => $"{FirstName} {LastName}";

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
