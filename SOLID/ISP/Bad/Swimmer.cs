namespace SOLID.ISP.Bad
{
    public class Swimmer : Exercises
    {
        private int _hoursPerDay = 2;

        public override void Swim()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                base.Swim();
            }
        }
    }
}
