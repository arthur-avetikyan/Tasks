using Operation;
using System;
using System.Runtime.Remoting.Messaging;

namespace Division
{
    public class Divide : IOperation
    {
        public string OperationName => "Divide";

        public string OperationSymbol => "/";

        public double Operate(params double[] numbers)
        {
            double lResult = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lResult /= numbers[i];
            }
            return lResult;
        }
    }
}
