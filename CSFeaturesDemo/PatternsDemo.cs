using System;
namespace CSFeaturesDemo
{
    
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Type { get; set; }
        public string Region { get; set; }
        public Employee ReportsTo { get; set; }
    }

    public enum Color
    {
        Unknown,
        Red,
        Blue,
        Green,
        Purple,
        Orange,
        Brown,
        Yellow
    }

    public static class PositionalPatternDemo
    {
        public static bool IsIn10thGradeTaughtby10thGradeTeacher(Student s)
        {
            return s is (_, _, (_, _, 10), 10);
        }
    }

    // PropertyPattern Demo
    public static class PropertyPatternDemo
    {
        public static bool IsIndiaBasedEmployeeWithUsManager(Employee e)
        {
            return e is { Region: "IN", ReportsTo: { Region: "US" } };
        }

        public static bool IsIndiaBasedEmployeeWithUsManagerWithTypeConversion(object o)
        {
            return o is Employee e &&
                e is { Region: "IN", ReportsTo: { Region: "US" } };
        }
    }

    // TuplePattern Demo
    public static class TuplePatternDemo
    {
        public static Color GetColor(Color c1, Color c2) =>
            (c1, c2) switch
            {
                (Color.Red, Color.Blue) => Color.Purple,
                (Color.Blue, Color.Red) => Color.Purple,

                (Color.Yellow, Color.Red) => Color.Orange,
                (Color.Red, Color.Yellow) => Color.Orange,

                (Color.Red, Color.Green) => Color.Brown,
                (Color.Green, Color.Red) => Color.Brown,

                (_, _) when c1 == c2 => c1,

                _ => Color.Unknown
            };
    }
}
