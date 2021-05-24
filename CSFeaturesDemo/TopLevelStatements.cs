using System;
using System.Text.Json;
using CSFeaturesDemo;

Console.WriteLine("Records Demo");
Person p1 = new("Raja", "Mani");
Person p2 = new("Jhansi", "Raja");

// p1 = p1 with { LastName = "Rocks" };
p1.LastName = "Rocks";
Console.WriteLine(p1);
Console.WriteLine(p2);

var json = JsonSerializer.Serialize(p1);
Console.WriteLine($"json = {json}");
var p3 = JsonSerializer.Deserialize<Person>(json);
var isEqual = p3 == p1;
Console.WriteLine($"p1 == p3: {isEqual}");

var (firstName, lastName) = p1;
Console.WriteLine("${LastName}, { FirstName}");

Console.WriteLine($"Is Jhansi in chat {IsInChat(p2)}");
static bool IsInChat(Person p) => p switch
{
    ("Raja", "Mani") => true,
    ("Jhansi", "Raja") => true,
    _ => false
};

PersonBase teacher = new Teacher("Raja", "Mani", 10);
PersonBase student = new Student("Priya", "Subburaj", (Teacher)teacher, 10);

Console.WriteLine($"Teacher {teacher} == Student {student} = {(teacher == student ? "Yes" : "No")}");

Student student2 = new Student("Priya", "Subburaj", (Teacher)teacher, 10);
Console.WriteLine($"Student {student} == Student {student2} = {(student == student2 ? "Yes" : "No")}");

// Positional PositionalPattern
Console.WriteLine("PositionalPattern Demo");
Console.WriteLine($"Is {student2.FirstName} in {student2.Grade}th Grade taught by {student2.Teacher.FirstName} = {(IsIn10thGradeTaughtby10thGradeTeacher(student2) ? "Yes" : "No")}");

// PropertyPattern
Console.WriteLine("PropertyPattern Demo");
Employee m = new Employee { FirstName = "Raja", LastName = "Mani", Region = "US", ReportsTo = null, Type = "Vice President" };
Employee e = new Employee { FirstName = "Thangapandiyan", LastName = "Govindasamy", Region = "IN", ReportsTo = m, Type = "Software Engineer" };
Employee e2 = new Employee { FirstName = "Anand", LastName = "Seshadri", Region = "IN", ReportsTo = m, Type = "Test Developer" };
Console.WriteLine($"Is {e.FirstName} working in {e.Region} reporting to his Manager {e.ReportsTo.FirstName} working in the {e.ReportsTo.Region} = {(IsIndiaBasedEmployeeWithUsManager(e) ? "Yes" : "No")}");
Console.WriteLine($"Is {e2.FirstName} working in {e2.Region} reporting to his Manager {e2.ReportsTo.FirstName} working in the {e2.ReportsTo.Region} = {(IsIndiaBasedEmployeeWithUsManagerWithTypeConversion(e2) ? "Yes" : "No")}");
// Positional PositionalPattern Demo
static bool IsIn10thGradeTaughtby10thGradeTeacher(Student s) => s is (_, _, (_, _, 10), 10);
// PropertyPattern Demo
static bool IsIndiaBasedEmployeeWithUsManager(Employee e) => e is { Region: "IN", ReportsTo: { Region: "US" } };
static bool IsIndiaBasedEmployeeWithUsManagerWithTypeConversion(object o) => o is Employee e &&
            e is { Region: "IN", ReportsTo: { Region: "US" } };

// SwitchExpression Demo
Console.WriteLine("SwitchExpression Demo");
Rectangle rectangle = new Rectangle(20, 30);
Rectangle square = new Rectangle(10, 10);
Circle smallCircle = new Circle(1);
Circle circle = new Circle(10);
Triangle triangle = new Triangle(10, 20, 30);
var unknownShape = (10, 20, 30, 40);
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(rectangle));
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(square));
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(smallCircle));
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(circle));
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(triangle));
Console.WriteLine(SwitchExpressionDemo.DisplayShapeInfo(unknownShape));

// TuplePattern Demo
Console.WriteLine("TuplePattern Demo");
Console.WriteLine($"A combination of {Color.Red} + {Color.Blue} gives {TuplePatternDemo.GetColor(Color.Red, Color.Blue)}");
Console.WriteLine($"A combination of {Color.Red} + {Color.Yellow} gives {TuplePatternDemo.GetColor(Color.Red, Color.Yellow)}");
Console.WriteLine($"A combination of {Color.Red} + {Color.Green} gives {TuplePatternDemo.GetColor(Color.Red, Color.Blue)}");
Console.WriteLine($"A combination of {Color.Red} + {Color.Red} gives {TuplePatternDemo.GetColor(Color.Red, Color.Red)}");
Console.WriteLine($"A combination of {Color.Yellow} + {Color.Green} gives {TuplePatternDemo.GetColor(Color.Yellow, Color.Green)}");
// IndexAndRange Demo
Console.WriteLine("IndexAndRange Demo");
IndexAndRangeDemo.IndexAndRange();

// JsonDemo
Console.WriteLine("Json Demo");
JsonDemo.Utf8JsonReaderDemo();
JsonDemo.JsonDocumentDemo();
JsonDemo.JsonWriterDemo();
JsonDemo.JsonSerializerDemo();

// DefaultInterfaceMemberDemo
DefaultInterfaceMemberDemo.Demo();

// UsingDeclarationDemo
UsingDeclarationDemo.Demo();

// AsyncStreamsDemo
await AsyncStreamsDemo.DemoAsync();

// StaticLocalFunctionsDemo
var staticLocalFunctionsDemo = new StaticLocalFunctionsDemo();
staticLocalFunctionsDemo.Demo();

// Other Language Additions
Console.WriteLine(@$"
Using @ before $ is now suppported in interpolated strings in
{{C#{9}}}");