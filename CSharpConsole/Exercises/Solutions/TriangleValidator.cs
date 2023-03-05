using System;

namespace CSharpConsole.Exercises.Solutions
{
    internal class TriangleValidator
    {
        public void Test()
        {
            TriangleValidator tv = new TriangleValidator();

            var a1 = Console.ReadLine();
            var b1 = Console.ReadLine();
            var c1 = Console.ReadLine();

            var edges = new string[] { a1, b1, c1 };

            foreach (var item in edges)
            {
                Console.WriteLine(item);
            }


            var a = int.Parse(a1);
            var b = int.Parse(b1);
            var c = int.Parse(c1);

            if (((a + b) > c) && 
                ((a + c) > b) && 
                ((b + c) > a))
            {
                Console.WriteLine("it is possible to create this triangle");
            }
            else
            {
                Console.WriteLine("It is impossible to create this triangle");
            }
        }
    }
}
