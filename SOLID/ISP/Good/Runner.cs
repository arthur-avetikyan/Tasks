using System;

namespace SOLID.ISP.Good
{
    public class Runner : IRunningExercise
    {
        private int _hoursPerDay = 3;

        public void Run()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                Console.WriteLine("Running");
            }
        }
    }
}
