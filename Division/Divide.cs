using Operation;
using System;

namespace Division
{
    public class Divide : IOperation
    {
        public int Operate(int arg0, int arg1) => arg0 / arg1;

        public double Operate(double arg0, double arg1) => arg0 / arg1;
    }
}
