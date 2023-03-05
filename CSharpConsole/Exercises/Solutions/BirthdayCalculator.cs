using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    internal class BirthdayCalculator
    {
        public void DateTimeOperations()
        {
            var birthday = DateTime.Parse(Console.ReadLine());
            DateTime todayDate = DateTime.Today; 
            TimeSpan daysFromBirthday = todayDate - birthday;

            Console.WriteLine(Math.Round(daysFromBirthday.TotalDays, 0));
            Console.WriteLine(int.Parse(daysFromBirthday.TotalDays.ToString()));

            Console.WriteLine(daysFromBirthday.TotalHours);

            Console.WriteLine("birthday day of week: " + birthday.ToString("dddd"));
        }
    }
}
