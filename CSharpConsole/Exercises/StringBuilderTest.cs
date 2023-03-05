using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises
{
    internal class StringBuilderTest
    {
        public void Execute()
        {
            var test = new StringBuilderTest();
            var loopCount = 150_000;
            var timer = Stopwatch.StartNew();

            test.ConcatUsingString(loopCount);
            Console.WriteLine($"Concatenating strings took {timer.ElapsedMilliseconds} ms.");
            timer.Restart();
            test.ConcatWithStringBuilder(loopCount);
            Console.WriteLine($"Concatenating StringBuilder took {timer.ElapsedMilliseconds} ms.");
            //timer.Reset();

        }

        public void ConcatUsingString(int count)
        {
            var str = string.Empty;
            for (int i = 0; i < count; i++)
            {
                str += "d"; // str = str + "d"
            }
        }

        public void ConcatWithStringBuilder(int count)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append("d");
            }
            var text = sb.ToString();
        }
    }
}
