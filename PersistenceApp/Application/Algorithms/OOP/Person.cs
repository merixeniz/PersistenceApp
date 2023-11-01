using System;

namespace Application.Algorithms.OOP
{
    public class Person
    {
        public virtual void Work()
        {
            Console.WriteLine("Person is working");
        }
    }

    public class Lawyer : Person
    {
        public override void Work()
        {
            Console.WriteLine("Lawyer is working");
        }
    }
    public class SoftwareDeveloper : Person
    {
        public override void Work()
        {
            base.Work();
            Console.WriteLine("SoftwareDeveloper is working");
        }
    }
}
