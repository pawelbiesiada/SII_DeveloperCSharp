using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    public class RainFall
    {
        int[] monthlyRainFall = new int[12];

        public double Average
        {
            get { return monthlyRainFall.Average(); }
        }

        public int GetMonthlyRainFall(int month)
        {
            return monthlyRainFall[month - 1];
        }

        public int GetMonthlyRainFall(Month month)
        {
            return monthlyRainFall[(int)month -1];
        }

        public void AddRainFall(int month, int rainFall = 100)
        {
            monthlyRainFall[month - 1] += rainFall;
        }

        public void AddRainFall(Month month, int rainFall)
        {
            monthlyRainFall[(int)month - 1] += rainFall;
        }


        public void Test()
        {
            var r = new RainFall();

            r.AddRainFall(1, 100);

            r.AddRainFall(1);

            r.AddRainFall(Month.January, 100);
            r.GetMonthlyRainFall(3);
            r.GetMonthlyRainFall(Month.March);

            var status = UserStatus.Inactive;

            if(status == UserStatus.Active) 
            {
             //zaloguj się
            }
        }

        public void ImportRainFall(RainFall rainFall)
        {
            if(rainFall == null) 
            { 
                return; 
            }

            for (int i = 0; i < monthlyRainFall.Length; i++)
            {
                var monthNumber = i + 1;
                AddRainFall(monthNumber, rainFall.GetMonthlyRainFall(monthNumber));
               // monthlyRainFall[i] += rainFall.GetMonthlyRainFall(i + 1);
            }
        }
    }

    enum UserStatus
    {
        Active = 101,
        Inactive = 102,
        Blocked = 103,
        ToBeVerified = 104,
    }

    public enum Month
    {
        January,
        February,
        March,
        April,
        May
    }
}
