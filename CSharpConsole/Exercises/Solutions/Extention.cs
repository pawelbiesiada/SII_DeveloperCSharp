using CSharpConsole.Samples.Class.Inheritance;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    public static class Extension
    {
        public static int CountWords(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            int wordCount = text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

            return wordCount;
        }

        public static int LetterCount(this string text, char letterToCount)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            int wordCount = text.Count(c => c == letterToCount);

            return wordCount;
        }

        public static bool BatchLoadTrunk(this FamilyCar fcar, int[] elements)
        {
            try
            {
                foreach (var item in elements)
                {
                    fcar.LoadTrunk(item);
                }
                return true;
            }
            catch (TrunkCapacityException ex)
            {
                return false;
            }
        }

        public static void Tester()
        {
            var sentence = "Lorem ipsum";
            var count = sentence.CountWords();
            var letterCount = sentence.LetterCount('e');

            var fcar = new FamilyCar(50);

            var allElementsLoaded = fcar.BatchLoadTrunk(new[] {10,25,30, 40,40 } );
        }
    } 
}
