using System.Collections.Generic;

namespace Calculator.IOperationServices
{
    public interface ICalculationService
    {
        double Calculate(List<string> options, List<double> numbers);
    }
}
