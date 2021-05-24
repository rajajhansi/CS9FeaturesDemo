using System;
namespace CSFeaturesDemo
{
    public class StaticLocalFunctionsDemo
    {
        private static string Field = "initial-value";
        public void Demo()
        {
            Console.WriteLine("StaticLocalFunctions Demo");
            var state = "42";
            DoSomethingWithState();
            DoSomethingWithField();

            Console.WriteLine($"state: {state}");
            Console.WriteLine($"Field: {Field}");

            static string DoSomethingWithState()
            {
                return "99";
            }

            static string DoSomethingWithField()
            {
                return Field = "modified!";
            }
        }

        
    }
}
