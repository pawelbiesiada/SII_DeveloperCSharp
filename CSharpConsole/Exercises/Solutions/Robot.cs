using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsole.Exercises.Solutions
{
    class MyClass
    {
        public void Test()
        {
            var r = new Robot("Joe", 10, false);
            r.IsOn = false;

            //var n = r.Name;


           r.Name = null;

            var st = r.Status;

         

            if(r.Name == null)
            {
                //
            }
            else
            {

            }


            r.SayHi();
        }
    }

    public class Robot
    {
        private string _name;

        public string Name
        {
            get
            { 
                return _name;
            }

            set 
            {
                if (value == null)
                {
                    _name = String.Empty; //""
                }
                else
                {
                    _name = value;
                }
            }
        }


        public string Status
        {
            get { return IsOn ? "Robot is turned on." : "Robot is turned off."; }
        }

        public string GetStatus()
        {
            return IsOn ? "Robot is turned on." : "Robot is turned off.";
        }


        //public string Name { get; private set; }
        public ushort Age { get; set; }
        public bool IsOn { get; set; }

        public Robot(string cName, ushort cAge) : this(cName, cAge, true) 
        {
            //
            Console.WriteLine(cName);
            //
            //
        }

        public Robot(string cName, ushort cAge, bool isOn)
        {
            Name = cName;
            Age = cAge;
            IsOn = isOn;
        }


        public void SayHi()
        {
            if (IsOn == true)
            {
                Console.WriteLine("Say Hi" + Name);
            }
        }

        public void Reset()
        {
            _name = null;
        }
    }
}
