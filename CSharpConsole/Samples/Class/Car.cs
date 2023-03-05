using CSharpConsole.Samples.Class.Inheritance;
using CSharpConsole.Samples.SOLID;
using System;

namespace CSharpConsole.Samples.Class
{
    public class Car : ICar
    {
        //Constant Field
        private const int ServiceCheckAfter = 10_000;

        // Fields
        private readonly int _speed;

        // Constructor
        public Car(int avgSpeed)
        {
            if (avgSpeed < 0)
                throw new ArgumentOutOfRangeException();
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;

        }

        public Car(int avgSpeed, ILogger logger)
        {
            //var car = new Car(100); initialization sample
            _speed = avgSpeed;
        }
        // Properties
        public int Distance { get; set; }
        public static int DistanceStatic { get; set; }

        // Methods
        public virtual void Drive(int duration)
        {
            Distance += CalculateDistance(_speed, duration);
            DistanceStatic += CalculateDistance(_speed, duration);
        }

        public bool IsServiceCheckNeeded()
        {
            return Distance > ServiceCheckAfter;
        }

        private static int CalculateDistance(int speed, int duration)
        {
            return speed * duration;
        }

    }

    public class ClassTest
    {
        public static void Main()
        {
            Car car = new Car(30);
            Car car2 = new Car(50);
            Car car3 = new Car(30);

            car.Drive(10);
            car2.Drive(10);

            var d = car2.Distance;
            d = Car.DistanceStatic;

            var areEqual = car == car2; //false
            areEqual = car == car3; //false

            areEqual = car.Equals(car2); //false
            areEqual = car.Equals(car3); //false

            car.Distance = 50;
            areEqual = car.Equals(car2); //false
            areEqual = car.Equals(car3); //false

            var copyCar = car;
            areEqual = car.Equals(copyCar); //true
            car.Distance = 10;
            areEqual = car.Equals(copyCar); //true

            ModifyClass(car);
            areEqual = car.Distance == 100; // true

            ModifyAndInitializeClass(car);
            areEqual = car.Distance == 200; // true
            areEqual = car.Distance == 300; // false
            var num = 6;
            var a = num;

            num = 5;


            var str1 = "Pawel";
           
            var str2 = str1;

            str1 = "Piotr";

            Console.WriteLine(str1);
            Console.WriteLine(str2);



            Console.WriteLine(a);

            modifyInt(num);
            Console.WriteLine(num);

        }

        public static void ModifyClass(Car carInMethod)
        {
            carInMethod.Distance = 100;
        }

        public static void ModifyAndInitializeClass(Car carInMethod)
        {
            carInMethod.Distance = 200;
            carInMethod = new Car(300);
        }

        public static void modifyInt(int number)
        {
            number = 100;
        }
    }
}
