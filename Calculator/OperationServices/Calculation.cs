using Calculator.IOperationServices;
using System.Collections.Generic;

namespace Calculator.OperationServices
{
    public class Calculation : ICalculationService
    {
        private IOperationResolverService _resolver;
        private IOperationPerformerService _operationPerformer;
        private int _operationsCount = 0;
        private double _result = 0;

        public Calculation(IOperationResolverService resolver, IOperationPerformerService operationPerformer)
        {
            _resolver = resolver;
            _operationPerformer = operationPerformer;
        }

        public double Calculate(List<string> options, List<double> numbers)
        {
            if (_operationsCount == 0)
            {
                _result = numbers[_operationsCount];
            }
            //else if (options.Contains("*")||options.Contains("/"))
            //{

            //}
            else
            {
                _result = CalculatePair(options[_operationsCount - 1], _result, numbers[_operationsCount]);
                options.RemoveAt(_operationsCount - 1);
                numbers.RemoveAt(_operationsCount);
            }

            _operationsCount++;
            if (_operationsCount < numbers.Count)
            {
                _result = Calculate(options, numbers);
            }
            return _result;
        }

        private double CalculatePair(string option, double firstOperand, double secondOperand)
        {
            _operationPerformer.SetOperation(_resolver.ResolveOperation(option));
            return _operationPerformer.PerformOperation(firstOperand, secondOperand);
        }
    }
}
