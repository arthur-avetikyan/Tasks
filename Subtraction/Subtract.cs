using Operation;

namespace Subtraction
{
    public class Subtract : IOperation
    {
        public int Operate(int arg0, int arg1) => arg0 - arg1;

        public double Operate(double arg0, double arg1) => arg0 - arg1;
    }
}
