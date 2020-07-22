using System;

namespace SOLID.ISP.Good
{
    public class Swimmer : ISwimmingExercise
    {
        private int _hoursPerDay = 2;

        public void Swim()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                Console.WriteLine("Swimming");
            }
        }
    }
}
