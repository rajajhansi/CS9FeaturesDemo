
using System;
namespace CSFeaturesDemo
{
    public sealed class Point
    {
        public int X { get; init; }
        public int Y { get; init; }

        void M()
        {
            var p = new Point
            {
                X = 42,
                Y = 13
            };
            // p.X = 5;
        }
    }
    public abstract record PersonBase(string FirstName, string LastName)
    {
        public string FirstName { get; set; } = FirstName;
        public string LastName { get; set; } = LastName;
    }

    public record Person(string FirstName, string LastName) : PersonBase(FirstName, LastName);
    public record Teacher(string FirstName, string LastName, int Grade) : PersonBase(FirstName, LastName);
    public record Student(string FirstName, string LastName, Teacher Teacher, int Grade) : PersonBase(FirstName, LastName);
}

