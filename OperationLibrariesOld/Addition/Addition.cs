using Operation;

namespace Addition
{
    public class Add : IOperation
    {
        public string OperationName => "Add";

        public string OperationRepresentation => "+";

        public double Operate(params double[] numbers)
        {
            double lResult = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                lResult += numbers[i];
            }
            return lResult;
        }
    }
}
