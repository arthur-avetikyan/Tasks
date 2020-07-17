using Operation;

namespace Subtraction
{
    public class Subtract : IOperation
    {
        public string OperationName => "Subtract";

        public string OperationRepresentation => "-";

        public double Operate(params double[] numbers)
        {
            double lResult = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                lResult -= numbers[i];
            }
            return lResult;
        }
    }
}
