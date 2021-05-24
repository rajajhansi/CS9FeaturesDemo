using System;
using System.Linq;

namespace CSFeaturesDemo
{
    public static class IndexAndRangeDemo
    {

        static void DisplayCollection(string arrVarName, int[] arr)
        {
            Console.WriteLine($"{arrVarName} = [ {string.Join(", ", arr)} ]");
            // Array.ForEach(arr, arrElement => Console.Write($"{(Array.IndexOf(arr, arrElement) < arr.Length -1 ? $"{arrElement}, " : $"{arrElement}")}"));
            // Console.WriteLine("]");
        }
        public static void IndexAndRange() 
        {
            var numbers = Enumerable.Range(1, 10).ToArray();
            var copy = numbers[0..^0];      
            DisplayCollection("copy", copy);
            
            var allButFirst = numbers[1..];          
            DisplayCollection("allButFirst", allButFirst);

            var lastItemRange = numbers[^1..];
            DisplayCollection("lastItemRange", lastItemRange);

            var lastItem = numbers[^1];
            Console.WriteLine(lastItem);

            var lastThree = numbers[^3..];
            DisplayCollection("lastThree", lastThree);

            Index middle = 4;
            Index threeFromEnd = ^3;
            Range customRange = middle..threeFromEnd;
            var custom = numbers[customRange];
            DisplayCollection("custom", custom);
        }
    }
}
