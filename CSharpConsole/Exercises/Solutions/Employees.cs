using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CSharpConsole.Exercises.Solutions
{
    public record User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public abstract class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual void CalculateSalary()
        {
            Console.WriteLine($"Obliczam wypłatę dla:{Name}");
        }

        public override string ToString()
        {
            return $"My name is {Name}, Id: {Id}";
        }

        public override bool Equals(object obj)
        {
            if(obj is not Employee) 
                return false;

            Employee emp = (Employee)obj;

            return emp.Id == Id && emp.Name == Name;
        }

        public override int GetHashCode()
        {
            return Id * Name.GetHashCode();
        }
    }

    public class Secretary : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("3000");
        }
    }

    public class Director : Employee
    {
        public void GetBonus()
        {
            Console.WriteLine("Wypłacam bonus");
        }

        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("5000");
        }
    }

    public class Programmer : Employee
    {
        public override void CalculateSalary()
        {
            base.CalculateSalary();
            Console.WriteLine("4000");
        }
    }


    class EmployeeFactory
    {
        public static List<Employee> CreateEmployees()
        {
            var employees = new List<Employee>();
            var sec1 = new Secretary { Id = 1, Name = "Anna" };
            var sec2 = new Secretary { Id = 2, Name = "Katarzyna" };
            employees.Add(sec1);
            employees.Add(sec2);
            var prog1 = new Programmer { Id = 3, Name = "Piotr" };
            var prog2 = new Programmer { Id = 4, Name = "Jan" };
            employees.Add(prog1);
            employees.Add(prog2);
            var dir1 = new Director { Id = 5, Name = "Marek" };
            employees.Add(dir1); return employees;

        }

        public void TestMethod()
        {
            var list = CreateEmployees();

            foreach (var emp in list)
            {
                emp.CalculateSalary();

                //if (emp.GetType() == typeof(Director))
                if (emp is Director)
                {
                    ((Director)emp).GetBonus();
                }
            }

            foreach (var emp in list)
            {
                Console.WriteLine(emp);
            }


            var emp1 = new Programmer { Id = 1, Name = "Paweł" };
            var emp2 = new Director { Id = 1, Name = "Paweł" };
                       

            var result = emp1.Equals(emp2); // emp1 == emp2

        }


    }
}
