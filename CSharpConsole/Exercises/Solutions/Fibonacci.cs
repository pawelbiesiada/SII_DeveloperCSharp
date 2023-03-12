using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    public class Fibonacci
    {
        public void Test()
        {
            int podanaLiczba = int.Parse(Console.ReadLine());
            var c = FindNextFibonacci(podanaLiczba);
            Console.WriteLine($"Najmniejsza liczba ciagu po podanej liczbie {podanaLiczba} to {c}");
        }

        public int FindNextFibonacci(int max)
        {
            int a = 1;
            int b = 1;
            Console.Write(a + " ");
            int temp;
            do
            {
                Console.Write(b + " ");
                temp = a;
                a = b;
                b = temp + b;
            } while (b < max);

            return b;
        }
    }
}
