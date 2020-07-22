using System;

namespace SOLID.ISP.Good
{
    public class Boxer : IBoxingExercise
    {
        private int _hoursPerDay = 1;

        public void Box()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                Console.WriteLine("Boxing");
            }
        }
    }
}
