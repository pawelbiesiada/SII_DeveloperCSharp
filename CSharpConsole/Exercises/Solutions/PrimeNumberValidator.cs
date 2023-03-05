using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    internal class PrimeNumberValidator
    {
        public void Test()
        {
            //z konsoli użytkownik podaje liczbę
            //walidacja liczby
            //wypisanie czy jest to liczba pierwsza na konsole

            string number = Console.ReadLine();
            int number1 = int.Parse(number);
            
            string GetTextIfIsPrime(int number1)
            {
                if (number1 <= 1)
                {
                    return $"{number} nie jest liczbą pierwszą.";
                }

                for (int i = 2; i <= Math.Sqrt(number1); i++)
                {
                    if (number1 % i == 0)
                    {
                        return $"{number} nie jest liczbą pierwszą.";
                    }
                }

                return $"{number} jest liczbą pierwszą.";
            }

            if(IsPrimeNumber(number1))
            {
                Console.WriteLine($"{number} jest liczbą pierwszą.");
            }
            else
            {
                Console.WriteLine($"{number} nie jest liczbą pierwszą.");
            }

            Console.WriteLine(GetTextIfIsPrime(number1));
        }

        //metoda walidująca zwracająca bool
        private bool IsPrimeNumber(int number1)
        {
            if (number1 <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number1); i++)
            {
                if (number1 % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
