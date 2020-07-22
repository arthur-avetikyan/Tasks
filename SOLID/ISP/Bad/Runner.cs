namespace SOLID.ISP.Bad
{
    public class Runner : Exercises
    {
        private int _hoursPerDay = 3;

        public override void Run()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                base.Run();
            }
        }
    }
}
