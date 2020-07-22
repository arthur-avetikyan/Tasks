using System;

namespace SOLID.ISP.Bad
{
    public abstract class Exercises
    {
        public virtual void Run()
        {
            Console.WriteLine("Running");
        }

        public virtual void Swim()
        {
            Console.WriteLine("Swimming");
        }

        public virtual void Box()
        {
            Console.WriteLine("Boxing");
        }
    }
}
