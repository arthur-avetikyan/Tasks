namespace SOLID.ISP.Bad
{
    public class Boxer : Exercises
    {
        private int _hoursPerDay = 1;

        public override void Box()
        {
            for (int i = 0; i < _hoursPerDay; i++)
            {
                base.Box();
            }
        }
    }
}
