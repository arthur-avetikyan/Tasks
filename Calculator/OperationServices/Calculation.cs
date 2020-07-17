using OperationManager.IOperationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationManager.OperationServices
{
    public class Calculation : ICalculationService
    {
        private IOperationResolver _resolver;
        private IOperationPerformer _operationPerformer;
        private int _operationsCount = 0;
        private double _result = 0;

        public Calculation(IOperationResolver resolver, IOperationPerformer operationPerformer)
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
            else if (options.Contains("*")||options.Contains("/"))
            {

            }
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
