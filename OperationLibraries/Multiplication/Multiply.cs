﻿using Operation;

namespace Multiplication
{
    public class Multiply : IOperation
    {
        public string OperationName => "Multiply";

        public string OperationRepresentation => "*";

        public double Operate(params double[] numbers)
        {
            double lResult = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                lResult *= numbers[i];
            }
            return lResult;
        }
    }
}
